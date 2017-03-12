using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ProjectGamesCShape
{
    class XML
    {
        
        Player player;

        public Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }
        public void loadsave(Player play)
        {
    
            XDocument doc = XDocument.Load("..\\..\\save.xml");
            var bok = from lv1 in doc.Descendants("save").Descendants("player")
                      select new { level = lv1.Element("level").Value,
                       hp = lv1.Element("hp").Value };

            foreach (var loadd in bok)
            {
                play.setLevel( Int32.Parse(loadd.level));
                
            }
            //Console.WriteLine(doc);
        }

        public void please_save()
        {
            XElement save_player = XElement.Load("..\\..\\save.xml");
            save_player.ReplaceAll(new XElement("player", new XAttribute("n", 1),
                                new XElement("level", player.Level),
                                new XElement("hp", player.Hp)
                            ));
            save_player.Save("..\\..\\save.xml");

        }

    }
}
