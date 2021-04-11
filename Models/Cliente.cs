﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Servico = new HashSet<Servico>();
        }

        [Required(ErrorMessage="Tem de colocar o número de contribuinte!")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage="Tem de colocar o nome do cliente!")]
        public string ClienteNome { get; set; }
        public string ClienteAbreviatura { get; set; }
        public string ClienteDescricao { get; set; }
        public int? ClienteErpid { get; set; }
        public string ClienteEmail { get; set; }

        public virtual ICollection<Servico> Servico { get; set; }
    }
}
