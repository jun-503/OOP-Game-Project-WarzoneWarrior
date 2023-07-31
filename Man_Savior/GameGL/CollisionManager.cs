using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Man_Savior.GameGL
{
    class CollisionManager
    {
        private GamePlayer player;
       

        public CollisionManager(GamePlayer player)
        {
            this.player = player;
          
        }

      

        public bool HandleEnemyCollisions(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies.ToList())
            {
                if (player.CurrentCell == enemy.CurrentCell)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HandleRewardCollision()
        {
            GameCell cell = player.CurrentCell.nextCell(GameDirection.Right);
            GameCell cell1 = player.CurrentCell.nextCell(GameDirection.Left);
            if (cell.CurrentGameObject.GameObjectType==GameObjectType.REWARD || cell1.CurrentGameObject.GameObjectType==GameObjectType.REWARD)
            {
                
                // Collision detected with the reward, increase player's health
                return true ;

          
                
            }
            
            return false;
        }

      
    }
}
