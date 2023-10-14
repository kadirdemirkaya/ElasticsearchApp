using System.ComponentModel.DataAnnotations;

namespace ElasticsearchForm.Enums
{
    public enum Category
    {
        [Display(Name = "İtalyanMutfagi")]
        İtalyanMutfagi,
        [Display(Name = "CinMutfagi")]
        CinMutfagi,
        [Display(Name = "HintMutfagi")]
        HintMutfagi,
        [Display(Name = "MeksikaMutfagi")]
        MeksikaMutfagi,
        [Display(Name = "JaponMutfagi")]
        JaponMutfagi,
        [Display(Name = "FransizMutfagi")]
        FransizMutfagi,
        [Display(Name = "TurkMutfagi")]
        TurkMutfagi,
        [Display(Name = "AmerikanMutfagi")]
        AmerikanMutfagi,
        [Display(Name = "IspanyolMutfagi")]
        IspanyolMutfagi
    }
}
