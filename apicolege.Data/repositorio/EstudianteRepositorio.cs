using apicolege.model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicolege.Data.repositorio
{
    public class EstudianteRepositorio : IEstudianteRepositorio
    {
        private readonly MySQLConfiguration _ConnectionString;
        public EstudianteRepositorio(MySQLConfiguration connectionString)
        {

            _ConnectionString = connectionString;

        }
        protected MySqlConnection dbConnection()

        {
            return new MySqlConnection(_ConnectionString.ConnectionString);
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudiante()
        {
            var db = dbConnection();
            var sql = @"SELECT id,Nombre
                       FROM Estudiante";
            return await db.QueryAsync<Estudiante>(sql, new { });
        }
   

        public async Task<Estudiante> GetEstudianteDetails(int id)
        {
                var db = dbConnection();

                var sql = @"SELECT id,Nombre
                       FROM Estudinte
                       WHERE id =@Id";

                return await db.QueryFirstOrDefaultAsync<Estudiante>(sql, new { id = id });
            }
    }
}
