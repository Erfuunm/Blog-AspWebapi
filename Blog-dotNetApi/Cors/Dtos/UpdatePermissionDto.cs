using System.ComponentModel.DataAnnotations;

namespace Blog_dotNetApi.Cors.Dtos
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

    }
}
