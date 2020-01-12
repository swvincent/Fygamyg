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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SaveBotton_Click(object sender, EventArgs e)
        {
            JournalEntry j = new JournalEntry();

            j.Book = bookTextBox.Text;
            j.Chapter = int.Parse(chapterTextBox.Text);
            j.BeginVerse = int.Parse(beginVerseTextBox.Text);
            j.EndVerse = int.Parse(endVerseTextBox.Text);
            j.Title = titleTextBox.Text;
            j.NoteText = noteTextBox.Text;

            using (var helper = new FygHelper())
            {
                j = helper.AddJournalEntry(j);
                MessageBox.Show(j.ID.ToString());
            }
        }
    }
}
