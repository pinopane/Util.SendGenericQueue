namespace Utils.ServiceBus.ClassLibrary.Queue.Services
{
    using Contracts;
    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public class AzureQueueSenderService<T> : IAzureQueueSenderService<T> where T : class
    {
        private readonly AzureQueueSettingsService _settings;
        private QueueClient _client;

        public AzureQueueSenderService(AzureQueueSettingsService settings)
        {
            _settings = settings;
            Init();
        }
        private void Init()
        {
            _client = new QueueClient(_settings.ConnectionString, _settings.QueueName);
        }
        public async Task SendAsync(T item)
        {
            await SendAsync(item, null);
        }

        /// <summary>
        /// Send async message to queue.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public async Task SendAsync(T item, Dictionary<string, object> properties)
        {
            var json = JsonConvert.SerializeObject(item);
            var message = new Message(Encoding.UTF8.GetBytes(json));

            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    message.UserProperties.Add(prop.Key, prop.Value);
                }
            }
            await _client.SendAsync(message);
        }
    }
}