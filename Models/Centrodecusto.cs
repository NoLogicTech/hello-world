using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public partial class Centrodecusto
    {
        public Centrodecusto()
        {
            Tiposervico = new HashSet<Tiposervico>();
        }

        public int CentrodecustoId { get; set; }
        public string CentrodecustoNome { get; set; }

        public virtual ICollection<Tiposervico> Tiposervico { get; set; }
    }
}
