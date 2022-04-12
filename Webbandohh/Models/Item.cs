using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webbandohh.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Tên")]
        public string Title { get; set; }

        [Display(Name = "Loại")]
        public int? CateId { get; set; }
        [Display(Name = "Người tạo")]
        public int? CreatorId { get; set; }
        [Display(Name = "Nhà sản xuất")]
        public int? ProId { get; set; }

        [Display(Name = "Tóm Tắt")]
        public string Summary { get; set; }

        [StringLength(250)]
        [Display(Name = "Upload file")]
        public string ImgUrl { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Ngày Nhập")]
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }
        [Display(Name = "Ngày Sửa")]
        [DataType(DataType.Date)]
        public DateTime? ModifierDate { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [ForeignKey("CateId")]
        public virtual Category Category { get; set; }
        [ForeignKey("CreatorId")]
        public virtual Creator Creator { get; set; }
        [ForeignKey("ProId")]
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}