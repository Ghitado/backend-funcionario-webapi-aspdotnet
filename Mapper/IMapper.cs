using backend_funcionario_webapi_aspdotnet.DTOs;
using backend_funcionario_webapi_aspdotnet.Models;

namespace backend_funcionario_webapi_aspdotnet.Mapper
{
    public interface IMapper
    {
        Funcionario NovoFuncionario(FuncionarioDTO funcionario);
        Funcionario NovoFuncionario(Funcionario funcionario);
        FuncionarioDTO NovoFuncionarioDTO(Funcionario funcionario);
    }
}
