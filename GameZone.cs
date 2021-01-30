using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGame
{
    class GameZone : PictureBox
    {
        public GameZone()
        {
            InitializeGameZone();
        }

        private void InitializeGameZone()
        {
            this.BackColor = Color.SteelBlue;
            this.Width = 400;
            this.Height = 400;
            this.Left = 40;
            this.Top = 40;
        }
    }
}
