using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16313_AleksandraRistic.Igrac
{
    class IgracJa : IIgrac
    {
        public override List<Move> GetListaPoteza(Tabla trenStanje)
        {

            List<Move> potezi = new List<Move>();
            foreach (Move m in IspitajObicno(trenStanje.Ruka, trenStanje.Talon.Last(),trenStanje.Boja))
                potezi.Add(m);

            
            foreach(Move m in potezi) 
            {
                if(m.Tip!=TipPoteza.KupiKartu)
                    //foreach(Karta k in m.Karte)
                    {
                    Karta k = new Karta();
                    k = m.Karte.Last();
                    if (k.Broj.CompareTo("8") == 0 || k.Broj.CompareTo("A") == 0)//znaci da nismo preklopili tu kartu
                        potezi = ObrisiTajPotez(potezi, m);
                    
                    }
               
            }

            return potezi;
        }


      private List<Move> ObrisiTajPotez(List<Move> potezi, Move m) //Remove move
        {
           List<Move> lista = new List<Move>(potezi);
           for(int i=0;i<lista.Count();i++)
            {
                if (lista[i] == m)
                     lista.RemoveAt(i);
            }
            return lista;
        }

        public override List<Move> IspitajJ(Karta k) //check J
        {
            List<Move> pot = new List<Move>();
            if (k.Broj.CompareTo("J") == 0)
            {
                pot.Add(new Move(TipPoteza.PromeniBoju, k.Boja,k));
               
            }
            return pot;
        }

        public List<Move> IspitajObicno(List<Karta> ruka, Karta talon,Boja boja) //Check basic
        {

            List<Move> potezi = new List<Move>();
            for (int i = 0; i < ruka.Count(); i++)
            {
                if (ruka[i].Broj.CompareTo(talon.Broj) == 0 || ruka[i].Boja == boja || ruka[i].Broj.CompareTo("J") == 0)
                {
                    List<Move> ispitajJ = IspitajJ(ruka[i]);
                    if (ispitajJ.Count() > 0)
                        foreach (Move m in ispitajJ)
                            potezi.Add(m);
                    else
                    {
                        List<Move> ispitaj8a = new List<Move>();
                        ispitaj8a = Ispitaj8A(ruka[i], ruka, ispitaj8a, talon);
                        if (ispitaj8a.Count > 0)
                            foreach (Move im in ispitaj8a)
                            {
                                potezi.Add(new Move(im));
                            }
                        else
                            potezi.Add(new Move(TipPoteza.BacaKartu, ruka[i].Boja, ruka[i]));
                    }

                }
                
            }
            if (potezi.Count() == 0)
                potezi.Add(new Move(TipPoteza.KupiKartu));

            return potezi;
        }
        public int NadjiURuci(List<Karta> ruka, Karta k) //Find in the hand 
        {
            for (int i = 0; i < ruka.Count(); i++)
                if (ruka[i].Broj.CompareTo(k.Broj) == 0 && ruka[i].Boja == k.Boja)
                    return i;
            return -1;

        }

        public List<Move> Ispitaj8A(Karta k, List<Karta> ruka, List<Move> ispitaj8a, Karta talon) //Check 8
        {
            List<Move> vec = new List<Move>();
            foreach (Move m in ispitaj8a)
                vec.Add(new Move(m));
                
            talon = k;
            List<Karta> rukaKopija = new List<Karta>();
            foreach (Karta krt in ruka)
                rukaKopija.Add(krt);

            if (k.Broj.CompareTo("8") == 0 || k.Broj.CompareTo("A") == 0)
            {
                vec.Add(new Move(TipPoteza.BacaKartu, k.Boja, k));
                if (NadjiURuci(rukaKopija, k) > -1)
                   rukaKopija.RemoveAt(NadjiURuci(rukaKopija, k));

                List<Move> pom = IspitajObicno(rukaKopija, talon,k.Boja);
                ispitaj8a.Clear();
                foreach (Move p in pom)
                {
                    Move ub = new Move(vec, p);
                    ispitaj8a.Add(ub);
                    
                }
            }

            return ispitaj8a;
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
