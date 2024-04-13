using Microsoft.EntityFrameworkCore;
using backend_funcionario_webapi_aspdotnet.Data;
using backend_funcionario_webapi_aspdotnet.Models;
using System.Collections.Generic;

namespace backend_funcionario_webapi_aspdotnet.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Funcionario>>> GetFuncionarios()
        {
            Response<List<Funcionario>> response = new Response<List<Funcionario>>();

            try
            {
                var funcionarios = await _context.Funcionarios
                    .ToListAsync();

                if (funcionarios == null)
                {
                    response.Mensagem = "Nenhum funcionario encontrado!";
                    return response;
                }

                response.Dados = new List<Funcionario>(funcionarios);
                response.Mensagem = "Funcionarios encontrado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<Response<Funcionario>> GetFuncionario(int id)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            try
            {
                var funcionario = await _context.Funcionarios
                    .FirstOrDefaultAsync(func => func.Ativo && func.Id == id);

                if (funcionario == null)
                {
                    response.Mensagem = "Funcionario não encontrado!";
                    return response;
                }

                response.Dados = funcionario;
                response.Mensagem = "Funcionario encontrado com sucesso";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<Response<Funcionario>> CriarFuncionario(Funcionario novoFuncionario)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            try
            {
                await _context.AddAsync(novoFuncionario);
                await _context.SaveChangesAsync();

                response.Dados = novoFuncionario; 
                response.Mensagem = "Funcionario criado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<Response<Funcionario>> AtualizarFuncionario(Funcionario funcionarioEditado)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            try
            {
                var funcionarioExiste = await _context.Funcionarios
                    .AsNoTracking()
                    .SingleOrDefaultAsync(func => func.Ativo == true && func.Id == funcionarioEditado.Id);

                if (funcionarioExiste == null)
                {
                    response.Mensagem = "Funcionario não encontrado!";
                    return response;
                }

                funcionarioEditado.NovaModificacao();

                _context.Funcionarios.Update(funcionarioEditado);
                await _context.SaveChangesAsync();

                response.Dados = funcionarioEditado;
                response.Mensagem = "Funcionario atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<Response<Funcionario>> InativarFuncionario(int id)
        {
            Response<Funcionario> response = new Response<Funcionario>();
            try
            {
                var funcionario = await _context.Funcionarios
                    .SingleOrDefaultAsync(func => func.Ativo && func.Id == id);

                if (funcionario == null)
                {
                    response.Mensagem = "Funcionario não encontrado!";
                    return response;
                }

                funcionario.InativarFuncionairo();
                await _context.SaveChangesAsync();

                response.Dados = funcionario;
                response.Mensagem = "Funcionario desativado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<Response<Funcionario>> DeletarFuncionario(int id)
        {
            Response<Funcionario> response = new Response<Funcionario>();

            try
            {
                var funcionario = await _context.Funcionarios
                    .SingleOrDefaultAsync(func => func.Ativo && func.Id == id);

                if (funcionario == null)
                {
                    response.Mensagem = "Funcionario não encontrado!";
                    return response;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                response.Dados = funcionario;
                response.Mensagem = "Funcionario deletado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }
    }
}
