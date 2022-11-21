using System;
using System.Collections.Generic;

#nullable disable

namespace weddingWebapp.DataAccess.DataObjects
{
    public partial class Regalo
    {
        public int Idregalo { get; set; }
        public string NombreRegalo { get; set; }
        public string NombreUsuario { get; set; }
        public int Monto { get; set; }
        public string Notaregalo { get; set; }
        public string Correo { get; set; }
    }
}
