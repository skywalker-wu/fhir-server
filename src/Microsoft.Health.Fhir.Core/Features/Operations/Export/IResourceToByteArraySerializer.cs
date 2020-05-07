﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Microsoft.Health.Fhir.Core.Features.Persistence;
using Microsoft.Health.Fhir.Core.Models;

namespace Microsoft.Health.Fhir.Core.Features.Operations.Export
{
    /// <summary>
    /// A serializer used to serialize the resource represented by <see cref="ResourceWrapper"/> to byte array.
    /// </summary>
    public interface IResourceToByteArraySerializer
    {
        /// <summary>
        /// Serializes the resource represented by <see cref="ResourceWrapper"/> to byte array.
        /// </summary>
        /// <param name="resourceWrapper">The resource wrapper used to serialize.</param>
        /// <returns>The serialized bytes.</returns>
        byte[] Serialize(ResourceWrapper resourceWrapper);

        byte[] Serialize(ResourceElement resource);
    }
}
