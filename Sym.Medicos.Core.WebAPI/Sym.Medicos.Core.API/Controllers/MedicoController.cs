using Microsoft.AspNetCore.Mvc;
using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using System;

namespace Sym.Medicos.Core.API.Controllers
{
    [Route("api/[Controller]")]
    public class MedicoController : Controller
    {
        // Instanciando a interface IMedicoRepository
        private readonly IMedicoRepository _medicoRepository;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="medicoRepository"></param>
        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        /// <summary>
        /// Método responsável por buscas todos os Medicos
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
                return Json(_medicoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por verificar se o Médico está cadastrado. 
        /// </summary>
        /// <param name="medico"></param>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        /// <returns></returns>
        [HttpPost("VerificaMedico")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public ActionResult VerificaMedico([FromBody] Medico medico)
        {
            try
            {
                var medicoRetorno = _medicoRepository.Obter(medico.Crm, medico.NomeMedico);

                if (medicoRetorno != null)
                    return Ok(medicoRetorno);

                return BadRequest("Médico inválido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por fazer o cadastro de Médico
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        [HttpPost]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Post([FromBody] Medico medico)
        {
            try
            {
                medico.Validate();
                if (!medico.EhValido)
                    return BadRequest(medico.ObterMensagensValidacao());

                var medicoCadastrado = _medicoRepository.ObterTodos(medico.Crm);

                if (medicoCadastrado != null)
                    return BadRequest("Médico já cadastrado no sistema.");

                if (medico.IdMedico > 0)
                    _medicoRepository.Atualizar(medico);
                else
                    _medicoRepository.Adicionar(medico);

                return Created("api/medico", medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por deletar consultório medico
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        /// <response code="200">Operação Executada com Sucesso.</response>
        /// <response code="403">Não Autorizado</response>
        /// <response code="404">Não encontrado.</response>
        /// <response code="500">Erro no Servidor.</response>
        [HttpPost("Deletar")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 403)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Deletar([FromBody] Medico medico)
        {
            try
            {
                _medicoRepository.Remover(medico);
                return Json(_medicoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
