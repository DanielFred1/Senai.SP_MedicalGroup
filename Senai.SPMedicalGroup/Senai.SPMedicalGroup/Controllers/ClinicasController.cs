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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository ClinicaRepositorio { get; set; }

        public ClinicasController()
        {
            ClinicaRepositorio = new ClinicaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Clinicas clinica)
        {
            try
            {
                ClinicaRepositorio.Cadastrar(clinica);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível efetuar o cadastro!");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(Clinicas clinica)
        {
            try
            {
                ClinicaRepositorio.Atualizar(clinica);
                return Ok("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível atualizar os dados da clínica!");
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                ClinicaRepositorio.Deletar(id);
                return Ok("Clinica removida do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível remover a clínica!");
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ClinicaRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Lista de clínicas não encontrada!");
            }
        }
    }
}