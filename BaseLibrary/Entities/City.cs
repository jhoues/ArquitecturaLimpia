using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        //Muchos a uno relacionado con pais
        public Country? Country { get; set; }
        public int CountryId { get; set; }
        //uno a muchos reacionado con Town
        [JsonIgnore]
        public List<Town>? Towns { get; set; }
    }
}
