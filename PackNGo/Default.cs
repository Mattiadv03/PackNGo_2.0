using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackNGo
{
    public class Beauty
    {
        public List<string> Denti { get; set; }
        public List<string> Doccia { get; set; }

        [JsonProperty("Cotton fioc")]
        public string Cottonfioc { get; set; }
        public string Cera { get; set; }
        public List<string> Cerotti { get; set; }
        public List<string> Extra { get; set; }
    }

    public class Intimo
    {
        public string Mutande { get; set; }
        public string Calzini { get; set; }
        public List<string> Pigiama { get; set; }

        [JsonProperty("Borsetta roba onta intimo")]
        public int Borsettarobaontaintimo { get; set; }
    }

    public class Default
    {
        public Beauty Beauty { get; set; }
        public List<string> Elettronica { get; set; }
        public List<string> Utility { get; set; }
        public Intimo Intimo { get; set; }
    }


}
