using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        //retourne le format de la chanson
        public override string Format
        {
            get { return "MP3"; } 
        }

        // écrit l'entête de la chanson selon les spécification du format mp3
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(Artiste.ToString() + "|"+ Annee.ToString() + "|" + Titre.ToString()) ;
            
        }

        // écrit les paroles dans le fichier selon les specifications mp3
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.WriteLine(pParoles);
        }


        // lit l'entête du fichier de la chanson
        public override void LireEntete()
        {
            // lit l'entête du fichier de la chanson
            StreamReader objwriter = new StreamReader(NomFichier.ToString());
            string enteteplusgras = objwriter.ReadLine();
            string[] enleveDugras = enteteplusgras.Split();

            // initialise les  champs de la chanson
            m_artiste = enleveDugras[0].Trim();
            m_année = int.Parse(enleveDugras[1]);
            m_titre = enleveDugras[2];





        }
        // lit les paroles de la chanson
        public override string LireParoles(StreamReader pobjfichier)
        {
            //saute l'entête de la chanson
            SauterEntete(pobjfichier);
            // lit les paroles du fichier et les retourne 
            string paroles = pobjfichier.ReadToEnd();
            return paroles;
        }

        // les constructeurs pour les Chansons MP3
        public  ChansonMP3(string pNomFichier)
            :base(pNomFichier)
        {
            
        }

        public ChansonMP3(string pRepertoire, string pArtiste, string ptitre, int pAnnée)
            :base(pRepertoire, pArtiste, ptitre, pAnnée)
        {
            
        }
    }
}
