using AppBlazor.Entities;
using System.ComponentModel;
namespace AppBlazor.Client.Servicios
{
    public class RepresentantesServicio
    {
        private  List<RepresentanteFormCLS> lstRepresentantes =null!;

        public RepresentantesServicio()
        {
            lstRepresentantes = new List<RepresentanteFormCLS>();
            lstRepresentantes.Add(new RepresentanteFormCLS { Num_Empl = 1, Nombre = "Carlos", Edad = 18, Cargo = "Vendedor", FechaContrato = DateTime.Parse("10/06/2025"), Cuota = 18, Ventas = 23 });
            lstRepresentantes.Add(new RepresentanteFormCLS { Num_Empl = 2, Nombre = "Bryan", Edad = 19, Cargo = "Supervisor", FechaContrato = DateTime.Parse("11/05/2025"), Cuota = 9, Ventas = 10 });
        }

        public  List<RepresentanteFormCLS> ObtenerRepresentante()
        {
            return lstRepresentantes;
        }
        public List<RepresentanteFormCLS> Eliminar(int idrepresentante)
        {
            var listaqueda = lstRepresentantes.Where(p => p.Num_Empl != idrepresentante).ToList();
            lstRepresentantes = listaqueda;
            return listaqueda;
        }

        public  void AgregarRepresentante(RepresentanteFormCLS nuevoRepresentante)
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

        
        
        public RepresentanteFormCLS recuperaRepresentanteporID(int idrepresentante)
        {
            var obj = lstRepresentantes.Where(p => p.Num_Empl == idrepresentante).FirstOrDefault();
            if (obj != null)
            {
                return new RepresentanteFormCLS { Num_Empl = obj.Num_Empl, Nombre = obj.Nombre, Edad = obj.Edad, Cargo = obj.Cargo,
                    FechaContrato = obj.FechaContrato, Cuota = obj.Cuota, Ventas = obj.Ventas};
            }
            else
            {
                return new RepresentanteFormCLS();
            }
        }

        

        
    }
}