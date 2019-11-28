using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoDiaryReport
    {
        public int CoDiaryReport { get; set; }
        public TimeSpan? HrGasta { get; set; }
        public int CoAtividade { get; set; }
        public string DsAssunto { get; set; }
        public long CoMovimento { get; set; }
        public long? NuOs { get; set; }
        public long? CoSistema { get; set; }
    }
}
