using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_TPLUS.Domain.Entities
{
    [Keyless]
    public class PRoot
    {
        public List<Plant>? Plants { get; set; }
    }

    public class Plant : EntityBase
    {
        // Ссылка на Consumption
        [JsonProperty("consumptions")]
        public IReadOnlyCollection<PlantConsumption> Consumptions { get; set; }
    }

    public class PlantConsumption
    {
        public PlantConsumption() => DateCreate = DateTime.Now; //При создании нового объекта дата создания равна текущей	

        [Key]
        public int Id { get; set; }

        [JsonProperty("Date")]
        [DataType(DataType.Time)]
        public DateTime DateCreate { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("Consumption")]
        public double Consumption { get; set; }
        
        [ForeignKey("ConsumerId")]
        public int PlantConsumerId { get; set; }

        public Plant? Plant { get; set; }
    }
}
