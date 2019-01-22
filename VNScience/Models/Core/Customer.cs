using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VNScience.Models.Core
{
    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Tên đối tác")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string CoverImage { get; set; }

        [Display(Name = "Website")]
        public string Homepage { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

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

        public virtual ApplicationUser CreatingUser { get; set; }
        public virtual ApplicationUser UpdatingUser { get; set; }
    }
}