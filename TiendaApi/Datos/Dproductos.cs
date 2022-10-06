using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using TiendaApi.Conexion;
using TiendaApi.Modelo;
namespace TiendaApi.Datos
{
    public class Dproductos
    {
        ConexionBD cn = new ConexionBD();
        public async Task <List<ModeloProductos>> MostrarProductos()
        {
            var lista = new List<ModeloProductos>();
            using (var sql = new MySqlConnection(cn.cadenaMySql()))
            {
                using (var cmd = new MySqlCommand("LISTARPRODUCTO", sql))
                {
                    //await llama o conecciones dependiendo del internet+}
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var modeloProductos = new ModeloProductos();
                            modeloProductos.id = (int)item["id"];
                            modeloProductos.descripcion = (string)item["descripcion"];
                            modeloProductos.precio = (string)item["precio"];
                            lista.Add(modeloProductos);
                        }
                    }

                }
            }
            return lista;
        }
        public async Task InsertaarProducto(ModeloProductos parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaMySql()))
            {
                using (var cmd = new MySqlCommand("INSERTARPROD", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prod", parametros.id);
                    cmd.Parameters.AddWithValue("des", parametros.descripcion);
                    cmd.Parameters.AddWithValue("pre", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task editarProducto(ModeloProductos parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaMySql()))
            {
                using (var cmd = new MySqlCommand("MODIFICARPROD", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prod", parametros.id);
                    cmd.Parameters.AddWithValue("des", parametros.descripcion);
                    cmd.Parameters.AddWithValue("pre", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task eliminarProducto(ModeloProductos parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaMySql()))
            {
                using (var cmd = new MySqlCommand("ELIMINARPROD", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prod", parametros.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
