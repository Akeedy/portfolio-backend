using System.ComponentModel.DataAnnotations;

namespace portfolio_backend.Models{

    public class  GetInTouch{
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Content{ get; set; }
    }
}