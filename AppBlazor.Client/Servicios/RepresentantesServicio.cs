using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBlazor.Entities;
namespace AppBlazor.Client.Servicios
{
    public static class RepresentantesServicio
    {
        public static List<RepresentanteFormCLS> lstRepresentantes = new();

        public static void AgregarLibro(RepresentanteFormCLS nuevoRepresentante)
        {
            lstRepresentantes.Add(nuevoRepresentante);
        }

        public static List<RepresentanteFormCLS> ObtenerLibros()
        {
            return lstRepresentantes;
        }
    }
}