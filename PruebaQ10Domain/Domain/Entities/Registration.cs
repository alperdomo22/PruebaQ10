using System.Reflection.Metadata;

namespace Domain.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public Registration(
            string description,
            int studentId,
            int subjectId
        )
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("La descripcion de la inscripcion de la materia es requerida");

            if (studentId < 1)
                throw new Exception("El estudiante al que se le inscribira la materia es obligatorio");

            if (subjectId < 1)
                throw new Exception("La materia que se inscribira es obligatoria");

            Description = description;
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
