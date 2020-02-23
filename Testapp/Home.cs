using Paramore.Brighter;
using System;
using System.Windows.Forms;
using TestAppService.Commands;
using Microsoft.Extensions.Logging;
using Paramore.Darker;
using TestAppService.Querys;

namespace Testapp
{
    public partial class Home : Form
    {
        private readonly ILogger<Home> _logger;
        private readonly IAmACommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public Home(ILogger<Home> logger, IAmACommandProcessor commandProcessor, IQueryProcessor queryProcessor)
        {
            _logger = logger;
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            InitializeComponent();
        }

        private async void AddBookClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var book = new AddBookCommand()
                {
                    Id = new Guid(),
                    Author = textAuthor.Text,
                    Title = textTitle.Text
                };
                _logger.LogInformation($"Adding book {book}");
                await _commandProcessor.SendAsync(book).ConfigureAwait(true);
                textAuthor.Clear();
                textTitle.Clear();
            }
        }

        private async void SaveDocumentClick(object sender, EventArgs e)
        {
            var command = new CreateDocumentCommand()
            {
                Id = new Guid(),
                FilePath = @"D:\",
                DocumentName = "TestDocument.docx"
            };
            _logger.LogInformation($"saving document {command.DocumentName}");
            await _commandProcessor.SendAsync(command).ConfigureAwait(true);
        }

        private void textTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                e.Cancel = true;
                textTitle.Select(0, textTitle.Text.Length);
                titleErrorProvider.SetError(textTitle, "Title cannot be empty");
            }
        }

        private void textAuthor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textAuthor.Text))
            {
                e.Cancel = true;
                textTitle.Select(0, textAuthor.Text.Length);
                authorErrorProvider.SetError(textAuthor, "Author name cannot be empty");
            }
        }

        private async void getBookBtn_Click(object sender, EventArgs e)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetBookQuery {Id = 1}).ConfigureAwait(false);
            textTitle.Text = result;
        }
    }
}
