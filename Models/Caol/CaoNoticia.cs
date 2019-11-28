using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoNoticia
    {
        public int CoNoticia { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string CoUsuario { get; set; }
        public DateTime DtNoticia { get; set; }
    }
}
