using System.ComponentModel.DataAnnotations;

namespace VolumeCalculatorWebApp.Models
{
    public class CyclinderProperties
    {
        [DataType(DataType.Text)]
        [Display(Name = "Radius")]
        public string Radius { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Volume")]
        public string Volume { get; set; }
    }

    public class ConeProperties
    {
        [DataType(DataType.Text)]
        [Display(Name = "Radius")]
        public string Radius { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Volume")]
        public string Volume { get; set; }

    }

    public class SphereProperties
    {
        [DataType(DataType.Text)]
        [Display(Name = "Radius")]
        public string Radius { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Volume")]
        public string Volume { get; set; }
    }

    public class VolumeViewModel
    {
        public CyclinderProperties CylinderProperties { get; set; }

        public ConeProperties ConeProperties { get; set; }

        public SphereProperties SphereProperties { get; set; }
    }
}