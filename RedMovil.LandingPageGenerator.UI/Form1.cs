using System.Collections.Generic;
using System.Windows.Forms;
using RedMovil.LandingPageGenerator.Domain;

namespace RedMovil.LandingPageGenerator.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ProcessTemplate(string templatePath)
        {
            lblStatus.Text = "";
            List<string> keyWordList = new List<string> { "Hola", "Chao" };

            bool processCompleted = Template.ProcessTemplate(keyWordList, templatePath);

            if (processCompleted)
            {
                lblStatus.Text = "Proceso completado!";
            }
            else
            {
                lblStatus.Text = "Ocurrio un error!";
            }
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            if (txtRuta.Text.Length != 0)
            {
                ProcessTemplate(txtRuta.Text);
            }
        }

        private void btSearchFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRuta.Text = openFileDialog.FileName;
            }
        }
    }
}