using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16313_AleksandraRistic.trans_tab
{
   public class HashElement
    {
        Move nabolji;
        int dubina;
        int beta;
        int alfa;
        int flag;

        public Move Nabolji
        {
            get { return nabolji; }
            set { nabolji = value; }
        }
        public int Dubina
        {
            get { return dubina; }
            set { dubina = value; }
        }

        public int Alfa
        {
            get { return alfa; }
            set { alfa = value; }
        }

        public int Beta
        {
            get { return beta; }
            set { beta = value; }
        }

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
    }
}
