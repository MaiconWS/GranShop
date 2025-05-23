using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Estoque { get; set; }

        public decimal ValorCusto { get; set; }

        public decimal ValorVenda { get; set; }
        
        public Boolean Destaque { get; set; }
    }
}