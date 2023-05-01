using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoClientes
{
    internal class Direccion
    {       
        public int Id { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public string? Sector { get; set; }
        public string? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Pais { get; set; }
    }
}
