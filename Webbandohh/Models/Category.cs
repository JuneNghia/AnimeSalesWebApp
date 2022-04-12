using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webbandohh.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CateId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Loại")]
        public string CateName { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}