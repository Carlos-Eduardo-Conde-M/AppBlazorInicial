using AppBlazor.Entities;
using System.Collections.Generic;
using System.ComponentModel;
namespace AppBlazor.Client.Servicios
{
    public class RepresentantesServicio
    {
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarbusqueda (string nombre)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombre);
            }
        }

        private  List<RepresentanteFormCLS> lstRepresentantes =null!;

        public RepresentantesServicio()
        {
            lstRepresentantes = new List<RepresentanteFormCLS>();
            lstRepresentantes.Add(new RepresentanteFormCLS { Num_Empl = 1, Nombre = "Carlos", Edad = 18, Cargo = "Vendedor",
                FechaContrato = DateTime.Parse("10/06/2025"), Cuota = 18, Ventas = 23,idSucursal=1,idDirector=1 });
            lstRepresentantes.Add(new RepresentanteFormCLS { Num_Empl = 2, Nombre = "Bryan", Edad = 19, Cargo = "Supervisor",
                FechaContrato = DateTime.Parse("11/05/2025"), Cuota = 9, Ventas = 10,idSucursal=2,idDirector=2 });
        }

        public  List<RepresentanteFormCLS> ObtenerRepresentante()
        {
            return lstRepresentantes;
        }

        public List<RepresentanteFormCLS> filtrarRepresenatntes(string nombre)
        {
            List<RepresentanteFormCLS> l = ObtenerRepresentante();
            if (nombre == null)
            {
                return l;
            }
            else
            {
                List<RepresentanteFormCLS> listafitrada = l.Where(p => p.Nombre.ToUpper().Contains(nombre.ToUpper())).ToList();
                return listafitrada;
            }
        }

        public List<RepresentanteFormCLS> Eliminar(int idrepresentante)
        {
            var listaqueda = lstRepresentantes.Where(p => p.Num_Empl != idrepresentante).ToList();
            lstRepresentantes = listaqueda;
            return listaqueda;
        }

        public  void AgregarRepresentante(RepresentanteFormCLS nuevoRepresentante)
        {
            int id = lstRepresentantes.Select(p => p.Num_Empl).Max() + 1;
            lstRepresentantes.Add(new RepresentanteFormCLS
            {
                Num_Empl = id,
                Nombre = nuevoRepresentante.Nombre,
                Edad = nuevoRepresentante.Edad,
                Cargo = nuevoRepresentante.Cargo,
                FechaContrato = nuevoRepresentante.FechaContrato,
                Cuota = nuevoRepresentante.Cuota,
                Ventas = nuevoRepresentante.Ventas,
                idSucursal= nuevoRepresentante.idSucursal,
                idDirector= nuevoRepresentante.idDirector
            });
        }
        public void ActualizarRepresentante(RepresentanteFormCLS nuevoRepresentante)
        {
            var obj = lstRepresentantes.Where(p => p.Num_Empl == nuevoRepresentante.Num_Empl).FirstOrDefault();
            if (obj != null)
            {
                obj.Nombre = nuevoRepresentante.Nombre;
                obj.Edad = nuevoRepresentante.Edad;
                obj.Cargo = nuevoRepresentante.Cargo;
                obj.FechaContrato = nuevoRepresentante.FechaContrato;
                obj.Cuota = nuevoRepresentante.Cuota;
                obj.Ventas = nuevoRepresentante.Ventas;
                obj.idSucursal = nuevoRepresentante.idSucursal;
                obj.idDirector= nuevoRepresentante.idDirector;
            }
        }



        public RepresentanteFormCLS recuperaRepresentanteporID(int idrepresentante)
        {
            var obj = lstRepresentantes.Where(p => p.Num_Empl == idrepresentante).FirstOrDefault();
            if (obj != null)
            {
                return new RepresentanteFormCLS { Num_Empl = obj.Num_Empl, Nombre = obj.Nombre, Edad = obj.Edad, Cargo = obj.Cargo,
                    FechaContrato = obj.FechaContrato, Cuota = obj.Cuota, Ventas = obj.Ventas , idSucursal = obj.idSucursal , idDirector = obj.idDirector};
            }
            else
            {
                return new RepresentanteFormCLS();
            }
        }

        

        

        
    }
}