using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;
using Senai.SPMedicalGroup.Interfaces;

namespace Senai.SPMedicalGroup.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void Cadastrar(Clinicas clinica)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                ctx.Clinicas.Add(clinica);
                ctx.SaveChanges();
            }
        }
    }
}
