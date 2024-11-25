namespace BooksStore.Core.Models
{
    public class Book
    {
        public const int TitleMaxVAlue = 250;
        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        
        public static(Book book, string Eror) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > TitleMaxVAlue)
            {
                error = "Title can not be Empty or longer than 250 symbols";
            }
            var book = new Book(id, title, description, price);
            return (book, error);
        }

    }
}
