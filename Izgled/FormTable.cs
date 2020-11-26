using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIG.AV.Karte;
using _16313_AleksandraRistic;

namespace Izgled
{
    public partial class FormTable : Form
    {

        #region atributi i konstuktor
        public Karta PomocnaKarta { get; set; }
        List<Label> lblPoteziKomp;
        int kupljene7ice = 0;// koliko je zadnjih 7ica sa talona kupljeno,  npr baci covek 7 pa komp 7, pa covek izvuce 4karte i tamo je 7 to znaci da komp kupi samo 2 karte a ne svih 6
        List<Button> btnKarteCoveka;
        List<Button> btnKarteKomp;
        List<Button> btnTalon;
        int igrac=0; //33 je kad je covek igrao 8,A 333 je kad je kupio kartu, 1 kad igra komp,66 kad komp kupio pa da opet igra
        ContextMakao kontext;

        List<Karta> covek;
        List<Karta> komp;
        List<Karta> talon;
        TIG.AV.Karte.Spil spilAV;
        Igra novaIgra;

        public FormTable()
        {
            InitializeComponent();

        }


        public FormTable(int igracc)
        {
            InitializeComponent();
            lblPoteziKomp = new List<Label>();

            this.igrac = igracc; 
            btnKarteCoveka = new List<Button>();
            btnKarteKomp = new List<Button>();
            btnTalon = new List<Button>();
            PomocnaKarta = new Karta();
            spilAV = new TIG.AV.Karte.Spil();
            spilAV.Promesaj();
            komp = new List<Karta>();
            covek = new List<Karta>();
            talon = new List<Karta>();

            kontext = new ContextMakao(new Tabla(), igrac);
            novaIgra = new Igra(kontext,1);
            

            for (int i = 0; i < 13; i++)
              {
                if (i % 13 == 0)
                {
                    talon.Add(spilAV.Karte.Last());
                    spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        komp.Add(spilAV.Karte.Last());
                        spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                    }
                    else
                    {
                        covek.Add(spilAV.Karte.Last());
                        spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                    }
                }
                 
              }
            novaIgra.SetRuka(komp); 

           /* foreach (Karta k in BrisiOvuFju())
                komp.Add(k);
            novaIgra.SetRuka(BrisiOvuFju());
            */

             novaIgra.Bacenekarte(talon, talon.Last().Boja, covek.Count());
           
           /* List<Karta> brisiListu = BrisiTalon();
            talon.Add(brisiListu.Last());
            novaIgra.Bacenekarte(brisiListu, brisiListu.Last().Boja, covek.Count());*/

            CrtajKompKarte();

            CrtajCovekoveKarte();
           
            CrtajTalon();

            
            izabraneKarteCov = new List<Karta>();
            if (igrac == 1)
                PokreniIgru();
        }
        #endregion

        #region fje za prikaz karti i talona nakon odigranog poteza racunara

        void ObnoviPrikazTalona(Karta novaTalon)
        {
             talon.Add(novaTalon);
             CrtajTalon();
                  
        }

        void ObnoviKarteKomp(List<Karta> izbacene)
        {
            foreach (Karta k in izbacene)
            {
                for (int i = 0; i < komp.Count(); i++)
                    if (komp[i].Boja == k.Boja && komp[i].Broj.CompareTo(k.Broj) == 0)
                    {
                        komp.RemoveAt(i);
                        kontext.TrenutnoStanje.Ruka.RemoveAt(i);
                    }
            }
            foreach (Button btn in btnKarteKomp)
                this.Controls.Remove(btn);
         
            btnKarteKomp.Clear();
            CrtajKompKarte();

        }

      

        #endregion

        #region fje za namestene karte
      /*  List<Karta> BrisiOvuFju()
        {
            List<Karta> karte = new List<Karta>();
            Karta pom1 = new Karta();
            pom1.Boja = Boja.Herz;
            pom1.Broj = "A";
            karte.Add(pom1);

            Karta pom2 = new Karta();
            pom2.Boja = Boja.Herz;
            pom2.Broj = "5";
            karte.Add(pom2);

            Karta pom3 = new Karta();
            pom3.Boja = Boja.Tref;
            pom3.Broj = "9";
            karte.Add(pom3);

            Karta pom4 = new Karta();
            pom4.Boja = Boja.Karo;
            pom4.Broj = "J";
            karte.Add(pom4);

            Karta pom5 = new Karta();
            pom5.Boja = Boja.Tref;
            pom5.Broj = "Q";
            karte.Add(pom5);

            Karta pom = new Karta();
            pom.Boja = Boja.Tref;
            pom.Broj = "8";
            karte.Add(pom);
            return karte;

        }

        List<Karta> BrisiTalon() //obrisi ovu fju posle
        {
            Karta brisiTalon = new Karta();
            brisiTalon.Boja = Boja.Herz;
            brisiTalon.Broj = "3";
            List<Karta> brisiListu = new List<Karta>();
            brisiListu.Add(brisiTalon);
            return brisiListu;
        }


    */
        #endregion

        #region pomocne metode za crtanje 

        void PostaviSlikuKarte(Karta k, Button b)
        {
           
            String naziv = @k.Broj;
            switch (k.Boja)
            {
                case Boja.Herz:
                    naziv += @"H.png";
                    break;
                case Boja.Karo:
                    naziv += @"D.png";
                    break;
                case Boja.Pik:
                    naziv += @"S.png";
                    break;
                case Boja.Tref:
                    naziv += @"C.png";
                    break;

            }
            b.Name = "btnKarta" + naziv;
            String pom = Environment.CurrentDirectory + @"\KarteSlike\" +@"_"+ naziv;
            String pom2 = Environment.CurrentDirectory;
            b.BackgroundImage = Image.FromFile(pom);


        }

        Karta SlikaUKartu(Button btn)
        {

            Karta k = new Karta();
            char[] charsToTrim = { '.' };

            String brPom = "";
            String br = btn.Name.Substring(8);
            int i = 0;
            while (br[i].ToString() != ".")
            {
                brPom = brPom + br[i];
                i++;
            }
            br = brPom;

            String tip = br.Last().ToString();
            char[] tipp = { tip.Last() };
            br = br.Trim(tipp);

            k.Broj = br;
            switch (tip)
            {
                case "H":
                    k.Boja = Boja.Herz;
                    break;
                case "D":
                    k.Boja = Boja.Karo;
                    break;
                case "S":
                    k.Boja = Boja.Pik;
                    break;
                case "C":
                    k.Boja = Boja.Tref;
                    break;
            }

            return k;

        }

        void ObnoviKarteCovek()
        {
            foreach (Button btn in btnKarteCoveka)
                this.Controls.Remove(btn);
            CrtajCovekoveKarte();
        }

        bool CrtajTalon() 
        {
            int w = (this.ClientSize.Width/4 + 112/2) ;
            int h = (this.ClientSize.Height/2 - 175/2) ;
            if (btnTalon.Count()>0)
            {
                this.Controls.Remove(btnTalon.Last());
            }
            CrtajKartu(w, h, -1);
            return true;
        }

        void CrtajCovekoveKarte()
        {
            foreach (Button btn in btnKarteCoveka)
                this.Controls.Remove(btn);

            int h = this.Height / 3 * 2-this.Height/30;
            int w = this.Width / 4 -100;
            int dim = covek.Count() * 57 + w;
            for (int i = 0; i < covek.Count(); i++)
            {
                CrtajKartu(dim, h, i);
                dim = dim - 53 - 4; //107 je sirina karte
            }

            
        }

        void CrtajKartu(int x, int y, int i)// i=-1 za talon, i=100-1000 za karte kompjutera, 0<i<100 za karte coveka
        {

            int sirinaKarte = 66*2-25;
            int duzinaKarte = 105*2-41;
            Button b = new Button();
            b.Location = new Point(x, y);
            if (i < 0) //to je talon
            {
                b.Text = "";
                PostaviSlikuKarte(talon.Last(), b);
                btnTalon.Add(b);
            }
            else
            {
               
                b.Text = "";
                if (i < 100)
                {
                    PostaviSlikuKarte(covek[i], b);
                    btnKarteCoveka.Add(b);
                    b.Click += new EventHandler(this.clik_KartaCoveka);

                }
                else
                {
                    PostaviSlikuKarte(komp[i - 100], b);
                    btnKarteKomp.Add(b);
                }
            }

            b.Size = new Size(sirinaKarte, duzinaKarte);
            b.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(b);
        }

        void CrtajKompKarte() //crtanje karti kompjutera (ovo ne treba korisniku da zna)
        {
            int dim = 0;
            foreach (Button btn in btnKarteKomp)
                this.Controls.Remove(btn);
            int h = this.Height/30 ;
            int w = this.Width / 4 - 100;
             dim = covek.Count() * 57 + w;
            
            for (int i = 0; i < komp.Count(); i++)
            {
                    CrtajKartu(dim, h, i + 100);
                    dim = dim - 53-4 ;
               
            }



           

        }


        void PrikazatiKartuPoKartuTalon(List<Karta> karte)
        {
            foreach (Label lbl in lblPoteziKomp)
                this.Controls.Remove(lbl);

            lblPoteziKomp.Clear();
            int i = 0;
            Label tlbl = new Label();
            tlbl.Text = "Na talonu: " + talon.Last().Broj + " " + talon.Last().Boja.ToString();
            CrtajLabelu(0, tlbl);

            foreach (Karta k in karte)
            {
                i++;
                ObnoviPrikazTalona(k);
                //System.Threading.Thread.Sleep(500); //hocu da mi ako bacim Atref pa 5tref, pokaze Atref pa saceka 2s pa prikaze 5tref
                //ali ovo ne radi, jer ceka da se zavrsi cela ova velika fja da bi prikazao karte talona i onda prikaze samo krajnji 5tref
                //neku nit ubaciti
                Label nlbl = new Label();
                nlbl.Text = k.Broj + " " + k.Boja.ToString();
                CrtajLabelu(i, nlbl);

            }
        }

        void CrtajLabelu(int i, Label lbl)
        {
            int top = 0;
            lbl.Left = 813;
            top += 263 + i * 25;
            lbl.Top = top;
            lbl.Image = Izgled.Properties.Resources.red;
            lbl.ForeColor = Color.WhiteSmoke;

            lblPoteziKomp.Add(lbl);
            this.Controls.Add(lbl);

        }

        #endregion

        #region zamenaSpila, da li je kraj, tip poteza kompa

        void TipPoteza(IMove mv)
        {
            if(mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.BacaKartu))
            {
                PrikazatiKartuPoKartuTalon(mv.Karte);
                ObnoviKarteKomp(mv.Karte);
                
            }
            if(mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.PromeniBoju))
            {
                kontext.TrenutnoStanje.Boja = mv.NovaBoja;
                talon.Last().Boja = mv.NovaBoja;
               
                
            }
            if(mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.KupiKartu ) && igrac != 66 && igrac !=770) //66 znaci da komp kupovao  karte i sad ne vuce kartua ako nema, 770 vuko je 7ice
            {
                komp.Add(spilAV.Karte.Last());
                List<Karta> pom=new List<Karta>();
                pom.Add(spilAV.Karte.Last());
                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                novaIgra.KupioKarte(pom);
                
                CrtajKompKarte();
                igrac = 66;
                PokreniIgru();
                

            }
            if(mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.KupiKazneneKarte))//automatski se kupuju dve kaznene karte
            {
                List<Karta> pom = new List<Karta>();
                
                komp.Add(spilAV.Karte.Last());
                pom.Add(spilAV.Karte.Last());
                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);

                komp.Add(spilAV.Karte.Last());
                pom.Add(spilAV.Karte.Last());
                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
               
                novaIgra.KupioKarte(pom);
                CrtajKompKarte();

            }
            if(mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.Makao))
            {
                MessageBox.Show("MAKAO", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (IspitajKraj())
                    this.Close();

            }
            if(mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.Poslednja))
                MessageBox.Show("POSLEDNJA", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (mv.Tip.HasFlag(TIG.AV.Karte.TipPoteza.PromeniBoju))
            {
                MessageBox.Show("Boja je promenjena u :" + mv.NovaBoja.ToString(), "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ObnoviKarteKomp(mv.Karte);
                PrikazatiKartuPoKartuTalon(mv.Karte);

            }
        }

        bool IspitajKraj() 
        {
            if (komp.Count() < 1)
            {
                int bCov = Bodovanje(2);
                int bKomp = Bodovanje(1);
                MessageBox.Show("Izgubili ste. Vas br poena:" + bCov.ToString() + " Poeni racunara: " + bKomp.ToString(), "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return true;
            }
            if (covek.Count() < 1)
            {
                MessageBox.Show("Cestitamo, pobedili ste", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return true;
            }
          /*  if(spilAV.Karte.Count()==1)
            {
                MessageBox.Show("Nema vise karti za izvlacenje ", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int bCov = Bodovanje(2);
                int bKomp = Bodovanje(1);
                if(bCov<bKomp)
                    MessageBox.Show("Cestitamo, pobedili ste. Vas br poena:" +bCov.ToString() +" Poeni racunara: "+bKomp.ToString(),
                         "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Izgubili ste. Vas br poena:" + bCov.ToString() + " Poeni racunara: " + bKomp.ToString(),
                        "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                return true;
            }*/
            if(spilAV.Karte.Count()<1)
            {
                Karta pom = talon.Last();
                foreach (Karta k in talon)
                    spilAV.Karte.Add(k);
                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                spilAV.Promesaj();
                talon.Clear();
                talon.Add(pom);
                novaIgra.ObnoviSpil(spilAV.Karte);
            }

            DaLiSpilOkrenuti(1);
            return false;


        }

        void DaLiSpilOkrenuti(int uSpilMin)
        {
            if (spilAV.Karte.Count() < uSpilMin)
            {
                Karta pom = talon.Last();
                foreach (Karta k in talon)
                    spilAV.Karte.Add(k);
                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                spilAV.Promesaj();
                talon.Clear();
                talon.Add(pom);
                novaIgra.ObnoviSpil(spilAV.Karte);
            }
        }

        int Bodovanje(int i) //1 je komp , 2 je covek
        {
            int poeni = 0;
            List<Karta> karte = new List<Karta>();
            if (i == 1)
                foreach (Karta k in komp)
                    karte.Add(k);
            else
                foreach (Karta k in covek)
                    karte.Add(k);

            foreach (Karta k in karte)
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

        
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//NEXT
        {
            if(igrac ==333)
                igrac = 1;
            PokreniIgru();
            if (igrac == 66)
            {
                igrac = 1;
                PokreniIgru();
            }
        }

        #endregion

        #region 7ice i 2tref 
        bool CovekKupuje2tref(Karta kojuCIgra)
        {
            if(talon.Last().Broj.CompareTo("2")==0 &&  talon.Last().Boja==Boja.Tref)
            {
                List<Karta> pom = new List<Karta>();
                for(int i=0;i<4;i++)
                {
                    DaLiSpilOkrenuti(4);

                    covek.Add(spilAV.Karte.Last());
                    pom.Add(spilAV.Karte.Last());
                    spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);

                }
                CrtajCovekoveKarte();
                return true;
            }
            return false;
        }
        bool CovekKupuje7ica(Karta kojuCIgra)
        {
            if (talon.Last().Broj.CompareTo("7") == 0) //ako je komp bacio 7
            {
                bool cekaj = false;
                int citajZadnje7ice = 0;
                if (kojuCIgra.Broj.CompareTo("7") == 0)
                    cekaj = true;
                int br7ica = 0;
                List<Karta> pom = new List<Karta>();
                if (cekaj == false)
                {
                    for (int i = talon.Count() - 1; i > talon.Count() - 5; i--)
                    {
                        if (i > 0)
                        {
                            if (talon[i].Broj.CompareTo("7") == 0)
                            {
                                br7ica++;
                            }
                            citajZadnje7ice = br7ica - kupljene7ice;
                        }
                    }
                    kupljene7ice = 0;
                    for (int i = talon.Count() - 1; i > talon.Count() - 1-citajZadnje7ice; i--)
                    {
                        if (talon[i].Broj.CompareTo("7") == 0)
                            {
                                kupljene7ice--;
                                DaLiSpilOkrenuti(2);

                                covek.Add(spilAV.Karte.Last());
                                pom.Add(spilAV.Karte.Last());
                                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);

                                covek.Add(spilAV.Karte.Last());
                                pom.Add(spilAV.Karte.Last());
                                spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                            }
                        
                        kupljene7ice++;
                    }

                    CrtajCovekoveKarte();
                    
                    return true;
                }
            }
            return false;
        }

        void KompKupuje2tref(Karta k)
        {
            if (k.Broj.CompareTo("2") == 0 && k.Boja == Boja.Tref)
            {
                List<Karta> pom = new List<Karta>();
                for (int i = 0; i < 4; i++)
                {
                    DaLiSpilOkrenuti(4);

                    komp.Add(spilAV.Karte.Last());
                    pom.Add(spilAV.Karte.Last());
                    spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);

                }
                novaIgra.KupioKarte(pom);
                CrtajKompKarte();               
            }
            
        }
        void KompKupuje7ice() //tj covek bacio 7
        {
            if (talon.Last().Broj.CompareTo("7") == 0)//ako covek baci 7
            {
                bool cekaj = false;
                foreach (Karta kp in komp)
                {
                    if (kp.Broj.CompareTo("7") == 0)
                        cekaj = true;

                }
                List<Karta> pom = new List<Karta>();
                if (cekaj == false)
                {
                    int citajZadnje7ice = 0;
                    int br7ica = 0;
                    for (int i = talon.Count() - 1; i > talon.Count() - 5; i--)
                    {
                        if (i > 0)
                        {
                            if (talon[i].Broj.CompareTo("7") == 0)
                            {
                                br7ica++;
                            }
                            citajZadnje7ice = br7ica - this.kupljene7ice;
                        }
                    }
                    this.kupljene7ice = 0;
                    for (int i = talon.Count() - 1; i > talon.Count() - 1 - citajZadnje7ice; i--)
                    {

                        if (talon[i].Broj.CompareTo("7") == 0)
                        {
                            this.kupljene7ice++;
                            DaLiSpilOkrenuti(2);

                            komp.Add(spilAV.Karte.Last());
                            pom.Add(spilAV.Karte.Last());
                            spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);

                            komp.Add(spilAV.Karte.Last());
                            pom.Add(spilAV.Karte.Last());
                            spilAV.Karte.RemoveAt(spilAV.Karte.Count() - 1);
                        }
                    }
                        
                    
                    novaIgra.KupioKarte(pom);
                    igrac = 770;
                    CrtajKompKarte();
                }
            }
        }

        #endregion

        #region Glavne fje

        List<Karta> izabraneKarteCov;

        void clik_KartaCoveka(object sender, EventArgs e)
        {
            if (igrac == 1)
                return;
            
            bool krajPoteza = false;
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            btn.FlatAppearance.BorderSize = 15;

            Karta k = SlikaUKartu(btn);
            
            CovekKupuje7ica(k);

            if (k.Broj.CompareTo(talon.Last().Broj) == 0 || k.Boja == talon.Last().Boja || k.Broj.CompareTo("J") == 0)
                izabraneKarteCov.Add(k);
            else
            {
                DialogResult dg= MessageBox.Show("Izaberite odgovarajucu", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            KompKupuje2tref(k);

            if (k.Broj == "A" || k.Broj == "8")
            {
              //  MessageBox.Show("Izaberite jos jednu kartu", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                igrac = 33;

            }
            else igrac = 1;
            Boja boja = new Boja();
            if(k.Broj=="J")
            {
                Form frm = new FormBirajBoju(this);
                frm.ShowDialog();
                boja = PomocnaKarta.Boja;
              
            }
            else
            {
                boja = izabraneKarteCov.Last().Boja;    
            }
            foreach(Karta kk in izabraneKarteCov)
            {
                for(int i=0;i<covek.Count();i++)
                {
                    if(covek[i].Boja==kk.Boja && covek[i].Broj.CompareTo(kk.Broj)==0)
                    {
                        covek.RemoveAt(i);
                    }
                }
            }

            PrikazatiKartuPoKartuTalon(izabraneKarteCov);
            ObnoviKarteCovek();
            if(igrac!=33) //33 kaze da je bacio 8 ili A, i da  covek opet igra
                igrac = 1;

            krajPoteza = true;
            if (krajPoteza)
                novaIgra.Bacenekarte(izabraneKarteCov, boja, covek.Count());


            btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            izabraneKarteCov = new List<Karta>();
            if (IspitajKraj())
                this.Close();
            else
            {
                PokreniIgru();
                if (igrac == 66 || igrac==770)//770 kupovao 7ice, 66znaci vuko je kartu
                {
                    PokreniIgru();
                    igrac = 2;
                }
            }
        }
        
      
        private void btnKupiKartu_Click(object sender, EventArgs e)
        {
            Karta k = new Karta();
            k.Broj = "3";
            k.Boja = Boja.Unknown;
            if (CovekKupuje7ica(k) == false)
            {
                covek.Add(spilAV.Karte.Last());
                spilAV.Karte.RemoveAt(spilAV.Karte.Count - 1);
            }

            if (igrac == 333)
                igrac = 1;
            if (igrac == 1)
                return;
        
            ObnoviKarteCovek();
            if(igrac!=33)//ako je 33 onda cekamo da preklopi 8,A
                igrac = 333;
        }

        private void btnKraj_Click(object sender, EventArgs e)
        {
            int bCov = Bodovanje(2);
            int bKomp = Bodovanje(1);
            if (bCov < bKomp)
                MessageBox.Show("Cestitamo, pobedili ste. Vas br poena:" + bCov.ToString() + " Poeni racunara: " + bKomp.ToString(),
                     "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Izgubili ste. Vas br poena:" + bCov.ToString() + " Poeni racunara: " + bKomp.ToString(),
                    "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
     

        void PokreniIgru()
        {
            novaIgra = new Igra(kontext,1); 

            IMove im = new Move();


            if (igrac == 1)//igra racunar 
            {
                KompKupuje7ice();//ako je kupio vraca 770

                foreach (Button btn in btnKarteCoveka)
                    btn.Enabled = false;
                novaIgra.Bacenekarte(talon, kontext.TrenutnoStanje.Boja, covek.Count()); 

                novaIgra.BeginBestMove();

                System.Threading.Thread.Sleep(1000);

                novaIgra.EndBestMove();
                im = novaIgra.BestMove;




                foreach (Button btn in btnKarteCoveka)
                    btn.Enabled = true;
                TipPoteza(im);
            }

            
            CovekKupuje2tref(talon.Last());
            igrac = 2;  
            if (IspitajKraj())
                this.Close();
            



        }

        #endregion
    }

}
