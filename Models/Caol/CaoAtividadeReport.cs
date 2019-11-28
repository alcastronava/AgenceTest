using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoAtividadeReport
    {
        public int Id { get; set; }
        public int CoCliente { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public string Lembrete { get; set; }
        public int CoAtividade { get; set; }
        public int CoOs { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public string Status { get; set; }
        public string Tempo { get; set; }
        public string CoUsuario { get; set; }
        public DateTime DataAtiv { get; set; }
        public string Retorno { get; set; }
        public int? CoFase { get; set; }
    }
}
