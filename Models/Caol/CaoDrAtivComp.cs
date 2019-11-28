using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoDrAtivComp
    {
        public int IdAtivComp { get; set; }
        public string CoUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Assunto { get; set; }
        public TimeSpan TempoGasto { get; set; }
    }
}
