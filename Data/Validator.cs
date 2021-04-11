using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;
using FluentValidation;
using CNRegistoHorasMVC;


namespace CNRegistoHorasMVC.Models
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            //--> REGRAS DE VALIDAÇÃO PARA CLIENTES

            RuleFor(cliente => cliente.ClienteId).NotNull().WithMessage("Tem de colocar o número de contribuinte!");
            
            RuleFor(cliente => cliente.ClienteNome).NotNull().WithMessage("Tem de colocar o nome do cliente!");
        }
        
    }
}