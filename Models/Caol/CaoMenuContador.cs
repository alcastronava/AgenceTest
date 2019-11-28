using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoMenuContador
    {
        public string CoUsuario { get; set; }
        public byte CoMenu { get; set; }
        public byte NuPontos { get; set; }
        public byte InProcessado { get; set; }
    }
}
