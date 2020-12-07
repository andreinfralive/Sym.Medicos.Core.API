using Microsoft.AspNetCore.Mvc;
using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using System;

namespace Sym.Medicos.Core.API.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        // Instanciando a interface Usuario
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="usuarioRepository"></param>
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Método responsável por buscas todos os Usuários
        /// </summary>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por verificar se o Usuário está cadastrado. 
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <returns></returns>
        [HttpPost("VerificaUsuario")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public ActionResult VerificaUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepository.ObterTodos(usuario.Email, usuario.Senha);

                if (usuarioRetorno != null)
                    return Ok(usuarioRetorno);

                return BadRequest("Usuário ou senha inválido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por fazer o cadastro de Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCadastrado = _usuarioRepository.Obter(usuario.NomeUsuario);

                if (usuarioCadastrado != null)
                    return BadRequest("Usuário já cadastrado no sistema.");

                _usuarioRepository.Adicionar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
