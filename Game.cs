using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Game : Form
    {
        GameZone gameZone = null;
        Snake snake = null;
        Food food = null;
        Timer mainTimer = null;


        Random rand = new Random();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;

            gameZone = new GameZone();
            this.Controls.Add(gameZone);

            snake = new Snake(this);
            this.Controls.Add(snake.body[0]);
            snake.body[0].BringToFront();

            food = new Food();
            this.Controls.Add(food);
            food.BringToFront();
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Interval = 500;
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            SnakeFoodCollision();
            
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: 
                    snake.Turn(9);
                    break;
                case Keys.Right:
                    snake.Turn(3);
                    break;
                case Keys.Down:
                    snake.Turn(6);
                    break;
                case Keys.Up:
                    snake.Turn(12);
                    break;
                case Keys.P:
                    snake.Stop();
                    break;
                case Keys.Q:
                    snake.Grow();
                    break;
            }
        }

        private void SnakeFoodCollision()
        {
            if (snake.body[0].Bounds.IntersectsWith(food.Bounds))
            {
                food.Left = rand.Next(40, 420);
                food.Top = rand.Next(40, 420);
                snake.Grow();
                
            }
        }

    }
}
