using Microsoft.AspNetCore.Mvc;
using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using System;
using System.Linq;

namespace Sym.Medicos.Core.API.Controllers
{
    /// <summary>
    /// Vinculo de Consultório e Medico
    /// </summary>
    [Route("api/[Controller]")]
    
    public class VinculoConsultorioMedicoController : Controller
    {
        //Instanciando a interface de VinculoConsultorioMedico
        private readonly IVinculoMedicoConsultorioRepository _vinculoMedicoConsultorioRepository;

        /// <summary>
        /// Método Construtor
        /// </summary>
        public VinculoConsultorioMedicoController(IVinculoMedicoConsultorioRepository vinculoMedicoConsultorioRepository)
        {
            _vinculoMedicoConsultorioRepository = vinculoMedicoConsultorioRepository;
        }

        /// <summary>
        /// Método responsável por buscas todos os vinculos de Médicos com Consultórios
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
                return Json(_vinculoMedicoConsultorioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por fazer o cadastro de Vinculo Médico e Consultório
        /// </summary>
        /// <param name="vinculo"></param>
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
        public IActionResult Post([FromBody] VinculoMedicoConsultorio vinculo)
        {
            try
            {
                vinculo.Validate();
                if (!vinculo.EhValido)
                    return BadRequest(vinculo.ObterMensagensValidacao());

                int vinculoMedico = _vinculoMedicoConsultorioRepository.ObterTodosVinculos(vinculo.CRM);

                if (vinculoMedico == 2)
                    return BadRequest("Médico já possui dois vinculos com Consultórios.");
                else
                {
                    var vinculoRetorno = _vinculoMedicoConsultorioRepository.ObterTodos(vinculo.CRM);

                    if (vinculoRetorno == null)
                        return BadRequest("Nenhum Médico Vinculado a nenhum Consultório.");

                    _vinculoMedicoConsultorioRepository.Adicionar(vinculo);
                }

                return Created("api/VinculoConsultorioMedico", vinculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Método responsável por deletar vinculo de médico com consultório
        /// </summary>
        /// <param name="vinculo"></param>
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
        public IActionResult Deletar([FromBody] VinculoMedicoConsultorio vinculo)
        {
            try
            {
                _vinculoMedicoConsultorioRepository.Remover(vinculo);
                return Json(_vinculoMedicoConsultorioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
