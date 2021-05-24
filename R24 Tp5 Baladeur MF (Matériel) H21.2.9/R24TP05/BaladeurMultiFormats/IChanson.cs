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
        // vas chercher les  informations pour les chansons
         int Annee { get; }
        string Artiste { get; }
        string Format { get; }
        string NomFichier { get; }
        string Paroles { get; }
        string Titre { get; }




        // Écrit les paroles
         void Ecrire(string pParoles);

        // Écrit l'entete  dans le fichier
        void EcrireEntete(StreamWriter pobjFichier);
        // écris les paroles dans le fichier
        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        // Lit l'entête dune chanson
        void LireEntete();

        // Lit les paroles dune chanson
        string LireParoles(StreamReader pobjfichier);
        // Saute L'entête pour aller au paroles de la chanson
        void SauterEntete(StreamReader pobjFichier);



    }
}
