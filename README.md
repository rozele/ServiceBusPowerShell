# Service Bus PowerShell Cmdlets

This repository includes a few cmdlets that are not provided by the Azure PowerShell CLI.

## New-ServiceBusSubscriptionSasToken

Generates a SAS token scoped to a specific Azure Service Bus topic subscription.

### Parameters

* *Namespace*: Azure Service Bus namespace
* *Topic*: Azure Service Bus topic name
* *Subscription*: Azure Service Bus subscription name
* *KeyName*: Azure Service Bus shared access policy key name
* *KeyName*: Azure Service Bus shared access policy key
* *Expiry*: Date time the SAS token should expire

### Installation

From PowerShell:

1. Clone the repo:
```
git clone https://github.com/rozele/ServiceBusPowerShell
```
2. Build the solution:
```
cd ServiceBusPowerShell
msbuild ServiceBusPowerShell.sln /p:Configuration=Release
```
3. Install the resulting DLL as a module:
```
Import-Module .\ServiceBusSasTokenModule\bin\Release\ServiceBusSasTokenModule.dll
```

### Example

```
New-ServiceBusSubscriptionSasToken
  -Namespace mysbns
  -Topic mytopic
  -Subscription mysub
  -KeyName mykey
  -Key <primary or secondary key>
  -Expiry 2020/01/01
```
