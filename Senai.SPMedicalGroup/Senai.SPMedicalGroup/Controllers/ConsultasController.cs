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

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                ConsultaRepositorio.Deletar(id);
                return Ok("Consulta removida do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível deletar a consulta!");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Consultas consulta)
        {
            try
            {
                ConsultaRepositorio.Atualizar(consulta);
                return Ok("Consulta atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível Atualizar a consulta!");
            }
        }

        [HttpPut("cancelar/{id}")]
        public IActionResult Cancelar(int id)
        {
            try
            {
                if (ConsultaRepositorio.BuscarPorId(id) == null)
                {
                    return NotFound("Consulta não encontrada!");
                }

                ConsultaRepositorio.Cancelar(id);
                return Ok("Consulta cancelada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cancelar a consulta!");
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
                return BadRequest("Lista de consultas não encontrada!");
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
                return NotFound("Médico não encontrado!");
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
                return NotFound("Prontuario não encontrado!");
            }
        }

    }
}