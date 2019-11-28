using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoDiaryReportConsultor
    {
        public int CoDiaryReportConsultor { get; set; }
        public int CoMovimento { get; set; }
        public int CoAtividade { get; set; }
        public string DsEmpresa { get; set; }
        public string DsAssunto { get; set; }
        public DateTime DtAgendamento { get; set; }
        public DateTime? DtAgendamentoFim { get; set; }
        public float VlFechamento { get; set; }
        public long? CoCliente { get; set; }
    }
}
