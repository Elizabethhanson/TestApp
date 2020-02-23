using Paramore.Brighter;
using System;

namespace TestAppService.Commands
{
    public class AddBookCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
