using AppBlazor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Test
{
    public class RepresentanteTest
    {
        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;

        }
        [Fact]
        public void ValidacionDebeFallarCuandoMetodosVacios()
        {
            var representante = new RepresentanteFormCLS();
            var errores = ValidarModelo(representante);


            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El id es obligatorio") ||
            e.ErrorMessage!.Contains("El valor debe de ser positivo"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El nombre es obligatorio"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("Solo se pueden ingresar edades mayores o iguales a 18 años"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El cargo es obligatorio"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La fecha de contrato debe estar entre el 01/01/1900 y el 01/01/2100"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La cuota es obligatoria") || e.ErrorMessage!.Contains("Solo se pueden ingresar valores entre 1 y 100"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("Las ventas son obligatorias") || e.ErrorMessage!.Contains("Solo se pueden ingresar números positivos"));

        }
        [Fact]
        public void ValidacionDebePasarConDatosCorrectos()
        {
            var representante = new RepresentanteFormCLS
            {
                Num_Empl = 1,
                Nombre = "libro de prueba",
                Edad = 19,
                Cargo = "Representante",
                FechaContrato = DateTime.Parse("01/01/2000"),
                Cuota = 1,
                Ventas = 1
            };
            var errores = ValidarModelo(representante);

            Assert.Empty(errores);
        }
    }
}
