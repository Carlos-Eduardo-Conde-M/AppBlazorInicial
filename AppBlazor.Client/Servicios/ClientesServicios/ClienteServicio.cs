using AppBlazor.Entities.ClienteCLS;
using AppBlazor.Entities.RepresentanteClS;
namespace AppBlazor.Client.Servicios.ClientesServicios
{
    public class ClienteServicio
    {
        private List<ClienteCLS> lstClientes = null!;
        public ClienteServicio()
        {
            lstClientes = new List<ClienteCLS>();
            lstClientes.Add(new ClienteCLS
            {
                CodigoCliente = 1,
                NombreCliente = "Juan Perez",
                IdRepresentante = 1,
                LimiteCredito = 5000
            });
            lstClientes.Add(new ClienteCLS
            {
                CodigoCliente = 2,
                NombreCliente = "Maria Lopez",
                IdRepresentante = 2,
                LimiteCredito = 10000
            });
        }

        public List<ClienteCLS> ObtenerClientes()
        {
            return lstClientes;
        }

        public List<ClienteCLS> EliminarClientes(int idCliente) 
        {
            var listaqueda = lstClientes.Where(p => p.CodigoCliente != idCliente).ToList();
            lstClientes = listaqueda;
            return listaqueda;
        }

        public void AgregarCliente(ClienteCLS nuevoCliente)
        {
            int id = lstClientes.Select(p => p.CodigoCliente).Max() + 1;
            lstClientes.Add(new ClienteCLS
            {
                CodigoCliente = nuevoCliente.CodigoCliente,
                NombreCliente = nuevoCliente.NombreCliente,
                IdRepresentante = nuevoCliente.IdRepresentante,
                LimiteCredito = nuevoCliente.LimiteCredito
            });
        }
        public void ActualizarCliente(ClienteCLS nuevoCliente)
        {
            var obj = lstClientes.Where(p => p.CodigoCliente == nuevoCliente.CodigoCliente).FirstOrDefault();
            if (obj != null)
            {
                obj.CodigoCliente = nuevoCliente.CodigoCliente;
                obj.NombreCliente = nuevoCliente.NombreCliente;
                obj.IdRepresentante = nuevoCliente.IdRepresentante;
                obj.LimiteCredito = nuevoCliente.LimiteCredito;
            }
        }

        public ClienteCLS recuperaClienteporID(int idCLiente)
        {
            var obj = lstClientes.Where(p => p.CodigoCliente == idCLiente).FirstOrDefault();
            if (obj != null)
            {
                return new ClienteCLS
                {
                    CodigoCliente = obj.CodigoCliente,
                    NombreCliente = obj.NombreCliente,
                    IdRepresentante = obj.IdRepresentante,
                    LimiteCredito = obj.LimiteCredito,
                    
                };
            }
            else
            {
                return new ClienteCLS();
            }
        }

        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarbusqueda(string nombre)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombre);
            }
        }
        public List<ClienteCLS> filtrarClientes(string nombre)
        {
            List<ClienteCLS> l = ObtenerClientes();
            if (nombre == null)
            {
                return l;
            }
            else
            {
                List<ClienteCLS> listafitrada = l.Where(p => p.NombreCliente.ToUpper().Contains(nombre.ToUpper())).ToList();
                return listafitrada;
            }
        }

    }
}
