using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16313_AleksandraRistic.Igrac
{
    public abstract class IIgrac
    {
       public abstract List<Move> GetListaPoteza(Tabla trenStanje);
        
        
        public virtual List<Move> IspitajJ(Karta k) 
        {
            List<Move> pot = new List<Move>();
            if (k.Broj.CompareTo("J") == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            pot.Add(new Move(TipPoteza.PromeniBoju, Boja.Herz));
                            break;
                        case 1:
                            pot.Add(new Move(TipPoteza.PromeniBoju, Boja.Karo));
                            break;
                        case 2:
                            pot.Add(new Move(TipPoteza.PromeniBoju, Boja.Pik));
                            break;
                        case 3:
                            pot.Add(new Move(TipPoteza.PromeniBoju, Boja.Tref));
                            break;

                    }
                }
            }
            return pot;
        }
    }
}
