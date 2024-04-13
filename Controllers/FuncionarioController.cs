using Microsoft.AspNetCore.Mvc;
using backend_funcionario_webapi_aspdotnet.Models;
using backend_funcionario_webapi_aspdotnet.Services;

namespace backend_funcionario_webapi_aspdotnet.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService employeeService)
        {
            _funcionarioService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> Get()
        {
            var result = await _funcionarioService.GetFuncionarios();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> Get(int id)
        {
            var result = await _funcionarioService.GetFuncionario(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Funcionario>> Post(Funcionario funcionario)
        {
            var result = await _funcionarioService.CriarFuncionario(funcionario);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Funcionario>> Put(Funcionario funcionario)
        {
            var result = await _funcionarioService.AtualizarFuncionario(funcionario);

            return Ok(result);
        }

        [HttpPut("InativarFuncionario/{id}")]
        public async Task<ActionResult<Funcionario>> Inactive(int id)
        {
            var result = await _funcionarioService.InativarFuncionario(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcionario>> Delete(int id)
        {
            var result = await _funcionarioService.DeletarFuncionario(id);

            return Ok(result);
        }
    }
}
