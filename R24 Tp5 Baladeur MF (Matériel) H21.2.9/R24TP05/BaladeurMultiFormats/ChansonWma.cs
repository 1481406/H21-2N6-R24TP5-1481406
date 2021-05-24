using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{

    public class ChansonWma : Chanson
    {

        // int privé générer au hasard pour satisfaire l'encodage WMA
        private int m_codage;
        //retourne le format de la chanson
        public override string Format
        {
            get { return "WMA"; }
        }
        // écrit l'entête de la chanson selon les spécification du format WMA
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            Random number = new Random();
            int randomInt = number.Next(3, 15);
            m_codage = randomInt;
            pobjFichier.WriteLine(  m_codage  + " / " + m_année + " / " + m_titre + " / " + m_artiste);
        }
        // écrit les paroles dans le fichier selon les specifications WMA
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            OutilsFormats.EncoderWMA(pParoles, m_codage);
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
        // les constructeurs pour les Chansons WMA
        public ChansonWma(string pNomFichier)
        : base(pNomFichier)
        {

        }
        public ChansonWma(string pRepertoire, string pArtiste, string ptitre, int pAnnée)
        : base(pRepertoire, pArtiste, ptitre, pAnnée)
        {

        }
    }
}
