using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoBancoHoras
    {
        public int CoBancHoras { get; set; }
        public string CoUsuario { get; set; }
        public string Periodo { get; set; }
        public int MinMes { get; set; }
        public int MinFerias { get; set; }
        public int MinPago { get; set; }
        public int MinTotal { get; set; }
    }
}
