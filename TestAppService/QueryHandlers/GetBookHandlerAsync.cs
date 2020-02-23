using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;
using TestAppService.Commands;
using TestAppService.Querys;
using TestAppService.Services;

namespace TestAppService.QueryHandlers
{
    public class GetBookHandlerAsync : QueryHandlerAsync<GetBookQuery, string>
    {
        private readonly DataContext _dbContext;
            
        public GetBookHandlerAsync(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<string> ExecuteAsync(GetBookQuery query, CancellationToken cancellationToken = default)
        {
            var book = await _dbContext.Books.Where(x => x.BookId == query.Id)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);
            return book.Title;
        }
    }
}
