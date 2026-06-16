namespace ContentManagementSystem.Areas.Admin.ViewModels
{
    public class HeroViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

        //public string ButtonText { get; set; }
        //public string DestinationUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
