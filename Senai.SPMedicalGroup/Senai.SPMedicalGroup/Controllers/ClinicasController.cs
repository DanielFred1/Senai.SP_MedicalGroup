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
                return BadRequest("Problema ao cadastrar!");
            }
        }
    }
}