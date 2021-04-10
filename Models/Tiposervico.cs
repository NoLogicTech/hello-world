using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public partial class Tiposervico
    {
        public Tiposervico()
        {
            Servico = new HashSet<Servico>();
        }

        public int TiposervicoId { get; set; }
        public string TiposervicoNome { get; set; }
        public string TiposervicoCategoria { get; set; }
        public int CentrodecustoId { get; set; }

        public virtual Centrodecusto Centrodecusto { get; set; }
        public virtual ICollection<Servico> Servico { get; set; }
    }
}
