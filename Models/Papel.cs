using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public partial class Papel
    {
        public Papel()
        {
            Colaborador = new HashSet<Colaborador>();
        }

        public int PapelId { get; set; }
        public string PapelNome { get; set; }

        public virtual ICollection<Colaborador> Colaborador { get; set; }
    }
}
