using Paramore.Brighter;
using System.Threading;
using System.Threading.Tasks;
using TestAppService.Commands;
using TestAppService.Services;

namespace TestAppService.Handlers
{
    public class AddBookHandlerAsync : RequestHandlerAsync<AddBookCommand>
    {
        private readonly DataContext _dbContext;
            
        public AddBookHandlerAsync(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<AddBookCommand> HandleAsync(AddBookCommand command, CancellationToken cancellationToken = default)
        {
            await _dbContext.Books.AddAsync(new Models.Book { Author = command.Author, Title = command.Title });
            await _dbContext.SaveChangesAsync();
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
