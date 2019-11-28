using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoFaturaPag
    {
        public int IdFaturaPag { get; set; }
        public int CoFatura { get; set; }
        public DateTime DtEfetuado { get; set; }
        public float ValorPago { get; set; }
    }
}
