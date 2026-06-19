using DAL.DomainModel;

namespace ContentManagementSystem.ViewModels
{
    public class HomeViewModel
    {

        public  HeroSection HeroSection { get; set; }

        public AboutSection AboutSection { get; set; }

        public List<Service> ServicesList { get; set; }

        public ContactMessage ContactMessage { get; set; }
    }
}
