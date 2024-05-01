using HealthKit;
using PackNGo.Database.Tabelle;
using SQLite;

namespace PackNGo.Database
{
    public class OperazioniDatabase<Table> where Table : class, new()
    {
        private SQLiteAsyncConnection conn;

        private async Task InitDB()
        {
            // Controllo se esiste già la connessione al db
            if (conn != null)
                // Si, evito di ricrearla
                return;

            // No, mi connetto
            conn = new SQLiteAsyncConnection(Database.Constants.DatabasePath, Database.Constants.Flags);

            // Creo le tabelle
            await conn.CreateTableAsync<Tabelle.CategorieOggetti>();
            await conn.CreateTableAsync<Tabelle.Oggetti>();
            await conn.CreateTableAsync<Tabelle.OggettiVacanze>();
            await conn.CreateTableAsync<Tabelle.TipologieVacanza>();
            await conn.CreateTableAsync<Tabelle.Vacanze>();

            // Popolo gli elementi del database

        }

        public async Task<List<Table>> SelectAllAsync()
        {
            await InitDB();
            return await conn.Table<Table>().ToListAsync();
        }

        public async Task<int> InsertAsync(Table elemento)
        {
            await InitDB();
            return await conn.InsertAsync(elemento);
        }

        public async Task<int> UpdateAsync(Table elemento)
        {
            await InitDB();
            return await conn.UpdateAsync(elemento);
        }

        public async Task<int> DeleteItemAsync(Table elemento)
        {
            await InitDB();
            return await conn.DeleteAsync(elemento);
        }
    }

}
