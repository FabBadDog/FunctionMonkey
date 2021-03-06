using FunctionMonkey.Abstractions.Builders.Model;

namespace FunctionMonkey.Model.OutputBindings
{
    public class ServiceBusQueueOutputBinding : AbstractConnectionStringOutputBinding
    {
        public string QueueName { get; set; }
        public string SessionIdPropertyName { get; set; }

        public bool HasSessionId => !string.IsNullOrWhiteSpace(SessionIdPropertyName);

        public ServiceBusQueueOutputBinding(string commandResultItemTypeName, string connectionStringSettingName) : base(commandResultItemTypeName, connectionStringSettingName)
        {
        }
    }
}