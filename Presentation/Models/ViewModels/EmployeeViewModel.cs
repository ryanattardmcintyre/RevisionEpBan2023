using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
       
    }
}
