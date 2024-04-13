using backend_funcionario_webapi_aspdotnet.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_funcionario_webapi_aspdotnet.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public Departamento Departamento { get; private set; }
        public Turno Turno { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataDeCriacao { get; private set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; private set; } = DateTime.Now.ToLocalTime();

        public Funcionario()
        {
        }

        public void NovaModificacao()
        {
            DataDeAlteracao = DateTime.Now.ToLocalTime();
        }

        public void InativarFuncionairo()
        {
            Ativo = false;
        }
    }
}
