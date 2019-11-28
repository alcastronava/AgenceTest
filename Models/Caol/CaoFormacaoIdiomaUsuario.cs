using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoFormacaoIdiomaUsuario
    {
        public string CoUsuario { get; set; }
        public int CoIdioma { get; set; }
        public int? NvLeitura { get; set; }
        public int? NvEscrita { get; set; }
        public int? NvFala { get; set; }
    }
}
