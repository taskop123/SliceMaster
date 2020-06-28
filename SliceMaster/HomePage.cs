using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SliceMaster
{
    public partial class HomePage : Form
    {
        // Ako imis nekoja druga ideja vo vrska so izgledo smeni ne e problem :D
        private int BestScore;
        public HomePage()
        {
            BestScore = 0;
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form1 newGame = new Form1();
            DialogResult result = newGame.ShowDialog();
            // ke se prakja scorot so ke se izvadi i ako e pogolem od best score ke se smesti tamu
            if (result == DialogResult.OK)
            {
                SetScore(newGame.TotalPoints);
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
    }
}
