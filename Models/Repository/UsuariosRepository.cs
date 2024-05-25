using Dapper;

namespace MarquezBouzoDanielExamen1.Models.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly Conexion _conexion;

        public UsuariosRepository (Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<Usuarios> LoginAsync(Usuarios usuarios)
        {
            var query = "SELECT * FROM usuarios WHERE usuarios.correo_electronico = @email AND contrasena = @pass";
            var parameters = new DynamicParameters();
            parameters.Add("email", usuarios.correo_electronico, System.Data.DbType.String);
            parameters.Add("pass", usuarios.contrasena, System.Data.DbType.String);
            using (var conexion = _conexion.ObtenerConexion())
            {
                return await conexion.QuerySingleOrDefaultAsync<Usuarios>(query, parameters);
            }
            
        }

        public void Register(Usuarios usuarios)
        {
            var query = "INSERT INTO usuarios (nombre, correo_electronico, contrasena) VALUES (@nombre, @email, @contrasena)";
            var parameters = new DynamicParameters();
            parameters.Add("nombre", usuarios.nombre, System.Data.DbType.String);
            parameters.Add("email", usuarios.correo_electronico, System.Data.DbType.String);
            parameters.Add("contrasena", usuarios.contrasena, System.Data.DbType.String);

            using (var conexion = _conexion.ObtenerConexion())
            {
                conexion.Execute(query,parameters);
            }
        }
    }
}
