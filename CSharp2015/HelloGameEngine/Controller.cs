using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloGameEngine
{
    class Controller 
    {
        public GameObject gameobj;
        public bool left = false;
        public bool right = false;
        public bool top = false;
        public bool bottom = false;
        public bool mission = true;
        public bool talkmission = false;
        public bool talk = false;
        public bool talkstone = false;
        public bool atkmon = false;
        public bool talkcapmfire = false;
        public bool talkaxe = false;
        public bool talktree = false;
        public bool gamewin = false;
        public int o = 0;
        private int x = 0;
        private int y = 0;
        public Controller(Form scene)
        {
            scene.KeyDown += new KeyEventHandler(onKeyDown);
            scene.KeyUp += new KeyEventHandler(onKeyUp);
        }

        public Controller(Form scene, GameObject charcontrol) : this(scene)
        {
            this.gameobj = charcontrol;
        }

        public void setObjectControl(GameObject charcontrol)
        {
            this.gameobj = charcontrol;
        }
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            this.gameobj.setIdle(true);
        }
        private void checkcapm()
        {
            if((gameobj.transform.position.X > 64*4-32&& gameobj.transform.position.Y>90*3-30&& gameobj.transform.position.X<64*4&& gameobj.transform.position.Y<90*4-20) )
            {
                right = true;
            }
            if ((gameobj.transform.position.X > 64 * 5-32 && gameobj.transform.position.Y > 90 * 3 - 30 && gameobj.transform.position.X < 64 * 5 && gameobj.transform.position.Y < 90 * 4 - 20))
            {
                left = true;
            }
            if ((gameobj.transform.position.X > 64 * 4 - 32 && gameobj.transform.position.Y > 90 * 3 - 32 && gameobj.transform.position.X < 64 * 5-32 && gameobj.transform.position.Y < 90 * 4 - 32))
            {
                top = true;
            }
            if ((gameobj.transform.position.X > 64 * 4 - 32 && gameobj.transform.position.Y > 90 * 3 - 32 && gameobj.transform.position.X < 64 * 5  && gameobj.transform.position.Y < 90 * 4 ))
            {
                talk = true;
                bottom = true;
            }
        }
        private void firewood()
        {
            if ((gameobj.transform.position.X > 32 * 6 && gameobj.transform.position.Y > 32 * 12-20&& gameobj.transform.position.X < 32 * 7 && gameobj.transform.position.Y < 32 * 13-20))
            {
                right = true;
                talkaxe = true;
            }
            if ((gameobj.transform.position.X > 32 * 7 && gameobj.transform.position.Y > 32 * 12 - 20 && gameobj.transform.position.X < 32 * 8 && gameobj.transform.position.Y < 32 * 13-20))
            {
                left = true;
                talkaxe = true;
            }
            if ((gameobj.transform.position.X > 32 * 6 && gameobj.transform.position.Y > 32 * 12 - 20 && gameobj.transform.position.X < 32 * 8 && gameobj.transform.position.Y < 32 * 13 - 20))
            {
                top = true;
                talkaxe = true;
            }
            if ((gameobj.transform.position.X > 32 * 6 && gameobj.transform.position.Y > 32 * 12 - 20 && gameobj.transform.position.X < 32 * 8-10 && gameobj.transform.position.Y < 32 * 13 ))
            {
                bottom = true;
                talkaxe = true;
            }
        }
        private void campfire()
        {
            if ((gameobj.transform.position.X > 32 * 8 && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                right = true;
                talkcapmfire = true;

            }
            if ((gameobj.transform.position.X > 32 * 9 && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 10 +10&& gameobj.transform.position.Y < 32 * 14 -5))
            {
                left = true;
                talkcapmfire = true;
            }
            if ((gameobj.transform.position.X > 32 * 8+10 && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 10 && gameobj.transform.position.Y < 32 * 14 - 10))
            {
                top = true;
                talkcapmfire = true;
            }
            if ((gameobj.transform.position.X > 32 * 8+10 && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 10 && gameobj.transform.position.Y < 32 * 14))
            {
                bottom = true;
                talkcapmfire = true;
            }
        }
        private void rabbit()
        {
            if ((gameobj.transform.position.X > 645&& gameobj.transform.position.Y>420 && gameobj.transform.position.Y < 450 && gameobj.transform.position.X <665))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                atkmon = true;
                right = true;
            }
            if ((gameobj.transform.position.X > 665 && gameobj.transform.position.Y > 420 && gameobj.transform.position.Y < 450 && gameobj.transform.position.X < 695))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                atkmon = true;
                left = true;
            }
            if ((gameobj.transform.position.X > 645 && gameobj.transform.position.Y > 420 && gameobj.transform.position.Y < 440 && gameobj.transform.position.X < 695))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                atkmon = true;
                top = true;
            }
            if ((gameobj.transform.position.X > 645 && gameobj.transform.position.Y > 430 && gameobj.transform.position.Y < 460 && gameobj.transform.position.X < 695))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                atkmon = true;
                bottom = true;
            }
        }
        private void stone()
        {
            if ((gameobj.transform.position.X > 645 && gameobj.transform.position.Y > 172 && gameobj.transform.position.Y < 202 && gameobj.transform.position.X < 665))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                talkstone = true;
                right = true;
            }
            if ((gameobj.transform.position.X > 665 && gameobj.transform.position.Y > 172 && gameobj.transform.position.Y < 202 && gameobj.transform.position.X < 695))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                talkstone = true;
                left = true;
            }
            if ((gameobj.transform.position.X > 645 && gameobj.transform.position.Y > 162 && gameobj.transform.position.Y < 192 && gameobj.transform.position.X < 695))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                talkstone = true;
                top = true;
            }
            if ((gameobj.transform.position.X > 645 && gameobj.transform.position.Y > 172 && gameobj.transform.position.Y < 222 && gameobj.transform.position.X < 695))// && gameobj.transform.position.Y > 32 * 13 - 20 && gameobj.transform.position.X < 32 * 9 && gameobj.transform.position.Y < 32 * 14 - 5))
            {
                talkstone = true;
                bottom = true;
            }
        }
        private void onKeyDown(object sender, KeyEventArgs eventkey)
        {
            x = gameobj.transform.position.X;
            y = gameobj.transform.position.Y;
            o++;
            // if (iscoli == false)
            // {
            if (eventkey.KeyCode == Keys.Left|| eventkey.KeyCode == Keys.A)
            {
                gameobj.transform.position.X = gameobj.transform.position.X - Attribute.speed;
                gameobj.setDirection(direction.Left);
                right = false;
                bottom = false;
                talk = false;
                top = false;
                talkstone = false;
                talkcapmfire = false;
                atkmon = false;
                talkaxe = false;
                talkmission = false;
                talktree = false;
            }
            if (eventkey.KeyCode == Keys.Right|| eventkey.KeyCode == Keys.D)
            {
                gameobj.transform.position.X = gameobj.transform.position.X + Attribute.speed;
                gameobj.setDirection(direction.Right);
                left = false;
                talk = false;
                talkstone = false;
                bottom = false;
                top = false;
                talkcapmfire = false;
                talkmission = false;
                talktree = false;
                atkmon = false;
                talkaxe = false;
            }
            if (eventkey.KeyCode == Keys.Up|| eventkey.KeyCode == Keys.W)
            {
                gameobj.transform.position.Y = gameobj.transform.position.Y - Attribute.speed;
                gameobj.setDirection(direction.Up);
                  bottom = false;
                atkmon = false;
                left = false;
                talkstone = false;
                right = false;
                talk = false;
                talkmission = false;
                talkaxe = false;
                talktree = false;
                talkcapmfire = false;
            }
            if (eventkey.KeyCode == Keys.Down|| eventkey.KeyCode == Keys.S)
            {
                gameobj.transform.position.Y = gameobj.transform.position.Y + Attribute.speed;
                gameobj.setDirection(direction.Down);
              top = false;
                atkmon = false;
                talkstone = false;
                left = false;
                talkaxe = false;
                talktree = false;
                talkmission = false;
                right = false;
                talk = false;
                talkcapmfire = false;
            }
            firewood();
            campfire();
            checkcapm();
            stone();
            rabbit();
                 if (gameobj.transform.position.X < (64*2)+32&& gameobj.transform.position.X >0 )//|| (gameobj.transform.position.X < 32 * 15 && gameobj.transform.position.X > 32 * 14 && gameobj.transform.position.Y > (32 * 14) + 10 && gameobj.transform.position.Y < 32 * 16 - 10))
                {
                    left = true;
                talktree = true;
            }
            if (gameobj.transform.position.X > 750&& gameobj.transform.position.X < 800)//|| (gameobj.transform.position.X>32*14&& gameobj.transform.position.X < 32 * 15&& gameobj.transform.position.Y>(32*14)+10&& gameobj.transform.position.Y<32*16-10))
            {
                
                right = true;
            }
            if (gameobj.transform.position.Y > 510&& gameobj.transform.position.Y < 600)
            {
                top = true;
            }
            if (mission == true)
            {
                if (gameobj.transform.position.Y > 0 && gameobj.transform.position.Y < 120 && gameobj.transform.position.X > 534 && gameobj.transform.position.X < 564)
                {
                    talkmission = true;
                    gameobj.transform.position.Y = y;
                }
            }
            if (gameobj.transform.position.Y > 0 && gameobj.transform.position.Y < 100 && gameobj.transform.position.X > 534 && gameobj.transform.position.X < 564)
            {
                gamewin = true;
            }
            if ( (gameobj.transform.position.Y > 0 && gameobj.transform.position.Y < 120 && gameobj.transform.position.X < 32* 17 && gameobj.transform.position.X >0) || (gameobj.transform.position.Y>0 && gameobj.transform.position.Y < 120 && gameobj.transform.position.X > 564 && gameobj.transform.position.X <800))
            {
                bottom = true;
            } 
            if (left == true)
            {
                gameobj.transform.position.X = x;
            }
            if (right == true)
            {
                gameobj.transform.position.X = x;
            }
            if (top == true)
            {
                gameobj.transform.position.Y = y;
            }
            if (bottom == true)
            {
                    gameobj.transform.position.Y = y;
            }
            // }

            gameobj.setIdle(false);
        }
    }
}