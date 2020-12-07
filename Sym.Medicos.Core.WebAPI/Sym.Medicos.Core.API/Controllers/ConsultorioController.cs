using Microsoft.AspNetCore.Mvc;
using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using System;

namespace Sym.Medicos.Core.API.Controllers
{
    [Route("api/[Controller]")]
    public class ConsultorioController : Controller
    {
        // Instanciando a interface de Consultorios
        private readonly IConsultorioRepository _consultorioRepository;

        /// <summary>
        /// Método Construtor
        /// </summary>
        public ConsultorioController(IConsultorioRepository consultorioRepository)
        {
            _consultorioRepository = consultorioRepository;
        }

        /// <summary>
        /// Método responsável por buscas todos os consultorio
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
                return Json(_consultorioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por verificar se o Consultório está cadastrado. 
        /// </summary>
        /// <param name="consultorio"></param>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <returns></returns>
        [HttpPost("VerificaConsultorio")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public ActionResult VerificaConsultorio([FromBody] Consultorio consultorio)
        {
            try
            {
                var consultorioRetorno = _consultorioRepository.Obter(consultorio.NomeConsultorio, consultorio.EnderecoConsultorio);

                if (consultorioRetorno != null)
                    return Ok(consultorioRetorno);

                return BadRequest("Consultório ou inválido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por fazer o cadastro de Consultorio
        /// </summary>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <param name="consultorio"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Post([FromBody] Consultorio consultorio)
        {
            try
            {
                consultorio.Validate();
                if (!consultorio.EhValido)
                    return BadRequest(consultorio.ObterMensagensValidacao());

                var consultorioCadastrado = _consultorioRepository.ObterTodos(consultorio.NomeConsultorio);

                if (consultorioCadastrado != null)
                    return BadRequest("Consultório já cadastrado no sistema.");

                if (consultorio.IdConsultorio > 0)
                    _consultorioRepository.Atualizar(consultorio);
                else
                    _consultorioRepository.Adicionar(consultorio);

                return Created("api/consultorio", consultorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por deletar consultório cadastrado
        /// </summary>
        /// <param name="consultorio"></param>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <returns></returns>
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Consultorio consultorio)
        {
            try
            {
                _consultorioRepository.Remover(consultorio);
                return Json(_consultorioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
