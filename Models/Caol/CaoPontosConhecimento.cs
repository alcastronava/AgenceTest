using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoPontosConhecimento
    {
        public int Idpontos { get; set; }
        public byte Pontuacao { get; set; }
        public string CoCoordenador { get; set; }
        public int Idconhecimento { get; set; }

        public virtual CaoUsuario CoCoordenadorNavigation { get; set; }
        public virtual CaoConhecimentos IdconhecimentoNavigation { get; set; }
        public virtual CaoEscalaRanking PontuacaoNavigation { get; set; }
    }
}
