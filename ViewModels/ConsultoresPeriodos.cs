using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTest.ViewModels
{
    public class ConsultoresPeriodos
    {
        public ConsultoresPeriodos()
        {
            Nombre = string.Empty;
            Periodos = new List<ConsultorPeriodo>();
            TotalGanancias = 0;
            TotalComisiones = 0;
            TotalSalario = 0;
            TotalLucro = 0;
        }

        public string Nombre { get; set; }

        public ICollection<ConsultorPeriodo> Periodos { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float TotalGanancias { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float TotalComisiones { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float TotalSalario { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float TotalLucro { get; set; }
    }
}
