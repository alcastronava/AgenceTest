using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoMovimentoOs
    {
        public int CoMovimentoOs { get; set; }
        public int NuOs { get; set; }
        public long CoSistema { get; set; }
        public long? CoTipoMovimento { get; set; }
        public long? NuValor { get; set; }
        public string DsValor { get; set; }
        public string UsuarioObs { get; set; }
        public DateTime? DtIni { get; set; }
        public DateTime? DtFim { get; set; }
    }
}
