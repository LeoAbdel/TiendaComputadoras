using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tienda_compu.Models
{
    public class Image
    {

        public int ImageId { get; set; }
        [StringLength(255)]
        public string ImageName { get; set; }
        public FileType FileType { get; set; }
        public int ProductId { get; set; }
        public virtual Producto Product { get; set; }

    }
}