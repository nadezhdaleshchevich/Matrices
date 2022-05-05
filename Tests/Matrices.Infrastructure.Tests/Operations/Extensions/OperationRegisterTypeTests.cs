using System;
using Matrices.Infrastructure.Operations.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Extensions
{
    public class OperationRegisterTypeTests
    {
        [Fact]
        public void LoadOperation_When_CollectionIsNull_Throw_ArgumentNullException()
        {
            IServiceCollection collection = null;

            Action action = () => OperationRegisterType.LoadOperation(collection);

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
