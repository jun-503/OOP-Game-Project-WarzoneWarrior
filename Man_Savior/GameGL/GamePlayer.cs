using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using System.Threading;
using Man_Savior;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;

namespace Man_Savior.GameGL
{
   
    class GamePlayer : GameObject
    {
       
        
        public static List<Bullet> bullets = new List<Bullet>();
        public bool isFiring = false;
        private Image imageRight;
        private Image imageLeft;
        public GameDirection CurrentDirection { get; private set; }

        private Bullet currentbullet;
        Form1 Form1;
        Level2 form;


        // Rest of the code...



        public GamePlayer(Image imageRight,Image imageLeft, GameCell startCell,Form1 form) : base(GameObjectType.PLAYER, imageRight)
        {
            this.imageRight = imageRight;
            this.imageLeft = imageLeft;
            this.CurrentCell = startCell;
            currentbullet = null;
            Form1 = form;
          
        }
        public GamePlayer(Image imageRight, Image imageLeft, GameCell startCell, Level2 form) : base(GameObjectType.PLAYER, imageRight)
        {
            this.imageRight = imageRight;
            this.imageLeft = imageLeft;
            this.CurrentCell = startCell;
            currentbullet = null;
             this.form= form;

        }
        public bool playerUpdate()
        {
            if(CurrentCell.nextCell(GameDirection.Right).CurrentGameObject.GameObjectType ==GameObjectType.EXIT)
            {
                if (Enemy.Enemies.Count == 0)
                {
                    return Game.level1Reached();
                }
            }
             return false;
            
        }
        public void FireBullet()
        {
            GameCell nextCell = CurrentCell.nextCell(GameDirection.Right); // Assuming you want the bullet to move right.
            if (nextCell != null && nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                currentbullet = new Bullet(Man_Savior.Properties.Resources.fire, nextCell, 15, GameDirection.Right);
                currentbullet.CurrentCell = nextCell;
                nextCell.setGameObject(currentbullet);
                bullets.Add(currentbullet);

            }

        }
      
        public void UpdateBullets(GameGrid grid)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                
                Bullet bullet = bullets[i];
                GameCell gameCell = grid.getCell(bullet.CurrentCell.X, bullet.CurrentCell.Y+1);
                bool remove = false;
                foreach (Enemy enemy in Enemy.Enemies.ToList())
                {

                    if (gameCell == enemy.CurrentCell)
                    {
                        // Collision detected with an enemy, remove the projectile and update the enemy's hit count
                        bullets.RemoveAt(i);
                        enemy.HitCount++;
                       if(enemy is Destructor d)
                       {
                            Form1.decreaseDestructorHealth();
                       }
                       else if (enemy is Sahara s)
                        {
                            Form1.decreaseSaharaHealth();
                        }
                        bullet.CurrentCell.removeGameObject();
                        

                        if (enemy.HitCount >= 5)
                        {
                            if(enemy is Destructor d1)
                            {
                                Form1.showKilledLabel();
                              
                            }
                            if (enemy is Sahara d2)
                            {
                                Form1.showSaharaKilledLabel();

                            }
                            // Enemy has been hit 5 times, remove it from the grid
                            enemy.CurrentCell.setGameObject(Game.getBlankGameObject());
                            Enemy.Enemies.Remove(enemy);

                            enemy.HitCount = 0;
                            
                           
                        }
                       remove = true;
                        break; // No need to check further enemies, exit the loop
                    }
                }
                if (!remove)
                {
                    if (bullet != null)
                    {
                        bullet.CurrentCell.setGameObject(Game.getBlankGameObject());
                        GameCell nextCell   = grid.getCell(bullet.CurrentCell.X , bullet.CurrentCell.Y +1);   
                        
                      
                        if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL || nextCell.CurrentGameObject.GameObjectType == GameObjectType.EXIT ||
                           nextCell.X < 0 || nextCell.X >= grid.Rows ||
                            nextCell.Y < 0 || nextCell.Y >= grid.Cols)
                        {

                            // Projectile hit a wall or reached the boundary, remove it.
                            bullet.CurrentCell.removeGameObject();

                            bullets.Remove(bullet);
                            break;

                        }

                        else
                        {
                            bullet.Update();
                        }

                    }
                }
            }
           
            
        }

      




        public GameCell move(GameDirection direction)
        {
            CurrentDirection = direction;
            if (direction == GameDirection.Left)
            {
                Image = imageLeft;
            }
            if (direction == GameDirection.Right)
            {
                Image = imageRight;
            }
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }
       
    }

    
}
