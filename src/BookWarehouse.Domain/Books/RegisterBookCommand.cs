using System;
using BookWarehouse.Domain.SharedKernel;
using CSharpFunctionalExtensions;

namespace BookWarehouse.Domain.Books
{
    public class RegisterBookCommand : ICommand
    {
        public string ISBN { get; }

        public string Title { get; }

        public string Author { get; }

        public decimal Weight { get; }

        public RegisterBookCommand(string isbn, string title, string author, decimal weight)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Weight = weight;
        }
    }

    internal sealed class RegisterBookCommandHandler : ICommandHandler<RegisterBookCommand>
    {
        private readonly IBookRepository _repository;

        public RegisterBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(RegisterBookCommand command)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                ISBN = command.ISBN,
                Author = command.Author,
                Title = command.Title,
                Weight = command.Weight
            };

            _repository.Insert(book);

            return Result.Ok(book);
        }
    }
}
