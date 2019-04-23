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
        public void Cadastrar(Medicos medico)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                ctx.Medicos.Add(medico);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Medicos medico)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Medicos informacaoMedico = new Medicos();

                informacaoMedico.Id = medico.Id;
                informacaoMedico.Nome = medico.Nome;
                informacaoMedico.Crm = medico.Crm;
                informacaoMedico.IdUsuario = medico.IdUsuario;
                informacaoMedico.IdAreaAtuacao = medico.IdAreaAtuacao;
                informacaoMedico.IdClinica = medico.IdClinica;

                ctx.Medicos.Update(medico);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Medicos medico = ctx.Medicos.Find(id);

                ctx.Medicos.Remove(medico);
                ctx.SaveChanges();
            }
        }

        public List<Medicos> Listar()
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Medicos.ToList();
            }
        }
    }
}
