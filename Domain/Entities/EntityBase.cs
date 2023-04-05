using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace TEST_TPLUS.Domain.Entities
{
    public abstract class EntityBase
    {
        [JsonProperty("ConsumerId")]
        [Key]
        public int ConsumerId { get; set; }

        [JsonProperty("Name")]
        [Required]
		[Display(Name = "Наименование")]
        public virtual string? Name { get; set; }

        [Required]
		[Display(Name = "Пользователь")]
		public virtual string? UserName { get; set; }
    }
}
