using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Tienda_compu.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [DisplayName("Nombre categoria")]
        public string Nombre { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

        public virtual ICollection<Producto> Products { get; set; }
    }
}