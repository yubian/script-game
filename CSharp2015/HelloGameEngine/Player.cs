using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class Player : GameObject
    {
        public int axe = 0;
        public int wood = 0;
        public int stone = 0;
        public int rabbit = 0;
        public int apple = 0;
        public int food = 5;
        private string Name = "Coding";
        private int MaxHealth = 110;
        private int MaxEmotion = 100;
        private int Health = 110;
        private int Emotion = 100;
        private int lv = 1;
        private int exp = 0;
        private int maxexp = 50;
        private int Logic = -9;
        private int Tech = 3;
        private int Creativity = 1;
        private int Communication = -10;
        private int Sincerity = 1;
        private int Memory = -10;
        private int Effort = 2;
        private int Generous = 1;
        private int money = 0;
        private int point = 5;
        public int getPoint()
        {
            return this.point;
        }
        public void setPoint(int p)
        {
            this.point = p;
        }
        public int getMoney() { return this.money; }
        public void setMoney(int mo) { this.money = mo; }
        public int getMaxExp(){return this.maxexp;}
        public void setMaxExp(int exp){this.maxexp = exp;}
        public int getLv() { return this.lv;}
        public int getExp()
        {
            return this.exp;
        }
        public void setLv(int lv)
        {
            this.lv = lv;
        }
        public void setExp(int exp)
        {
            this.exp = exp;
        }
        public string getName()
        {
            return this.Name;
        }
        public int getHealth()
        {
            return this.Health;
        }
        public int getEmotion()
        {
            return this.Emotion;
        }
        public int getMaxHealth()
        {
            return this.MaxHealth;
        }
        public int getMaxEmotion()
        {
            return this.MaxEmotion;
        }
        public void setMaxHealth(int hp)
        {
            this.MaxHealth = hp;
        }
        public void setMaxEmotion(int emo)
        {
            this.MaxEmotion = emo;
        }
        public int getLogic()
        {
            return this.Logic;
        }
        public int getTech()
        {
            return this.Tech;
        }
        public int getCreativity()
        {
            return this.Creativity;
        }
        public int getCommunication()
        {
            return this.Communication;
        }
        public int getSincerity()
        {
            return this.Sincerity;
        }
        public int getMemory()
        {
            return this.Memory;
        }
        public int getEffort()
        {
            return this.Effort;
        }
        public int getGenerous()
        {
            return this.Generous;
        }
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setHealth(int hp)
        {
            this.Health = hp;
        }
        public void setEmotion(int emo)
        {
            this.Emotion = emo;
        }
        public void setLogic(int logic)
        {
            this.Logic = logic;
        }
        public void setTech(int tech)
        {
            this.Tech = tech;
        }
        public void setCreativity(int Creativity)
        {
            this.Creativity = Creativity;
        }
        public void setCommunication(int Communication)
        {
            this.Communication = Communication;
        }
        public void setSincerity(int Sincerity)
        {
            this.Sincerity = Sincerity;
        }
        public void setMemory(int Memory)
        {
            this.Memory = Memory;
        }
        public void setEffort(int Effort)
        {
            this.Effort = Effort;
        }
        public void setGenerous(int Generous)
        {
            this.Generous = Generous;
        }
        public Player(RenderTileObject robj) : base(robj)
        {
            this.objRender.setFrameIndex(1);
        }

        public override void animate()
        {
            if(idle == false)
            {
                if (this.direction == direction.Up)
                    this.startframe = 9;
                if (this.direction == direction.Down)
                    this.startframe = 0;
                if (this.direction == direction.Left)
                    this.startframe = 3;
                if (this.direction == direction.Right)
                    this.startframe = 6;

                base.animate();
            }
            
        }

        public override void setIdle(bool idle)
        {
            base.setIdle(idle);

            if(this.idle == true)
            {
                if (this.direction == direction.Up)
                    this.objRender.setFrameIndex(10);
                if (this.direction == direction.Down)
                    this.objRender.setFrameIndex(1);
                if (this.direction == direction.Left)
                    this.objRender.setFrameIndex(4);
                if (this.direction == direction.Right)
                    this.objRender.setFrameIndex(7);
            }
            
        }
    }
}
