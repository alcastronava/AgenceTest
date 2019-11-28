using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoObsCliente
    {
        public int CoObs { get; set; }
        public string Descricao { get; set; }
        public int CoCliente { get; set; }
        public string CoUsuario { get; set; }
        public DateTime? DtObs { get; set; }
    }
}
