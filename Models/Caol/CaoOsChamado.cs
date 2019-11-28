using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoOsChamado
    {
        public int CoChamado { get; set; }
        public int CoSistema { get; set; }
        public int CoOs { get; set; }
        public string DsChamado { get; set; }
        public int CoTipo { get; set; }
        public int CoPrioridade { get; set; }
        public int CoItem { get; set; }
        public string Descricao { get; set; }
        public string DsSolucao { get; set; }
        public string Tempo { get; set; }
        public DateTime DtChamado { get; set; }
        public int Status { get; set; }
        public string CoUsuario { get; set; }
        public string CoAnalista { get; set; }
        public string Email { get; set; }
    }
}
