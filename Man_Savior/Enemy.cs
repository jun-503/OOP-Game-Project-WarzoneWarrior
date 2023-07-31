using Man_Savior.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Man_Savior
{
    abstract class Enemy:GameObject
    {
        static List<Enemy> enemies = new List<Enemy>();
        private int hitCount = 0;
        public GameDirection direction;
        public Enemy(char DisplayCharacter, GameObjectType type) : base(type, DisplayCharacter)
        {
            this.DisplayCharacter = DisplayCharacter;
            this.GameObjectType = type;
        }

        public Enemy(Image img, GameObjectType type) : base(type, img)
        {
            this.GameObjectType = type;
            this.Image = img;
        }
        public int HitCount
        {
            get { return hitCount; }
            set { hitCount = value; }
        }
        public static List<Enemy> Enemies
        { get { return enemies; }
            
        }

        public abstract GameCell MoveGhost(GameGrid grid);
       
    }
}
