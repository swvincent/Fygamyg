using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibleUtil;
using fygdb;
using fygdb.models;

namespace fygwin
{
    public partial class MainForm : Form
    {
        private Reference bibleRef;
        private JournalEntry currentJournalEntry;

        public MainForm()
        {
            InitializeComponent();
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            ProcessSearchText(searchTextBox.Text);
        }

        private void ProcessSearchText(string searchText)
        {
            var r = ParseReference(searchText);

            if (r != null)
            {
                bibleRef = r;
                UpdateGUI();
            }
        }

        private Reference ParseReference(string searchText)
        {
            try
            {
                var r = Reference.Parse(searchText);

                if (r.ContiguousVerses())
                    return r;
                else
                    MessageBox.Show("Unable to load this reference: verses must be contiguous.", "Invalid Reference",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
            catch (Exception caught)
            {
                MessageBox.Show($"Unable to parse this reference: {caught.Message}.", "Parse Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }

        private void UpdateGUI()
        {
            searchTextBox.Text = bibleRef.ToString();

            var results = GetJournalEntriesForReference(bibleRef);

            entriesListView.Items.Clear();

            foreach (var r in results)
            {
                var values = new string[] { r.Book.BookName, r.ChapterText, r.VersesText, r.Title };

                var l = new ListViewItem(values);
                l.Tag = r;

                entriesListView.Items.Add(l);
            }


        }

        private List<JournalEntry> GetJournalEntriesForReference(Reference r)
        {
            int beginVerse = 0;
            int endVerse = 0;

            if (r.Verses.Any())
            {
                beginVerse = r.Verses.Min();
                endVerse = r.Verses.Max();
            }

            using (var helper = new JournalEntryHelper())
            {
                return helper.GetJournalEntries(r.Book.BookNumber, r.Chapter, beginVerse, endVerse);
            }
        }

        private void EntriesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entriesListView.SelectedItems.Count > 0)
            {
                var j = (JournalEntry)entriesListView.SelectedItems[0].Tag;
                LoadAndDisplayJournalEntry(j);
            }
            else
                LoadAndDisplayJournalEntry();
        }

        private void LoadAndDisplayJournalEntry(JournalEntry j = null)
        {
            currentJournalEntry = j;

            if (currentJournalEntry != null)
            {
                entryTextBox.Text = currentJournalEntry.NoteText;
                entryTextBox.Enabled = true;
            }
            else
            {
                entryTextBox.Clear();
                entryTextBox.Enabled = false;
            }
        }
}
}
