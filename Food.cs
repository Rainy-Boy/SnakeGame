using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGame
{
    class Food : PictureBox
    {
        Random rand = new Random();
        Game game = null;
        public Food(Game gameInstance)
        {
            game = gameInstance;
            InitializeFood();
        }

        private void InitializeFood()
        {
            this.BackColor = Color.Red;
            this.Width = 20;
            this.Height = 20;
            Relocate();
        }

        public void Render()
        {
            game.Controls.Add(this);
            this.BringToFront();
        }

        public void Relocate()
        {
            var multiplier = rand.Next(0, 20);
            var L = 40 + 20 * multiplier;
            var T = 40 + 20 * multiplier;
            this.Location = new Point(L, T);


        }

    }
}
