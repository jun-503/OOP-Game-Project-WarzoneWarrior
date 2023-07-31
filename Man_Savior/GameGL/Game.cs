using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Man_Savior.GameGL
{
    public class Game
    {
        static int score = 0;
        static bool flag = true;
        public static GameObject getBlankGameObject(){
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, Man_Savior.Properties.Resources.simplebox);
            return blankGameObject;
        }
        public static GameObject getCurrentObject(GameCell c)
        {

            GameObject Object = new GameObject(c.CurrentGameObject.GameObjectType, c.CurrentGameObject.Image);

            return Object;
        }

        public static void AddScore()
        {
            score++;

        }

        public static void SetFlag()
        {
            flag = false;
        }
        public static bool GetFlag()
        {
            return flag;
        }
        public static int ReturnScore()
        {
            return score;
        }
        public static bool level1Reached()
        {
            return true;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = Man_Savior.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '_' || displayCharacter=='!' || displayCharacter=='W')
            {
                img = Man_Savior.Properties.Resources.horizontal;
                
            }

            if (displayCharacter == '#')
            {
                img = Man_Savior.Properties.Resources.vertical;
            }

            if (displayCharacter == '$')
            {
                img = Man_Savior.Properties.Resources.pallet;
            }
            if (displayCharacter == 'R' || displayCharacter == 'P') {
                img = Man_Savior.Properties.Resources.Player;
               
            }
            if (displayCharacter == 'L' || displayCharacter == 'P')
            {
                img = Man_Savior.Properties.Resources.PlayerLeft;

            }

            return img;
        }
    }
}
