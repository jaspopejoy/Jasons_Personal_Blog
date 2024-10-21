using System.ComponentModel.DataAnnotations;

namespace Jasons_Personal_Blog.Models.ViewModels
{
    public class CreateTagRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }
    }
}
