using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tienda_compu.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Marca { get; set; }
        public string Ram { get; set; }
        public string Almacenamiento { get; set; }
        public string Peso { get; set; }
        public decimal Precio { get; set; }
        public string Color { get; set; }
        public String Teclado { get; set; }
        public string TipoPantalla { get; set; }
        [DisplayName("URL de la imagen")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Debe agregar una imagen para el producto")]
        public string ImageUrl { get; set; }


        public int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }


        public virtual ICollection<Image> Images { get; set; }
    }
}