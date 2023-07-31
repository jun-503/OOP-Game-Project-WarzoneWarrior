using Man_Savior.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Man_Savior
{
    internal class Sahara:Enemy
    {
        public Sahara(char DisplayCharacter,GameCell cell,GameObjectType type,GameDirection direction):base(DisplayCharacter,type) { 
            this.DisplayCharacter = DisplayCharacter;
            this.CurrentCell = cell;
            this.direction = direction;
            this.GameObjectType = type;
        }
        public Sahara(Image img, GameCell cell, GameObjectType type, GameDirection direction) : base(img, type)
        {
            this.Image = img;
            this.CurrentCell = cell;
            this.direction = direction;
            this.GameObjectType = type;
        }

        public override GameCell MoveGhost(GameGrid grid)
        {
          GameCell currentCell = this.CurrentCell;
            
            if (direction == GameDirection.Left)
            {
                GameCell next = grid.getCell(CurrentCell.X, CurrentCell.Y - 1);
              
                if(next.CurrentGameObject.GameObjectType !=GameObjectType.WALL)
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
                    direction = GameDirection.Right;
                }
            }
            else if(direction == GameDirection.Right) {
                GameCell next  = grid.getCell(CurrentCell.X,CurrentCell.Y + 1);
               
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
                    direction = GameDirection.Left;
                }
            }
            return null;
        }
    }
}
