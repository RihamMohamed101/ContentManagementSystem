namespace ContentManagementSystem.Areas.Admin.ViewModels
{
    public class AboutViewModel
    {
        public string Title { get; set; }           
        public string Subtitle { get; set; }        
        public string Description { get; set; }     
        public string? ImageUrl { get; set; }       

        public IFormFile? ImageFile { get; set; }
    }
}
