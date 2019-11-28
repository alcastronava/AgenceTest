using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoOmbudsman
    {
        public int Id { get; set; }
        public byte Idtipo { get; set; }
        public byte Idcategoria { get; set; }
        public DateTime Data { get; set; }
        public string Comentario { get; set; }
        public byte CoEscritorio { get; set; }

        public virtual CaoCategoriasOmbudsman IdcategoriaNavigation { get; set; }
        public virtual CaoTipoOmbudsman IdtipoNavigation { get; set; }
    }
}
