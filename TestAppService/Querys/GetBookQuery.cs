using Paramore.Darker;

namespace TestAppService.Querys
{
    public class GetBookQuery : IQuery<string>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
