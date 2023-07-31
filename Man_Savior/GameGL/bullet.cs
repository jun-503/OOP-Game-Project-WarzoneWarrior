using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Man_Savior.GameGL
{
     class Bullet:GameObject
    {
        private int speed;
        private GameDirection direction;

        public Bullet(Image image, GameCell startCell, int speed, GameDirection direction) : base(GameObjectType.BULLET, image)
        {
            this.CurrentCell = startCell;
            this.speed = speed;
            this.direction = direction;
        }

        public void Update()
        {
            // Move the bullet horizontally based on its direction and speed
            if (direction == GameDirection.Left)
            {
                CurrentCell = CurrentCell.nextCell(GameDirection.Left);
            }
            else if (direction == GameDirection.Right)
            {
                CurrentCell = CurrentCell.nextCell(GameDirection.Right);
            }
        }
    }
}
