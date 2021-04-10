using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Servico = new HashSet<Servico>();
        }

        public int ColaboradorId { get; set; }
        public string ColaboradorNomedeutilizador { get; set; }
        public string ColaboradorNome { get; set; }
        public string ColaboradorApelido { get; set; }
        public string ColaboradorAlcunha { get; set; }
        public string ColaboradorEmail { get; set; }
        public int PapelId { get; set; }
        public string ColaboradorSenha { get; set; }
        public bool ColaboradorEstado { get; set; }
        public int ColaboradorNif { get; set; }

        public virtual Papel Papel { get; set; }
        public virtual ICollection<Servico> Servico { get; set; }
    }
}
