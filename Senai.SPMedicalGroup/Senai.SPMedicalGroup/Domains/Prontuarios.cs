using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.Domains
{
    public partial class Prontuarios
    {
        public Prontuarios()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
