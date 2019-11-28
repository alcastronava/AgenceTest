using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoBoleto
    {
        public int CoBoleto { get; set; }
        public int CoCliente { get; set; }
        public int CoSistema { get; set; }
        public int CoOs { get; set; }
        public string Valor { get; set; }
        public string Vencimento { get; set; }
        public int Status { get; set; }
        public string Boleto { get; set; }
        public string LinhaDig { get; set; }
        public string Parcela { get; set; }
    }
}
