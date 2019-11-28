using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class PermissaoSistema
    {
        public string CoUsuario { get; set; }
        public long CoTipoUsuario { get; set; }
        public long CoSistema { get; set; }
        public string InAtivo { get; set; }
        public string CoUsuarioAtualizacao { get; set; }
        public DateTime DtAtualizacao { get; set; }
    }
}
