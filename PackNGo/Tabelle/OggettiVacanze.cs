using SQLite;

namespace PackNGo.Tabelle
{
    [Table("OggettiVacanze")]
    public class OggettiVacanze
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100), NotNull]
        public string nomeOggetto { get; set; }

        [NotNull]
        public int numeroDeciso { get; set; }

        public int idVacanza { get; set; }

        public int idCategoria { get; set; }
    }
}
