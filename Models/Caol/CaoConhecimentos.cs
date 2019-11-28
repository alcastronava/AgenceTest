using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoConhecimentos
    {
        public CaoConhecimentos()
        {
            CaoConhecimentosFontes = new HashSet<CaoConhecimentosFontes>();
            CaoPontosConhecimento = new HashSet<CaoPontosConhecimento>();
        }

        public int Idconhecimento { get; set; }
        public string Assunto { get; set; }
        public string Conhecimento { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
        public string Usuario { get; set; }
        public DateTime Datahora { get; set; }

        public virtual CaoUsuario UsuarioNavigation { get; set; }
        public virtual ICollection<CaoConhecimentosFontes> CaoConhecimentosFontes { get; set; }
        public virtual ICollection<CaoPontosConhecimento> CaoPontosConhecimento { get; set; }
    }
}
