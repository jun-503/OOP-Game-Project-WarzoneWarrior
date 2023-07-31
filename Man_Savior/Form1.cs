using Man_Savior.GameGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;


namespace Man_Savior
{
    public partial class Form1 : Form
    {
        int count = 1;
        
        CollisionManager collider;
        GamePlayer player;
        Destructor d;
        Sahara S;
        GameGrid grid;
        Image playerImageRight;
        Image PlayerImageLeft;
        
        public Form1()
        {

            InitializeComponent();


        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            HealthBar.Minimum = 0;
            HealthBar.Maximum = 100;
           
            grid = new GameGrid("Maze1.txt", 20, 44);
            
             playerImageRight = Game.getGameObjectImage('R');
             PlayerImageLeft = Game.getGameObjectImage('L');

            GameCell startCell = grid.getCell(17, 8);
            player = new GamePlayer(playerImageRight, PlayerImageLeft,startCell,this);
            collider = new CollisionManager(player);
            GameCell desCell = grid.getCell(17 , 35);
            GameCell sahCell = grid.getCell(6, 27);

           
            d = new Destructor(Man_Savior.Properties.Resources.Destructor, desCell, GameObjectType.ENEMY, GameDirection.Up);
            S = new Sahara(Man_Savior.Properties.Resources.Sahara,sahCell,GameObjectType.ENEMY,GameDirection.Left);
            Enemy.Enemies.Add(d);
            Enemy.Enemies.Add(S);
           
            printMaze(grid);
        }
        public  void decreaseDestructorHealth()
        {
            if (desBar.Value > 0)
            {
                desBar.Value -= 20;
            }
        }
        public void showKilledLabel()
        {
            desBar.Visible = false;
            desKilled.Visible = true;
        }
        public void showSaharaKilledLabel()
        {
            progressBar1.Visible = false;
            label5.Visible = true;
        }

        public  void decreaseSaharaHealth()
        {
            if (progressBar1.Value > 0)
            {
                progressBar1.Value -= 20;
            }
        }
        public void printMaze(GameGrid grid)
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

        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

       
        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                player.FireBullet();
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                Image playerImg = Game.getGameObjectImage('R');
                player.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                player.move(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                player.move(GameDirection.Down);
            }
            foreach (Enemy i in Enemy.Enemies)
            {
                i.MoveGhost(grid);
                

            }
            if(Enemy.Enemies.Count ==1 && count==1)
            {
                Kills.Text = "1";
                count--;
            }
            if(Enemy.Enemies.Count==0 && count ==0)
            {
                Kills.Text = "2";
                count--;
            }
            player.UpdateBullets(grid);
            if (collider.HandleRewardCollision()) 
            {
                if (HealthBar.Value != 100)
                {
                    HealthBar.Value += 10;
                }
            }

            if (collider.HandleEnemyCollisions(Enemy.Enemies))
            { 
                if(HealthBar.Value > 0)
                {
                    HealthBar.Value -= 20;
                }
                
            }
            if (HealthBar.Value==0)
            {
                timer1.Enabled = false;
                MessageBox.Show("You Loose");
            }
            if(player.playerUpdate())
            {
                timer1.Enabled = false;
                MessageBox.Show(" Level 1 conquered ");
                Level2 level2 = new Level2();
                level2.Show();
            }
           
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void desKilled_Click(object sender, EventArgs e)
        {

        }
    }
}
