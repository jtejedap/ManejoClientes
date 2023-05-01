using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoClientes.BL
{
    internal class ClientManagement
    {

        IClienteRepository GetClienteRepository()
        {
            return new DAL.ClienteSql();
        }
        public bool AgregarCliente(Cliente cliente)
        {
            IClienteRepository obj = GetClienteRepository();              //Persistencia en Base de Datos registro cliente
            obj.AgregarCliente(cliente);
            return true;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            IClienteRepository obj = GetClienteRepository();              //Actualización registro en Base de Datos
            obj.ActualizarCliente(cliente);
            return true;
        }

        public Cliente BuscarCliente(string criterio)
        {
            IClienteRepository obj = GetClienteRepository();              //Busqueda en Base de Datos con filtro busqueda
            return obj.BuscarCliente(criterio);
        }

        public List<Cliente> BuscarTodos()
        {
            IClienteRepository obj = GetClienteRepository();              //Busqueda en Base de Datos todos los registros
            return obj.BuscarTodos();
        }

        public bool BorrarCliente(int clientId)
        {
            IClienteRepository obj = GetClienteRepository();              //Desactivación cliente en Base de Datos
            obj.BorrarCliente(clientId);
            return true;
        }
    }
}
