using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VNScience.Models.Core
{
    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên giải pháp")]
        public string Name { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string CoverImage { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; }

        [StringLength(128)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày sửa")]
        public DateTime? UpdatedAt { get; set; }

        [StringLength(128)]
        [Display(Name = "Người sửa")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Thuộc giải pháp")]
        public int? ParentId { get; set; }

        public virtual ProductCategory Parent { get; set; }
        public virtual List<ProductCategory> Children { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual ApplicationUser CreatingUser { get; set; }
        public virtual ApplicationUser UpdatingUser { get; set; }
    }
}