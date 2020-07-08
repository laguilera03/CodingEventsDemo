using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//for required (validation)
using System.Linq;
using System.Threading.Tasks;

//Closely Mirrors Event Model (takes "responsibility") and can add a layer of security by using attributes (validation)
namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Error")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
