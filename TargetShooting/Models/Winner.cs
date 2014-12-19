using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetShooting.Models
{
    [Table("T_Winner")]
    [DisplayName("中奖人")]
    public class Winner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "姓名", Order = 10)]
        [StringLength(20)]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "电话", Order = 20)]
        [StringLength(20)]
        public string Tel
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "地址", Order = 30)]
        [StringLength(200)]
        public string Address
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "创建时间", Order = 40)]
        public DateTime CreateTime
        {
            get;
            set;
        }
    }
}