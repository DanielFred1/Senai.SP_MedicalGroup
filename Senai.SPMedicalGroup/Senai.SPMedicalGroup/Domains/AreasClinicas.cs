using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.Domains
{
    public partial class AreasClinicas
    {
        public AreasClinicas()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
