namespace PruebaQ10Web.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
    }

    public class SubjectRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
    }
}
