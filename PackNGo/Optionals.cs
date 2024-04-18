using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackNGo
{
    public class Bicicletta
    {
        [JsonProperty("Maglietta tecnica")]
        public string Magliettatecnica { get; set; }

        [JsonProperty("Pantaloni da bici")]
        public string Pantalonidabici { get; set; }

        [JsonProperty("Calze tecniche")]
        public string Calzetecniche { get; set; }

        [JsonProperty("Scarpe da ginnastica per la bicicletta")]
        public int Scarpedaginnasticaperlabicicletta { get; set; }
    }

    public class Neve
    {
        [JsonProperty("Giacca da neve")]
        public int Giaccadaneve { get; set; }

        [JsonProperty("Pantaloni da neve")]
        public int Pantalonidaneve { get; set; }

        [JsonProperty("Calze grosse da neve")]
        public int Calzegrossedaneve { get; set; }

        [JsonProperty("Scarponcini/Doposcii")]
        public int ScarponciniDoposcii { get; set; }

        [JsonProperty("Berretto da neve")]
        public int Berrettodaneve { get; set; }
        public int Scaldacollo { get; set; }

        [JsonProperty("Guanti da neve")]
        public int Guantidaneve { get; set; }

        [JsonProperty("Calza maglia")]
        public int Calzamaglia { get; set; }
    }

    public class PiscinaMare
    {
        public string Costume { get; set; }
        public string Cuffia { get; set; }

        [JsonProperty("Telo mare")]
        public int Telomare { get; set; }

        [JsonProperty("Borsetta roba onta piscina/mare")]
        public int Borsettarobaontapiscinamare { get; set; }
    }

    public partial class Optionals
    {
        public List<string> Crema_solare { get; set; }
        public List<string> Lavoro { get; set; }
        public List<string> Svago { get; set; }
        public List<string> Pioggia { get; set; }
        public List<string> Campeggio { get; set; }
        public PiscinaMare Piscina_Mare { get; set; }
        public Bicicletta Bicicletta { get; set; }
        public Neve Neve { get; set; }
    }
}
