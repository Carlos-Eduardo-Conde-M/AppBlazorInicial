using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBlazor.Entities;
namespace AppBlazor.Client.Servicios
{
    public static class RepresentantesServicio
    {
            public static List<RepresentanteFormCLS> lstRepresentantes = new() 
            {
                new RepresentanteFormCLS
    {
        Num_Empl = 1,
        Nombre = "Juan Pérez",
        Edad = 30,
        Cargo = "Vendedor",
        FechaContrato = new DateTime(2015, 5, 10),
        Cuota = 50,
        Ventas = 60
    },
    new RepresentanteFormCLS
    {
        Num_Empl = 2,
        Nombre = "María López",
        Edad = 28,
        Cargo = "Vendedor",
        FechaContrato = new DateTime(2018, 3, 22),
        Cuota = 40,
        Ventas = 45
    },
            };

        public static void AgregarLibro(RepresentanteFormCLS nuevoRepresentante)
        {
            lstRepresentantes.Add(nuevoRepresentante);
        }

        public static void EditarLibro(RepresentanteFormCLS nuevoRepresentante)
        {
            var representante = lstRepresentantes.FirstOrDefault(r => r.Num_Empl == nuevoRepresentante.Num_Empl);
            if (representante != null)
            {
                lstRepresentantes.Remove(representante);
                lstRepresentantes.Add(nuevoRepresentante);
            }
        }

        public static void EliminarRepresentante(int id)
        {
            var representante = lstRepresentantes.FirstOrDefault(r => r.Num_Empl == id);
            if (representante != null)
            {
                lstRepresentantes.Remove(representante);
            }
        }

        public static List<RepresentanteFormCLS> ObtenerLibros()
        {
            return lstRepresentantes;
        }
    }
}