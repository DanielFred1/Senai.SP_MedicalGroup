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

        public void Atualizar(Clinicas clinica)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Clinicas atualizarClinica = new Clinicas();

                atualizarClinica.Id = clinica.Id;
                atualizarClinica.Nome = clinica.Nome;
                atualizarClinica.RazaoSocial = clinica.RazaoSocial;
                atualizarClinica.Endereco = clinica.Endereco;
                atualizarClinica.Cep = clinica.Cep;
                atualizarClinica.Cnpj = clinica.Cnpj;

                ctx.Clinicas.Update(clinica);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Clinicas clinica = ctx.Clinicas.Find(id);

                ctx.Clinicas.Remove(clinica);
                ctx.SaveChanges();
            }
        }

        public List<Clinicas> Listar()
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Clinicas.ToList();
            }
        }
    }
}
