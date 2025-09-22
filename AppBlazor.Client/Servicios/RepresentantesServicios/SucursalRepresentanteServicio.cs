using AppBlazor.Entities.RepresentanteClS;
using System.ComponentModel;
namespace AppBlazor.Client.Servicios.RepresentantesSrevicios
{
    public class SucursalRepresentanteServicio
    {
        private List<SucursalRepresentanteCLS> lista;
        public SucursalRepresentanteServicio()
        {
            lista = new List<SucursalRepresentanteCLS>();
            lista.Add(new SucursalRepresentanteCLS() { idSucursal = 1, surcursal = "La Paz" });
            lista.Add(new SucursalRepresentanteCLS() { idSucursal = 2, surcursal = "Cochabamba" });
            lista.Add(new SucursalRepresentanteCLS() { idSucursal = 3, surcursal = "Santa Cruz" });
        }

        public List<SucursalRepresentanteCLS> listarSucursales()
        {
            return lista;
        }

        public int obteneridSucursal(string sucursal)
        {
            var obj = lista.Where(p => p.surcursal == sucursal).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idSucursal;
            }
        }

        public string obtenernombreSucursal(int id)
        {
            var obj = lista.Where(p => p.idSucursal == id).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.surcursal;
            }
        }

    }
}
