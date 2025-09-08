using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class RepresentanteFormCLS
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe de ser positivo")]
        public int Num_Empl { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;


        [Range(18, int.MaxValue, ErrorMessage = "Solo se pueden ingresar edades mayores o iguales a 18 años")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = null!;

        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "La fecha de contrato debe estar entre el 01/01/1900 y el 01/01/2100")]
        public DateTime FechaContrato { get; set; } = DateTime.Parse("31/12/1899")!;

        [Required(ErrorMessage = "La cuota es obligatoria")]
        [Range(1, 100, ErrorMessage = "Solo se pueden ingresar valores entre 1 y 100")]
        public int Cuota { get; set; }

        [Required(ErrorMessage = "Las ventas son obligatorias")]
        [Range(1, int.MaxValue, ErrorMessage = "Solo se pueden ingresar números positivos")]
        public int Ventas { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Debe de seleccionar una Sucursal")]
        public int idSucursal { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar un Director")]
        public int idDirector { get; set; }
        public RepresentanteFormCLS(){}
        
    }
}
