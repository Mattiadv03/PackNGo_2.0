using PackNGo.Database.Tabelle;
using SQLite;

namespace PackNGo.Database
{
    public class OperazioniDatabase<Table> where Table : class, new() 
    {
        private SQLiteAsyncConnection? conn;

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

            // Popolo il database

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

        public async void csvToDB(string percorsoCSV, SQLiteAsyncConnection conn, string nomeTabella, string[] nomiColonne)
        {
            // Leggo il file CSV
            using (var sr = new StreamReader(percorsoCSV))
            {
                string line;
                bool primaEsecuzione = true;
                while((line = await sr.ReadLineAsync()) != null)
                {
                    var valori = line.Split(',');

                    if (primaEsecuzione)
                    {
                        primaEsecuzione = false;
                        continue;
                    }

                    // Crea l'istruzione INSERT con parametri
                    string sql = $"INSERT INTO {nomeTabella} ({string.Join(",", nomiColonne)}) VALUES (@{nomiColonne[0]}, @{nomiColonne[1]}, ...)";

                    // Aggiungi parametri per ogni valore
                    using (var command = new SQLiteCommand(sql, conn))
                    {
                        for (int i = 0; i < valori.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@{nomiColonne[i]}", valori[i]);
                        }

                        // Esegui l'istruzione INSERT
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }

}
