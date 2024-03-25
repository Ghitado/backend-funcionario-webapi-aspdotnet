using backend_funcionario_webapi_aspdotnet.DTOs;
using backend_funcionario_webapi_aspdotnet.Models;

namespace backend_funcionario_webapi_aspdotnet.Mapper
{
    public class Mapper : IMapper
    {
        public Funcionario NovoFuncionario(FuncionarioDTO funcionario)
        {
            return new Funcionario(funcionario.Nome, funcionario.Sobrenome, funcionario.Departamento, funcionario.Turno);
        }

        public Funcionario NovoFuncionario(Funcionario funcionario)
        {
            return new Funcionario(funcionario.Nome, funcionario.Sobrenome, funcionario.Departamento, funcionario.Turno);
        }

        public FuncionarioDTO NovoFuncionarioDTO(Funcionario funcionario)
        {
            return new FuncionarioDTO(funcionario.Nome, funcionario.Sobrenome, funcionario.Departamento, funcionario.Turno);
        }
    }
}
