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
        public IActionResult Listar(Usuarios usuario)
        {
            try
            {
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Lista não encontrada.");
            }
        }


        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok("Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Problema ao Cadastrar!");
            }
        }

    }
}