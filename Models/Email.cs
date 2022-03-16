using System.ComponentModel.DataAnnotations;

namespace portfolio_backend.Models{

    public class  GetInTouch{
        [Required]
        public string To { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content{ get; set; }
    }
}