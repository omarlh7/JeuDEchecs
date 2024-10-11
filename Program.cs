using System;

namespace JeuDEchecs
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = new Plateau();
            plateau.AfficherPlateau();

            bool partieEnCours = true;
            while (partieEnCours)
            {
                Console.WriteLine("Entrez votre coup (ex: e2 e4): ");
                string coup = Console.ReadLine();
                if (!plateau.DeplacerPiece(coup))
                {
                    Console.WriteLine("Coup invalide, réessayez.");
                }
                plateau.AfficherPlateau();
            }
        }
    }
}
