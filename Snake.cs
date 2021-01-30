using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGame
{
    class Snake
    {
        public List<PictureBox> body = new List<PictureBox>();

        public int HorVelocity { get; set; } = 0;
        public int VerVelocity { get; set; } = 0;

        private Timer timerMove = null;

        public Snake()
        {
            InitializeSnake();
            InitializeTimerMove();
        }

        private void InitializeSnake()
        {
            PictureBox pixel = new PictureBox();
            pixel.BackColor = Color.Red;
            pixel.Width = 20;
            pixel.Height = 20;
            pixel.Left = 200;
            pixel.Top = 200;

            body.Add(pixel);
        }

        public void MoveRight()
        {
            this.HorVelocity = 2;
        }
        public void MoveLeft()
        {
            this.HorVelocity = -2;
        }
        public void MoveUp()
        {
            this.VerVelocity = -2;
        }
        public void MoveDown()
        {
            this.VerVelocity = 2;
        }

        private void InitializeTimerMove()
        {
            timerMove = new Timer();
            timerMove.Interval = 10;
            timerMove.Tick += TimerMove_Tick;
            timerMove.Start();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            this.body[0].Left += this.HorVelocity;
            this.body[0].Top += this.VerVelocity;
        }
    }
}
