using Ovale_updater.Github;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovale_updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var git = new Git();

            await git.Clone("Xeltor", "Xeltors_Ovale_Scripts");

            OvaleScriptsLogTextbox.Text = await git.Log("Xeltor", "Xeltors_Ovale_Scripts");
            OvaleLogTextbox.Text = await git.Log("Xeltor", "Ovale");
        }
    }
}
