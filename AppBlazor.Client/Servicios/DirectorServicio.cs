using AppBlazor.Entities;
using System.ComponentModel;
namespace AppBlazor.Client.Servicios
{
    public class DirectorServicio
    {
        private List<DirectorCLS> lista;
        public DirectorServicio()
        {
            lista = new List<DirectorCLS>();
            lista.Add(new DirectorCLS() { IDdirector = 1, Director = "Zuñiga" });
            lista.Add(new DirectorCLS() { IDdirector = 2, Director = "Azpiazu" });
        }

        public List<DirectorCLS> listarDirector()
        {
            return lista;
        }

        public int obteneridDirector(string sucursal)
        {
            var obj = lista.Where(p => p.Director == sucursal).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.IDdirector;
            }
        }

        public string obtenernombredirector(int id)
        {
            var obj = lista.Where(p => p.IDdirector == id).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.Director;
            }
        }
    }
}
