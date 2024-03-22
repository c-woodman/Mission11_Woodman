namespace Mission11_Woodman.Models
{
    public interface IBookRepository
    {

        public IQueryable<Book> Books { get; }
    }
}
