using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities.ClienteCLS
{
    public class ClienteCLS
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe de ser positivo")]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "El NombreCliente es obligatorio")]
        public string NombreCliente { get; set; } = null!;

        [Required(ErrorMessage = "El IdRepresentante es obligatorio")]
        public int IdRepresentante { get; set; }

        [Required(ErrorMessage = "Las ventas son obligatorias")]
        [Range(1, int.MaxValue, ErrorMessage = "Solo se pueden ingresar números positivos")]
        public int LimiteCredito { get; set; }

    }
}
