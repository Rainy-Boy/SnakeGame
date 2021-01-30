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

        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameZone = new GameZone();
            this.Controls.Add(gameZone);

            snake = new Snake();
            this.Controls.Add(snake.body[0]);
            snake.body[0].BringToFront();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                snake.MoveUp();
            }
            else if (e.KeyCode == Keys.A)
            {
                snake.MoveLeft();
            }
            else if (e.KeyCode == Keys.D)
            {
                snake.MoveRight();
            }
            else if (e.KeyCode == Keys.S)
            {
                snake.MoveDown();
            }
        }
    }
}
