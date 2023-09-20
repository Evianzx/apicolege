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
    public class DocenteRepositorio : IDocenteRepositorio
    {
        private readonly MySQLConfiguration _ConnectionString;
        public DocenteRepositorio(MySQLConfiguration connectionString)
        {

            _ConnectionString = connectionString;

        }
        protected MySqlConnection dbConnection()

        {
            return new MySqlConnection(_ConnectionString.ConnectionString);
        }

        public async Task<IEnumerable<Docente>> GetAllDocente()
        {
            var db = dbConnection();
            var sql = @"SELECT id,Nombre
                       FROM Docente";
            return await db.QueryAsync<Docente>(sql, new { });
        }


        public async Task<Docente> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id,Nombre
                       FROM Docente
                       WHERE id =@Id";

            return await db.QueryFirstOrDefaultAsync<Docente>(sql, new { id = id });
        }

    }
}
