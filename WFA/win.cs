using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class win : Form
    {
        string score;
        private readonly SoundPlayer winSound;

        public win(string score)
        {
            this.score = score;
            InitializeComponent();
            txtScore.Text = score;
            winSound = new SoundPlayer(Properties.Resources.win);
            winSound.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu = new menu();
            menu.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void win_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
