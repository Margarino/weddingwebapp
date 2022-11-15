using System;
using System.Collections.Generic;

#nullable disable

namespace weddingWebapp.Models
{
    public partial class Regalo
    {
        public int IdRegalo { get; set; }
        public string NombreRegalo { get; set; }
        public int CostoRegalo { get; set; }
        public string DescripcionRegalo { get; set; }
        public string Path { get; set; }
    }
}
