using System.Reflection.Metadata;

namespace Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
        public ICollection<Registration> Registrations { get; set; }

        public Subject(
            string name,
            string code,
            int credits
        )
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("El nombre de la materia es requerido");

            if (string.IsNullOrEmpty(code))
                throw new Exception("El codigo de la materia es requerido");

            if (credits < 1)
                throw new Exception("Los creditos de la materia son requeridos");

            Name = name;
            Code = code;
            Credits = credits;
        }
    }
}
