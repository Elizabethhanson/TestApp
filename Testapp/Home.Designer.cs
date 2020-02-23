using System.Windows.Forms;

namespace Testapp
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textAuthor = new System.Windows.Forms.TextBox();
            this.titleErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.authorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.getBookBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.titleErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.authorErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 318);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save Document";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveDocumentClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(515, 214);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 59);
            this.button2.TabIndex = 0;
            this.button2.Text = "Add Book";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddBookClick);
            // 
            // textTitle
            // 
            this.titleErrorProvider.SetIconPadding(this.textTitle, 2);
            this.textTitle.Location = new System.Drawing.Point(143, 50);
            this.textTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(285, 27);
            this.textTitle.TabIndex = 1;
            this.textTitle.Validating += new System.ComponentModel.CancelEventHandler(this.textTitle_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author";
            // 
            // textAuthor
            // 
            this.authorErrorProvider.SetIconPadding(this.textAuthor, 2);
            this.textAuthor.Location = new System.Drawing.Point(143, 120);
            this.textAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textAuthor.Name = "textAuthor";
            this.textAuthor.Size = new System.Drawing.Size(285, 27);
            this.textAuthor.TabIndex = 1;
            this.textAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.textAuthor_Validating);
            // 
            // titleErrorProvider
            // 
            this.titleErrorProvider.ContainerControl = this;
            // 
            // authorErrorProvider
            // 
            this.authorErrorProvider.ContainerControl = this;
            // 
            // getBookBtn
            // 
            this.getBookBtn.Location = new System.Drawing.Point(326, 196);
            this.getBookBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getBookBtn.Name = "getBookBtn";
            this.getBookBtn.Size = new System.Drawing.Size(148, 59);
            this.getBookBtn.TabIndex = 3;
            this.getBookBtn.Text = "Get Book";
            this.getBookBtn.UseVisualStyleBackColor = true;
            this.getBookBtn.Click += new System.EventHandler(this.getBookBtn_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.getBookBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textAuthor);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Home";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.titleErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.authorErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textAuthor;
        private System.Windows.Forms.ErrorProvider titleErrorProvider;
        private System.Windows.Forms.ErrorProvider authorErrorProvider;
        private System.Windows.Forms.Button getBookBtn;
    }
}

