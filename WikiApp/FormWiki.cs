using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//Glenn M122777
//18/8/2023
namespace WikiApp
{
    public partial class FormWiki : Form
    {
        public FormWiki()
        {
            InitializeComponent();
            InitializeArray(arrayRecord);
            toolTip1.SetToolTip(textBoxName, "Double click to clear textboxes");
            toolTip1.SetToolTip(textBoxSearch, "Double click to clear textboxes");
            toolStripStatusLabel1.Text = "Thank you for using " + this.Text + ". Welcome!";
        }
        #region Global 2D string array
        /// <summary>
        /// 9.1 Create a global 2D string array, use static variables for the dimensions (row = 12, column = 4)
        /// </summary>
        /// <param name="max">Max number of records</param>
        /// <param name="attributes">name, category, structure, definition fields</param>
        /// <param name="arrayRecord">2D arrays indexed by two subscripts. ? is nullable reference</param>
        /// <param name="ptr">array pointer for next empty element because array is filled with "~"</param>
        /// <param name="charLimit">for definition</param>
        /// <param name="fileName">WikiApp.Definitions.dat is recommended for easier maintenance / conflict with other similar projects</param>
        /// <param name="stopwatch">to measure time</param>
        /// <remarks>
        /// Recommended to use PascalCasing and separate namespace components with periods. e.g. Microsoft.Office.PowerPoint
        /// PascalCase for all identifiers except compound words and parameters.
        /// </remarks>
        static int max = 12;
        static int attributes = 4;
        string[,] arrayRecord = new string[max, attributes];
        int ptr;
        int charLimit = 150;
        const string fileName = "definitions.dat";
        Stopwatch stopwatch = new Stopwatch(); // topwatch to measure time
        //Initialise array method
        private void InitializeArray(object[,] array)
        {
            ptr = 0; //reset array pointer
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < attributes; j++)
                {
                    array[i, j] = "~";
                }
            }
        }
        #endregion
        #region ADD button
        /// <summary>
        /// 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        /// </summary>
        private void buttonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            AddRecord();
        }
        private void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                toolStripStatusLabel1.Text = "Please enter name";
                ChangeControlColour(1, textBoxName);
                return;
            }
            if (textBoxName.Text == "~")
            {
                toolStripStatusLabel1.Text = "Please enter proper value";
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxCategory.Text))
            {
                toolStripStatusLabel1.Text = "Please enter category";
                ChangeControlColour(1, comboBoxCategory);
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxStructure.Text))
            {
                toolStripStatusLabel1.Text = "Please enter structure";
                ChangeControlColour(1, comboBoxStructure);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxDefinition.Text))
            {
                toolStripStatusLabel1.Text = "Please enter definition";
                ChangeControlColour(1, textBoxDefinition);
                return;
            }
            //if else for all textboxes to be filled
            if (!string.IsNullOrWhiteSpace(textBoxName.Text) &&
                !string.IsNullOrWhiteSpace(comboBoxCategory.Text) &&
                !string.IsNullOrWhiteSpace(comboBoxStructure.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDefinition.Text) && ptr < max)
            {
                string str = textBoxName.Text.Trim();
                //Data Structure Name
                string name = char.ToUpper(str[0]) + str.Substring(1);
                arrayRecord[ptr, 0] = name;
                //Category
                str = comboBoxCategory.Text.Trim();
                string category = char.ToUpper(str[0]) + str.Substring(1);
                arrayRecord[ptr, 1] = category;
                //Structure
                str = comboBoxStructure.Text.Trim();
                string structure = char.ToUpper(str[0]) + str.Substring(1);
                arrayRecord[ptr, 2] = structure;
                //Definition
                str = textBoxDefinition.Text.Trim();
                string definition = char.ToUpper(str[0]) + str.Substring(1);
                arrayRecord[ptr, 3] = definition;
                ptr++; //for sortbubble
                ClearAllTextBoxes();
                SortBubble(arrayRecord);
                DisplayArray(arrayRecord, listViewArray);
                toolStripStatusLabel1.Text = name + " is added to listView";
            }
            else if (ptr >= max)
            {
                toolStripStatusLabel1.Text = "Max Array size reached";
            }
            else
            {
                toolStripStatusLabel1.Text = "Ensure all textboxes properly filled";
            }
            ChangeControlColour(default, textBoxName);
            ChangeControlColour(default, comboBoxCategory);
            ChangeControlColour(default, comboBoxStructure);
            ChangeControlColour(default, textBoxDefinition);
        }
        // method to change text box colours. Receives paramater from method call (integer)
        private void ChangeControlColour(int colour, Control control)
        {
            if (control != null)
            {
                control.ForeColor = Color.Black;
                switch (colour)
                {
                    //case 0: control.BackColor = default(Color); break; //if case 0 is red, default stay red?
                    case 1: control.BackColor = Color.Red; break;
                    case 2: control.BackColor = Color.Orange; break;
                    case 3: control.BackColor = Color.Yellow; break;
                    case 4: control.BackColor = Color.Green; break;
                    case 5:
                        control.BackColor = Color.Blue;
                        control.ForeColor = Color.White; break;
                    case 6:
                        control.BackColor = Color.Indigo;
                        control.ForeColor = Color.White; break;
                    case 7: control.BackColor = Color.Violet; break;
                    default: control.BackColor = default(Color); break;
                }
            }
        }
        #endregion
        #region EDIT button
        /// <summary>
        /// 9.3 Create an EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        private void buttonEdit_MouseClick(object sender, MouseEventArgs e)
        {

            if (listViewArray.SelectedItems.Count == 0)
            {
                toolStripStatusLabel1.Text = "Please select from the list first to edit";
            }
            else
            {
                if (textBoxName.Text.Trim() != "~")
                {
                    int index = listViewArray.SelectedIndices[0];
                    EditArrayElement(arrayRecord, index);
                    //ClearAllTextBoxes();
                    SortBubble(arrayRecord);
                    DisplayArray(arrayRecord, listViewArray);
                    toolStripStatusLabel1.Text = $"{textBoxName.Text} edited successfully";
                }
                else
                    toolStripStatusLabel1.Text = "Please enter proper value";
            }
        }
        private void EditArrayElement(string[,] array, int index)
        {
            array[index, 0] = textBoxName.Text;
            array[index, 1] = comboBoxCategory.Text;
            array[index, 2] = comboBoxStructure.Text;
            array[index, 3] = textBoxDefinition.Text;
        }
        #endregion
        #region DELETE button
        /// <summary>
        /// 9.4 Create a DELETE button that removes all the information from a single entry of the array;
        /// the user must be prompted before the final deletion occurs  
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        private void buttonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewArray.SelectedItems.Count == 0)
            {
                toolStripStatusLabel1.Text = "Please select from the list first to delete";
            }
            else
            {
                int index = listViewArray.SelectedIndices[0];
                //listViewArray.Items[index].Selected = true;
                string name = listViewArray.Items[index].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //DeleteArrayElement(arrayRecord, index);
                    //int index = listViewArray.SelectedIndices[0];
                    //create new array to hold sorted values without deleted index.
                    string[,] newArray = new string[max, attributes];
                    InitializeArray(newArray);
                    int newPtr = 0; //new array index
                                    // Iterate through the items in the ListView, excluding the selected index
                                    //for (int i = 0; i < listViewArray.Items.Count; i++)
                    foreach (ListViewItem listViewItem in listViewArray.Items)
                    {
                        //if (i != selectedIndex)
                        if (listViewItem.Index != index)
                        {
                            //ListViewItem listViewItem = listViewArray.Items[i];
                            newArray[newPtr, 0] = listViewItem.Text;
                            newArray[newPtr, 1] = listViewItem.SubItems[1].Text;
                            newArray[newPtr, 2] = listViewItem.SubItems[2].Text;
                            newArray[newPtr, 3] = listViewItem.SubItems[3].Text;
                            newPtr++;
                        }
                    }
                    arrayRecord = newArray;
                    ClearAllTextBoxes();
                    //SortBubble(arrayRecord); //already sorted
                    DisplayArray(arrayRecord, listViewArray);
                    toolStripStatusLabel1.Text = name + " is deleted";
                }
                else if (result == DialogResult.No)
                {
                    //close dialog, do nothing
                }
            }
        }
        //old delete method. has error? wrong index due to display / sort? not sure how to fix.
        private void DeleteArrayElement(string[,] array, int index)
        {
            //int index = listViewArray.SelectedIndices[0];
            //create new array to hold sorted values without deleted index.
            string[,] newArray = new string[max, attributes];
            InitializeArray(newArray);
            int newPtr = 0; //new array index
                            // Iterate through the items in the ListView, excluding the selected index
                            //for (int i = 0; i < listViewArray.Items.Count; i++)
            foreach (ListViewItem listViewItem in listViewArray.Items)
            {
                //if (i != selectedIndex)
                if (listViewItem.Index != index)
                {
                    //ListViewItem listViewItem = listViewArray.Items[i];
                    newArray[newPtr, 0] = listViewItem.Text;
                    newArray[newPtr, 1] = listViewItem.SubItems[1].Text;
                    newArray[newPtr, 2] = listViewItem.SubItems[2].Text;
                    newArray[newPtr, 3] = listViewItem.SubItems[3].Text;
                    newPtr++;
                }
            }
            array = newArray;
            ClearAllTextBoxes();
            //SortBubble(arrayRecord); //already sorted
            DisplayArray(arrayRecord, listViewArray);
            toolStripStatusLabel1.Text = index + " is deleted";
        }
        #endregion
        #region CLEAR method
        /// <summary>
        /// 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        /// </summary>
        private void ClearAllTextBoxes()
        {
            textBoxName.Clear();
            comboBoxCategory.ResetText();
            comboBoxStructure.ResetText();
            textBoxDefinition.Clear();
            textBoxSearch.Clear();
        }
        //Mouse Double Click events
        private void textBoxSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearAllTextBoxes();
        }

        private void textBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearAllTextBoxes();
            //textBoxName.Text = "";
            //comboBoxCategory.Text = "";
            //comboBoxStructure.Text = "";
            //textBoxDefinition.Text = "";
        }
        #endregion
        #region SORT method
        /// <summary>
        /// 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending,
        /// ensure you use a separate swap method that passes the array element to be swapped
        /// (do not use any built-in array methods)
        /// </summary>
        /// <param name="array"></param>
        private void SortBubble(string[,] array)
        {
            for (int x = 0; x < ptr; x++)
            {
                for (int y = 0; y < ptr - 1; y++)
                {
                    //if name value less than y, swap row
                    if (array[x, 0].CompareTo(array[y, 0]) < 0)
                    {
                        SwapElements(array, x, y);
                    }
                }
            }
        }
        //SwapElements method
        private void SwapElements(string[,] array, int a, int b)
        {
            //For a single-dimensional array, Length == GetLength(0), same value as .Length
            //For a two - dimensional array, Length == GetLength(0) * GetLength(1)
            for (int x = 0; x < array.GetLength(1); x++)
            {
                string temp = array[a, x];
                array[a, x] = array[b, x];
                array[b, x] = temp;
            }
        }
        #endregion
        #region SEARCH method
        /// <summary>
        /// 9.7 Write the code for a Binary Search for the Name in the 2D array
        /// and display the information in the other textboxes when found, 
        /// add suitable feedback if the search in not successful and clear the search textbox 
        /// (do not use any built-in array methods)
        /// </summary>
        //Search method
        private string ReplaceString(string input)
        {
            //match any characters that are not letters/digits, replace with empty string ""
            return Regex.Replace(input, "[^a-zA-Z0-9]+", "").ToLowerInvariant();
        }

        private void SearchName()
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                toolStripStatusLabel1.Text = "Enter Name to search";
            }
            else
            {
                bool found = false;
                int min = 0;
                int max = ptr - 1;
                //replace method to ignore dash e.g. Self-Balance Tree
                string target = ReplaceString(textBoxSearch.Text);
                stopwatch.Start();
                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    string arrayTarget = ReplaceString(arrayRecord[mid, 0]);
                    //Compare for position, equal for value comparison
                    if (target.Equals(arrayTarget, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //clear previous selected item
                        listViewArray.SelectedIndices.Clear();
                        //Highlight / select item in listview
                        //listViewArray.SelectedIndices.Add(mid);
                        listViewArray.Items[mid].Selected = true;
                        //get elements to display on textboxes
                        textBoxName.Text = arrayRecord[mid, 0];
                        comboBoxCategory.Text = arrayRecord[mid, 1];
                        comboBoxStructure.Text = arrayRecord[mid, 2];
                        textBoxDefinition.Text = arrayRecord[mid, 3];
                        stopwatch.Stop();
                        toolStripStatusLabel1.Text = $"{textBoxName.Text:F2} is found! ({stopwatch.Elapsed.TotalSeconds:F3} seconds)";
                        found = true;
                        break;
                    }
                    else if (target.CompareTo(arrayRecord[mid, 0]) < 0)
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }
                }
                if (!found)
                {
                    stopwatch.Stop();
                    toolStripStatusLabel1.Text = textBoxSearch.Text + $" not found ({stopwatch.Elapsed.TotalSeconds:F3} seconds)";
                }
            }
        }
        private void buttonSearch_MouseClick(object sender, MouseEventArgs e)
        {
            SearchName();
            ClearAllTextBoxes();
            //listViewArray.SelectedIndices.Clear(); //to clear highlighted selection as well
            textBoxSearch.Focus();//set input focus without selecting text.
            //textBoxSearch.Select(); //set input focus and select all text within control
        }
        #endregion
        #region DISPLAY method
        /// <summary>
        /// 9.8 Create a display method that will show the following information in a ListView: Name and Category
        /// </summary>
        /// <param name="array"></param>
        /// <param name="displayControl"></param>
        private void DisplayArray(string[,] array, Control displayControl)
        {
            if (displayControl is ListView listview)
            {
                listview.Items.Clear();
                ptr = 0;
                for (int i = 0; i < max; i++)
                {
                    if (array[i, 0] != "~")
                    {
                        ListViewItem listViewItem = new ListViewItem(array[i, 0]);
                        listViewItem.SubItems.Add(array[i, 1]);
                        listViewItem.SubItems.Add(array[i, 2]);
                        listViewItem.SubItems.Add(array[i, 3]);
                        listViewArray.Items.Add(listViewItem);
                        ptr++;
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
            else
            {
                MessageBox.Show("Array is not placed into listview");
            }
        }
        #endregion
        #region SELECT event
        /// <summary>
        /// 9.9 Create a method so the user can select a definition (Name) from the ListView
        /// and all the information is displayed in the appropriate Textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Select item in List View and display in Text Box
        private void listViewArray_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewArray.SelectedItems.Count == 0)
            {
                toolStripStatusLabel1.Text = "Please select from the list";
            }
            else
            {
                int currentItem = listViewArray.SelectedIndices[0];
                // put the selected List View item into the textbox
                textBoxName.Text = arrayRecord[currentItem, 0];
                comboBoxCategory.Text = arrayRecord[currentItem, 1];
                comboBoxStructure.Text = arrayRecord[currentItem, 2];
                textBoxDefinition.Text = arrayRecord[currentItem, 3];
                //to change colour pass parameter (int 1-7) to method
                //ChangeTextBoxColour(1);
            }
        }
        #endregion
        #region SAVE button
        /// <summary>
        /// 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat
        /// which is sorted by Name, ensure the user has the option to select an alternative file.
        /// Use a file stream and BinaryWriter to create the file. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <remarks>
        /// dialog filter https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.filedialog.filter?view=windowsdesktop-7.0
        /// save dialog https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-save-files-using-the-savefiledialog-component
        /// binary writer https://learn.microsoft.com/en-us/dotnet/api/system.io.binarywriter?view=net-7.0
        /// </remarks>
        private void SaveToBinary(string fileName)
        {
            try
            {
                // Create a FileStream and BinaryWriter to write to the selected file
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    // Loop through the items in the ListView and write them to the file
                    foreach (ListViewItem listViewItem in listViewArray.Items)
                    {
                        binaryWriter.Write(listViewItem.Text);
                        for (int i = 1; i < listViewItem.SubItems.Count; i++)
                        {
                            binaryWriter.Write(listViewItem.SubItems[i].Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error writing data to file: " + ex.Message;
            }
        }
        private void buttonSave_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Application.StartupPath;
                    saveFileDialog.Filter = "Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
                    saveFileDialog.DefaultExt = ".dat";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = fileName; // Set default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFileName = saveFileDialog.FileName; // Use user input filename
                        SaveToBinary(selectedFileName);
                        toolStripStatusLabel1.Text = "Save successful";
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error writing data to file: " + ex.Message;
            }

        }
        #endregion
        #region LOAD button
        /// <summary>
        /// 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array
        /// ensure the user has the option to select an alternative file. 
        /// Use a file stream and BinaryReader to complete this task. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// file stream https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-7.0
        /// open file dialog https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-7.0
        /// </remarks>
        private bool LoadFromBinary(string fileName)
        {
            try
            {
                // Initialize array before loading data
                InitializeArray(arrayRecord);
                stopwatch.Start();
                // Create a FileStream and BinaryWriter to read from the selected file
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    // Initialize row and column counters
                    int rowCount = 0;
                    int columnCount = 0;
                    // Read the data from the file and populate the 2D array
                    for (int i = 0; i < max; i++)
                    {
                        for (int j = 0; j < attributes; j++)
                        {
                            arrayRecord[i, j] = binaryReader.ReadString();
                            columnCount++;
                        }
                        rowCount++;
                    }
                    // Check if the number of rows and columns in the file matches the expected dimensions
                    if (rowCount != max || columnCount != max * attributes)
                    {
                        MessageBox.Show("Invalid file format. Number of Rows and columns do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error occurred while loading file: " + ex.Message;
                return false;
            }
        }
        private void buttonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 2; // file extensions in drop-down
                openFileDialog.RestoreDirectory = true; //box restores current directory before closing

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog.FileName;
                    LoadFromBinary(selectedFileName);
                    DisplayArray(arrayRecord, listViewArray);
                    stopwatch.Stop();
                    toolStripStatusLabel1.Text = $"Load successful! ({stopwatch.Elapsed.TotalSeconds:F3} seconds)";
                }
            }
        }
        #endregion
        #region OTHER Events (Buttons, Dropdown, Mouse Clicks, Mouse Double Clicks)
        /// <summary>
        /// 9.12 All code is required to be adequately commented, and each interaction must have suitable error trapping
        /// and/or feedback. All methods must utilise the appropriate Dialog Boxes, Message Boxes, etc 
        /// to ensure fully user functionality. Map the programming criteria (9.1 - 9.11)
        /// and features to your code/methods by adding comments above the method signatures.
        /// Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/). 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Regex replace https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace?view=net-7.0</remarks>
        private void comboBoxCategory_MouseClick(object sender, MouseEventArgs e)
        {
            //comboBoxCategory.Items.Clear(); //for testing
            comboBoxCategory.BeginUpdate();
            for (int i = 0; i < ptr; i++)
            {
                if (!comboBoxCategory.Items.Contains($"{arrayRecord[i, 1]}"))
                {
                    comboBoxCategory.Items.Add($"{arrayRecord[i, 1]}");
                }
            }
            comboBoxCategory.Sorted = true;
            comboBoxCategory.EndUpdate();
        }
        private void comboBoxStructure_MouseClick(object sender, MouseEventArgs e)
        {

            //comboBoxStructure.Items.Clear(); //for testing
            comboBoxStructure.BeginUpdate();
            for (int i = 0; i < ptr; i++)
            {
                if (!comboBoxStructure.Items.Contains($"{arrayRecord[i, 2]}"))
                {
                    comboBoxStructure.Items.Add($"{arrayRecord[i, 2]}");
                }
            }
            comboBoxStructure.Sorted = true;
            comboBoxStructure.EndUpdate();
        }
        //Form closing event
        private void FormWiki_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes before closing?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = Application.StartupPath;
                        saveFileDialog.Filter = "Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
                        saveFileDialog.DefaultExt = ".dat";
                        saveFileDialog.AddExtension = true;
                        saveFileDialog.FileName = fileName; // Set default file name

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedFileName = saveFileDialog.FileName; // Use user input filename
                            SaveToBinary(selectedFileName); // Save changes using the existing method
                            toolStripStatusLabel1.Text = "Save successful";
                        }
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = "Error writing data to file: " + ex.Message;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                // Cancel the form closing event
                e.Cancel = true;
            }
        }
        //Form load event
        private void FormWiki_Load(object sender, EventArgs e)
        {
            // display arrays when the form is opened
            DisplayArray(arrayRecord, listViewArray);
        }
        //Key press event to prevent issues with symbols e.g. comma as values must be unique
        //restrict inputs for textbox name, category, structure, and definition. !char.IsControl allows backspace and delete etc without blocking it.
        //ValidateText method
        private void ValidateText(Control control, int charLimit)
        {
            if (control is TextBox textBox)
            {
                int cursorPosition = textBox.SelectionStart;
                // Remove extra spaces by replacing them with a single space
                textBox.Text = Regex.Replace(textBox.Text, @"\s+", " ");

                // Restore cursor position
                textBox.SelectionStart = cursorPosition;

                // Handle KeyPress event to disallow symbols
                textBox.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '-')
                    {
                        e.Handled = true;
                    }
                };
                if (textBox.Text.Length > charLimit)
                {
                    MessageBox.Show($"Character limit exceeded. Maximum {charLimit} characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = $"Please use less than {charLimit} characters";
                }
            }
            else if (control is ComboBox comboBox)
            {
                int cursorPosition = comboBox.SelectionStart;
                // Remove extra spaces by replacing them with a single space
                comboBox.Text = Regex.Replace(comboBox.Text, @"\s+", " ");

                // Restore the cursor position
                comboBox.SelectionStart = cursorPosition;

                // Handle the KeyPress event to disallow symbols
                comboBox.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                };

                if (comboBox.Text.Length > charLimit)
                {
                    MessageBox.Show($"Character limit exceeded. Maximum {charLimit} characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = $"Please use less than {charLimit} characters";
                }
            }
        }
        //TextChanged events
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            ValidateText(textBoxName, 32);
        }
        private void comboBoxCategory_TextChanged(object sender, EventArgs e)
        {
            ValidateText(comboBoxCategory, 32);
        }
        private void comboBoxStructure_TextChanged(object sender, EventArgs e)
        {
            ValidateText(comboBoxStructure, 32);
        }
        private void textBoxDefinition_TextChanged(object sender, EventArgs e)
        {
            ValidateText(textBoxDefinition, 250);
            //int cursorPosition = textBoxDefinition.SelectionStart;
            //Remove extra spaces by replacing them with a single space
            //textBoxDefinition.Text = Regex.Replace(textBoxDefinition.Text, @"\s+", " ");
            //if (textBoxDefinition.Text.Length > charLimit)
            //{
            //    MessageBox.Show($"Character limit exceeded. Maximum {charLimit} characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    toolStripStatusLabel1.Text = $"Please use less than {charLimit} characters";
            //}
            //Restore the cursor position
            //textBoxDefinition.SelectionStart = cursorPosition;
        }
        #endregion
    }
}
/* NOTES
 * "FullRowSelect" true to make entire row highlighted
 * hide listview definition column - just set width to 0. e.g. listViewArray.Columns[0].Width = 0; https://stackoverflow.com/questions/7811669/how-to-hide-a-column-in-a-listview-control
 * if (listViewArray.CheckedIndices.Count == 0) //cannot edit/delete if click elsewhere
 * citems standards https://www.citems.com.au/services/application-development/
 * naming namespace https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces
 * arrays https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
 * delete array https://stackoverflow.com/questions/26303030/how-can-i-delete-rows-and-columns-from-2d-array-in-c
 * Foreach with arrays https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
 * Rank property display number of dimensions of an array https://docs.microsoft.com/en-us/dotnet/api/system.array.rank
 * textbox multiline = true https://support.microsoft.com/en-au/office/enable-a-text-box-to-accept-multiple-lines-of-text-dc76b29c-2570-47b1-94f9-4b8a55b7cb03
 * capitalise first string https://inspirnathan.com/posts/67-capitalize-first-letter-of-string-in-csharp/
 */