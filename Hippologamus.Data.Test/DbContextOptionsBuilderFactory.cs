using Hippologamus.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hippologamus.Data.Test
{
    public class DbContextOptionsBuilderFactory
    {
        public static DbContextOptions<HippologamusContext> Create() => new DbContextOptionsBuilder<HippologamusContext>()
                     .UseInMemoryDatabase("InMemoryDatabase" + Guid.NewGuid()).Options;
    }
}
