using apicolege.model;
using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicolege.Data.repositorio
{
    public class AsignaturaRepositorio :IAsignaturaRepositorio
    {
        private readonly MySQLConfiguration _ConnectionString;
        public AsignaturaRepositorio(MySQLConfiguration connectionString)
        {

            _ConnectionString = connectionString;

        }
        protected MySqlConnection dbConnection()

        {
            return new MySqlConnection(_ConnectionString.ConnectionString);
        }
        public  async Task<bool> DeletAsignatura(Asignatura Asignatura)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM  Asignatura WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new {Id = Asignatura.Id});
            return result    > 0;

        }

        public async Task<IEnumerable<Asignatura>> GetAllAsignatura()
        {
            var db = dbConnection();
            var sql = @"SELECT id,Nombre,Docente_idDocente,Curso_id
                       FROM Asignatura";
            return  await db.QueryAsync<Asignatura>(sql, new { });
        }

        public async Task<Asignatura> GetAsignaturaDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id,Nombre, Profesor, Estudiantes, Curso
                       FROM Asignatura 
                       WHERE id =@Id";

           return  await db.QueryFirstOrDefaultAsync<Asignatura>(sql, new { id =id});
        }

      

        public async Task<bool> InsertcAsignatura(Asignatura Asignatura)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO ASIGNATURA(Nombre,Profesor,Estudiantes,curso)
                       VALUES(@Nombre,@Profesor,@Estudiantes,@Curso)";

            var result = await db.ExecuteAsync(sql, new 
                       { Asignatura.Docente_idDocente, Asignatura.Curso_id,Asignatura.Nombre});
            return result > 0;
        }

        public async Task<bool> InsertcInscrito(Inscrito inscrito)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO inscrito(Asignatura_id,Estudiante_id)
                       VALUES(@Asignatura,@Estudiantes)";

            var result = await db.ExecuteAsync(sql, new
            { Asignatura=inscrito.Asignatura_id, Estudiantes = inscrito.Estudiante_id });
            return result > 0;
        }

        public async Task<bool> UpdateAsignatura(Asignatura asignatura)
        {
            var db = dbConnection();

            var sql = @"UPDATE ASIGNATURA
                       SET Nombre=@Nombre,
                           Docente_idDocente=@Docente,
                           Curso_id=@Curso
                           WHERE id =@Id";
               var result = await db.ExecuteAsync(sql,new 
               { Docente = asignatura.Docente_idDocente, Curso= asignatura.Curso_id,asignatura.Nombre,asignatura.Id });
            return result > 0;



        }

        public Task<Asignatura> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsignatura(Asignatura asignatura)
        {
            throw new NotImplementedException();
        }

        Task<object?> IAsignaturaRepositorio.GetAsignaturaDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
