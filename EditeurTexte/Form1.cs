using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditeurTexte
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                if (Path.GetExtension(openFileDialog1.FileName).ToUpper() == ".TXT")
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "ERREUR !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile(openFileDialog1.FileName);
        }

        private void enregistrersousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Fichier Texte | *.txt | Fichier RichText | *.rtf";
            switch (saveFileDialog1.ShowDialog())
            {
                case DialogResult.OK:
                    MessageBox.Show("Votre fichier à bien été enregistré dans " + saveFileDialog1.FileName);
                    return;
                case DialogResult.Cancel:
                    MessageBox.Show("Annulation de l'enregistrement");
                    return;
            }
            if (Path.GetExtension(saveFileDialog1.FileName).ToUpper() == ".TXT")
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
            else
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez vous vraiment quitter ?","Quitter ?",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                Application.Exit();
        }

        private void couleurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (colorDialog1.ShowDialog())
            {
                case DialogResult.OK:
                    richTextBox1.SelectionColor = colorDialog1.Color;
                    return;
            }
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (fontDialog1.ShowDialog())
            {
                case DialogResult.OK:
                    richTextBox1.SelectionFont = fontDialog1.Font;
                    return;
            }
        }
    }
}
