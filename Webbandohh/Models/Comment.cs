using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webbandohh.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        public int? ItemId { get; set; }
        [StringLength(200)]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool IsActive { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}