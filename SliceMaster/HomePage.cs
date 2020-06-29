using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SliceMaster
{
    public partial class HomePage : Form
    {
        WindowsMediaPlayer WindowsMediaPlayer = new WindowsMediaPlayer();
        private int BestScore;
        public HomePage()
        {
            BestScore = 0;
            DoubleBuffered = true;
            InitializeComponent();
            WindowsMediaPlayer.URL = "menu_music.mp3";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form1 newGame = new Form1();
            WindowsMediaPlayer.controls.stop();
            DialogResult result = newGame.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetScore(newGame.TotalPoints);
                WindowsMediaPlayer.controls.play();
            }

        }
        private void SetScore(int points)
        {
            if (points > BestScore)
            {
                BestScore = points;
            }
            lblBestScore.Text = string.Format("Best score: {0}", BestScore);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            WindowsMediaPlayer.controls.play();
        }
    }
}
