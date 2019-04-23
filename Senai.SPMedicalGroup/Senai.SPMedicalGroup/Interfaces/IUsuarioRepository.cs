using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;

namespace Senai.SPMedicalGroup.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        void Cadastrar(Usuarios usuario);

        void Atualizar(Usuarios usuario);

        void Deletar(int id);

        Usuarios BuscarPorEmailESenha(string email, string senha);
    }
}
