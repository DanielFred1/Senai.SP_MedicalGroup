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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [HttpGet("listar")]
        public IActionResult Listar(int id)
        {
            try
            {
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Lista de usuarios não encontrada.");
            }
        }


        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok("Usuario cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar usuario.");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Atualizar(usuario);
                return Ok("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível atualizar os dados do usuário.");
            }
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                UsuarioRepositorio.Deletar(id);
                return Ok("Usuario removido do sistema com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover o usuario.");
            }
        }

    }
}