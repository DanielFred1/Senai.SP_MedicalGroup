﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;
using Senai.SPMedicalGroup.Interfaces;

namespace Senai.SPMedicalGroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void Agendar(Consultas consulta)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Consultas consulta)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Consultas InformacaoConsulta = new Consultas();

                InformacaoConsulta.IdMedico = consulta.IdMedico;
                InformacaoConsulta.IdProntuario = consulta.IdProntuario;
                InformacaoConsulta.DataHora = consulta.DataHora;
                InformacaoConsulta.Descricao = "Consulta Realizada";
                InformacaoConsulta.Status = consulta.Status;

                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consultas> Listar()
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Consultas.ToList();
            }
        }

        public void Cancelar(int id)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Consultas consulta = new Consultas();

                consulta.Id = BuscarPorId(id).Id;
                consulta.IdMedico = BuscarPorId(id).IdMedico;
                consulta.IdProntuario = BuscarPorId(id).IdProntuario;
                consulta.DataHora = BuscarPorId(id).DataHora;
                consulta.Descricao = BuscarPorId(id).Descricao;
                consulta.Status = "Cancelada";

                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Consultas consulta = ctx.Consultas.Find(id);

                ctx.Consultas.Remove(consulta);
                ctx.SaveChanges();
            }
        }

        public Consultas BuscarPorId(int id)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Consultas.Find(id);
            }
        }

        public List<Consultas> BuscarPorIdMedico(int idmedico)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Consultas.Where(i => i.IdMedico == idmedico).ToList();
            }
        }

        public List<Consultas> BuscarPorIdProntuario(int idprontuario)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Consultas.Where(i => i.IdProntuario == idprontuario).ToList();
            }
        }

        public List<Consultas> BuscarConsultasMedico(int idmedico)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Consultas.Where(i => i.IdMedico == idmedico).ToList();
            }
        }

        public List<Consultas> BuscarConsultasProntuario(int idprontuario)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Consultas.Where(i => i.IdProntuario == idprontuario).ToList();
            }
        }

    }
}
