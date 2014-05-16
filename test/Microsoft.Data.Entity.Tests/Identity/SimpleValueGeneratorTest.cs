// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Data.Entity.Identity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Moq;
using Xunit;

namespace Microsoft.Data.Entity.Tests.Identity
{
    public class SimpleValueGeneratorTest
    {
        [Fact]
        public async Task NextAsync_delegates_to_sync_method()
        {
            var configuration = Mock.Of<DbContextConfiguration>();
            var property = Mock.Of<IProperty>();

            var generatorMock = new Mock<SimpleValueGenerator> { CallBase = true };
            generatorMock.Setup(m => m.Next(configuration, property)).Returns("Boo!");

            Assert.Equal("Boo!", await generatorMock.Object.NextAsync(configuration, property));
        }
    }
}
