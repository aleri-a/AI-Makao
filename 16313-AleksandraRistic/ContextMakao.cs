using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16313_AleksandraRistic.trans_tab;
using TIG.AV.Karte;


namespace _16313_AleksandraRistic
{
    public class ContextMakao:ICloneable
    {
        #region atributi
        
       public int NaPotezu { get; set; } // 1 sam ja 2 je protivnik
       public Tabla TrenutnoStanje { get; set; }

       public int Value { get; set; }
       static  bool stop = false;
       public bool Stop { get; set; }
        
     
        #endregion

        #region konstruktori
        public ContextMakao()
        {
            NaPotezu = 1; //ja uvek kreceem prva
            TrenutnoStanje = new Tabla();
            Value = 0;
            Stop = false;
        }

        public ContextMakao(Tabla t, int igrac)
        {
            TrenutnoStanje = new Tabla(t);
            NaPotezu = igrac;
            Value = 0;
        }

        public ContextMakao(ContextMakao makao)
        {
            NaPotezu = makao.NaPotezu;
            Value = makao.Value;
            stop = makao.Stop;
            TrenutnoStanje = new Tabla(makao.TrenutnoStanje);
        }
        
        #endregion

        #region funkcije

        public void PotezMoj(List<Karta> kojaSamBacila) //My Move
        {
            if(kojaSamBacila.Count()>0)
                foreach (Karta k in kojaSamBacila)
                TrenutnoStanje.Talon.Add(k);
        }

        public virtual int Evaluate()
        {
            List<Karta> zaBacanje = new List<Karta>();
            
            int bodovi = 0;
            if (TrenutnoStanje.Pobedio==2)
                return -10000;
            if (TrenutnoStanje.Pobedio == 1)
                return 10000;
            bodovi += TrenutnoStanje.BodoviEvaluacija();
            bodovi += TrenutnoStanje.Ruka.Count() * 100;
            if(TrenutnoStanje.Pobedio==1)
             return bodovi; 
            else return -bodovi;
            
        }

        public List<Move> GetListaMogucihPoteza() //Get the list of possibilities
        {
            List<Move> potezi = TrenutnoStanje.GetListaPoteza(NaPotezu);
            foreach (Move p in potezi)
            {
                p.NarednoStanje = new ContextMakao(new Tabla(TrenutnoStanje), NaPotezu);
                p.PrethodnoStanje = this;
                ObnovaStanja(p, NaPotezu); 
                int sledeciNaPotezu = NaPotezu;
                if (sledeciNaPotezu == 1) sledeciNaPotezu = 2;
                else sledeciNaPotezu = 1;
                p.NarednoStanje.NaPotezu = sledeciNaPotezu;
                TipPoteza n = new TipPoteza();
                 n = p.Tip;
                if (p.NarednoStanje.TrenutnoStanje.Ruka.Count() == 0)
                    n = TipPoteza.Poslednja ^ p.Tip;
                p.Tip = n;
            }
            if (potezi.Count() == 0)
                potezi.Add(new Move(TipPoteza.KupiKartu));
            return potezi;
        }

        public void ObnovaStanja(Move p, int naPotezu) // Return state on the first 
        {

            if (p.Tip == TipPoteza.KupiKartu) // type of move. Buy card
                return;
            foreach (Karta k in p.Karte)
                if (naPotezu == 1)
                {
                    for (int i = 0; i < p.NarednoStanje.TrenutnoStanje.Ruka.Count(); i++)
                        if (p.NarednoStanje.TrenutnoStanje.Ruka[i].Broj.CompareTo(k.Broj) == 0 && p.NarednoStanje.TrenutnoStanje.Ruka[i].Boja == k.Boja)
                        {
                            p.NarednoStanje.TrenutnoStanje.Ruka.RemoveAt(i);
                            p.NarednoStanje.TrenutnoStanje.Talon.Add(k);
                        }
                }
                else
                {
                    for (int i = 0; i < p.NarednoStanje.TrenutnoStanje.Spil.Karte.Count(); i++)
                        if (p.NarednoStanje.TrenutnoStanje.Spil.Karte[i].Broj.CompareTo(k.Broj) == 0 && p.NarednoStanje.TrenutnoStanje.Spil.Karte[i].Boja == k.Boja)
                            p.NarednoStanje.TrenutnoStanje.Spil.Karte.RemoveAt(i);
                }

        }

        public static Move AlfaBeta(ContextMakao stanje, int dubina, int alfa, int beta)
        {
            
            if (stop)
                return null;
            if (stanje == null)
                return null;
            List<Move> potezi = stanje.GetListaMogucihPoteza();

            
            if (TranspozicionaTabela.Sadrzi(stanje))
            {
                HashElement tmp = TranspozicionaTabela.VratiEl(stanje);
                if (tmp.Dubina >= dubina) return tmp.Nabolji;
                else
                {
                    potezi.Insert(0, tmp.Nabolji);
                }
                
            }

            if (TranspozicionaTabela.Sadrzi(stanje) && TranspozicionaTabela.VratiEl(stanje).Dubina < dubina)
            {
                    Move najbolji = TranspozicionaTabela.VratiEl(stanje).Nabolji;
            }
            

            if (dubina == 0 || potezi.Count == 0) 
            {
                Move pom = new Move();
                pom.Value = stanje.Evaluate();
                pom.NarednoStanje = null;
                //Careful we still don't know what move is the best 

                return pom;
            }
            else if (stanje.NaPotezu == 1) //komp 
            {
               

                Move temp = new Move();
                temp.Value = Int32.MinValue;
                int alfa1 = Int32.MinValue;
                foreach (var sledecciPotez in potezi)
                {
                    if (TranspozicionaTabela.Sadrzi(stanje))
                    {
                        alfa1 = TranspozicionaTabela.VratiEl(stanje).Alfa;
                    }
                   

                    Move b = AlfaBeta(sledecciPotez.NarednoStanje, dubina - 1, alfa1, beta);
                    if (b.Value > temp.Value)
                    {
                        temp = sledecciPotez;
                        temp.Value = b.Value;
                    }
                    if (alfa1 < temp.Value) alfa1 = temp.Value;
                    if (beta <= alfa1) break;
                }
                
                if (TranspozicionaTabela.Sadrzi(stanje))
                {
                    HashElement pom = TranspozicionaTabela.VratiEl(stanje);
                    if (pom.Dubina <= dubina)
                    {
                        pom.Alfa = alfa1;
                        pom.Dubina = dubina;
                        pom.Nabolji = temp;
                        pom.Beta = beta;
                        pom.Flag = 0;
                    }
                }
                else
                {
                    HashElement pom = new HashElement
                    {

                        Alfa = alfa1,
                        Dubina = dubina,
                        Nabolji = temp,
                        Beta = beta,
                        Flag = 0
                    };
                    TranspozicionaTabela.Add(stanje, pom);
                }
                return temp;
            }
            else
            {
                
                if (TranspozicionaTabela.Sadrzi(stanje))
                {
                    HashElement el = TranspozicionaTabela.VratiEl(stanje);
                    if (el.Dubina >= dubina) return el.Nabolji;

                }
                Move temp = new Move();
                temp.Value = Int32.MaxValue;
                int beta1 = Int32.MaxValue;
                foreach (var sledeciPotez in potezi)
                {
                   
                    if (TranspozicionaTabela.Sadrzi(stanje))
                        beta1 = TranspozicionaTabela.VratiEl(stanje).Beta;
                    
                    Move b = AlfaBeta(sledeciPotez.NarednoStanje, dubina - 1, alfa, beta1);
                    if (b.Value < temp.Value)
                    {
                        temp = sledeciPotez;
                        temp.Value = b.Value;
                    }
                    if (beta1 > temp.Value) beta1 = temp.Value;
                    if (beta1 <= alfa) break;
                }
               
                if (TranspozicionaTabela.Sadrzi(stanje))
                {
                    HashElement tmp = TranspozicionaTabela.VratiEl(stanje);
                    if (tmp.Dubina <= dubina)
                    {
                        tmp.Alfa = alfa;
                        tmp.Beta = dubina;
                        tmp.Nabolji = temp;
                        tmp.Beta = beta1;
                        tmp.Flag = 0;

                    }

                }
                else
                {
                    HashElement pom = new HashElement
                    {
                        Nabolji = temp,
                        Alfa = alfa,
                        Beta = beta1,
                        Flag = 0,
                        Dubina = dubina
                    };
                    TranspozicionaTabela.Add(stanje, pom);
                    
                }
                return temp;
            }
                

            
            
        }
    
        public void DodajURuku(List<Karta> izvuceneKArte)
        {
            TrenutnoStanje.DodajURuku(izvuceneKArte);
        }

        public void  PotezProtivnika(List<Karta> karte, Boja boja,int BrojKarataProtivnika)
        {
            TrenutnoStanje.PotezProtivnika(karte, boja, BrojKarataProtivnika);
        }

        public object Clone()
        {
            
          ContextMakao a=(ContextMakao)this.MemberwiseClone();
            return a;
        }

        public override int GetHashCode()
        {
            Tabla pom = TrenutnoStanje;
            return pom.GetHashCode();
        }

        #endregion
    }
}
