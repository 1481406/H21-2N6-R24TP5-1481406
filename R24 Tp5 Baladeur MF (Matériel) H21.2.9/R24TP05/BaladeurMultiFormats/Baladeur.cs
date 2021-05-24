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
        // les constante + la liste dans laquel les chansons vons être stocker.
        private const string NOM_RÉPERTOIRE = "Chansons";
        private List<Chanson> m_colChansons;


        // retourne le compte de chansons dans la liste
        public int NbChansons
        {
            get { return m_colChansons.Count(); }
        }
        // affiche les chansons dans la liste
        public void AfficherLesChansons(ListView pListView)
        {
            // clair la liste si il y avais des informations qui ne sont plus a jour
            pListView.Clear();
            // pour chaques chansons dans la liste de chansons
            foreach (var ChansonCourante in m_colChansons)
            {
                // load ses champs dans la listview
                ListViewItem objitem = new ListViewItem(ChansonCourante.Artiste);
                objitem.SubItems.Add(ChansonCourante.Titre);
                objitem.SubItems.Add(ChansonCourante.Annee.ToString());
                objitem.SubItems.Add(ChansonCourante.Format);
                objitem.Tag = ChansonCourante;
                
               
                // ajoute les objets a la chanson.
                pListView.Items.Add(objitem);
            }
            
        }

        // retourne la chanson dans l'index courant.
        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }
        // Construit la liste de chansons 
        public void ConstruireLaListeDesChansons()
        {
            // si le directory n'existe pas 
            if (!Directory.Exists("Chansons"))
            {
                throw new DirectoryNotFoundException();
            }
           
            // mais si il existe,
            if (Directory.Exists(NOM_RÉPERTOIRE))
            {
                // contiens le nom de tout les fichiers dans le répertoire de la constante.
                string[] fichiersDesChansons = Directory.GetFiles(NOM_RÉPERTOIRE);

                // pour chaques chansons 
                foreach (var ChansonsIndividuelles in fichiersDesChansons)
                {
                    // si le fichier n'existe pas 
                    if (!File.Exists( NOM_RÉPERTOIRE + "\\" + ChansonsIndividuelles))
                    {
                        throw new FileNotFoundException();
                    }
                    //sinon si il existe
                    
                    // split le nom afin d'aller y chercher son extention
                    string[] Nomsplit = ChansonsIndividuelles.Split('.');
                    string extentionDeFichier = Nomsplit[1];

                    // instancie une nouvelle chanson appeller Chanson courante, elle ne  peut être null a cause des sorties
                    Chanson chansonCourante;

                    // si le fichier est en wma
                    if (extentionDeFichier == "wma")
                    {
                        chansonCourante = new ChansonWma(ChansonsIndividuelles);

                    }
                    // si le fichier est en mp3
                    else if (extentionDeFichier == "mp3")
                    {
                        chansonCourante = new ChansonMP3(ChansonsIndividuelles);
                    }
                    else if (extentionDeFichier == "aac")
                    {
                        chansonCourante = new ChansonAAC(ChansonsIndividuelles);
                    }

                    else
                    {
                        throw new FileLoadException();
                    }
                    m_colChansons.Add(chansonCourante);


                }
            }

        }

        // convertis la chanson en aac
        public void ConvertirVersAAC(int pIndex)
        {
            Chanson lachanson = m_colChansons[pIndex];
           
            ChansonAAC Lachansonaac = new ChansonAAC(lachanson.NomFichier,lachanson.Artiste,lachanson.Titre,lachanson.Annee);
           
            
            Lachansonaac.Ecrire(lachanson.Paroles);
           
            File.Delete("Chanson\\" + lachanson.NomFichier);

            

        }
        //Convertis la chanson vers mp3
        public void ConvertirVersMP3(int pIndex)
        {
            Chanson lachanson = m_colChansons[pIndex];


            ChansonMP3 Lachansonmp3 = new ChansonMP3(lachanson.NomFichier, lachanson.Artiste, lachanson.Titre, lachanson.Annee);
            
            
            Lachansonmp3.Ecrire(lachanson.Paroles);
            File.Delete("Chanson\\" + lachanson.NomFichier);

        }
        // Convertir Vers WMA
        public void ConvertirVersWMA(int pIndex)
        {
         
            
            Chanson lachanson = m_colChansons[pIndex];
            ChansonWma LachansonWMA = new ChansonWma(lachanson.NomFichier, lachanson.Artiste, lachanson.Titre, lachanson.Annee);
          
            LachansonWMA.Ecrire(lachanson.Paroles);
          
            File.Delete("Chanson\\" + lachanson.NomFichier);
        }

        // clear la collection de chansons.
        public Baladeur()
        {
            m_colChansons.Clear();
        }


    }
}
