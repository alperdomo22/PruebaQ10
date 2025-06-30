namespace Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public ICollection<Registration> Registrations { get; set; }

        public Student (
            string firstName,
            string lastName,
            string document,
            string email
        )
        {
            if (string.IsNullOrEmpty(firstName))
                throw new Exception("El nombre del estudiante es requerido");

            if (string.IsNullOrEmpty(lastName))
                throw new Exception("El apellido del estudiante es requerido");

            if (string.IsNullOrEmpty(document))
                throw new Exception("El documento del estudiante es requerido");

            if (string.IsNullOrEmpty(email))
                throw new Exception("El correo electronico del estudiante es requerido");

            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
        }
    }
}
