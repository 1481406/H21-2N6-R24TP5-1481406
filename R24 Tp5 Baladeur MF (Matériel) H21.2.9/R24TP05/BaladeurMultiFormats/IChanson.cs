using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    interface IChanson
    {        
         int Annee { get; }
        string Artiste { get; }
        string Format { get; }
        string NomFichier { get; }
        string Paroles { get; }
        string Titre { get; }





         void Ecrire(string pParoles);
        void EcrireEntete(StreamWriter pobjFichier);

        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        void LireEntete();

        void LireParoles(StreamWriter pobjfichier, string pParoles);

        void SauterEntete(StreamReader pobjFichier);



    }
}
