using System.ComponentModel.DataAnnotations;

namespace Blog_dotNetApi.Cors.Dtos
{
    public class DataDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }
    }
}
