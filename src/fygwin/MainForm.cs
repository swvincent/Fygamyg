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

namespace fygwin
{
    public partial class MainForm : Form
    {
        private string lastSearchText;
        private Reference bibleRef;

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
        }
    }
}
