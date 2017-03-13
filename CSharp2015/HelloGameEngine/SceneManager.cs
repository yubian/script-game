using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HelloGameEngine
{

    class SceneManager : Form
    {
        private int kpo = 0;
        private const int fps = 60;
        private int counter;
        private Renderer render;
        private Controller control;
        private Timer gameTimer;
        private GraphDrawer gdrawer;
        private Graph graph;
        private Player player;
        private GameObject box;
        private NPC npc;
        private Map map;
        private int k = 0;
        private bool state=true;
        private PictureBox chbox;
        private PictureBox hp;
        private PictureBox mp;
        private PictureBox box1;
        private PictureBox box2;
        private PictureBox box4;
        private PictureBox box3;
        public PictureBox box5;
        private PictureBox box6;
        private PictureBox box7;
        private bool state1 = true;
        private PictureBox scenebox;
        private PictureBox box8;
        private bool scene = true;
        private PictureBox bgtxt;
        private PictureBox chtxt1;
        private PictureBox chtxt2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private PictureBox pointbox;
        private Button button1;
        public static RenderTileObject mapss;
        private int mission = 3;
        private Monster mon;
        private int cc = 0;
        private Label label1;
        private PictureBox namebox;
        private PictureBox bar;
        private Label hpbar;
        private Label mpbar;
        private Button next;
        private PictureBox item;
        private PictureBox axe;
        private PictureBox wood;
        private PictureBox stone;
        private PictureBox rabbitmeat;
        private PictureBox food;
        private Button use;
        private PictureBox apple;
        private PictureBox select;
        private int kk = 32;
        private bool axefristuse = true;
        private int iditem = 1;
        private PictureBox talk;
        private Label talktxt;
        private bool axeuse=false;
        private Label textbok;
        private int talkid = 0;
        private PictureBox scenepop;
        private PictureBox popup;
        private Label label2;
        private PictureBox bgapple;
        private Label txtapple;
        private PictureBox bgpoint;
        private Label point;
        private bool fristtalk = true;
        public SceneManager ()
        {this.control = new Controller(this);
           
            this.Size = new Size(800, 615);
            map = new Map();
            this.render = new Renderer(this);

            
            
           mapck();maplay2();
          
            Image boximage = Image.FromFile(@"images/tile/maptile.png");
            mapss = new RenderTileObject(boximage, 64, 32);
            mapss.setBoundPosition(64 * 0, 32*3);
            mapss.setFrameIndex(1);
            render.addtoRender(mapss);
            mapss = new RenderTileObject(boximage, 64, 32);
            mapss.setBoundPosition(64 * 1, 32 * 3);
            mapss.setFrameIndex(1);
            render.addtoRender(mapss);
            Image boximage1 = Image.FromFile(@"images/camp.png");
            mapss = new RenderTileObject(boximage1, 64, 90);
            mapss.setBoundPosition(64 * 4, 90 * 3);
            mapss.setFrameIndex(0);
            render.addtoRender(mapss);
            Image boximage2 = Image.FromFile(@"images/tile/maptile.png");
            mapss = new RenderTileObject(boximage2, 32, 64);
            mapss.setBoundPosition(32 * 17, 60 * 1);
            mapss.setFrameIndex(8);
            render.addtoRender(mapss);
           

            InitializeComponent();
            
            this.graph = new Graph();
          //  this.graph.show(true);
            //this.gdrawer = new GraphDrawer(this, graph);//ตัววาดกราฟ
            Image chimage = Image.FromFile(@"images/ch/ch.png");
            RenderTileObject ch = new RenderTileObject(chimage, 32, 32);
            this.player = new Player(ch);
            player.setPosition(new Vector2(600, 400));
            this.control.setObjectControl(this.player);
            Image imgnpc = Image.FromFile(@"images/tile/vx_chara03_a.png");
            Image imgmon = Image.FromFile(@"images/tile/Aindra.png");
            //    RenderObject boxro = new RenderObject(boximage);
            //this.box = new GameObject(boxro);
            // this.box.setPosition(new Vector2(50, 50));
            // this.box.setStartFrame(1);
            // this.box.setAnimationrate(1);
            RenderTileObject chmon = new RenderTileObject(imgmon, 32, 32);
            chmon.setFrameIndex(1);
            mon = new Monster(chmon);
            mon.game.setPosition(new Vector2(32*21, 32*14));
            RenderTileObject chnpc = new RenderTileObject(imgnpc, 32, 48);//คนละตำแหน่งกันจึงต้องสร้างobjขึ้นมาใหม่
            chnpc.setFrameIndex(7);
            this.npc = new NPC(chnpc, this.graph, 1);
            npc.gameobject.setPosition(new Vector2(32*9, 32*10));
            render.addtoRender(chmon);
            //render.addtoRender(this.graph);
           // render.addtoRender(boxro);
            render.addtoRender(chnpc);
            render.addtoRender(ch);
            mapck1();
           
            // this.Paint += new PaintEventHandler(Painter);
             maplay1();
            initime();
        }
     /* private void Painter(object sender, PaintEventArgs e)
           {
          Graphics g = e.Graphics;
         Image tilemap = Image.FromFile(@"images/tilea2.png");
           Brush tx = new TextureBrush(tilemap, new Rectangle(0, 0, 32, 32));
          e.Graphics.FillRectangle(tx, ClientRectangle);
             }
             */
        public void mapck() {
            Image boximage = Image.FromFile(@"images/tile/maptile.png");
        for (int i = 0; i < 10; i++)
            {
               
                for (int j = 0; j < 13; j++)
                {
                    RenderTileObject mapss = new RenderTileObject(boximage, 64, 96);
                    mapss.setBoundPosition(64 * j, k);
                    mapss.setFrameIndex(5);
                    render.addtoRender(mapss);
                    
                } k= i * 96;
            }
           
        }
        public void mapck1()
        {
            Image boximage = Image.FromFile(@"images/tile/maptile.png");
            for (int i = 0; i < map.maphiegh(); i++)
            {

                for (int j = 0; j < map.mapwidth(); j++)
                {
                    if (map.getmaps(i, j) == 1)
                    {
                        RenderTileObject mapss = new RenderTileObject(boximage, 32, 32);
                        mapss.setBoundPosition(32 * j, k);
                        mapss.setFrameIndex(19);
                        render.addtoRender(mapss);
                    }
                    if (map.getmaps(i, j) == 2)
                    {
                        RenderTileObject mapss = new RenderTileObject(boximage, 32, 32);
                        mapss.setBoundPosition(32 * j, k);
                        mapss.setFrameIndex(5);
                        render.addtoRender(mapss);
                    }
                    if (map.getmaps(i, j) == 3)
                    {
                        RenderTileObject mapss = new RenderTileObject(boximage, 32, 32);
                        mapss.setBoundPosition(32 * j, k);
                        mapss.setFrameIndex(13);
                        render.addtoRender(mapss);
                    }
                    if (map.getmaps(i, j) == 4)
                    {
                        RenderTileObject mapss = new RenderTileObject(boximage, 32, 32);
                        mapss.setBoundPosition(32 * j, k);
                        mapss.setFrameIndex(7);
                        render.addtoRender(mapss);
                    }

                }
                k = i * 32;
            }

        }
        public void maplay1()
        {
            
            Image boximage = Image.FromFile(@"images/tile/maptile.png");
            for (int i = 0; i < map.maphiegh1(); i++)
            {

                for (int j = 0; j < map.mapwidth1(); j++)
                {
                    if (map.getmaps1(i,j) == 1)
                    {
                        mapss = new RenderTileObject(boximage, 64,64);
                        mapss.setBoundPosition(64 * j, k);
                        mapss.setFrameIndex(0);
                        render.addtoRender(mapss);
                    }
                    if (map.getmaps1(i, j) == 2)
                    {
                        mapss = new RenderTileObject(boximage, 32, 64);
                        mapss.setBoundPosition(64 * j, k);
                        mapss.setFrameIndex(3);
                        render.addtoRender(mapss);
                    }
                    if (map.getmaps1(i, j) == 3)
                    {
                        mapss = new RenderTileObject(boximage, 64, 64);
                        mapss.setBoundPosition(64 * j, k);
                        mapss.setFrameIndex(1);
                        render.addtoRender(mapss);
                    }

                }
                k = i * 64;
            }

        }
        public void maplay2()
        {

            Image boximage = Image.FromFile(@"images/tile/maptile.png");
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 26; j++)
                {
                    if (map.getmaps2(i, j) == 1)
                    {
                        mapss = new RenderTileObject(boximage, 32, 64);
                        mapss.setBoundPosition(32 * j, k);
                        mapss.setFrameIndex(6);
                        render.addtoRender(mapss);
                    }

                }
                k = i * 60;
            }
        }
        public void initime()
        {
            this.gameTimer = new Timer();
            this.gameTimer.Interval = 1000/fps;
            this.gameTimer.Tick += new EventHandler(onUpdate);
           
            this.gameTimer.Start();
            
        }

        public static Bitmap textimg(string txt, string fontn, int fontsize)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
           
            Font font = new Font(fontn, fontsize);
            SizeF stringSize = g.MeasureString(txt, font);
            bmp = new Bitmap(bmp, (int)stringSize.Width, (int)stringSize.Height);
            g = Graphics.FromImage(bmp);
            g.DrawString(txt, font, Brushes.White, 0, 0);
            font.Dispose();
            g.Flush();
            g.Dispose();
            return bmp;     
        }    
   
        public void showbutton()
        {
            if (player.getPoint() <= 0)
            {
                button1.Hide();
                button2.Hide();
                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();
            }
            if (player.getPoint() > 0)
            {
                button1.Show();
                button2.Show();
                button3.Show();
                button4.Show();
                button5.Show();
                button6.Show();
                button7.Show();
                button8.Show();
            }
        }
        private void use_Click(object sender, EventArgs e)
        {
            if (iditem == 1) {
                if (player.axe > 0 && axefristuse == true)
                {
                    player.axe = 0;
                    axefristuse = false;
                    axeuse = true;
                    MessageBox.Show("ติดตั้งเรียบร้อบ");
                }
            }
            if (iditem == 2)
            {
                if (player.wood > 0)
                {
                    player.wood = player.wood - 1;
                    player.setEmotion(player.getEmotion() + 5);
                    if (player.getEmotion() > player.getMaxEmotion())
                    {
                        player.setEmotion(player.getMaxEmotion());
                    }
                }
            }
            if (iditem == 3)
            {
                if (player.stone > 0)
                {
                    player.stone = player.stone - 1;
                    player.setEmotion(player.getEmotion() + 5);
                    if (player.getEmotion() > player.getMaxEmotion())
                    {
                        player.setEmotion(player.getMaxEmotion());
                    }
                }
            }
            if (iditem == 4)
            {
                if (player.rabbit > 0)
                {
                    player.rabbit = player.rabbit - 1;
                    player.setEmotion(player.getEmotion() +10);
                    player.setHealth(player.getHealth() - 20);
                    if (player.getEmotion() > player.getMaxEmotion())
                    {
                        player.setEmotion(player.getMaxEmotion());
                    }
                    if (player.getHealth() <0)
                    {
                        player.setHealth(0);                    
                    }
                }
            }
            if (iditem == 5)
            {
                if (player.food > 0)
                {
                    player.food = player.food - 1;
                    player.setHealth(player.getHealth() + 30);
                    if (player.getHealth() > player.getMaxHealth())
                    {
                        player.setHealth(player.getMaxHealth());
                    }
                }
            }
            if (iditem == 6)
            {
                if (player.apple > 0)
                {
                    player.apple = player.apple - 1;
                    player.setEmotion(player.getEmotion() + 40);
                    if (player.getEmotion() > player.getMaxEmotion())
                    {
                        player.setEmotion(player.getMaxEmotion());
                    }
                }
            }
            state = true;
            statusshow();
        }
        public void statusshow()
        {
            if (state == true)
            {
               
                bgpoint.Hide();
                bgapple.Hide();
                point.Hide();
                apple.Hide();
                bar.Hide();
                mpbar.Hide();
                hpbar.Hide();
                showbutton();
                chbox.Show();
                select.Show();
                namebox.Show();
                namebox.Image = textimg(player.getName(), "Bookman Old Style", 120);
                namebox.SizeMode = PictureBoxSizeMode.StretchImage;
                pointbox.Show();
                pointbox.Image = textimg("Point    " + player.getPoint(), "Bookman Old Style", 120);
                pointbox.SizeMode = PictureBoxSizeMode.StretchImage;
                hp.Show();
                hp.Image = textimg("Health    " + player.getHealth() + "/" + player.getMaxHealth(), "Bookman Old Style", 120);
                hp.SizeMode = PictureBoxSizeMode.StretchImage;
                mp.Show();
                mp.Image = textimg("Emotion   " + player.getEmotion() + "/" + player.getMaxEmotion(), "Bookman Old Style", 120);
                mp.SizeMode = PictureBoxSizeMode.StretchImage;
                box1.Show();
                box1.Image = textimg("Logic                 " + player.getLogic(), "Bookman Old Style", 120);
                box1.SizeMode = PictureBoxSizeMode.StretchImage;
                box2.Show();
                box2.Image = textimg("Creativity         " + player.getCreativity(), "Bookman Old Style", 120);
                box2.SizeMode = PictureBoxSizeMode.StretchImage;
                box3.Show();
                box3.Image = textimg("Communication      " + player.getCommunication(), "Bookman Old Style", 120);
                box3.SizeMode = PictureBoxSizeMode.StretchImage;
                box4.Show();
                box4.Image = textimg("Tech               " + player.getTech(), "Bookman Old Style", 120);
                box4.SizeMode = PictureBoxSizeMode.StretchImage;
                box5.Show();
                box5.Image = textimg("Sincerity          " + player.getSincerity(), "Bookman Old Style", 120);
                box5.SizeMode = PictureBoxSizeMode.StretchImage;
                box6.Show();
                box6.Image = textimg("Generous           " + player.getGenerous(), "Bookman Old Style", 120);
                box6.SizeMode = PictureBoxSizeMode.StretchImage;
                box7.Show();
                box7.Image = textimg("Memory             " + player.getMemory(), "Bookman Old Style", 120);
                box7.SizeMode = PictureBoxSizeMode.StretchImage;
                box8.Show();
                box8.Image = textimg("Effort             " + player.getEffort(), "Bookman Old Style", 120);
                box8.SizeMode = PictureBoxSizeMode.StretchImage;
                axe.Show();
                axe.Image = textimg("Axe                     " + player.axe, "Bookman Old Style", 120);
                axe.SizeMode = PictureBoxSizeMode.StretchImage;
                wood.Show();
                wood.Image = textimg("Woods                   " + player.wood, "Bookman Old Style", 120);
                wood.SizeMode = PictureBoxSizeMode.StretchImage;
                item.Show();
                item.Image = textimg("Items", "Bookman Old Style", 120);
                item.SizeMode = PictureBoxSizeMode.StretchImage;
                stone.Show();
                stone.Image = textimg("Stone                   " + player.stone, "Bookman Old Style", 120);
                stone.SizeMode = PictureBoxSizeMode.StretchImage;
                apple.Show();
                apple.Image = textimg("Apple                   " + player.apple, "Bookman Old Style", 120);
                apple.SizeMode = PictureBoxSizeMode.StretchImage;
                rabbitmeat.Show();
                rabbitmeat.Image = textimg("Rabbit Meat             " + player.rabbit, "Bookman Old Style", 120);
                rabbitmeat.SizeMode = PictureBoxSizeMode.StretchImage;
                food.Show();
                food.Image = textimg("Food                     " + player.food, "Bookman Old Style", 120);
                food.SizeMode = PictureBoxSizeMode.StretchImage;
                use.Show();

                scenebox.Show(); state = false;
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            missionpass();
            if (state == false)
            {
                talk.Show();
                talktxt.Show();
                select.Hide();
                bar.Show();
                hpbar.Show();
                mpbar.Show();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                use.Enabled = false;
                namebox.Hide();
                chbox.Hide();
                hp.Hide();
                mp.Hide();
                box1.Hide();
                box2.Hide();
                box3.Hide();
                box4.Hide();
                box5.Hide();
                box6.Hide();
                box7.Hide();
                box8.Hide();
                button1.Hide();
                button2.Hide();
                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();
                scenebox.Hide();
                pointbox.Hide();
                axe.Hide();
                wood.Hide();
                item.Hide();
                stone.Hide();
                apple.Hide();
                rabbitmeat.Hide();
                food.Hide();
                use.Hide();
                this.gameTimer.Start();
                state = true;
            }
            else if (state == true)
            {
                talk.Hide();
                talktxt.Hide();
                label2.Hide();
                label2.Hide();
                popup.Hide();
                use.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                statusshow();
                state = false;
                this.gameTimer.Stop();
            }
        }
       
        private int uphp()
        {
            cc = control.o;
            if (cc >= kk)
            {
                kk += 32;
                player.setHealth(player.getHealth() - 5);
            }
            return player.getHealth();
        }
 private void talktrue()
        {
            if (control.talk == true)
            {
                talkid = 1;
                talk.Location = new Point(302, 310);
                talktxt.Text = "Talk";
                talktxt.Location = new Point(309, 315); talktxt.Show();
                talk.Show();

               

            }
            if (control.talktree == true)
            {
                talkid = 2;
                talktxt.Location = new Point(139, 284);
                talktxt.Text = "Cut";
                talk.Location = new Point(132, 279); talktxt.Show();
                talk.Show();
               

            }
            if (control.talkaxe == true)
            {
                talkid = 3;
                talktxt.Location = new Point(244, 371);
                talktxt.Text = "Pick";
                talk.Location = new Point(237, 366);talktxt.Show();
                talk.Show();
                

            }
            if (control.talkcapmfire == true)
            {
                talkid = 4;
                talktxt.Location = new Point(304, 403);
                talktxt.Text = "Use";
                talk.Location = new Point(297, 398); talktxt.Show();
                talk.Show();
               

            }
            if (control.atkmon == true)
            {
                talkid = 5;
                talktxt.Location = new Point(691, 442);
                talktxt.Text = "Kill";
                talk.Location = new Point(684, 437);
               
                talktxt.Show(); talk.Show();

            }
            if (control.talkstone == true)
            {
                talkid = 6;
                talktxt.Location = new Point(697, 185);
                talktxt.Text = "Pick";
                talk.Location = new Point(690, 180);
                
                talktxt.Show();talk.Show();

            }
            if (control.talkmission == true)
            {
                talkid = 7;
                talktxt.Location = new Point(558, 51);
                talktxt.Text = ". . .";
                talk.Location = new Point(551, 44);
                
                talktxt.Show();talk.Show();

            }
            else if (control.talkmission == false&& control.talk==false&&
                control.talkaxe==false&& control.talkcapmfire==false&& 
                control.talkstone==false&& control.talktree==false&& control.atkmon==false)
            {
                
                talkid = 0;
                talk.Hide();
                talktxt.Hide();
               
            }

        }
        private void closepopup()
        {
            if(control.talkmission == false && control.talk == false &&
                control.talkaxe == false && control.talkcapmfire == false &&
                control.talkstone == false && control.talktree == false && control.atkmon == false)
            {
                
                bgpoint.Hide();
                bgapple.Hide();
                point.Hide();
                txtapple.Hide();
                label2.Hide();
                popup.Hide();
            }
        }
        private void onUpdate(object sender, EventArgs e)
        {
                talktrue();

                closepopup();
                hpbar.Text = "Health       " + uphp() + "/" + player.getMaxHealth();
                mpbar.Text = "Emotion    " + player.getEmotion() + "/" + player.getMaxEmotion();
                this.counter++;
                if (counter > fps)
                    this.counter = 0;

                render.render(this.CreateGraphics());
                LogicUpdate();
            
            if (control.gamewin == true)
            {
                this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new Point(303, 252);
                label2.Text = "You win";
                label2.Show();
               
                popup.Show();
                scenepop.Show();
                gameTimer.Stop();
            }if (player.getHealth() <= 0 || player.getEmotion() <= 0) {
                this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new Point(273, 252);
                label2.Text = "Game Over";
                label2.Show();

                popup.Show();
                scenepop.Show();
                gameTimer.Stop();
            }

        }
        private void LogicUpdate()
        {
            player.onUpdate(this.counter);
            npc.update(this.counter);
            mon.update(this.counter);
         //   box.onUpdate(this.counter);
         //   box.setIdle(false);

            
        }
        private void missionpass() {
           
            if (player.getLogic() > mission && player.getCommunication() > mission && player.getCreativity() > mission && player.getEffort() > mission && player.getGenerous() > mission
                && player.getMemory() > mission && player.getTech() > mission && player.getSincerity() > mission)
            { control.mission = false; }
        }
        private void button88(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setEffort(player.getEffort() + 1);
                state = true;
                player.setPoint(player.getPoint() - 1);
                statusshow();
                
            }
        }

        private void button77(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setGenerous(player.getGenerous() + 1);
                state = true;
                player.setPoint(player.getPoint() - 1);
                statusshow();
               
            }
        }

        private void button66(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setPoint(player.getPoint() - 1);
                player.setTech(player.getTech() + 1);
                state = true;
                statusshow();
            }
        }

        private void button55(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setPoint(player.getPoint() - 1);
                player.setCreativity(player.getCreativity() + 1);
                state = true;
                statusshow();
            }
        }

        private void button44(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setPoint(player.getPoint() - 1);
                player.setMemory(player.getMemory() + 1);
                state = true;
                statusshow();
            }
        }

        private void button33(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setPoint(player.getPoint() - 1);
                player.setSincerity(player.getSincerity() + 1);
                state = true;
                statusshow();
            }
        }

        private void button22(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setPoint(player.getPoint() - 1);
                player.setCommunication(player.getCommunication() + 1);
                state = true;
                statusshow();
            }
        }

        private void button11(object sender, EventArgs e)
        {
            if (player.getPoint() > 0)
            {
                player.setPoint(player.getPoint() - 1);
                player.setLogic(player.getLogic() + 1);
                state = true;
                statusshow();
            }
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneManager));
            this.chbox = new System.Windows.Forms.PictureBox();
            this.scenebox = new System.Windows.Forms.PictureBox();
            this.hp = new System.Windows.Forms.PictureBox();
            this.mp = new System.Windows.Forms.PictureBox();
            this.box1 = new System.Windows.Forms.PictureBox();
            this.box2 = new System.Windows.Forms.PictureBox();
            this.box4 = new System.Windows.Forms.PictureBox();
            this.box3 = new System.Windows.Forms.PictureBox();
            this.box5 = new System.Windows.Forms.PictureBox();
            this.box6 = new System.Windows.Forms.PictureBox();
            this.box7 = new System.Windows.Forms.PictureBox();
            this.box8 = new System.Windows.Forms.PictureBox();
            this.bgtxt = new System.Windows.Forms.PictureBox();
            this.chtxt1 = new System.Windows.Forms.PictureBox();
            this.chtxt2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.pointbox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.namebox = new System.Windows.Forms.PictureBox();
            this.bar = new System.Windows.Forms.PictureBox();
            this.hpbar = new System.Windows.Forms.Label();
            this.mpbar = new System.Windows.Forms.Label();
            this.next = new System.Windows.Forms.Button();
            this.item = new System.Windows.Forms.PictureBox();
            this.axe = new System.Windows.Forms.PictureBox();
            this.wood = new System.Windows.Forms.PictureBox();
            this.stone = new System.Windows.Forms.PictureBox();
            this.rabbitmeat = new System.Windows.Forms.PictureBox();
            this.food = new System.Windows.Forms.PictureBox();
            this.use = new System.Windows.Forms.Button();
            this.apple = new System.Windows.Forms.PictureBox();
            this.select = new System.Windows.Forms.PictureBox();
            this.talk = new System.Windows.Forms.PictureBox();
            this.talktxt = new System.Windows.Forms.Label();
            this.textbok = new System.Windows.Forms.Label();
            this.scenepop = new System.Windows.Forms.PictureBox();
            this.popup = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bgapple = new System.Windows.Forms.PictureBox();
            this.txtapple = new System.Windows.Forms.Label();
            this.bgpoint = new System.Windows.Forms.PictureBox();
            this.point = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgtxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtxt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtxt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rabbitmeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.food)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.talk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenepop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgapple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgpoint)).BeginInit();
            this.SuspendLayout();
            // 
            // chbox
            // 
            this.chbox.BackColor = System.Drawing.Color.Transparent;
            this.chbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbox.BackgroundImage")));
            this.chbox.Image = ((System.Drawing.Image)(resources.GetObject("chbox.Image")));
            this.chbox.Location = new System.Drawing.Point(12, 51);
            this.chbox.Name = "chbox";
            this.chbox.Size = new System.Drawing.Size(150, 150);
            this.chbox.TabIndex = 3;
            this.chbox.TabStop = false;
            this.chbox.Visible = false;
            // 
            // scenebox
            // 
            this.scenebox.BackColor = System.Drawing.Color.Transparent;
            this.scenebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scenebox.BackgroundImage")));
            this.scenebox.Enabled = false;
            this.scenebox.Location = new System.Drawing.Point(0, -36);
            this.scenebox.Name = "scenebox";
            this.scenebox.Size = new System.Drawing.Size(800, 615);
            this.scenebox.TabIndex = 1;
            this.scenebox.TabStop = false;
            this.scenebox.Visible = false;
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.Color.Transparent;
            this.hp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hp.BackgroundImage")));
            this.hp.Location = new System.Drawing.Point(168, 142);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(250, 23);
            this.hp.TabIndex = 5;
            this.hp.TabStop = false;
            this.hp.Visible = false;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.Color.Transparent;
            this.mp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mp.BackgroundImage")));
            this.mp.Location = new System.Drawing.Point(168, 171);
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(250, 23);
            this.mp.TabIndex = 6;
            this.mp.TabStop = false;
            this.mp.Visible = false;
            // 
            // box1
            // 
            this.box1.BackColor = System.Drawing.Color.Transparent;
            this.box1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box1.BackgroundImage")));
            this.box1.Location = new System.Drawing.Point(168, 242);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(250, 23);
            this.box1.TabIndex = 7;
            this.box1.TabStop = false;
            this.box1.Visible = false;
            // 
            // box2
            // 
            this.box2.BackColor = System.Drawing.Color.Transparent;
            this.box2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box2.BackgroundImage")));
            this.box2.Location = new System.Drawing.Point(168, 357);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(250, 23);
            this.box2.TabIndex = 8;
            this.box2.TabStop = false;
            this.box2.Visible = false;
            // 
            // box4
            // 
            this.box4.BackColor = System.Drawing.Color.Transparent;
            this.box4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box4.BackgroundImage")));
            this.box4.Location = new System.Drawing.Point(168, 386);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(250, 23);
            this.box4.TabIndex = 9;
            this.box4.TabStop = false;
            this.box4.Visible = false;
            // 
            // box3
            // 
            this.box3.BackColor = System.Drawing.Color.Transparent;
            this.box3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box3.BackgroundImage")));
            this.box3.Location = new System.Drawing.Point(168, 270);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(250, 23);
            this.box3.TabIndex = 10;
            this.box3.TabStop = false;
            this.box3.Visible = false;
            // 
            // box5
            // 
            this.box5.BackColor = System.Drawing.Color.Transparent;
            this.box5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box5.BackgroundImage")));
            this.box5.Location = new System.Drawing.Point(168, 299);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(250, 23);
            this.box5.TabIndex = 11;
            this.box5.TabStop = false;
            this.box5.Visible = false;
            // 
            // box6
            // 
            this.box6.BackColor = System.Drawing.Color.Transparent;
            this.box6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box6.BackgroundImage")));
            this.box6.Location = new System.Drawing.Point(168, 415);
            this.box6.Name = "box6";
            this.box6.Size = new System.Drawing.Size(250, 23);
            this.box6.TabIndex = 12;
            this.box6.TabStop = false;
            this.box6.Visible = false;
            // 
            // box7
            // 
            this.box7.BackColor = System.Drawing.Color.Transparent;
            this.box7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box7.BackgroundImage")));
            this.box7.Location = new System.Drawing.Point(168, 328);
            this.box7.Name = "box7";
            this.box7.Size = new System.Drawing.Size(250, 23);
            this.box7.TabIndex = 13;
            this.box7.TabStop = false;
            this.box7.Visible = false;
            // 
            // box8
            // 
            this.box8.BackColor = System.Drawing.Color.Transparent;
            this.box8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box8.BackgroundImage")));
            this.box8.Location = new System.Drawing.Point(168, 445);
            this.box8.Name = "box8";
            this.box8.Size = new System.Drawing.Size(250, 23);
            this.box8.TabIndex = 14;
            this.box8.TabStop = false;
            this.box8.Visible = false;
            // 
            // bgtxt
            // 
            this.bgtxt.BackColor = System.Drawing.Color.Transparent;
            this.bgtxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bgtxt.BackgroundImage")));
            this.bgtxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bgtxt.Location = new System.Drawing.Point(0, 427);
            this.bgtxt.Name = "bgtxt";
            this.bgtxt.Size = new System.Drawing.Size(787, 153);
            this.bgtxt.TabIndex = 17;
            this.bgtxt.TabStop = false;
            this.bgtxt.Visible = false;
            // 
            // chtxt1
            // 
            this.chtxt1.BackColor = System.Drawing.Color.Transparent;
            this.chtxt1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chtxt1.BackgroundImage")));
            this.chtxt1.Image = ((System.Drawing.Image)(resources.GetObject("chtxt1.Image")));
            this.chtxt1.Location = new System.Drawing.Point(-2, 430);
            this.chtxt1.Name = "chtxt1";
            this.chtxt1.Size = new System.Drawing.Size(148, 150);
            this.chtxt1.TabIndex = 18;
            this.chtxt1.TabStop = false;
            this.chtxt1.Visible = false;
            // 
            // chtxt2
            // 
            this.chtxt2.BackColor = System.Drawing.Color.Transparent;
            this.chtxt2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chtxt2.BackgroundImage")));
            this.chtxt2.Image = ((System.Drawing.Image)(resources.GetObject("chtxt2.Image")));
            this.chtxt2.Location = new System.Drawing.Point(635, 430);
            this.chtxt2.Name = "chtxt2";
            this.chtxt2.Size = new System.Drawing.Size(150, 150);
            this.chtxt2.TabIndex = 19;
            this.chtxt2.TabStop = false;
            this.chtxt2.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(432, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 20;
            this.button1.TabStop = false;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button11);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(432, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 21;
            this.button2.TabStop = false;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button22);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(432, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 22;
            this.button3.TabStop = false;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button33);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(432, 328);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 23;
            this.button4.TabStop = false;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button44);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(432, 357);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 24;
            this.button5.TabStop = false;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button55);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Location = new System.Drawing.Point(432, 386);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 25;
            this.button6.TabStop = false;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button66);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(432, 415);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 26;
            this.button7.TabStop = false;
            this.button7.Text = "+";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button77);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(432, 445);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 23);
            this.button8.TabIndex = 27;
            this.button8.TabStop = false;
            this.button8.Text = "+";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button88);
            // 
            // pointbox
            // 
            this.pointbox.BackColor = System.Drawing.Color.Transparent;
            this.pointbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pointbox.BackgroundImage")));
            this.pointbox.Location = new System.Drawing.Point(268, 477);
            this.pointbox.Name = "pointbox";
            this.pointbox.Size = new System.Drawing.Size(150, 23);
            this.pointbox.TabIndex = 28;
            this.pointbox.TabStop = false;
            this.pointbox.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(9, 523);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 44);
            this.label1.TabIndex = 31;
            this.label1.Text = "Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // namebox
            // 
            this.namebox.BackColor = System.Drawing.Color.Transparent;
            this.namebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("namebox.BackgroundImage")));
            this.namebox.Location = new System.Drawing.Point(168, 51);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(100, 30);
            this.namebox.TabIndex = 32;
            this.namebox.TabStop = false;
            this.namebox.Visible = false;
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.Transparent;
            this.bar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bar.BackgroundImage")));
            this.bar.Location = new System.Drawing.Point(606, 12);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(166, 60);
            this.bar.TabIndex = 33;
            this.bar.TabStop = false;
            // 
            // hpbar
            // 
            this.hpbar.BackColor = System.Drawing.Color.Transparent;
            this.hpbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpbar.ForeColor = System.Drawing.Color.White;
            this.hpbar.Image = ((System.Drawing.Image)(resources.GetObject("hpbar.Image")));
            this.hpbar.Location = new System.Drawing.Point(615, 20);
            this.hpbar.Name = "hpbar";
            this.hpbar.Size = new System.Drawing.Size(147, 22);
            this.hpbar.TabIndex = 34;
            this.hpbar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mpbar
            // 
            this.mpbar.BackColor = System.Drawing.Color.Transparent;
            this.mpbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mpbar.ForeColor = System.Drawing.Color.White;
            this.mpbar.Image = ((System.Drawing.Image)(resources.GetObject("mpbar.Image")));
            this.mpbar.Location = new System.Drawing.Point(615, 42);
            this.mpbar.Name = "mpbar";
            this.mpbar.Size = new System.Drawing.Size(147, 22);
            this.mpbar.TabIndex = 35;
            this.mpbar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.Transparent;
            this.next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("next.BackgroundImage")));
            this.next.Enabled = false;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next.ForeColor = System.Drawing.Color.White;
            this.next.Location = new System.Drawing.Point(586, 550);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(42, 23);
            this.next.TabIndex = 36;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = false;
            this.next.Visible = false;
            this.next.Click += new System.EventHandler(this.talk_Click);
            // 
            // item
            // 
            this.item.BackColor = System.Drawing.Color.Transparent;
            this.item.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("item.BackgroundImage")));
            this.item.Location = new System.Drawing.Point(483, 205);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(75, 30);
            this.item.TabIndex = 37;
            this.item.TabStop = false;
            this.item.Visible = false;
            // 
            // axe
            // 
            this.axe.BackColor = System.Drawing.Color.Transparent;
            this.axe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("axe.BackgroundImage")));
            this.axe.Location = new System.Drawing.Point(483, 241);
            this.axe.Name = "axe";
            this.axe.Size = new System.Drawing.Size(200, 23);
            this.axe.TabIndex = 38;
            this.axe.TabStop = false;
            this.axe.Visible = false;
            this.axe.Click += new System.EventHandler(this.axe_Click);
            // 
            // wood
            // 
            this.wood.BackColor = System.Drawing.Color.Transparent;
            this.wood.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("wood.BackgroundImage")));
            this.wood.Location = new System.Drawing.Point(483, 270);
            this.wood.Name = "wood";
            this.wood.Size = new System.Drawing.Size(200, 23);
            this.wood.TabIndex = 39;
            this.wood.TabStop = false;
            this.wood.Visible = false;
            this.wood.Click += new System.EventHandler(this.wood_Click);
            // 
            // stone
            // 
            this.stone.BackColor = System.Drawing.Color.Transparent;
            this.stone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stone.BackgroundImage")));
            this.stone.Location = new System.Drawing.Point(483, 299);
            this.stone.Name = "stone";
            this.stone.Size = new System.Drawing.Size(200, 23);
            this.stone.TabIndex = 40;
            this.stone.TabStop = false;
            this.stone.Visible = false;
            this.stone.Click += new System.EventHandler(this.stone_Click);
            // 
            // rabbitmeat
            // 
            this.rabbitmeat.BackColor = System.Drawing.Color.Transparent;
            this.rabbitmeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rabbitmeat.BackgroundImage")));
            this.rabbitmeat.Location = new System.Drawing.Point(483, 328);
            this.rabbitmeat.Name = "rabbitmeat";
            this.rabbitmeat.Size = new System.Drawing.Size(200, 23);
            this.rabbitmeat.TabIndex = 41;
            this.rabbitmeat.TabStop = false;
            this.rabbitmeat.Visible = false;
            this.rabbitmeat.Click += new System.EventHandler(this.rabbitmeat_Click);
            // 
            // food
            // 
            this.food.BackColor = System.Drawing.Color.Transparent;
            this.food.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("food.BackgroundImage")));
            this.food.Location = new System.Drawing.Point(483, 357);
            this.food.Name = "food";
            this.food.Size = new System.Drawing.Size(200, 23);
            this.food.TabIndex = 42;
            this.food.TabStop = false;
            this.food.Visible = false;
            this.food.Click += new System.EventHandler(this.food_Click);
            // 
            // use
            // 
            this.use.BackColor = System.Drawing.Color.Transparent;
            this.use.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("use.BackgroundImage")));
            this.use.Enabled = false;
            this.use.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.use.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.use.ForeColor = System.Drawing.Color.White;
            this.use.Location = new System.Drawing.Point(640, 415);
            this.use.Name = "use";
            this.use.Size = new System.Drawing.Size(44, 23);
            this.use.TabIndex = 44;
            this.use.Text = "Use";
            this.use.UseVisualStyleBackColor = false;
            this.use.Visible = false;
            this.use.Click += new System.EventHandler(this.use_Click);
            // 
            // apple
            // 
            this.apple.BackColor = System.Drawing.Color.Transparent;
            this.apple.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("apple.BackgroundImage")));
            this.apple.Location = new System.Drawing.Point(483, 386);
            this.apple.Name = "apple";
            this.apple.Size = new System.Drawing.Size(200, 23);
            this.apple.TabIndex = 45;
            this.apple.TabStop = false;
            this.apple.Visible = false;
            this.apple.Click += new System.EventHandler(this.apple_Click);
            // 
            // select
            // 
            this.select.BackColor = System.Drawing.Color.Transparent;
            this.select.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select.BackgroundImage")));
            this.select.Image = ((System.Drawing.Image)(resources.GetObject("select.Image")));
            this.select.Location = new System.Drawing.Point(689, 241);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(23, 23);
            this.select.TabIndex = 46;
            this.select.TabStop = false;
            this.select.Visible = false;
            // 
            // talk
            // 
            this.talk.BackColor = System.Drawing.Color.Transparent;
            this.talk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("talk.BackgroundImage")));
            this.talk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.talk.Location = new System.Drawing.Point(551, 46);
            this.talk.Name = "talk";
            this.talk.Size = new System.Drawing.Size(35, 21);
            this.talk.TabIndex = 47;
            this.talk.TabStop = false;
            this.talk.Visible = false;
            this.talk.Click += new System.EventHandler(this.talk_Click);
            // 
            // talktxt
            // 
            this.talktxt.AutoSize = true;
            this.talktxt.BackColor = System.Drawing.Color.Transparent;
            this.talktxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.talktxt.ForeColor = System.Drawing.Color.White;
            this.talktxt.Image = ((System.Drawing.Image)(resources.GetObject("talktxt.Image")));
            this.talktxt.Location = new System.Drawing.Point(561, 51);
            this.talktxt.Name = "talktxt";
            this.talktxt.Size = new System.Drawing.Size(24, 9);
            this.talktxt.TabIndex = 48;
            this.talktxt.Text = "Talk";
            this.talktxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.talktxt.Visible = false;
            this.talktxt.Click += new System.EventHandler(this.talk_Click);
            // 
            // textbok
            // 
            this.textbok.AutoSize = true;
            this.textbok.BackColor = System.Drawing.Color.Transparent;
            this.textbok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbok.ForeColor = System.Drawing.Color.White;
            this.textbok.Image = ((System.Drawing.Image)(resources.GetObject("textbok.Image")));
            this.textbok.Location = new System.Drawing.Point(182, 471);
            this.textbok.Name = "textbok";
            this.textbok.Size = new System.Drawing.Size(0, 24);
            this.textbok.TabIndex = 49;
            this.textbok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scenepop
            // 
            this.scenepop.BackColor = System.Drawing.Color.Transparent;
            this.scenepop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scenepop.BackgroundImage")));
            this.scenepop.Location = new System.Drawing.Point(0, -1);
            this.scenepop.Name = "scenepop";
            this.scenepop.Size = new System.Drawing.Size(800, 600);
            this.scenepop.TabIndex = 50;
            this.scenepop.TabStop = false;
            this.scenepop.Visible = false;
            // 
            // popup
            // 
            this.popup.BackColor = System.Drawing.Color.Transparent;
            this.popup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("popup.BackgroundImage")));
            this.popup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popup.Location = new System.Drawing.Point(238, 242);
            this.popup.Name = "popup";
            this.popup.Size = new System.Drawing.Size(300, 75);
            this.popup.TabIndex = 51;
            this.popup.TabStop = false;
            this.popup.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(268, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 52;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // bgapple
            // 
            this.bgapple.BackColor = System.Drawing.Color.Transparent;
            this.bgapple.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bgapple.BackgroundImage")));
            this.bgapple.Location = new System.Drawing.Point(360, 268);
            this.bgapple.Name = "bgapple";
            this.bgapple.Size = new System.Drawing.Size(66, 23);
            this.bgapple.TabIndex = 56;
            this.bgapple.TabStop = false;
            this.bgapple.Visible = false;
            this.bgapple.Click += new System.EventHandler(this.trapple_Click);
            // 
            // txtapple
            // 
            this.txtapple.AutoSize = true;
            this.txtapple.BackColor = System.Drawing.Color.Transparent;
            this.txtapple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapple.ForeColor = System.Drawing.Color.White;
            this.txtapple.Image = ((System.Drawing.Image)(resources.GetObject("txtapple.Image")));
            this.txtapple.Location = new System.Drawing.Point(371, 270);
            this.txtapple.Name = "txtapple";
            this.txtapple.Size = new System.Drawing.Size(49, 16);
            this.txtapple.TabIndex = 57;
            this.txtapple.Text = "Apple";
            this.txtapple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtapple.Visible = false;
            this.txtapple.Click += new System.EventHandler(this.trapple_Click);
            // 
            // bgpoint
            // 
            this.bgpoint.BackColor = System.Drawing.Color.Transparent;
            this.bgpoint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bgpoint.BackgroundImage")));
            this.bgpoint.Location = new System.Drawing.Point(360, 242);
            this.bgpoint.Name = "bgpoint";
            this.bgpoint.Size = new System.Drawing.Size(66, 23);
            this.bgpoint.TabIndex = 59;
            this.bgpoint.TabStop = false;
            this.bgpoint.Visible = false;
            this.bgpoint.Click += new System.EventHandler(this.bgpoint_Click);
            // 
            // point
            // 
            this.point.AutoSize = true;
            this.point.BackColor = System.Drawing.Color.Transparent;
            this.point.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point.ForeColor = System.Drawing.Color.White;
            this.point.Image = ((System.Drawing.Image)(resources.GetObject("point.Image")));
            this.point.Location = new System.Drawing.Point(371, 245);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(43, 16);
            this.point.TabIndex = 61;
            this.point.Text = "Point";
            this.point.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.point.Visible = false;
            this.point.Click += new System.EventHandler(this.bgpoint_Click);
            // 
            // SceneManager
            // 
            this.ClientSize = new System.Drawing.Size(784, 576);
            this.Controls.Add(this.point);
            this.Controls.Add(this.bgpoint);
            this.Controls.Add(this.txtapple);
            this.Controls.Add(this.bgapple);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.popup);
            this.Controls.Add(this.scenepop);
            this.Controls.Add(this.textbok);
            this.Controls.Add(this.talktxt);
            this.Controls.Add(this.talk);
            this.Controls.Add(this.select);
            this.Controls.Add(this.apple);
            this.Controls.Add(this.use);
            this.Controls.Add(this.food);
            this.Controls.Add(this.rabbitmeat);
            this.Controls.Add(this.stone);
            this.Controls.Add(this.wood);
            this.Controls.Add(this.axe);
            this.Controls.Add(this.item);
            this.Controls.Add(this.next);
            this.Controls.Add(this.mpbar);
            this.Controls.Add(this.hpbar);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pointbox);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chtxt2);
            this.Controls.Add(this.chtxt1);
            this.Controls.Add(this.bgtxt);
            this.Controls.Add(this.box8);
            this.Controls.Add(this.box7);
            this.Controls.Add(this.box6);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.mp);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.chbox);
            this.Controls.Add(this.scenebox);
            this.Name = "SceneManager";
            this.Text = "13570278";
            ((System.ComponentModel.ISupportInitialize)(this.chbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgtxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtxt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtxt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rabbitmeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.food)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.talk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenepop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgapple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgpoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void axe_Click(object sender, EventArgs e)
        {
            iditem = 1;
            select.Location = new Point(689, 241);
        }

        private void wood_Click(object sender, EventArgs e)
        {
            iditem = 2;
            select.Location = new Point(689, 270);
        }

        private void stone_Click(object sender, EventArgs e)
        {
            iditem = 3;
            select.Location = new Point(689, 299);
        }

        private void rabbitmeat_Click(object sender, EventArgs e)
        {
            iditem = 4;
            select.Location = new Point(689, 328);
        }

        private void food_Click(object sender, EventArgs e)
        {
            iditem = 5;
            select.Location = new Point(689, 357);
        }

        private void apple_Click(object sender, EventArgs e)
        {
            iditem = 6;
            select.Location = new Point(689, 386);
        }

        private void talk_Click(object sender, EventArgs e)
        {
            if (talkid == 1)
            {
                if (fristtalk == true)
                {
                    if (control.talk == true)
                    {
                        next.Enabled = true;
                        textbok.Text = "จะผ่านถ่ำนั้นไปได้ต้องมีทักษะทุกอย่างมากกว่า " + mission+"\nเจ้าสามารถเรียนรู้ทักษะจากข้าได้แต่มีข้อแลกเปลี่ยน";
                        gameTimer.Stop();
                        chtxt1.Show();
                        chtxt2.Show();
                        textbok.Show();
                        next.Show();
                        label1.Hide();
                        bgtxt.Show();
                        control.talk = false;
                        
                    }
                    else if (control.talk == false)
                    {
                        next.Enabled = false;
                        gameTimer.Start();
                        chtxt1.Hide();
                        chtxt2.Hide();
                        bgtxt.Hide();
                        label1.Show();
                        next.Hide();
                        textbok.Hide();
                        fristtalk =false;
                       
                    }
                }
                if (fristtalk == false)
                {
                    trad();
                   
                }
            }
            if (talkid == 2)
            {
                trad();
                
            }
            if (talkid == 3)
            {
                trad();
            }
            if (talkid == 4)
            {
                trad(); 
            }
            if (talkid == 5)
            {
                trad();
            }
            if (talkid == 6)
            {
                trad(); 
            }
            if (talkid == 7)
            {
                trad(); 

            }
            
        }
        private void trad()
        {
            if (control.talk == true)
            {
txtapple.Show();
                point.Show();
                
                bgpoint.Show();
                bgapple.Show();
               
                
                

            }
            if (control.talktree == true)
            {
                if (axeuse == true)
                {
                    int m = 0;
                    int j = 0;
                    m = player.getLogic();
                    if (m < 0)
                       m = 0;
                    j = player.wood;
                    player.wood = (player.wood + 5)+(m/2);
                    m = player.wood - j;
                    label2.Text = "ได้รับ Wood"+ m ;
                    player.setEmotion(player.getEmotion() - 10);
                    label2.Show();
                    popup.Show();
                    if (player.getEmotion() < 0)
                        player.setEmotion(0);
                    
                }
                if (axeuse == false)
                {

                    label2.Text = "ต้องติดตั้ง Axe ก่อน";
                    label2.Show();
                    popup.Show();
                   
                }
                


            }
            if (control.talkaxe == true)
            {
                if (player.getTech()<=5)
                {
                    label2.Text = "ต้องมีทักษะ Tech มากกว่า 5";
                    label2.Show();
                    popup.Show();
                }
                if (player.getTech()>5)
                {
                    if (player.axe == 0 && axeuse == false)
                    {
                        player.axe = player.axe + 1;
                        label2.Text = "ได้รับ Axe 1 อัน";
                        player.setEmotion(player.getEmotion() - 30);
                        label2.Show();
                        popup.Show();
                        if (player.getEmotion() < 0)
                            player.setEmotion(0);
                    }
                    if (axeuse == true)
                    {
                        
                        label2.Text = "ว่างเปล่า";
                        label2.Show();
                        popup.Show();
                    }
                }
                


            }
            if (control.talkcapmfire == true)
            {
                if (player.getCreativity() > 3)
                {
                    if (player.rabbit >= 2)
                    {
                        int m = 0;
                        int j = 0;
                        m = player.getSincerity();
                        if (m < 0)
                            m = 0;
                        j = player.food;
                        player.food = (player.food + 1) + (m / 2);
                        m = player.food - j;
                        label2.Text = "ได้รับ Food " + m;
                        player.rabbit = player.rabbit - 2;
                        player.setEmotion(player.getEmotion() - 10);
                        label2.Show();
                        popup.Show();
                        if (player.getEmotion() < 0)
                            player.setEmotion(0);
                    }
                    else {
                        label2.Text = "Rabbit Meat ไม่พอ " ;
                        label2.Show();
                        popup.Show();
                    }
                }
                else if (player.getCreativity() <= 3)
                {
                    label2.Text = "ต้องมี Creativity มากกว่า 3";
                    label2.Show();
                    popup.Show();
                }
                 

            }
            if (control.atkmon == true)
            {
                if (axeuse == true)
                {
                    int m = 0;
                    int j = 0;
                    m = player.getEffort();
                    if (m < 0)
                        m = 0;
                    j = player.rabbit;
                    player.rabbit = (player.rabbit + 5) + (m / 2);
                    m = player.rabbit - j;
                    label2.Text = "ได้รับ Rabbit Meat " + m;
                    player.setEmotion(player.getEmotion() - 15);
                    label2.Show();
                    popup.Show();
                    if (player.getEmotion() < 0)
                        player.setEmotion(0);


                }
                if (axeuse == false)
                {

                    label2.Text = "ไม่มีอาวุธ";
                    label2.Show();
                    popup.Show();

                }
               

            }
            if (control.talkstone == true)
            {
                int m = 0;
                int j = 0;
                m = player.getMemory();
                if (m < 0)
                    m = 0;
                j = player.stone;
                player.stone = (player.stone + 5) + (m / 2);
                m = player.stone - j;
                label2.Text = "ได้รับ Stone " + m;
                player.setEmotion(player.getEmotion() - 10);
                label2.Show();
                popup.Show();
                if (player.getEmotion() < 0)
                    player.setEmotion(0);
               

            }
            if (control.talkmission == true)
            {
                player.setHealth(player.getHealth() - 10);
                label2.Text = "Health -10";
                if (player.getHealth() < 0)
                    player.setHealth(0);
                label2.Show();
                popup.Show();
                
            }
        }

        private void trapple_Click(object sender, EventArgs e)
        {
            bgapple.Hide();
            txtapple.Hide();
            point.Hide();
            bgpoint.Hide();
            if (player.getGenerous() <= 2)
            {
                label2.Text = "ต้องมี Generous มากกว่า 2";
                label2.Show();
                popup.Show();
            }
            if (player.getGenerous() > 2)
            {
                if (player.wood >= 2 && player.stone >= 2)
                {
                    int m = 0;
                    int j = 0;
                    m = player.getCommunication();
                    if (m < 0)
                        m = 0;
                    j = player.apple;
                    player.apple = (player.apple + 1) + (m / 2);
                    m = player.apple - j;
                    label2.Text = "ได้รับ Apple " + m;
                    player.stone = player.stone - 2;
                    player.wood = player.wood - 2;
                    label2.Show();
                    popup.Show();
                }
                else
                {
                    label2.Text = "ต้องใช้ Wood และ Stone 2";
                    label2.Show();
                    popup.Show();
                }

            }
        }

        private void bgpoint_Click(object sender, EventArgs e)
        {
            bgapple.Hide();
            txtapple.Hide();
            point.Hide();
            bgpoint.Hide();
            if (kpo== 0)
            {
                if (player.stone >= 10)
                {
                    player.stone = player.stone - 10;
                    player.setPoint(player.getPoint() + 10);
                    label2.Text = "ได้รับ Point 10";
                    label2.Show();
                    popup.Show();
                    kpo = 1;
                }
                else
                {
                    label2.Text = "ต้องใช้ Stone 10";
                    label2.Show();
                    popup.Show();
                }
            }
            else if (kpo == 1)
            {
                if (player.wood >= 10)
                {
                    player.wood = player.wood - 10;
                    player.setPoint(player.getPoint() + 10);
                    label2.Text = "ได้รับ Point 10";
                    label2.Show();
                    popup.Show();
                    kpo = 2;
                }
                else
                {
                    label2.Text = "ต้องใช้ Wood 10";
                    label2.Show();
                    popup.Show();
                }
            }
            else if (kpo == 2)
            {
                if (player.wood >= 5&&player.stone>=5)
                {
                    player.wood = player.wood - 5;
                    player.stone = player.stone - 5;
                    player.setPoint(player.getPoint() + 10);
                    label2.Text = "ได้รับ Point 10";
                    label2.Show();
                    popup.Show();
                    kpo = 3;
                }
                else
                {
                    label2.Text = "ต้องใช้ Wood และ Stone 5";
                    label2.Show();
                    popup.Show();
                }
            }
            else if (kpo == 3)
            {
                if (player.rabbit >=6)
                {
                    player.rabbit = player.rabbit - 6;
                    player.setPoint(player.getPoint() + 10);
                    label2.Text = "ได้รับ Point 10";
                    label2.Show();
                    popup.Show();
                    kpo = 4;
                }
                else
                {
                    label2.Text = "ต้องใช้ Rabbit Meat 6";
                    label2.Show();
                    popup.Show();
                }
            }
            else if (kpo == 4)
            {
                if (player.food >= 4)
                {
                    player.food = player.food - 4;
                    player.setPoint(player.getPoint() + 10);
                    label2.Text = "ได้รับ Point 10";
                    label2.Show();
                    popup.Show();
                    kpo = 5;
                }
                else
                {
                    label2.Text = "ต้องใช้ Food 4";
                    label2.Show();
                    popup.Show();
                }
            }
            else if (kpo == 5)
            {
                if (player.apple >= 3)
                {
                    player.apple = player.apple - 3;
                    player.setPoint(player.getPoint() + 10);
                    label2.Text = "ได้รับ Point 10";
                    label2.Show();
                    popup.Show();
                    kpo = 0;
                }
                else
                {
                    label2.Text = "ต้องใช้ Apple 3";
                    label2.Show();
                    popup.Show();
                }
            }

        }















        /*RenderObject bg = new RenderObject(Image.FromFile(@"images/bg.png"));
    RenderObject p1 = new RenderObject(Image.FromFile(@"images/p1.png"));


    render.addtoRender(bg);
    render.addtoRender(p1);
    for(int i =0;i<5;i++)
    {
    RenderObject p2 = new RenderObject(Image.FromFile(@"images/p2.png"));
    p2.setBoundPosition(100 * i, 100 * i);
    render.addtoRender(p2);

    }

    p1.setBoundPosition(50, 50);
    private void onKeyboardDown(object sender, KeyEventArgs eventkey)
    {
    if(eventkey.KeyCode == Keys.Left)
    {
    ch.setFreamIndex(3);
    ch.setBoundPosition(x--,y);
    }
    if (eventkey.KeyCode == Keys.Right)
    {
    ch.setFreamIndex(6);
    ch.setBoundPosition(x++, y);
    }
    if (eventkey.KeyCode == Keys.Up)
    {
    ch.setFreamIndex(9);
    ch.setBoundPosition(x, y--);
    }
    if (eventkey.KeyCode == Keys.Down)
    {
    ch.setFreamIndex(0);
    ch.setBoundPosition(x, y++);
    }
    render.render(this.CreateGraphics());
    Console.WriteLine("KeyDown");
    }*/
    }
}
