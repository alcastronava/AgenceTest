using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoSistemaObs
    {
        public int CoObs { get; set; }
        public string Descricao { get; set; }
        public long? CoSistema { get; set; }
        public string CoUsuario { get; set; }
        public DateTime? DtObs { get; set; }
    }
}
