
namespace Exo_Article
{
    public class Article
    {

        public int Ref { get; set; }
        public string Nom { get; set; }
        public float PrixVente { get; set; }

        public Article(){ 
            Ref = 1;
            Nom = "article par défault";
            PrixVente = 1.00f;
        
        }

        public override string ToString()
        {
            return "ref de l'article : "+this.Ref+ "\nDésignation de l'article : " + this.Nom+"\nPrix de vente:  "+this.PrixVente;
        }

    }
}
