using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai.SPMedicalGroup.Domains;
using Senai.SPMedicalGroup.Interfaces;

namespace Senai.SPMedicalGroup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public List<Usuarios> Listar()
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Usuarios usuario)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Usuarios informacaoUsuario = new Usuarios();

                informacaoUsuario.Id = usuario.Id;
                informacaoUsuario.Email = usuario.Email;
                informacaoUsuario.Senha = usuario.Senha;
                informacaoUsuario.IdTipoUsuario = usuario.IdTipoUsuario;

                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                Usuarios usuario = ctx.Usuarios.Find(id);

                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (SPMedicalGroupContext ctx = new SPMedicalGroupContext())
            {
                return ctx.Usuarios.Include(c => c.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
        }
    }
}
