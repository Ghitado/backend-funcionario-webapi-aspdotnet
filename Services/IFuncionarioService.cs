using backend_funcionario_webapi_aspdotnet.Models;

namespace backend_funcionario_webapi_aspdotnet.Services
{
    public interface IFuncionarioService
    {
        Task<Response<List<Funcionario>>> GetFuncionarios();
        Task<Response<Funcionario>> GetFuncionario(int id);
        Task<Response<Funcionario>> CriarFuncionario(Funcionario funcionario);
        Task<Response<Funcionario>> AtualizarFuncionario(Funcionario funcionario);
        Task<Response<Funcionario>> InativarFuncionario(int id);
        Task<Response<Funcionario>> DeletarFuncionario(int id);
    }
}
