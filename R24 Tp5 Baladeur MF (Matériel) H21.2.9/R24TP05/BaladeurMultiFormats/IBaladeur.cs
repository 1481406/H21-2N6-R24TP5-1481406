using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
   public interface IBaladeur
    {
        // vas chercher le nombres de chansons.
         int NbChansons
        {
            get;
        }
        // // affiher les chansons dans le lsv
        void AfficherLesChansons(ListView pListView);
        // Index de la chanson courante.
        Chanson ChansonAt(int pIndex);
        // Construit la liste de chanson a partir des fichiers
        void ConstruireLaListeDesChansons();
        // convertis le format des chansons en AAC
        void ConvertirVersAAC(int pIndex);
        // convertis le format des chansons en MP3
        void ConvertirVersMP3(int pIndex);
        //convertis le format des chansons en WMA
        void ConvertirVersWMA(int pIndex);



    }
}
