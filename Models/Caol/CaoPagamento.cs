using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoPagamento
    {
        public long CoPagamento { get; set; }
        public string CoUsuario { get; set; }
        public string TpPagamento { get; set; }
        public DateTime DtPagamento { get; set; }
        public float VlPagamento { get; set; }
        public DateTime DtReferenciaPagamento { get; set; }
    }
}
