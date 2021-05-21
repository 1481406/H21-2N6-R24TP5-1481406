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
            throw new NotImplementedException();
        }

        public override string LireParoles(StreamReader pobjfichier)
        {
            throw new NotImplementedException();
        }

        public  ChansonMP3(string pNomFichier)
            :base(pNomFichier)
        {
            
        }

    }
}
