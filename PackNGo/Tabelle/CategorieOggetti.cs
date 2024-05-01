using SQLite;

namespace PackNGo.Tabelle
{
    [Table("CategorieOggetti")]
    public class CategorieOggetti
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100), Unique, NotNull]
        public string nomeCategoria { get; set; }
    }
}
