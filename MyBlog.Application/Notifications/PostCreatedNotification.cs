using MediatR;
using System.Diagnostics;

namespace MyBlog.Application.Notifications
{
    public class PostCreatedNotification : INotification
    {
        public int Id { get; set; }
    }

    public class PostCreatedNotificationHandler1 : INotificationHandler<PostCreatedNotification>
    {
        public async Task Handle(PostCreatedNotification notification, CancellationToken cancellationToken)
        {
            Debug.Print($"1 - Handler = {notification.Id.ToString()}");
        }
    }

    public class PostCreatedNotificationHandler2 : INotificationHandler<PostCreatedNotification>
    {
        public async Task Handle(PostCreatedNotification notification, CancellationToken cancellationToken)
        {
            Debug.Print($"2 - Handler = {notification.Id.ToString()}");
        }
    }
}
