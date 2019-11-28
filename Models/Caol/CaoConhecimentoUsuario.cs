using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoConhecimentoUsuario
    {
        public string CoUsuario { get; set; }
        public int CoConhecimento { get; set; }
        public int? NvConhecimento { get; set; }
        public byte? IsCertificado { get; set; }
    }
}
