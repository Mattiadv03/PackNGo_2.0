using SQLite;

namespace PackNGo.Tabelle
{
    [Table("Vacanze")]
    public class Vacanze
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100), NotNull]
        public string nomeVacanza { get; set; }

        [NotNull]
        public int numeroDiNotti { get; set; }

        [MaxLength(100), NotNull]
        public string stagione { get; set; }

        public int idTipologia { get; set; }
    }
}
