using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ManejoClientes.DAL
{
    internal class ClienteSql : IClienteRepository
    {
        private SqlConnection _connection;
        private void connection()
        {
            string connectionstring = "Server=myServerName\\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;";
            _connection = new SqlConnection(connectionstring);
        }

        public bool AgregarCliente(Cliente cliente)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AgregarCliente",_connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre",cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@correo", cliente.Correo);
            cmd.Parameters.AddWithValue("@empresa", cliente.Empresa);

            _connection.Open();
            int clientid = Convert.ToInt32(cmd.ExecuteScalar());

            foreach(var addr in cliente.Direccion)
            {
                this.AgregarDireccion(addr, clientid);
            }
            return true;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ActualizarCliente", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@correo", cliente.Correo);
            cmd.Parameters.AddWithValue("@empresa", cliente.Empresa);

            _connection.Open();
            
            foreach (var addr in cliente.Direccion)
            {
                this.ActualizarDireccion(addr, cliente.Id, addr.Id);
            }
            return true;
        }

        public Cliente BuscarCliente(string criterio)
        {
            connection();
            SqlCommand cmd = new SqlCommand("BuscarCliente", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@criterio", criterio);
            _connection.Open();
            cmd.ExecuteNonQuery();
            return new Cliente();
            _connection.Close();
            
        }

        public List<Cliente> BuscarTodos()
        {
            connection();
            SqlCommand cmd = new SqlCommand("BuscarTodos", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            cmd.ExecuteNonQuery();
            return new List<Cliente>();
            _connection.Close();

        }

        public bool BorrarCliente(int clientId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("BorrarCliente", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientid", clientId);
            
            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        private bool AgregarDireccion(Direccion direccion, int idcliente)
        {            
            connection();
            SqlCommand cmd = new SqlCommand("AgregarDireccion", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", idcliente);
            cmd.Parameters.AddWithValue("@calle", direccion.Calle);
            cmd.Parameters.AddWithValue("@numero", direccion.Numero);
            cmd.Parameters.AddWithValue("@sector", direccion.Sector);
            cmd.Parameters.AddWithValue("@ciudad", direccion.Ciudad);
            cmd.Parameters.AddWithValue("@codigopostal", direccion.CodigoPostal);
            cmd.Parameters.AddWithValue("@pais", direccion.Pais);
            cmd.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        private bool ActualizarDireccion(Direccion direccion, int idcliente, int idaddr)
        {
            connection();
            SqlCommand cmd = new SqlCommand("ActualizarDireccion", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", idcliente);
            cmd.Parameters.AddWithValue("@idcliente", idaddr);
            cmd.Parameters.AddWithValue("@calle", direccion.Calle);
            cmd.Parameters.AddWithValue("@numero", direccion.Numero);
            cmd.Parameters.AddWithValue("@sector", direccion.Sector);
            cmd.Parameters.AddWithValue("@ciudad", direccion.Ciudad);
            cmd.Parameters.AddWithValue("@codigopostal", direccion.CodigoPostal);
            cmd.Parameters.AddWithValue("@pais", direccion.Pais);
            cmd.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
    }
}
