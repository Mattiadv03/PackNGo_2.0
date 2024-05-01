using SQLite;

namespace PackNGo.Database.Tabelle
{
    [Table("TipologieVacanza")]
    public class TipologieVacanza
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100), Unique, NotNull]
        public string nomeTipologiaFormattato { get; set; }

        [MaxLength(100), Unique, NotNull]
        public string nomeTipologiaTrimmed { get; set; }
    }
}
