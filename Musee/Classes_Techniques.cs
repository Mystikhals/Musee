using System.Collections.Generic;

namespace Musee
{
    // Utilisation des PREDICATS et de la méthode de COMPARAISON sur les classes METIER
    public class Predicats
    {
        // Donnée utilisées par le PREDICAT
        public static string nomArtiste = "";

        // Méthode PREDICAT (pour "Find()", "FindAll()"...)
        // Cette fonction sera appliquée, à tour de rôle, à chaque élement 
        // d'une collection d'OEUVRES pour une SALLE...
        public static bool RechercheOeuvresArtiste(Oeuvre o)
        {
            return nomArtiste == o.GetArtiste().GetNomArtiste();
        }

        // Méthodes de COMPARAISON (pour "Sort()") entre deux objets OEUVRE ACHETEE
        // Cette méthode doit retourner, suivant le critère de comparaison 
        //      0 si = égalité
        //      1 = si o1 > o2
        //      -1 = si o1 < o2
        public static int ComparerOeuvresParNom(Oeuvre o1, Oeuvre o2)
        {
            // A COMPLETER
        }
        public static int ComparerOeuvresParPrix(Oeuvre o1, Oeuvre o2)
        {
            List<Oeuvre_Achetee> lesOeuvres = new List<Oeuvre_Achetee>();
            if (o1.GetType() == typeof(Oeuvre_Achetee) && o2.GetType() == typeof(Oeuvre_Achetee))
            {
                lesOeuvres.Add((Oeuvre_Achetee)o1);
                lesOeuvres.Add((Oeuvre_Achetee)o2);
                if (lesOeuvres[0].GetPrixOeuvre() < lesOeuvres[1].GetPrixOeuvre())
                {
                    return -1;
                }
                else if (lesOeuvres[0].GetPrixOeuvre() > lesOeuvres[1].GetPrixOeuvre())
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
