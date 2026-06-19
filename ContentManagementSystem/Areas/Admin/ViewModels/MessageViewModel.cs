namespace ContentManagementSystem.Areas.Admin.ViewModels
{
    public class MessageViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public string? TimeAgo { get; set; } = string.Empty;
        public bool? IsRead { get; set; } = false;

    }
}
