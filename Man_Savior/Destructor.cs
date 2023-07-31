using Man_Savior.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;


namespace Man_Savior
{
    class Destructor : Enemy
    {
        public Destructor(char DisplayCharacter, GameCell cell, GameObjectType type, GameDirection direction) : base(DisplayCharacter, type)
        {
            this.DisplayCharacter = DisplayCharacter;
            this.CurrentCell = cell;
            this.direction = direction;
            this.GameObjectType = type;
        }

        public Destructor(Image img, GameCell cell, GameObjectType type, GameDirection direction) : base(img, type)
        {
            this.Image = img;
            this.CurrentCell = cell;
            this.direction = direction;
            this.GameObjectType = type;
        }
      
        public override GameCell MoveGhost(GameGrid grid)
        {

            GameCell currentCell = this.CurrentCell;
            if (direction == GameDirection.Up)
            {
                
                GameCell next = grid.getCell(CurrentCell.X - 1, CurrentCell.Y);

               
                if (next.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    if (next != null)
                    {
                        currentCell.setGameObject(Game.getCurrentObject(next));
                        CurrentCell = next;
                        return next;
                    }

                }
                else if (next.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    direction = GameDirection.Down;
                }
            }

            if (direction == GameDirection.Down)
            {
                GameCell next = grid.getCell(CurrentCell.X + 1, CurrentCell.Y);

                
                if (next.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    if (next != null)
                    {
                        currentCell.setGameObject(Game.getCurrentObject(next));
                        CurrentCell = next;
                        return next;
                    }

                }
                else if (next.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {

                    direction = GameDirection.Up;
                }

            }
            return null;
        }
    }

}
