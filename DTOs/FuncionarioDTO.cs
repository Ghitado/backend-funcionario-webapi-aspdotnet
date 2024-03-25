using backend_funcionario_webapi_aspdotnet.Models.Enums;

namespace backend_funcionario_webapi_aspdotnet.DTOs
{
    public class FuncionarioDTO
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public Departamento Departamento { get; private set; }
        public Turno Turno { get; private set; }
        public bool Ativo { get; private set; }

        public FuncionarioDTO(string nome, string sobrenome, Departamento departamento, Turno turno)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Departamento = departamento;
            Turno = turno;
            Ativo = true;
        }
    }
}
