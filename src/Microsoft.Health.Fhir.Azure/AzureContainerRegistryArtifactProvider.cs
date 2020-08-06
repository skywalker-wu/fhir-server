// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Health.Fhir.Core.Features.Operations;

namespace Microsoft.Health.Fhir.Azure
{
    public class AzureContainerRegistryArtifactProvider : IArtifactProvider
    {
        public async Task FetchArtifactAsync(string location, Stream targetStream, CancellationToken cancellationToken)
        {
            string[] locationInfo = location.Split(':');
            string registry = locationInfo[0];
            string repo = locationInfo[1];
            string digest = locationInfo[2];

            string url = string.Format("https://{0}.azurecr.io/v2/{1}/blobs/sha256:{2}", registry, repo, digest);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = CreateAuthenticationHeaderValue();
            string metadata = await client.GetStringAsync(new Uri(url));
        }

        private AuthenticationHeaderValue CreateAuthenticationHeaderValue()
        {
            return new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "sowutest", "WTGbXTlpm1nIDp+LMD8AIFZh1rP1wEOk"))));
        }
    }
}
