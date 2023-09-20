using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicolege.model
{
   public class Asignatura
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int ? Docente_idDocente { get; set; }
        public  int ? Curso_id {  get; set; }
       

    }
}
