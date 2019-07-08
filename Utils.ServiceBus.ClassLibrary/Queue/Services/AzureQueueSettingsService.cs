namespace Utils.ServiceBus.ClassLibrary.Queue.Services
{
    using System;
    /// <summary>
    /// Create Connection Settings.
    /// </summary>
    public class AzureQueueSettingsService
    {
        /// <summary>
        /// Connection String Queue.
        /// </summary>
        public string ConnectionString { get; }
        /// <summary>
        /// Queue Name
        /// </summary>
        public string QueueName { get; }

        /// <summary>
        /// Create Connection Settings.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="queueName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AzureQueueSettingsService(string connectionString, string queueName)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            if (string.IsNullOrEmpty(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            ConnectionString = connectionString;
            QueueName = queueName;
        }
    }
}