using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using TiendaApi.Datos;
using TiendaApi.Modelo;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class productoController:ControllerBase
    {
        //proceso get
        //async espera deacuerdo a tu net
        [HttpGet]
        public async Task <ActionResult<List<ModeloProductos>>> Get()
        {
            var funcion = new Dproductos();
            var lista = await funcion.MostrarProductos();
            return lista;
        }
        [HttpPost]
        public async Task Post([FromBody] ModeloProductos parametros)
        {
            var funcion = new Dproductos();
            await funcion.InsertaarProducto(parametros);
        }
        [HttpPut("{id}")]
       public async Task<ActionResult> put (int id,[FromBody] ModeloProductos parametros)
        {
            var funcion = new Dproductos();
            parametros.id = id;
            await funcion.editarProducto(parametros);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var funcion = new Dproductos();
            var parametros = new ModeloProductos();
            parametros.id = id;
            await funcion.eliminarProducto(parametros);
            return NoContent();
        }
    }
}
