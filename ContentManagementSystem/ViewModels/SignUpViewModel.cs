using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.ViewModels
{
    public class SignUpViewModel
    {
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
