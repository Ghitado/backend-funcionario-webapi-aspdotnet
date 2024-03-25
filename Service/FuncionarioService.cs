using Microsoft.EntityFrameworkCore;
using backend_funcionario_webapi_aspdotnet.Data;
using backend_funcionario_webapi_aspdotnet.DTOs;
using backend_funcionario_webapi_aspdotnet.Mapper;
using backend_funcionario_webapi_aspdotnet.Models;
using System;

namespace backend_funcionario_webapi_aspdotnet.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FuncionarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<Funcionario>>> GetFuncionarios()
        {
            Response<List<Funcionario>> response = new Response<List<Funcionario>>();

            var funcionarios = await _context.Funcionarios
                .Where(func => func.Ativo)
                .ToListAsync();

            if (funcionarios == null)
            {
                response.Mensagem = "Nenhum funcionario encontrado!";
                return response;
            }

            response.Dados = new List<Funcionario>(funcionarios);
            response.Mensagem = "Funcionarios encontrado com sucesso!";

            return response;
        }

        public async Task<Response<List<Funcionario>>> GetByIdFuncionario(int id)
        {
            Response<List<Funcionario>> response = new Response<List<Funcionario>>();

            var funcionario = await _context.Funcionarios
                .Where(func => func.Ativo && func.Id == id)
                .ToListAsync();

            if (funcionario == null)
            {
                response.Mensagem = "Funcionario não encontrado!";
                return response;
            }

            response.Dados = funcionario;
            response.Mensagem = "Funcionario encontrado com sucesso";

            return response;
        }

        public async Task<Response<Funcionario>> CriarFuncionario(FuncionarioDTO funcionario)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            var novoFuncionario = _mapper.NovoFuncionario(funcionario);

            await _context.AddAsync(novoFuncionario);
            await _context.SaveChangesAsync();

            response.Dados = novoFuncionario; 
            response.Mensagem = "Funcionario criado com sucesso!";

            return response;
        }

        public async Task<Response<Funcionario>> AtualizarFuncionario(Funcionario funcionario)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            var funcionarioExiste = await _context.Funcionarios
                .AsNoTracking()
                .SingleOrDefaultAsync(func => func.Ativo && func.Id == funcionario.Id);

            if (funcionarioExiste == null)
            {
                response.Mensagem = "Funcionario não encontrado!";
                return response;
            }

            funcionario.NovaModificacao();

            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();

            response.Dados = funcionario;
            response.Mensagem = "Funcionario atualizado com sucesso!";

            return response;
        }

        public async Task<Response<Funcionario>> InativarFuncionario(int id)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            var funcionario = await _context.Funcionarios
                .SingleOrDefaultAsync(func => func.Ativo && func.Id == id);

            if (funcionario == null)
            {
                response.Mensagem = "Funcionario não encontrado!";
                return response;
            }

            funcionario.InativarFuncionairo();
            await _context.SaveChangesAsync();

            response.Dados = _mapper.NovoFuncionario(funcionario);
            response.Mensagem = "Funcionario desativado com sucesso!";

            return response;
        }

        public async Task<Response<Funcionario>> DeletarFuncionario(int id)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            var funcionario = await _context.Funcionarios
                .SingleOrDefaultAsync(func => func.Ativo && func.Id == id);

            if (funcionario == null)
            {
                response.Mensagem = "Funcionario não encontrado!";
                return response;
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            response.Dados = _mapper.NovoFuncionario(funcionario);
            response.Mensagem = "Funcionario deletado com sucesso!";

            return response;
        }
    }
}
