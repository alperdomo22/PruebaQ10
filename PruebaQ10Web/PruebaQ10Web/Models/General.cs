namespace PruebaQ10Web.Models
{
    public class GeneralResponse<T>
    {
        public bool Success { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}
