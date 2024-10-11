using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDEchecs
{
    internal class Plateau
    {
        private string[,] cases;

        public Plateau()
        {
            cases = new string[8, 8];
            InitialiserPlateau();
        }

        public void InitialiserPlateau()
        {
            // Initialisation des pièces blanches
            cases[0, 0] = "T"; cases[0, 1] = "C"; cases[0, 2] = "F"; cases[0, 3] = "Q";
            cases[0, 4] = "K"; cases[0, 5] = "F"; cases[0, 6] = "C"; cases[0, 7] = "T";
            for (int i = 0; i < 8; i++)
                cases[1, i] = "P"; // Pions blancs

            // Initialisation des cases vides
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cases[i, j] = ".";
                }
            }

            // Initialisation des pièces noires
            cases[7, 0] = "t"; cases[7, 1] = "c"; cases[7, 2] = "f"; cases[7, 3] = "q";
            cases[7, 4] = "k"; cases[7, 5] = "f"; cases[7, 6] = "c"; cases[7, 7] = "t";
            for (int i = 0; i < 8; i++)
                cases[6, i] = "p"; // Pions noirs
        }

        // Affiche le plateau d'échecs
        public void AfficherPlateau()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(cases[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Déplace une pièce d'une case à une autre
        public bool DeplacerPiece(string coup)
        {
            string[] positions = coup.Split(' ');
            if (positions.Length != 2)
                return false;

            (int ligneDepart, int colonneDepart) = ConvertirPosition(positions[0]);
            (int ligneArrivee, int colonneArrivee) = ConvertirPosition(positions[1]);

            if (ligneDepart == -1 || ligneArrivee == -1)
                return false;

            if (cases[ligneDepart, colonneDepart] == ".")
                return false;

            // Effectuer le déplacement
            cases[ligneArrivee, colonneArrivee] = cases[ligneDepart, colonneDepart];
            cases[ligneDepart, colonneDepart] = ".";

            return true;
        }

        // Convertir une position comme "e2" en coordonnées
        private (int, int) ConvertirPosition(string position)
        {
            if (position.Length != 2)
                return (-1, -1);

            int colonne = position[0] - 'a';
            int ligne = 8 - (position[1] - '0');

            if (colonne < 0 || colonne >= 8 || ligne < 0 || ligne >= 8)
                return (-1, -1);

            return (ligne, colonne);
        }
    }
}

