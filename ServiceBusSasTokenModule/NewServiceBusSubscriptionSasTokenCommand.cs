using System;
using System.Management.Automation;

namespace ServiceBusSasTokenModule
{
    [Cmdlet(VerbsCommon.New, "ServiceBusSubscriptionSasToken")]
    public class NewServiceBusSubscriptionSasTokenCommand : Cmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Azure Service Bus namespace")]
        public string Namespace
        {
            get;
            set;
        }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Azure Service Bus topic name")]
        public string Topic
        {
            get;
            set;
        }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Azure Service Bus subscription name")]
        public string Subscription
        {
            get;
            set;
        }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Azure Service Bus shared access policy key name")]
        public string KeyName
        {
            get;
            set;
        }

        [Parameter(
            Position = 4,
            Mandatory = true,
            HelpMessage = "Azure Service Bus shared access policy key")]
        public string Key
        {
            get;
            set;
        }

        [Parameter(
            Position = 5,
            Mandatory = true,
            HelpMessage = "Number of days the token should be valid for")]
        public DateTime Expiry
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var resourceUri = $"sb://{Namespace}.servicebus.windows.net/{Topic}/subscriptions/{Subscription}";
            var sasToken = SasTokenGenerator.GetSasToken(resourceUri, KeyName, Key, Expiry);
            WriteObject(sasToken);
        }
    }
}
