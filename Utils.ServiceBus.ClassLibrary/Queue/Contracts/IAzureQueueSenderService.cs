namespace Utils.ServiceBus.ClassLibrary.Queue.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAzureQueueSenderService<T>
    {
        Task SendAsync(T item);
        Task SendAsync(T item, Dictionary<string, object> properties);
    }
}