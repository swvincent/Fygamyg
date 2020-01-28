using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fygdb;
using fygdb.models;

namespace fygwin
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();

            using (var helper = new BookHelper())
            {
                bookComboBox.DataSource = helper.GetAllBooks();
                bookComboBox.DisplayMember = "BookName";
                bookComboBox.ValueMember = "BookId";
            }

            using (var helper = new EntryTypeHelper())
            {
                comboBox1.DataSource = helper.GetAllEntryTypes();
                comboBox1.DisplayMember = "EntryTypeName";
                comboBox1.ValueMember = "EntryTypeId";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            { 
                JournalEntry j = new JournalEntry();

                j.BookId = int.Parse(bookComboBox.SelectedValue.ToString());
                j.Chapter = int.Parse(chapterTextBox.Text);
                j.BeginVerse = int.Parse(beginVerseTextBox.Text);
                j.EndVerse = int.Parse(endVerseTextBox.Text);
                j.EntryTypeId = int.Parse(comboBox1.SelectedValue.ToString());
                j.Title = titleTextBox.Text;
                j.NoteText = noteTextBox.Text;

                using (var helper = new JournalEntryHelper())
                {
                    j = helper.AddJournalEntry(j);
                    dbStatusLabel.Text = $"Saved with ID {j.JournalEntryId}";
                }

                // Reset
                titleTextBox.Text = null;
                noteTextBox.Text = null;
                bookComboBox.Focus();
            }
            catch (Exception caught)
            {
                MessageBox.Show($"Exception occured: {caught.Message}");
            }
        }
    }
}
