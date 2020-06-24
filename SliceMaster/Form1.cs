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
        public Form1()
        {
            //Backgroundimage = "Images/background.png"
            Game = new GameScene();
            InitializeComponent();
        }
    }
}
