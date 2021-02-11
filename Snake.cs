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
        private Game game = null;

        public List<PictureBox> body = new List<PictureBox>();
        

        public int Step { get; private set; } = 20;
        public int HorVelocity { get; private set; } = 0;
        public int VerVelocity { get; private set; } = 0;

        

        public Snake(Game gameInstance)
        {
            game = gameInstance;
            InitializeSnake();
            
        }

        private void InitializeSnake()
        {
            PictureBox pixel = new PictureBox();
            pixel.BackColor = Color.Green;
            pixel.Width = 20;
            pixel.Height = 20;
            pixel.Left = 200;
            pixel.Top = 200;

            body.Add(pixel);
            for (int i = 0; i < 2; i++)
            {
                this.Grow();
            }

        }

        /// <summary>
        /// Change direction of snake
        /// </summary>
        /// <param name="direction">3 - right, 9 - left, 6 - down, 12 - up</param>

        public void Turn(int direction) 
        {
            switch (direction)
            {
                case 3: //turn right
                    this.HorVelocity = 1;
                    this.VerVelocity = 0;
                    break;
                case 9: //turn left
                    this.HorVelocity = -1;
                    this.VerVelocity = 0;
                    break;
                case 6: //turn down
                    this.HorVelocity = 0;
                    this.VerVelocity = 1;
                    break;
                case 12: //turn up
                    this.HorVelocity = 0;
                    this.VerVelocity = -1;
                    break;
            }
        }

        /// <summary>
        /// Stop the snake completely
        /// </summary>

        public void Stop()
        {
            this.HorVelocity = 0;
            this.VerVelocity = 0;
        }

        public void Grow()
        {
            PictureBox pixel = new PictureBox();
            pixel.BackColor = Color.Green;
            pixel.Width = 20;
            pixel.Height = 20;
            pixel.Location = body[0].Location;

            body.Add(pixel);
            game.Controls.Add(pixel);
            

            pixel.BringToFront();
        }

        public void Move()
        {
            
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].Location = body[i - 1].Location;
            }

            body[0].Left += this.HorVelocity * this.Step;
            body[0].Top += this.VerVelocity * this.Step;

        }

    }
}
