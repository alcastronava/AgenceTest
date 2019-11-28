using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoUsuario
    {
        public CaoUsuario()
        {
            CaoConhecimentos = new HashSet<CaoConhecimentos>();
            CaoHistOcorrenciasOs = new HashSet<CaoHistOcorrenciasOs>();
            CaoPontosConhecimento = new HashSet<CaoPontosConhecimento>();
        }

        public string CoUsuario { get; set; }
        public string NoUsuario { get; set; }
        public string DsSenha { get; set; }
        public string CoUsuarioAutorizacao { get; set; }
        public long? NuMatricula { get; set; }
        public DateTime? DtNascimento { get; set; }
        public DateTime? DtAdmissaoEmpresa { get; set; }
        public DateTime? DtDesligamento { get; set; }
        public DateTime? DtInclusao { get; set; }
        public DateTime? DtExpiracao { get; set; }
        public string NuCpf { get; set; }
        public string NuRg { get; set; }
        public string NoOrgaoEmissor { get; set; }
        public string UfOrgaoEmissor { get; set; }
        public string DsEndereco { get; set; }
        public string NoEmail { get; set; }
        public string NoEmailPessoal { get; set; }
        public string NuTelefone { get; set; }
        public DateTime DtAlteracao { get; set; }
        public string UrlFoto { get; set; }
        public string InstantMessenger { get; set; }
        public int? Icq { get; set; }
        public string Msn { get; set; }
        public string Yms { get; set; }
        public string DsCompEnd { get; set; }
        public string DsBairro { get; set; }
        public string NuCep { get; set; }
        public string NoCidade { get; set; }
        public string UfCidade { get; set; }
        public DateTime? DtExpedicao { get; set; }

        public virtual ICollection<CaoConhecimentos> CaoConhecimentos { get; set; }
        public virtual ICollection<CaoHistOcorrenciasOs> CaoHistOcorrenciasOs { get; set; }
        public virtual ICollection<CaoPontosConhecimento> CaoPontosConhecimento { get; set; }
    }
}
