using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClimaTempo.Models
{
    [Table("Cidade")]
    public class CidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public EstadoModel Estado { get; set; }
    }
}