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
        Timer mainTimer = null;

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

            snake = new Snake();
            this.Controls.Add(snake.body[0]);
            snake.body[0].BringToFront();
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
            snake.body[0].Top += snake.VerVelocity * snake.Step;
            snake.body[0].Left += snake.HorVelocity * snake.Step;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                snake.HorVelocity = 0;
                snake.VerVelocity = -1;
            }
            else if (e.KeyCode == Keys.A)
            {
                snake.HorVelocity = -1;
                snake.VerVelocity = 0;
            }
            else if (e.KeyCode == Keys.D)
            {
                snake.HorVelocity = 1;
                snake.VerVelocity = 0;
            }
            else if (e.KeyCode == Keys.S)
            {
                snake.HorVelocity = 0;
                snake.VerVelocity = 1;
            }
            else if (e.KeyCode == Keys.P)
            {
                snake.HorVelocity = 0;
                snake.VerVelocity = 0;
            }
        }
    }
}
