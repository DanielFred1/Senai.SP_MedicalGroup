using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Senai.SPMedicalGroup.Domains;
using Senai.SPMedicalGroup.Interfaces;
using Senai.SPMedicalGroup.Repositories;

namespace Senai.SPMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepositorio { get; set; }

        public ConsultasController()
        {
            ConsultaRepositorio = new ConsultaRepository();
        }

        [HttpPost("agendar")]
        public IActionResult Agendar(Consultas consulta)
        {
            try
            {
                ConsultaRepositorio.Agendar(consulta);
                return Ok("Consulta agendada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível Agendar a consulta!");
            }
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, Consultas consulta)
        {
            try
            {
                if (ConsultaRepositorio.BuscarPorId(id) == null)
                {
                    return NotFound("Consulta não encontrada!");
                }

                ConsultaRepositorio.Atualizar(id, consulta);
                return Ok("Consulta atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível Atualizar a consulta!");
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar(int id)
        {
            try
            {
                return Ok(ConsultaRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Consultas não encontradas!");
            }
        }

        [HttpGet("buscarporidmedico/{idmedico}")]
        public IActionResult BuscarPorIdMedico(int idmedico)
        {
            try
            {
                return Ok(ConsultaRepositorio.BuscarPorIdMedico(idmedico));
            }
            catch (Exception ex)
            {
                return NotFound("Não foi possível encontrar Médico!");
            }
        }

        [HttpGet("buscarporidprontuario/{idprontuario}")]
        public IActionResult BuscarPorIdProntuario(int idprontuario)
        {
            try
            {
                return Ok(ConsultaRepositorio.BuscarPorIdProntuario(idprontuario));
            }
            catch (Exception ex)
            {
                return NotFound("Não foi possível encontrar Prontuario!");
            }
        }

    }
}