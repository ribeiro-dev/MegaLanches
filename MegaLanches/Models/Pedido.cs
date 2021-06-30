using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MegaLanches.Models
{
    public class Pedido
    {
        [BindNever] // informa para o Id nao ser incluido no formulario
        public int PedidoId { get; set; }
        public List<PedidoDetalhe> PedidoItens { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o endereco")]
        [Display(Name = "Endereco")]
        [StringLength(100)]
        public string Endereco1 { get; set; }

        [Required(ErrorMessage = "Informe o complemento do endereço")]
        [Display(Name = "COmplemento")]
        [StringLength(100)]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telefone{ get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "O email nao possui um formato correto")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PedidoTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime PedidoEnviado { get; set; }
    }
}