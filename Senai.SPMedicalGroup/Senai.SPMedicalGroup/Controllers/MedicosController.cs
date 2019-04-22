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

        [HttpGet("listar")]
        public IActionResult Listar(Medicos medico)
        {
            try
            {
                return Ok(MedicoRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Lista não encontrada.");
            }
        }
    }
}