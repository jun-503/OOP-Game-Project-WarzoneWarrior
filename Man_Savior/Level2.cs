using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Man_Savior.GameGL;

namespace Man_Savior
{
    public partial class Level2 : Form
    {
        GameGrid grid2;
        GamePlayer player;
        Image playerImageRight;
        Image playerImageLeft;
       
        public Level2()
        {
            InitializeComponent();
           
        }

        private void Level2_Load(object sender, EventArgs e)
        {
            // form.Close();
            grid2 = new GameGrid("Maze2.txt", 22, 59);
            playerImageRight = Game.getGameObjectImage('R');
            playerImageLeft = Game.getGameObjectImage('L');
            
            GameCell startCell = grid2.getCell(19, 6);
            player = new GamePlayer(playerImageRight, playerImageLeft, startCell, this);
            printMaze(grid2);
           
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);


                    this.Controls.Add(cell.PictureBox);
                    //  printCell(cell);
                }

            }
        }
       
    }
}
