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

            if (result == DialogResult.OK)
            {
                var currentFileName = OFD.FileName;
                FileNameTextBox.Text = currentFileName;
                List<string> justChatLines = JsonFile.ProcessJSONFile(OFD.FileName, this);


            }
            //string allChat = StreamOutLines(justChatLines);
            //ChatTextBox.Text = allChat;
        }
    }
}
