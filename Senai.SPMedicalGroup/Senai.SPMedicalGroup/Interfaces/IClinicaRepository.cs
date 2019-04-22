using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;

namespace Senai.SPMedicalGroup.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinicas clinica);
    }
}
