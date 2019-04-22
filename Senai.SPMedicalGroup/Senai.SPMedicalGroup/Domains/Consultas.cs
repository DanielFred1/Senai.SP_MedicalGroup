using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public int IdProntuario { get; set; }
        public int IdMedico { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Prontuarios IdProntuarioNavigation { get; set; }

    }

}
