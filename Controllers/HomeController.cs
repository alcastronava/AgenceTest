using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenceTest.Models;
using AgenceTest.Models.Caol;
using Microsoft.AspNetCore.Diagnostics;
using AgenceTest.ViewModels;
using System.Globalization;
using AgenceTest.Extensions;

namespace AgenceTest.Controllers
{
    public class ChartPoint
    {
        public string Label { get; set; }
        public float Value { get; set; }
    }

    public class ChartDataConsultor
    {
        public ChartDataConsultor()
        {
            list = new List<ChartPoint>();
        }

        public string Nombre { get; set; }

        public ICollection<ChartPoint> list { get; set; }
    }

    public class ChartData
    {
        public ChartData()
        {
            Costo = 0;
            Consultores = new List<ChartDataConsultor>();
        }

        public float Costo { get; set; }

        public ICollection<ChartDataConsultor> Consultores { get; set; }
    }

    public class HomeController : Controller
    {
        public const string CookieConsultores = "Consultores";

        private readonly AgenceCaolContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            AgenceCaolContext context,
            ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<MultiSelectList> GetConsultores()
        {
            List<long> TiposUsuarios = new List<long>(new long[] { 0, 1, 2 });
            var consultores =
                        await
                        (from p in _context.PermissaoSistema
                         join u in _context.CaoUsuario
                         on p.CoUsuario equals u.CoUsuario
                         where (p.CoSistema == 1 && p.InAtivo == "S" && TiposUsuarios.Contains(p.CoTipoUsuario))
                         orderby u.NoUsuario
                         select u)
                         .ToListAsync();

            return new MultiSelectList(consultores, "CoUsuario", "NoUsuario");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.Consultores = await GetConsultores();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            HttpContext.Session.SetObjectAsJson(CookieConsultores, string.Empty);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PeriodoConsultores periodoConsultores)
        {
            if (periodoConsultores.ConsultIds == null || periodoConsultores.ConsultIds.Count() == 0)
            {
                ModelState.AddModelError("ConsultIds", "Por favor seleccione los consultores");
            }

            if (ModelState.IsValid)
            {
                int months = (periodoConsultores.ToDate.Year - periodoConsultores.FromDate.Year) * 12 + periodoConsultores.ToDate.Month - periodoConsultores.FromDate.Month;

                List<ConsultoresPeriodos> consultores = new List<ConsultoresPeriodos>();
                foreach (var consult in periodoConsultores.ConsultIds)
                {
                    string nombre = string.Empty;
                    CaoUsuario usuario = await _context.CaoUsuario.Where(x => x.CoUsuario == consult).FirstOrDefaultAsync();
                    if (usuario != null)
                    {
                        nombre = usuario.NoUsuario;
                    }

                    ConsultoresPeriodos consultor = new ConsultoresPeriodos();
                    consultor.Nombre = nombre;

                    for (int i = 0; i < months + 1; i++)
                    {
                        DateTime FromDate = periodoConsultores.FromDate.AddMonths(i);
                        //Se cambia al ultimo dia del mismo mes
                        DateTime ToDate = new DateTime(FromDate.Year, FromDate.Month, DateTime.DaysInMonth(FromDate.Year, FromDate.Month));

                        var osList =
                                from fa in _context.CaoFatura
                                join os in _context.CaoOs on fa.CoOs equals os.CoOs
                                join us in _context.CaoUsuario on os.CoUsuario equals us.CoUsuario
                                where us.CoUsuario == consult && fa.DataEmissao >= FromDate && fa.DataEmissao <= ToDate
                                select (new
                                {
                                    facId = fa.CoFatura,
                                    valor = fa.Valor * (1 - fa.TotalImpInc / 100),
                                    comision = fa.Valor * (1 - fa.TotalImpInc / 100) * (fa.ComissaoCn / 100)
                                });

                        float ganancias = 0;
                        float comisiones = 0;
                        foreach (var item in osList)
                        {
                            ganancias += item.valor;
                            comisiones += item.comision;
                        }

                        CaoSalario salarioConsultor = await _context.CaoSalario.Where(x => x.CoUsuario == consult).FirstOrDefaultAsync();
                        float salario = 0;
                        if (salarioConsultor != null)
                        {
                            salario = salarioConsultor.BrutSalario;
                        }

                        float lucro = ganancias - salario - comisiones;

                        ConsultorPeriodo periodo = new ConsultorPeriodo
                        {
                            Periodo = FromDate.ToString("MMM yyyy"),
                            Ganancias = ganancias,
                            Comisiones = comisiones,
                            Salario = salario,
                            Lucro = lucro
                        };
                        consultor.Periodos.Add(periodo);
                        consultor.TotalGanancias += periodo.Ganancias;
                        consultor.TotalComisiones += periodo.Comisiones;
                        consultor.TotalSalario += periodo.Salario;
                        consultor.TotalLucro += periodo.Lucro;
                    }
                    consultores.Add(consultor);
                }

                HttpContext.Session.SetObjectAsJson(CookieConsultores, consultores);

                return PartialView("_Consultores", consultores);
            }
            return View(periodoConsultores);
        }

        public JsonResult GetChartData()
        {
            ChartData chartData = new ChartData();

            List<ConsultoresPeriodos> consultores = HttpContext.Session.GetObjectFromJson<List<ConsultoresPeriodos>>(CookieConsultores);

            if (consultores != null && consultores.Count > 0)
            {
                float costoMedio = 0;
                foreach (var consultor in consultores)
                {
                    ChartDataConsultor data = new ChartDataConsultor();
                    data.Nombre = consultor.Nombre;
                    foreach (var item in consultor.Periodos)
                    {
                        data.list.Add(
                            new ChartPoint {
                                Label = item.Periodo,
                                Value = item.Ganancias
                            });
                    }
                    if (consultor.Periodos.Count() > 0)
                        costoMedio += consultor.TotalSalario / consultor.Periodos.Count();
                    chartData.Consultores.Add(data);
                }
                if (consultores.Count() > 0)
                    costoMedio = costoMedio / consultores.Count();
                chartData.Costo = costoMedio;
            }
            return Json(chartData);
        }

        public JsonResult GetChartPie()
        {
            List<ChartPoint> list = new List<ChartPoint>();

            List<ConsultoresPeriodos> consultores = HttpContext.Session.GetObjectFromJson<List<ConsultoresPeriodos>>(CookieConsultores);

            if (consultores != null && consultores.Count > 0)
            {
                foreach (var consultor in consultores)
                {
                    list.Add(
                        new ChartPoint
                        {
                            Label = consultor.Nombre,
                            Value = consultor.TotalGanancias
                        });
                }
            }

            return Json(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                ErrorViewModel errorVM = new ErrorViewModel();
                errorVM.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

                var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                ViewBag.Path = feature?.OriginalPath;

                return View("Error404", errorVM);
            }

            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                _logger.LogError(exceptionFeature.Error.Message + Environment.NewLine + "\tPath: " + exceptionFeature.Path);
                ViewBag.Path = exceptionFeature.Path;
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
