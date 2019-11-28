using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoFatura
    {
        public int CoFatura { get; set; }
        public int CoCliente { get; set; }
        public int CoSistema { get; set; }
        public int CoOs { get; set; }
        public int NumNf { get; set; }
        public float Total { get; set; }
        public float Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CorpoNf { get; set; }
        public float ComissaoCn { get; set; }
        public float TotalImpInc { get; set; }
    }
}
