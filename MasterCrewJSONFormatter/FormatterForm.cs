using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterCrewJSONFormatter
{
    public partial class FormatterForm : Form
    {
        public FormatterForm()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "JSON|*.json|All|*.*";
            OFD.FileName = "chat";
            DialogResult result = OFD.ShowDialog();
            List<string> jsonLines = new List<string>();
            if (result == DialogResult.OK)
            {
                var currentFileName = OFD.FileName;
                FileNameTextBox.Text = currentFileName;
                jsonLines = JsonFile.ProcessJSONFile(OFD.FileName, this);


            }
            string allJson = StreamOutLines(jsonLines);
            JsonTextBox.Text = allJson;
        }

        private string StreamOutLines(List<string> jsonLines)
        {
            string outputLines = string.Empty;
            foreach (string line in jsonLines)
            {
                outputLines = outputLines + line;
            }
            return outputLines;
        }
    }


}
