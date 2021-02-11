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
        public Food()
        {
            InitializeFood();
        }

        private void InitializeFood()
        {
            this.BackColor = Color.Red;
            this.Width = 20;
            this.Height = 20;
            this.Left = rand.Next(40, 420);
            this.Top = rand.Next(40, 420);
        }
    }
}
