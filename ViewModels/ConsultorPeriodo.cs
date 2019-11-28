using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTest.ViewModels
{
    public class ConsultorPeriodo
    {
        public string Periodo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float Ganancias { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float Comisiones { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float Salario { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public float Lucro { get; set; }
    }
}
