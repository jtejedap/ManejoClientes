using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoClientes
{
    internal interface IClienteRepository
    {
        Cliente BuscarCliente(string criterio);  
        List<Cliente> BuscarTodos();
        bool ActualizarCliente(Cliente cliente); 
        bool AgregarCliente(Cliente cliente); 
        bool BorrarCliente(int clientId); 
    }
}
