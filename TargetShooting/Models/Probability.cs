using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetShooting.Models
{
    [Table("T_Probability")]
    [DisplayName("中奖概率")]
    public class Probability
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "用户", Order = 10)]
        public int UserId
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "收塔人", Order = 20)]
        [StringLength(20)]
        public string ReveiverName
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "手机号码", Order = 30)]
        [StringLength(20)]
        public string Mobile
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "详细地址", Order = 40)]
        [StringLength(200)]
        public string Address
        {
            get;
            set;
        }

        [Display(Name = "备注", Order = 50)]
        [StringLength(1000)]
        public string Remark
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "创建时间", Order = 60)]
        public DateTime CreateTime
        {
            get;
            set;
        }
    }
}