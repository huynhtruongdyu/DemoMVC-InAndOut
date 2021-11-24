using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Borrower { get; set; }

        [Required]
        public string Lender { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Item Type")]
        [ForeignKey("ItemType")]
        public int? ItemTypeId { get; set; }

        public virtual ItemType ItemType { get; set; }
    }
}