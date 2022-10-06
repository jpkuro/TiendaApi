namespace TiendaApi.Conexion
{
    public class ConexionBD
    {
        private string connectionstring = string.Empty;
        public ConexionBD()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionstring = builder.GetSection("ConnectionStrings:conexion").Value;
        }

        public string cadenaMySql()
        {
            return connectionstring;
        }
    }
}
