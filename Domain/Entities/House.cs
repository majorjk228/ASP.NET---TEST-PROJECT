using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_TPLUS.Domain.Entities
{
    [Keyless]
    public class HRoot
    {
        public List<House> houses { get; set; }
    }

    public class House : EntityBase
    {
        // Ссылка на Consumption
        [JsonProperty("consumptions")]
        public IReadOnlyCollection<HouseConsumption> Consumptions { get; set; }
    }

    public class HouseConsumption
    {
        public HouseConsumption() => DateCreate = DateTime.Now; //При создании нового объекта дата создания равна текущей	

        [Key]
        public int Id { get; set; }

        [JsonProperty("Date")]
        [DataType(DataType.Time)]
        public DateTime DateCreate { get; set; }
        [JsonProperty("Weather")]
        public double Weather { get; set; }
        [JsonProperty("Consumption")]
        public double Consumption { get; set; }


        //[Required]
        [ForeignKey("HouseConsumerId")]
        public House? House { get; set; }

    }
}
