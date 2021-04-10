using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public partial class Servico
    {
        public int ServicoId { get; set; }
        public int ColaboradorId { get; set; }
        public int ClienteId { get; set; }
        public int TiposervicoId { get; set; }
        public DateTime ServicoDataservico { get; set; }
        public byte[] ServicoDataregisto { get; set; }
        public int ServicoHoras { get; set; }
        public string ServicoDescricao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public virtual Tiposervico Tiposervico { get; set; }
    }
}
