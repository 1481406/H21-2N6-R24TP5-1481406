using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {

        private const string NOM_RÉPERTOIRE = "Chansons";
        private List<Chanson> m_colChansons;



        public int NbChansons
        {
            get;
        }

        public void AfficherLesChansons(ListView pListView)
        {
            pListView.Clear();
            foreach (var ChansonCourante in m_colChansons)
            {
                ListViewItem objitem = new ListViewItem(ChansonCourante.Artiste);
                objitem.SubItems.Add(ChansonCourante.Titre);
                objitem.SubItems.Add(ChansonCourante.Annee.ToString());
                objitem.SubItems.Add(ChansonCourante.Format);
                objitem.Tag = ChansonCourante;
                
               
                
                pListView.Items.Add(objitem);
            }
            
        }

        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        public void ConstruireLaListeDesChansons()
        {
            if (!Directory.Exists("Chansons"))
            {
                throw new DirectoryNotFoundException();
            }
            // how is this supposed to be done???? 

            if (Directory.Exists(NOM_RÉPERTOIRE))
            {
                string[] fichiersDesChansons = Directory.GetFiles(NOM_RÉPERTOIRE);

                foreach (var ChansonsIndividuelles in fichiersDesChansons)
                {

                    if (!File.Exists( NOM_RÉPERTOIRE + "\\" + ChansonsIndividuelles))
                    {
                        throw new FileNotFoundException();
                    }
                    string[] Nomsplit = ChansonsIndividuelles.Split('.');
                    string extentionDeFichier = Nomsplit[1];


                    Chanson chansonCourante;

                    if (extentionDeFichier == "wma")
                    {
                        chansonCourante = new ChansonWma(ChansonsIndividuelles);

                    }
                    else if (extentionDeFichier == "mp3")
                    {
                        chansonCourante = new ChansonMP3(ChansonsIndividuelles);
                    }
                    else //(extentionDeFichier == "aac")
                    {
                        chansonCourante = new ChansonAAC(ChansonsIndividuelles);
                    }
                    m_colChansons.Add(chansonCourante);


                }
            }

        }

        public void ConvertirVersAAC(int pIndex)
        {
            Chanson lachanson = m_colChansons[pIndex];
           
            ChansonAAC Lachansonaac = new ChansonAAC(lachanson.NomFichier,lachanson.Artiste,lachanson.Titre,lachanson.Annee);
           
            
            Lachansonaac.Ecrire(lachanson.Paroles);
           
            File.Delete("Chanson\\" + lachanson.NomFichier);

            

        }

        public void ConvertirVersMP3(int pIndex)
        {
            Chanson lachanson = m_colChansons[pIndex];


            ChansonMP3 Lachansonmp3 = new ChansonMP3(lachanson.NomFichier, lachanson.Artiste, lachanson.Titre, lachanson.Annee);
            
            
            Lachansonmp3.Ecrire(lachanson.Paroles);
            File.Delete("Chanson\\" + lachanson.NomFichier);

        }

        public void ConvertirVersWMA(int pIndex)
        {
         
            
            Chanson lachanson = m_colChansons[pIndex];
            ChansonWma LachansonWMA = new ChansonWma(lachanson.NomFichier, lachanson.Artiste, lachanson.Titre, lachanson.Annee);
          
            LachansonWMA.Ecrire(lachanson.Paroles);
          
            File.Delete("Chanson\\" + lachanson.NomFichier);
        }

        public Baladeur()
        {
            m_colChansons.Clear();
        }


    }
}
