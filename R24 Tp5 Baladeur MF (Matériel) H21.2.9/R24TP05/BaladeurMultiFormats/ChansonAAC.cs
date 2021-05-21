using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        public override string Format => throw new NotImplementedException();

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            throw new NotImplementedException();
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ChansonAAC(string pNomFichier)
        :base(pNomFichier)
        {
        
        }
        public ChansonAAC(string pRepertoire, string pArtiste, string ptitre, int pAnnée)
        : base(pRepertoire, pArtiste, ptitre, pAnnée)
        {

        }

    }
}
