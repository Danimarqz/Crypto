using Dapper;

namespace MarquezBouzoDanielExamen1.Models.Repository
{
    public class CriptomonedasRepository : ICriptomonedasRepository
    {
        private readonly Conexion _conexion;

        public CriptomonedasRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Criptomonedas>> GetAll()
        {
            var query = "SELECT * FROM Criptomonedas";
            using (var connection = _conexion.ObtenerConexion())
            {
                var Criptomonedas = await connection.QueryAsync<Criptomonedas>(query);
                return Criptomonedas.ToList();
            }
        }

        public async Task<Criptomonedas> GetById(int id)
        {
            var query = $"SELECT * FROM Criptomonedas WHERE Criptomonedas.id = {id}";
            using (var connection = _conexion.ObtenerConexion())
            {
                var producto = await connection.QuerySingleOrDefaultAsync<Criptomonedas>(query, new { id });
                return producto;
            }
        }

        public void Save(Criptomonedas Criptomonedas)
        {
            var query = "INSERT INTO criptomonedas (nombre, descripcion, simbolo) VALUES (@nombre, @descripcion, @simbolo)";
            var parameters = new DynamicParameters();
            parameters.Add("nombre", Criptomonedas.nombre, System.Data.DbType.String);
            parameters.Add("descripcion", Criptomonedas.descripcion, System.Data.DbType.String);
            parameters.Add("simbolo", Criptomonedas.simbolo, System.Data.DbType.String);

            using (var conexion = _conexion.ObtenerConexion())
            {
                conexion.Execute(query, parameters);
            }
        }
        public void Delete(Criptomonedas c)
        {
            var query = $"DELETE FROM criptomonedas WHERE criptomonedas.id = {c.id}";
            using ( var conexion = _conexion.ObtenerConexion())
            {
                conexion.Execute(query);
            }
        }

        public async Task Edit(Criptomonedas c)
        {
            
            var query = "UPDATE criptomonedas SET descripcion = @descripcion, simbolo = @simbolo WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("descripcion", c.descripcion, System.Data.DbType.String);
            parameters.Add("simbolo", c.simbolo, System.Data.DbType.String);
            parameters.Add("id", c.id, System.Data.DbType.Int32);
            using ( var conexion = _conexion.ObtenerConexion())
            {
                await conexion.ExecuteAsync(query, parameters);
            }
        }
    }
}
