using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenceTest.Models.Caol;

namespace AgenceTest.Controllers
{
    public class CaoUsuariosController : Controller
    {
        private readonly AgenceCaolContext _context;

        public CaoUsuariosController(AgenceCaolContext context)
        {
            _context = context;
        }

        // GET: CaoUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaoUsuario.ToListAsync());
        }

        // GET: CaoUsuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caoUsuario = await _context.CaoUsuario
                .FirstOrDefaultAsync(m => m.CoUsuario == id);
            if (caoUsuario == null)
            {
                return NotFound();
            }

            return View(caoUsuario);
        }

        // GET: CaoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoUsuario,NoUsuario,DsSenha,CoUsuarioAutorizacao,NuMatricula,DtNascimento,DtAdmissaoEmpresa,DtDesligamento,DtInclusao,DtExpiracao,NuCpf,NuRg,NoOrgaoEmissor,UfOrgaoEmissor,DsEndereco,NoEmail,NoEmailPessoal,NuTelefone,DtAlteracao,UrlFoto,InstantMessenger,Icq,Msn,Yms,DsCompEnd,DsBairro,NuCep,NoCidade,UfCidade,DtExpedicao")] CaoUsuario caoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caoUsuario);
        }

        // GET: CaoUsuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caoUsuario = await _context.CaoUsuario.FindAsync(id);
            if (caoUsuario == null)
            {
                return NotFound();
            }
            return View(caoUsuario);
        }

        // POST: CaoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CoUsuario,NoUsuario,DsSenha,CoUsuarioAutorizacao,NuMatricula,DtNascimento,DtAdmissaoEmpresa,DtDesligamento,DtInclusao,DtExpiracao,NuCpf,NuRg,NoOrgaoEmissor,UfOrgaoEmissor,DsEndereco,NoEmail,NoEmailPessoal,NuTelefone,DtAlteracao,UrlFoto,InstantMessenger,Icq,Msn,Yms,DsCompEnd,DsBairro,NuCep,NoCidade,UfCidade,DtExpedicao")] CaoUsuario caoUsuario)
        {
            if (id != caoUsuario.CoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaoUsuarioExists(caoUsuario.CoUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(caoUsuario);
        }

        // GET: CaoUsuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caoUsuario = await _context.CaoUsuario
                .FirstOrDefaultAsync(m => m.CoUsuario == id);
            if (caoUsuario == null)
            {
                return NotFound();
            }

            return View(caoUsuario);
        }

        // POST: CaoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var caoUsuario = await _context.CaoUsuario.FindAsync(id);
            _context.CaoUsuario.Remove(caoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaoUsuarioExists(string id)
        {
            return _context.CaoUsuario.Any(e => e.CoUsuario == id);
        }
    }
}
