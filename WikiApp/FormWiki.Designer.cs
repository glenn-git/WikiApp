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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWiki));
            columnHeaderDefinition = new ColumnHeader();
            textBoxName = new TextBox();
            textBoxDefinition = new TextBox();
            textBoxSearch = new TextBox();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonSearch = new Button();
            buttonEdit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxStructure = new ComboBox();
            comboBoxCategory = new ComboBox();
            listViewArray = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderCategory = new ColumnHeader();
            columnHeaderStructure = new ColumnHeader();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolTip1 = new ToolTip(components);
            buttonReset = new Button();
            groupBoxData = new GroupBox();
            statusStrip1.SuspendLayout();
            groupBoxData.SuspendLayout();
            SuspendLayout();
            // 
            // columnHeaderDefinition
            // 
            columnHeaderDefinition.Text = "Definition";
            columnHeaderDefinition.Width = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(6, 52);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(263, 27);
            textBoxName.TabIndex = 0;
            textBoxName.TextChanged += textBoxName_TextChanged;
            textBoxName.MouseDoubleClick += textBoxName_MouseDoubleClick;
            // 
            // textBoxDefinition
            // 
            textBoxDefinition.Location = new Point(6, 215);
            textBoxDefinition.Multiline = true;
            textBoxDefinition.Name = "textBoxDefinition";
            textBoxDefinition.Size = new Size(263, 112);
            textBoxDefinition.TabIndex = 3;
            textBoxDefinition.TextChanged += textBoxDefinition_TextChanged;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(395, 48);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search";
            textBoxSearch.Size = new Size(288, 27);
            textBoxSearch.TabIndex = 4;
            textBoxSearch.MouseDoubleClick += textBoxSearch_MouseDoubleClick;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(275, 47);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(72, 39);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.MouseClick += buttonAdd_MouseClick;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(275, 98);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(72, 40);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.MouseClick += buttonDelete_MouseClick;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(192, 255, 192);
            buttonSave.Location = new Point(452, 363);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 40);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.MouseClick += buttonSave_MouseClick;
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.FromArgb(255, 192, 192);
            buttonLoad.Location = new Point(371, 363);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 40);
            buttonLoad.TabIndex = 8;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.MouseClick += buttonLoad_MouseClick;
            // 
            // buttonSearch
            // 
            buttonSearch.Image = (Image)resources.GetObject("buttonSearch.Image");
            buttonSearch.Location = new Point(371, 48);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(27, 27);
            buttonSearch.TabIndex = 9;
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.MouseClick += buttonSearch_MouseClick;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(275, 150);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(72, 40);
            buttonEdit.TabIndex = 11;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.MouseClick += buttonEdit_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 12;
            label1.Text = "Data Structure Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 82);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 13;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 141);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 14;
            label3.Text = "Structure";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(6, 192);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 15;
            label4.Text = "Definition";
            // 
            // comboBoxStructure
            // 
            comboBoxStructure.FormattingEnabled = true;
            comboBoxStructure.Items.AddRange(new object[] { "Linear", "Non-Linear" });
            comboBoxStructure.Location = new Point(6, 161);
            comboBoxStructure.Name = "comboBoxStructure";
            comboBoxStructure.Size = new Size(263, 28);
            comboBoxStructure.TabIndex = 18;
            comboBoxStructure.TextChanged += comboBoxStructure_TextChanged;
            comboBoxStructure.MouseClick += comboBoxStructure_MouseClick;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Items.AddRange(new object[] { "Abstract", "Array", "Graph", "Hash", "List", "Tree" });
            comboBoxCategory.Location = new Point(6, 110);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(263, 28);
            comboBoxCategory.TabIndex = 19;
            comboBoxCategory.TextChanged += comboBoxCategory_TextChanged;
            comboBoxCategory.MouseClick += comboBoxCategory_MouseClick;
            // 
            // listViewArray
            // 
            listViewArray.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderCategory, columnHeaderStructure, columnHeaderDefinition });
            listViewArray.FullRowSelect = true;
            listViewArray.Location = new Point(371, 81);
            listViewArray.Name = "listViewArray";
            listViewArray.Size = new Size(312, 264);
            listViewArray.TabIndex = 20;
            listViewArray.UseCompatibleStateImageBehavior = false;
            listViewArray.View = View.Details;
            listViewArray.SelectedIndexChanged += listViewArray_SelectedIndexChanged;
            listViewArray.MouseClick += listViewArray_MouseClick;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 160;
            // 
            // columnHeaderCategory
            // 
            columnHeaderCategory.Text = "Category";
            columnHeaderCategory.Width = 80;
            // 
            // columnHeaderStructure
            // 
            columnHeaderStructure.Text = "Structure";
            columnHeaderStructure.Width = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 471);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(754, 25);
            statusStrip1.TabIndex = 21;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(199, 20);
            toolStripStatusLabel1.Text = "Thank you for using WikiApp";
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(533, 362);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(75, 40);
            buttonReset.TabIndex = 22;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.MouseClick += buttonReset_MouseClick;
            // 
            // groupBoxData
            // 
            groupBoxData.Controls.Add(label1);
            groupBoxData.Controls.Add(textBoxName);
            groupBoxData.Controls.Add(label2);
            groupBoxData.Controls.Add(comboBoxCategory);
            groupBoxData.Controls.Add(buttonEdit);
            groupBoxData.Controls.Add(label4);
            groupBoxData.Controls.Add(comboBoxStructure);
            groupBoxData.Controls.Add(label3);
            groupBoxData.Controls.Add(buttonDelete);
            groupBoxData.Controls.Add(textBoxDefinition);
            groupBoxData.Controls.Add(buttonAdd);
            groupBoxData.Location = new Point(12, 12);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(353, 333);
            groupBoxData.TabIndex = 23;
            groupBoxData.TabStop = false;
            // 
            // FormWiki
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 496);
            Controls.Add(groupBoxData);
            Controls.Add(buttonReset);
            Controls.Add(statusStrip1);
            Controls.Add(listViewArray);
            Controls.Add(buttonSearch);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(textBoxSearch);
            Name = "FormWiki";
            Text = "WikiApp Version 1.3";
            FormClosing += FormWiki_FormClosing;
            Load += FormWiki_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxDefinition;
        private TextBox textBoxSearch;
        private Button buttonAdd;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonLoad;
        private Button buttonSearch;
        private Button buttonEdit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxStructure;
        private ComboBox comboBoxCategory;
        private ListView listViewArray;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderCategory;
        private ColumnHeader columnHeaderStructure;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ColumnHeader columnHeaderDefinition;
        private ToolTip toolTip1;
        private Button buttonReset;
        private GroupBox groupBoxData;
    }
}