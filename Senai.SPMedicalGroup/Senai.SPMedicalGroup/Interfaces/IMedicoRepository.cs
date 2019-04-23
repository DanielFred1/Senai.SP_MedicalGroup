using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;

namespace Senai.SPMedicalGroup.Interfaces
{
    interface IMedicoRepository
    {
        void Cadastrar(Medicos medico);

        void Atualizar(Medicos medico);

        void Deletar(int id);

        List<Medicos> Listar();
    }
}
