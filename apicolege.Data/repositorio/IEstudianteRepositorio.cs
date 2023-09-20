using apicolege.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicolege.Data.repositorio
{
     public interface IEstudianteRepositorio
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiante();
        Task<Estudiante> GetEstudianteDetails(int id);
    }
}
