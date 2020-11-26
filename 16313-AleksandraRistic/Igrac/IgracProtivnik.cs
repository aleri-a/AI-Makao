using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16313_AleksandraRistic.Igrac
{
    class IgracProtivnik : IIgrac
    {
        public override List<Move> GetListaPoteza(Tabla trenStanje)
        {
            
            List<Move> potezi = new List<Move>();
            potezi = IspitajObicno(trenStanje.Spil,trenStanje.Talon.Last());
            return potezi;
        }

       
       public List<Move> IspitajObicno(Spil spp,Karta talon) //CheckBasic
        {

            List<Move> potezi = new List<Move>();
            for (int i = 0; i < spp.Karte.Count(); i++)
            {
                if (spp.Karte[i].Broj.CompareTo(talon.Broj) == 0 || spp.Karte[i].Boja == talon.Boja)
                {
                    List<Move> ispitajJ = IspitajJ(spp.Karte[i]);
                    if (ispitajJ.Count() > 0)
                        foreach (Move m in ispitajJ)
                            potezi.Add(m);
                    else
                    {
                        List<Move> ispitaj8a = new List<Move>();
                        ispitaj8a = Ispitaj8A(spp.Karte[i], spp, ispitaj8a, talon);
                        if(ispitaj8a.Count>0)
                            foreach (Move m in ispitaj8a)
                                potezi.Add(m);
                    }
                   
                }
                
            }
            return potezi;
        }

        public List<Move> Ispitaj8A(Karta k, Spil spil, List<Move> ispitaj8a, Karta talon) //Check for 8
        {
            talon = k;
            if (k.Broj.CompareTo("8") == 0 || k.Broj.CompareTo("A") == 0)
            {
                ispitaj8a.Add(new Move(TipPoteza.BacaKartu, k.Boja, k));
                if (NadjiUSpilu(spil, k) > -1)
                    spil.Karte.RemoveAt(NadjiUSpilu(spil, k));
             
                List<Move> pom = IspitajObicno(spil, talon);
                foreach (Move p in pom)
                    ispitaj8a.Add(p);
            }

            return ispitaj8a;
        }
        public int NadjiUSpilu(Spil spil, Karta k) //Find in the deck 
        {
            for (int i = 0; i < spil.Karte.Count(); i++)
                if (spil.Karte[i].Broj.CompareTo(k.Broj) == 0 && spil.Karte[i].Boja == k.Boja)
                    return i;
            return -1;

        }



        public IIgrac Igrac()
        {
            throw new NotImplementedException();
        }

        public IIgrac Igrac(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
