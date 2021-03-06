using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}