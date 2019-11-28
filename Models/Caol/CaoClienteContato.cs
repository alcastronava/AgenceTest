using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoClienteContato
    {
        public int CoCliente { get; set; }
        public DateTime? DtContato { get; set; }
        public int? FgAgendado { get; set; }
        public TimeSpan? HrIni { get; set; }
        public TimeSpan? HrEnd { get; set; }
    }
}
