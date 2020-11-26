using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;
using _16313_AleksandraRistic.Igrac;

namespace _16313_AleksandraRistic
{
   public class Tabla
    {
        #region atributi
        
        public Spil Spil { get; set; }
        public List<Karta> Ruka { get; set; }
        public List<Karta> Talon { get; set; }
        public int BrkarataProtivnika { get; set; }
        public Boja Boja { get; set; }
        

        private int pobedio = 0;
        public int Pobedio { get => pobedio; set => pobedio = value; }

        #endregion

        #region constructor
        public Tabla()
        {
            Spil = new Spil();
            Ruka = new List<Karta>();
            Talon = new List<Karta>();
            BrkarataProtivnika = -1;
            Pobedio = -1;
        }



        public Tabla(Tabla t)
        {
            //Spil = new Spil();
            Talon = new List<Karta>();
            Ruka = new List<Karta>();
            Spil = t.Spil;
            foreach (Karta k in t.Ruka)
                Ruka.Add(k);
            foreach (Karta k in t.Talon)
                Talon.Add(k);
            BrkarataProtivnika = t.BrkarataProtivnika;
        }
        #endregion

        #region fje


      

        public List<Move> GetListaPoteza(int idIgraca)
        {
            List<Move> potezi = new List<Move>();
            if (DaLiJeKraj(out pobedio))
                return potezi;
           
            IIgrac igrac;
            if (idIgraca == 1)
                igrac = new IgracJa();
            else igrac = new IgracProtivnik();

            List<Move> sviPot = igrac.GetListaPoteza(this);
            foreach (Move m in sviPot)  
                potezi.Add(m);
                
          
            return potezi;
            
        }
        
        

        public bool DaLiJeKraj(out int pobedio)//1 ja pobedila 2 protivnik
        {
           
            if (BrkarataProtivnika < 1 || (Spil.Karte.Count() == 2 && (Spil.Karte[Spil.Karte.Count() - 1].Broj == "A" || Spil.Karte[Spil.Karte.Count() - 1].Broj == "8")))
            {
                pobedio = 2;
                return true;
            }
            else
            {
                if(Ruka.Count()==0)
                {
                    pobedio = 1;
                    return true;
                }
                else
                {
                    if (Spil.Karte.Count() == 0)
                    {
                        if (Poeni(1) > Poeni(2))
                            pobedio = 1;
                        else pobedio = 0;
                        return true;

                    }
                    else
                    {
                        pobedio = 0;
                        return false;
                    }

                }
            }
        }

        public int BodoviEvaluacija()
        {
            int ukupniPoeni = 0;
            foreach (Karta k in Ruka)
            {
                int poeni = 0;
                switch (k.Broj)
                {
                    case "J":
                        poeni += 1;
                        break;
                    case "Q":
                        poeni += 13;
                        break;
                    case "K":
                        poeni += 14;
                        break;
                    case "A":
                        poeni += 15 * Ruka.Count();
                        break;
                    case "8":
                        poeni += 15*Ruka.Count();
                        break;
                    case "7":
                        if (BrkarataProtivnika < 3)
                            poeni += 7 * BrkarataProtivnika;
                        break;
                    case "2":
                        if (k.Boja==Boja.Tref  )
                            poeni += 8 * BrkarataProtivnika;
                        break;

                }
                if (poeni == 0)
                    poeni += Int32.Parse(k.Broj);
                ukupniPoeni += poeni;
            }
            return ukupniPoeni;
        }
    
        public int Poeni(int i) //i nema svrhu
        {
            int poeni = 0;

            foreach (Karta k in Ruka)
            {
                if (k.Broj.CompareTo("J") == 0)
                    poeni += 25; 
                else
                {
                    if (k.Broj.CompareTo("Q") == 0 || k.Broj.CompareTo("K") == 0 || k.Broj.CompareTo("A") == 0)
                        poeni += 10;
                    else poeni += Int32.Parse(k.Broj);
                }

            }
            return poeni;
        }


        public void DodajURuku(List<Karta> izvuceneKArte)
        {
           foreach(Karta k in izvuceneKArte)
            {
                Ruka.Add(k);
                for(int i=0;i<Spil.Karte.Count();i++)
                    if (Spil.Karte[i].Broj.CompareTo(k.Broj) == 0 && Spil.Karte[i].Boja == k.Boja)
                        Spil.Karte.RemoveAt(i);


            }
        }


        public void PotezProtivnika(List<Karta> karte, Boja boja, int brojKarataProtivnika)
        {
            BrkarataProtivnika = brojKarataProtivnika;
            Boja = boja;
            if(Talon.Count()<1 || karte.Last().Boja!=Talon.Last().Boja || karte.Last().Broj.CompareTo(Talon.Last().Broj)!=0)
                foreach(Karta k in karte)
                {
                    Talon.Add(k);
                    for (int i = 0; i < Spil.Karte.Count(); i++)
                        if (Spil.Karte[i].Broj.CompareTo(k.Broj) == 0 && Spil.Karte[i].Boja == k.Boja)
                            Spil.Karte.RemoveAt(i);

                }
           
        }

        public override int GetHashCode()
        {
            int pom = 0;
            pom += PoeniBRZnak(Ruka);
            pom += PoeniBRZnak(Talon) * 100;
            pom += BrkarataProtivnika * 1000;
            
            return pom;
        }

        int PoeniBRZnak(List<Karta> karte)
        {
            int pom = 0;
            int poeni = 0;
            foreach (Karta k in karte)
            {
                if (k.Broj.CompareTo("J") == 0)
                    poeni += 13;
                if (k.Broj.CompareTo("Q") == 0 )
                    poeni += 14;
                if (k.Broj.CompareTo("A") == 0)
                    poeni += 11;
                if (k.Broj.CompareTo("K") == 0)
                    poeni += 15;
                if (k.Broj.CompareTo("") == 0)
                    poeni += 1;
                if(k.Broj.CompareTo("K") != 0 && k.Broj.CompareTo("Q") != 0 && k.Broj.CompareTo("J") != 0 && k.Broj.CompareTo("A") != 0 && k.Broj.CompareTo("") != 0)
                    poeni += Int32.Parse(k.Broj)+1;
                if (k.Boja == Boja.Tref)
                    poeni *= 2;
                if (k.Boja == Boja.Karo)
                    poeni *= 3;
                if (k.Boja == Boja.Herz)
                    poeni *= 4;
                if (k.Boja == Boja.Pik)
                    poeni *= 5;

                pom += poeni;
            }
            return pom;
        }


        #endregion
    }
}
