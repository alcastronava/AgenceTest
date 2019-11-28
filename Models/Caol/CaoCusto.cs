using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoCusto
    {
        public long CoCusto { get; set; }
        public byte CoTipoCusto { get; set; }
        public string Descricao { get; set; }
        public byte CoEscritorio { get; set; }
        public DateTime? DtCompra { get; set; }
        public DateTime? DtPagamento { get; set; }
        public string CoBoleto { get; set; }
        public float Valor { get; set; }
        public string Parcela { get; set; }
        public byte? Pag { get; set; }
        public long CoCustoHigh { get; set; }
    }
}
