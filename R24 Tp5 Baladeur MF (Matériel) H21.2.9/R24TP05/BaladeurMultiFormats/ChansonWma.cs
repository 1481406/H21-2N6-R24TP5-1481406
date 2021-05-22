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

      
        private int m_codage;

        public override string Format
        {
            get { return "WMA"; }
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            Random number = new Random();
            int randomInt = number.Next(3, 15);
            m_codage = randomInt;
            pobjFichier.WriteLine(  m_codage  + " / " + m_année + " / " + m_titre + " / " + m_artiste);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            OutilsFormats.EncoderWMA(pParoles, m_codage);
            pobjFichier.WriteLine(pParoles);
        }

        public override void LireEntete()
        {
            StreamReader objwriter = new StreamReader(NomFichier.ToString());
            string enteteplusgras = objwriter.ReadLine();
            string[] enleveDugras = enteteplusgras.Split();
            m_artiste = enleveDugras[0].Trim();
            m_année = int.Parse(enleveDugras[1]);
            m_titre = enleveDugras[2];

        }

        public override string LireParoles(StreamReader pobjfichier)
        {
            SauterEntete(pobjfichier);
            string paroles = pobjfichier.ReadToEnd();
            return paroles;
        }

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
