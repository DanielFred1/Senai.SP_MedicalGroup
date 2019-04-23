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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MedicoRepositorio { get; set; }

        public MedicosController()
        {
            MedicoRepositorio = new MedicoRepository();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Medicos medico)
        {
            try
            {
                MedicoRepositorio.Cadastrar(medico);
                return Ok("Medico cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar o(a) Medico(a).");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Medicos medico)
        {
            try
            {
                MedicoRepositorio.Atualizar(medico);
                return Ok("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível atualizar dados do Medico(a).");
            }
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                MedicoRepositorio.Deletar(id);
                return Ok("Medico(a) removido(a) do sistema com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover Medico(a) do sistema.");
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar(int id)
        {
            try
            {
                return Ok(MedicoRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Lista de Medicos não encontrada.");
            }
        }
    }
}