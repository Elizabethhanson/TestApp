using Paramore.Brighter;
using System;

namespace TestAppService.Commands
{
    public class CreateDocumentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string DocumentName { get; set; }
    }
}
