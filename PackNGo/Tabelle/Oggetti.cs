using SQLite;

namespace PackNGo.Tabelle
{
    [Table("Oggetti")]
    public class Oggetti
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100), Unique, NotNull]
        public string nomeOggettoFormattato { get; set; }

        [MaxLength(100), Unique, NotNull]
        public string nomeOggettoTrimmed { get; set; }

        [NotNull]
        public int numeroNecessario { get; set; }

        public int idCategoria { get; set; }
    }
}
