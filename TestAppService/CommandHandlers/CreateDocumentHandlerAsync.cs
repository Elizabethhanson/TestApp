using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Paramore.Brighter;
using System.Threading;
using System.Threading.Tasks;
using TestAppService.Commands;

namespace TestAppService.Handlers
{
    public class CreateDocumentHandlerAsync : RequestHandlerAsync<CreateDocumentCommand>
    {
        public CreateDocumentHandlerAsync()
        {
        }

        public override async Task<CreateDocumentCommand> HandleAsync(CreateDocumentCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var fileName = command.FilePath + command.DocumentName;
            using (WordprocessingDocument wordDocument =
                    WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("Create text in body - CreateWordprocessingDocument"));
            }
            return await base.HandleAsync(command);
        }
    }
}
