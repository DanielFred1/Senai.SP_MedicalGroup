using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public int IdUsuario { get; set; }
        public int IdAreaAtuacao { get; set; }
        public int IdClinica { get; set; }

        public AreasClinicas IdAreaAtuacaoNavigation { get; set; }
        public Clinicas IdClinicaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
