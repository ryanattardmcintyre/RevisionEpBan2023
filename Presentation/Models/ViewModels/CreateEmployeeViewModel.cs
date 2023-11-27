using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Models.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; } 
        public string DepartmentFK { get; set; } 
        public string PassportNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
