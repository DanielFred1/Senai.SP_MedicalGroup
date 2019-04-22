using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;
using Senai.SPMedicalGroup.Interfaces;

namespace Senai.SPMedicalGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public List<Medicos> Listar()
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Medicos.ToList();
            }
        }
    }
}
