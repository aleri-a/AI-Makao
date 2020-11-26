using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16313_AleksandraRistic.trans_tab
{
    public static class TranspozicionaTabela
    {

        private static Dictionary<ContextMakao, HashElement> transpozicionaTabela;

       static TranspozicionaTabela()
        {
            transpozicionaTabela = new Dictionary<ContextMakao, HashElement>();
        }

        public static HashElement VratiEl(ContextMakao ab)
        {
            return transpozicionaTabela[ab];
        }
        public static HashElement Remove(ContextMakao ab)
        {
            HashElement pom = transpozicionaTabela[ab];
            transpozicionaTabela.Remove(ab);
            return pom;
        }

        public static void Add(ContextMakao ab, HashElement h)
        {
            transpozicionaTabela.Add(ab, h);
        }

        public static bool Sadrzi(ContextMakao ab) 
        {
            return transpozicionaTabela.ContainsKey(ab);
        }
    }
}

