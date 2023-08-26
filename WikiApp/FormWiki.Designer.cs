namespace WikiApp
{
    partial class FormWiki
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonSearch = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(46, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(47, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(47, 89);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(46, 122);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 27);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(385, 25);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 27);
            textBox5.TabIndex = 4;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(171, 29);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(72, 39);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(171, 76);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(72, 40);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(304, 339);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 40);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(410, 339);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 40);
            buttonLoad.TabIndex = 8;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(304, 25);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 27);
            buttonSearch.TabIndex = 9;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(304, 69);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(181, 264);
            listBox1.TabIndex = 10;
            // 
            // FormWiki
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(buttonSearch);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "FormWiki";
            Text = "WikiApp Version 1.2";
            Load += FormWiki_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button buttonAdd;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonLoad;
        private Button buttonSearch;
        private ListBox listBox1;
    }
}