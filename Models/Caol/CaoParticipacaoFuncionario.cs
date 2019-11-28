using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoParticipacaoFuncionario
    {
        public int CoPartFuncionario { get; set; }
        public float PcParticipacao { get; set; }
        public string CoUsuario { get; set; }
        public byte CoEscritorio { get; set; }
        public DateTime DtReferencia { get; set; }
    }
}
