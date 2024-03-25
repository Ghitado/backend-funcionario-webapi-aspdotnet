using Microsoft.AspNetCore.Mvc;
using backend_funcionario_webapi_aspdotnet.DTOs;
using backend_funcionario_webapi_aspdotnet.Models;
using backend_funcionario_webapi_aspdotnet.Service;

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
        public async Task<ActionResult<List<FuncionarioDTO>>> Get(int id)
        {
            var result = await _funcionarioService.GetByIdFuncionario(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(FuncionarioDTO funcionario)
        {
            var result = await _funcionarioService.CriarFuncionario(funcionario);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Funcionario funcionario)
        {
            var result = await _funcionarioService.AtualizarFuncionario(funcionario);

            return Ok(result);
        }

        [HttpPut("inativarFuncionario")]
        public async Task<ActionResult> Inactive(int id)
        {
            var result = await _funcionarioService.InativarFuncionario(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _funcionarioService.DeletarFuncionario(id);

            return Ok(result);
        }
    }
}
