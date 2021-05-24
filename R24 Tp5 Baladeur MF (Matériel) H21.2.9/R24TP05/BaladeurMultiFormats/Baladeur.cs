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
                // will this work?????
                if (!Directory.Exists("Chansons"))
                {
                    throw new DirectoryNotFoundException();
                }
                foreach (var item in Directory.GetFiles("Chansons"))
                {
                    if (!File.Exists(item))
                    {
                        throw new FileNotFoundException();
                    }
                    
                  //  m_colChansons.Add(ChansonAAC(item));
                }
                pListView.Items.Add(ChansonCourante.ToString());
            }
            
        }

        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        public void ConstruireLaListeDesChansons()
        {

            // how is this supposed to be done???? 
            foreach (var Chanson in m_colChansons)
            {
                if (!File.Exists(Chanson.ToString()))
                {
                    throw new FileNotFoundException();
                }
                


            }
        }

        public void ConvertirVersAAC(int pIndex)
        {
            ChansonAAC Lachansonaac = new ChansonAAC(m_colChansons[pIndex].ToString());

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
