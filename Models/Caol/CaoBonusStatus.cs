using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoBonusStatus
    {
        public int Id { get; set; }
        public string CoUsuario { get; set; }
        public DateTime DataSolic { get; set; }
        public string Mes { get; set; }
        public string Valor { get; set; }
        public string IsSolic { get; set; }
        public string IsPg { get; set; }
        public string IsHoras { get; set; }
    }
}
