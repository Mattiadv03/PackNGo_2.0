using SQLite;

namespace PackNGo.Database.Tabelle
{
    [Table("Oggetti")]
    public class Oggetti
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100), Unique, NotNull]
        public string nomeOggettoFormattato { get; set; }

        [MaxLength(100), NotNull]
        public string numeroNecessario { get; set; }

        public int idCategoria { get; set; }
    }
}
