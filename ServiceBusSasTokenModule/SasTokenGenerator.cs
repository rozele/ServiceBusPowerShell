//--------------------------------------------------------------------------------- 
// Microsoft (R)  Windows Azure SDK 
// Software Development Kit 
//  
// Copyright (c) Microsoft Corporation. All rights reserved.   
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES  
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.  
//--------------------------------------------------------------------------------- 

namespace ServiceBusSasTokenModule
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    class SasTokenGenerator
    {
        public static string GetSasToken(string resourceUri, string keyName, string key, DateTime expiry)
        {
            var expiryString = GetExpiry(expiry);
            var stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiryString;
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));

            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiryString, keyName);
            return sasToken;
        }

        private static string GetExpiry(DateTime expiry)
        {
            var expirySinceEpoch = expiry - new DateTime(1970, 1, 1);
            return Convert.ToString((int)expirySinceEpoch.TotalSeconds);
        }
    }
}
