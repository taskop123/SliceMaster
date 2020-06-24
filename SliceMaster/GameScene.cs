using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceMaster
{
    public class GameScene
    {
        public List<Fruit> AllFruits { get; set; }
        public int TotalPoints { get; set; }
        //brzina na dvizenje za site ovosja
        private int Velocity;
        //konstruktor
        public GameScene()
        {
            TotalPoints = 0;
            AllFruits = new List<Fruit>();
        }
        //dodavanje na ovosje
        public void AddFruit(String Name, Point Location)
        {
            Fruit NewFruit;
            if (Name.Equals("Watermelon"))
                NewFruit = new Watermelon(Name, Location);
            else if (Name.Equals("Pineapple"))
                NewFruit = new Pineapple(Name, Location);
            else if (Name.Equals("Apple"))
                NewFruit = new Apple(Name, Location);
            else if (Name.Equals("Orange"))
                NewFruit = new Orange(Name, Location);
            else if (Name.Equals("Strawberry"))
                NewFruit = new Strawberry(Name, Location);
            else
                NewFruit = new Bomb(Name, Location);
            AllFruits.Add(NewFruit);
        }

    }
}
