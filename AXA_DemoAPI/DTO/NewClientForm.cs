using System.ComponentModel.DataAnnotations;

namespace AXA_DemoAPI.DTO
{
    public class NewClientForm
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
