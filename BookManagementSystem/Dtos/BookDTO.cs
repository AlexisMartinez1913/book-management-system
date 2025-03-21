namespace BookManagementSystem.Dtos
{
    public class BookDTO
    {
        //Dtos - clases simples para transferir datos y no exponer directamente
        //las entidades
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
    }
}
