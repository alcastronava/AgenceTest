using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoOsDailyReport
    {
        public int CoDaily { get; set; }
        public int? CoOs { get; set; }
        public int? CoFase { get; set; }
        public string CoUsuario { get; set; }
        public string DsAssunto { get; set; }
        public TimeSpan? TempoGasto { get; set; }
        public DateTime? Data { get; set; }
        public int? CoStatusAtual { get; set; }
        public int? CoChamado { get; set; }
        public int? CoAtividade { get; set; }
    }
}
