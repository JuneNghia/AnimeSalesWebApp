using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webbandohh.Models
{
    [Table("Creator")]
    public class Creator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreatorId { get; set; }

        [StringLength(50)]
        public string CreatorName { get; set; }

        [StringLength(100)]
        public string History { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
