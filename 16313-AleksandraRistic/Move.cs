using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16313_AleksandraRistic
{
    public class Move : TIG.AV.Karte.IMove
    {
        #region Properties
        public TipPoteza Tip { get; set; }
        public List<Karta> Karte { get; set; }
        public Boja NovaBoja { get; set; }

        public ContextMakao PrethodnoStanje { get; set; }
        public ContextMakao NarednoStanje { get; set; }
        public int Value { get; set; }
        #endregion

        #region Konstruktori
        public Move()
        {
            Karte = new List<Karta>();
            PrethodnoStanje = new ContextMakao();
            NarednoStanje = new ContextMakao();
            //NovaBoja = Boja.Unknown; //15.1

        }
        public Move(Move im)
        {
            Karte = new List<Karta>();
            Tip = im.Tip;
            foreach (Karta k in im.Karte)
                Karte.Add(k);
            NovaBoja = im.NovaBoja;
            //PrethodnoStanje = new ContextMakao(new ContextMakao()); //15.1
           // NarednoStanje = new ContextMakao(new ContextMakao()); //15.1

            PrethodnoStanje = new ContextMakao(im.PrethodnoStanje);
           NarednoStanje= new ContextMakao(im.NarednoStanje); 
            Value = im.Value;

        }

       
        public Move(ContextMakao prethodnoSt, ContextMakao narednoSt)
        {
            Karte = new List<Karta>();
            PrethodnoStanje = prethodnoSt;
            NarednoStanje = narednoSt;
          //  NovaBoja = Boja.Unknown; 15.1
            Value = 0;
        }

        public Move (List<Move> potezi)//baci 8karo, baci Akaro, baci 5karo
        {
            Karte = new List<Karta>();
           foreach(Move m  in potezi)
            {
                Tip |= m.Tip;//or tj da moze da se izvrse i potezi baci kartu i menjaj boju npr bacam 8 pa J
            }
           
            foreach(Move m in potezi)
            {
                if (m.Tip==TipPoteza.BacaKartu)
                    foreach (Karta k in m.Karte)
                        Karte.Add(k);            
            }
            NovaBoja = Karte.Last().Boja;
        
}

        public Move(List<Move> lista, Move m)
        {
            Karte = new List<Karta>();
            foreach (Move mm in lista)
            {
                Tip |= mm.Tip;
            }

            Tip |= m.Tip;

            foreach (Move mm in lista)
            {
                if (mm.Tip != TipPoteza.KupiKartu && mm.Tip!=TipPoteza.KupiKazneneKarte )
                    foreach (Karta k in mm.Karte)
                        Karte.Add(k);               
            }
            if (m.Tip != TipPoteza.KupiKartu && m.Tip != TipPoteza.KupiKazneneKarte)
                foreach (Karta k in m.Karte)
                    Karte.Add(k);
            
        }
        
        public Move(TipPoteza novi)
        {
            Tip = novi;
            //NovaBoja = Boja.Unknown; 15.1
            Karte = null;

        }

        public Move(TipPoteza noviTip, Boja novaBoja, Karta zaBacanje)
        {
            Tip = noviTip;
            NovaBoja = novaBoja;
            Karte = new List<Karta>();
            Karte.Add(zaBacanje);


        }

        public Move(TipPoteza noviTip, Boja novaBoja)
        {
            Tip = noviTip;
            Karte = new List<Karta>();
            if (Tip == TipPoteza.PromeniBoju)
            {
                Karta pom = new Karta();
                pom.Broj = "J";
                
                Karte.Add(pom);
            }
            else Karte = null;
            NovaBoja = novaBoja;

        }


        #endregion


    }
}
