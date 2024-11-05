using Data.Models;

namespace SharedComponents.Interfaces;

public interface IBlogNotificationService
{
    event Action<BlogPost>? BlogPostChanged;
    Task SendNotification(BlogPost post);
}