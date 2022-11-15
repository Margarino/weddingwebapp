using System;
using System.Collections.Generic;

#nullable disable

namespace weddingWebapp.Models
{
    public partial class Ordenregalo
    {
        public int IdOrdenRegalo { get; set; }
        public string Correo { get; set; }
        public string Nota { get; set; }
        public int MontoRegalo { get; set; }
    }
}
