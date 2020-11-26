using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16313_AleksandraRistic
{
    public class Igra : IIgra
    {

        private bool stani;
        ContextMakao context;

        #region konstruktor
        public ContextMakao ContextMakao
        {
            get { return context; }
            set { context = value; }
        }
        public Igra()
        {
            this.context = new ContextMakao();
            stani = false;
        }
        public Igra(ContextMakao km, int i)
        {
            context = km;
            stani = false;
            BestMove = new Move();
        }
        public Igra(ContextMakao km)
        {
            context = new ContextMakao(km);
            stani = false;
            BestMove = new Move();
        }
        #endregion

        #region interfejs
        public IMove BestMove { get; set; }

        public void Bacenekarte(List<Karta> karte, Boja boja, int BrojKarataProtivnika)
        {
            context.PotezProtivnika(karte, boja, BrojKarataProtivnika);
            

        }
        void IterativeDeepening()
        {
            int i = 1;

            while (true)
            {
                BestMove = ContextMakao.AlfaBeta(context, i, int.MinValue, int.MaxValue);
                i++;

            }
        }
        public void BeginBestMove()
        {
            stani = false;
            //
            Task.Run(() =>
            {
                int i = 1;
                while (true)
                {
                    if (stani)
                    {
                        stani = false;
                        break;
                    }
                    BestMove = ContextMakao.AlfaBeta(context, i, int.MinValue, int.MaxValue);
                    i++;
                   
                }
            } //
            );
        }
        
        public void EndBestMove()
        {
            stani = true;
            context.Stop = true;
            if (BestMove.Tip.HasFlag(TipPoteza.KupiKartu) || BestMove.Tip.HasFlag(TipPoteza.KupiKazneneKarte))
                return;
            else
                context.PotezMoj(BestMove.Karte);
            
        }

        public void KupioKarte(List<Karta> karte)
        {
            context.DodajURuku(karte);
        }

        public void Reset()
        {
            this.context = new ContextMakao();
            stani = false;
        }

        public void SetRuka(List<Karta> karte)
        {
            context.DodajURuku(karte);
        }

        public void ObnoviSpil(List<Karta> noviS)
        {
            foreach(Karta k in noviS)
                context.TrenutnoStanje.Spil.Karte.Add(k);
        }

       
        #endregion
    }
}
