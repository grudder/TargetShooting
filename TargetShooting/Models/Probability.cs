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

        [Required]
        [Display(Name = "名称", Order = 10)]
        [StringLength(20)]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "位置", Order = 20)]
        [StringLength(20)]
        public string Position
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "概率值", Order = 30)]
        public int Value
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "图片文件", Order = 40)]
        [StringLength(200)]
        public string ImageFile
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "是否中奖", Order = 50)]
        public bool IfWin
        {
            get;
            set;
        }
    }
}