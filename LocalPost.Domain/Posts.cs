namespace LocalPost.Domain
{
    public class Posts
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
