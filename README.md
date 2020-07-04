# SliceMaster <img src="https://raw.githubusercontent.com/taskop123/SliceMaster/master/SliceMaster/icon_picture_uyx_icon.ico" width="60" height="60">

Windows Forms Application developed by:
* Jovan Tashkov - 186092
* Tashko Pavlov - 181104  
Application inspired by the game [Fruit Ninja](https://fruitninja.com/).
***

Играта којашто ја развивавме е инспирирана од играта [Fruit Ninja](https://fruitninja.com/). Играта SliceMaster е игра во којашто играчот треба да собира поени со сечење на овошја (<img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/watermelon2.png" width="10" height="10">, <img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/apple.png" width="10" height="10">, <img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/orange1.png" width="10" height="10">, <img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/pineapple.png" width="10" height="10"> и <img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/strawberry.png" width="10" height="10">) и притоа има бомби (<img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/bomba.png" width="10" height="10">) кои не се дозволени да се сечат, односно ако се пресече бомба играчот ја губи играта. Победник е оној којшто има најголем број на поени. Секое овошје носи различен број на поени. Исто така играта завршува доколку играчот не пресече 3 овошја, односно 3 овошја ја завршиле својата траекторија на движење без да бидат пресечени од играчот. Откако ќе се слули еден од овие настани коишто водат до завршување на играта, на екранот се испишува "Game Over" и вкупниот број на поени коишто играчот ги освоил. На одреден број секунди од левата или десната страна на формата се појавуваат 2 типа на овошја коишто се избрани случајно(Random) и една бомба, откако овошјето ќе се појави тоа се движи најпрво нагоре и притоа одејќи кон центарот на формата. Овошјето(тука се смета и бомбата) се движат нагоре сè додека не ја достигнат нивната максимална височина(max-height), потоа, овошјето својата траекторија ја продолжува надолу, сè додека не ја достигне долната граница на формата и тогаш повторно се движи нагоре. Во даден момент овошјата може да се појавуваат само од едната страна, на пример: ако последно овошјата се појавиле од левата страна, сега овошјата ќе се појават од десната страна на формата и обратно.
При секое промашување на овошјето, односно не пресечување на овошјето додека се движи, во долниот десен агол се додава знакот: <img src="https://github.com/taskop123/SliceMaster/blob/master/SliceMaster/Resources/Xsign.png" width="10" height="10">, овој знак се додава 3 пати и потоа играта завршува.
***
## Како изгледа играњето на играта
Најпрво при старт на играта се стартнува формата HomePage, која изгледа на следниов начин:
<img src="https://github.com/taskop123/SliceMaster/blob/master/ScreenShots/tasko.PNG">
Во лабелата лево доле "Best Score: 0", се впишува најдобриот резултат од тековната инстанца на играта, односно доколку повторно ја вклучиме играта најдобриот резултат ќе биде пребришан. Имаме уште 2 копчиња, "Play" и "Quit Game", коишто според текстот можеме да заклучиме за што служат.
### При клик на копчето "Play":
<img src="https://github.com/taskop123/SliceMaster/blob/master/ScreenShots/homeformtomainform.gif">
При клик на ова копче како што може да забележиме не пренасочува веднаш кон играње на играта.

### Како изгледа играњето на играта
<img src="https://github.com/taskop123/SliceMaster/blob/master/ScreenShots/game_over_labe.gif">
Еве како изгледа едно сценарио на завршување на играта. Во долниот лев агол имаме toolStripLabel-а која ни ги брои тековните поени. Исто така во горниот лев акол имаме "menu strip" каде имаме "Pause toolStripMenuItem", при клик на ова копче играта се паузира и воедно името на ова копче се променува во "Continue", играта е паузирана се додека не се притисне на копчето уште еднаш.

## Како ни се структурирани класите
```C#
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SliceMaster
{
    public abstract class Fruit
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public Image FruitImage { get; set; }
        public float Radius { get; set; }
        public bool IsHit { get; set; }
        public int Points { get; set; }
        public int Direction { get; set; }
        public bool UpOrDown { get; set; }
        public WindowsMediaPlayer FruitSlicedSound { get; set; }
        public float Velocity { get; set; }
        public Random VelocityPicker;
        public int State { get; set; }
        public Fruit(string Name, Point Location, int Direction, int Radius)
        {
            this.Radius = Radius;
            UpOrDown = true;
            this.Direction = Direction;
            this.Name = Name;
            this.Location = Location;
            this.IsHit = false;
            VelocityPicker = new Random();
            this.Velocity = VelocityPicker.Next(6, 8);
            this.State = 1;
            FruitSlicedSound = new WindowsMediaPlayer();
        }

        
        public abstract void MoveUp(float velocity);
        public abstract void MoveDown(float velocity); 
        public abstract void Draw(Graphics g); 
        public abstract void IsHitByUser(Point p1); 
    }
}
```
Ова ни е апстракната класа за Овошје(Fruit), од која што наследуваат сите овошја. Притоа, за секое овошје имаме посебна класа кадешто овие методи ни се имплементирани.

Зошто ваква структура на класи?
 - Ја одбравме оваа структура бидејќи секое овошје во нашата игра има нешто заедничко, затоа, сето она што е заедничко за овошјата е напишано во оваа апстрактна     класа. Но, секое овошје изгледа различно, има различен радиус, има различна брзина на движење итн.
 
 
 ## Како изгледа методот IsHitByUser(Point p1)
 
 ```C#
  public override void IsHitByUser(Point p1)
        {
            float Distance = (p1.X - this.Location.X) * (p1.X - this.Location.X) + (p1.Y - this.Location.Y) * (p1.Y - this.Location.Y);
            if (Distance <= Radius * Radius)
            {
                this.IsHit = true;
                FruitSlicedSound.URL = "fruit_cut.mp3";
                FruitSlicedSound.controls.play();
            }
        }
 ```
 Овој метод ми е имплементиран во секое класа(овошје), која ми наследува од класата Fruit. Се повикува секогаш кога имаме Event: "MouseMove", при што како аргумент во овој метод се праќа моменталната положба на глувчето, и се проверува дали сегашната положба на глувчето лежи во самата кружница која овошјето ја исцртува. Се проверува на тој начин што се пресметува евклидово растојание.
 
 
