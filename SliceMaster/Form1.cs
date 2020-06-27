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
    public partial class Form1 : Form
    {
        // glavniot objekt preku koj ke gi izvrsuvame site metodi
        private GameScene Game;
        private Random randomFruitPicker;
        private Random LocationPicker;
        private int TimerCall;
        public Form1()
        {
            //Backgroundimage = "Images/background.png"
            Game = new GameScene(this.Width);
            InitializeComponent();
            this.DoubleBuffered = true;
            randomFruitPicker = new Random(); // Ke ja koristime ovaa slucajna promenliva za izbiranje na slucajno ovosje;
            LocationPicker = new Random(); // Promenliva koja ke odlucuva od koja lokacija da pocne da se frla ovosjeto;
            TimerCall = 0;
            //timer1.Start();
            Game.AddFruit("Apple", new Point(0 - LocationPicker.Next(100, 110), LocationPicker.Next(250, Height))); // najprvo gledame vo koja nasoka ke se dvizi ovosjeto

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Game.DrawAllFruits(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Fruit f in Game.AllFruits)
            {
                f.MoveUp(f.Velocity, 0);
            }
            Invalidate();
        }
    }
}
