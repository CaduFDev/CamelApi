using CamelDev.CamelApi.Api.HATEOAS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamelDev.CamelApi.Api.DTO
{
    public class AlunoDTO : RestResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O Nome do aluno é obrigatório*")]
        [StringLength(maximumLength:100, MinimumLength = 2, ErrorMessage ="O Nome do aluno deve conter entre 2 e 100 caracteres.")]
        public string Name { get; set; }
        
        [StringLength(300,ErrorMessage ="O E-mail deve ser inserido para recebimento de informativos importantes")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A Mensalidade do aluno é obrigatória")]
        [Range(0.01, 9999.99, ErrorMessage ="A Mensalidade deve conter entre 0,01 e 9999,99")]
        public decimal Mensalidade { get; set; }


    }
}