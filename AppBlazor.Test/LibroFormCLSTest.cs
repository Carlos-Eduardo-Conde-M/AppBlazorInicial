using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;
namespace AppBlazor.Test
    
{
    public class LibroFormCLSTest
    {
        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo,null,null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;

        }
        [Fact]
        public void ValidacionDebeFallarCuandoMetodosVacios()
        {
            var libro = new LibroFormCLS();
            var errores = ValidarModelo(libro);

            Assert.Contains(errores,e=> e.ErrorMessage!.Contains("El id es requerido") ||
            e.ErrorMessage!.Contains("El valor debe de ser positivo"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El titulo es requerido"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El resumen es requerido"));
        }
        [Fact]
        public void ValidacionDebePasarConDatosCorrectos()
        {
            var libro = new LibroFormCLS
            {
                idLibro=1,
                titulo="libro de prueba",
                resumen="este es el resumen del libro de prueba"
            };
            var errores= ValidarModelo(libro);

            Assert.Empty(errores);
        }
    }
}