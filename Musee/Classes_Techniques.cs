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

        }

        // Méthodes de COMPARAISON (pour "Sort()") entre deux objets OEUVRE ACHETEE
        // Cette méthode doit retourner, suivant le critère de comparaison 
        //      0 si = égalité
        //      1 = si o1 > o2
        //      -1 = si o1 < o2
        public static int ComparerOeuvresParNom(Oeuvre o1, Oeuvre o2)
        {

        }
        public static int ComparerOeuvresParPrix(Oeuvre o1, Oeuvre o2)
        {

        }
    }
}
