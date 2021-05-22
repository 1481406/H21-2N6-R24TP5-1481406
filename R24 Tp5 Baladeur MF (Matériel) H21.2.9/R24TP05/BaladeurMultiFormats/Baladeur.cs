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
            throw new NotImplementedException();
        }

        public Chanson ChansonAt(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConstruireLaListeDesChansons()
        {
            foreach (var Chanson in m_colChansons)
            {
                if ()
                {

                }
            }
        }

        public void ConvertirVersAAC(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }

        public Baladeur()
        {
            m_colChansons.Clear();
        }


    }
}
