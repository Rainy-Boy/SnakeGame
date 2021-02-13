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
        Label labelScore = new Label();
        int scoreCounter = 0;

        Random rand = new Random();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
        }

        private void InitializeGame()
        {
            //add event handlers
            this.KeyDown += Game_KeyDown;

            //add gamezone
            gameZone = new GameZone();
            this.Controls.Add(gameZone);

            //add snake
            snake = new Snake(this);
            this.Controls.Add(snake.body[0]);
            snake.body[0].BringToFront();

            //add snake
            food = new Food(this);
            food.Render();

            //add scoring label
            labelScore.Left = 500;
            labelScore.Top = 40;
            labelScore.Text = "0";
            this.Controls.Add(labelScore);
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
            var multiplier = 1;
            if (snake.body[0].Bounds.IntersectsWith(food.Bounds))
            {
                food.Relocate();
                while (FoodSnakeBodyCollision())
                {
                    food.Relocate();
                }

                snake.Grow();
                scoreCounter++;
                labelScore.Text = scoreCounter.ToString();
            }
            if (scoreCounter == 5 * multiplier)
            {
                mainTimer.Interval = 500 - 25 * multiplier;
                multiplier++;
            }
        }

        private bool FoodSnakeBodyCollision()
        {
            foreach(var pixel in snake.body)
            {
                if (pixel.Bounds.IntersectsWith(food.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        private void SnakeSelfCollision()
        {
            for (int i = 1; i < snake.body.Count - 1; i++)
            {
                if (snake.body[i].Bounds.IntersectsWith(snake.body[0].Bounds))
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            MessageBox.Show("You lost");
        }

    }
}
