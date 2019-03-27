using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace GoodMarket.Application.Tests.Application
{
    public class TestEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IDictionary<string, string> Props { get; set; }
        public IList<TestEntity2> SubList { get; set; }
    }

    public class TestEntity2 : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestEntityConfig : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.HasMany(e => e.SubList);
            builder.HasAlternateKey(e => e.Name);
            builder.Property(e => e.Props).HasConversion(
                e => SSerializer.Serialize(e), 
                e => SSerializer.Deserialize<Dictionary<string, string>>(e));
        }
    }
}
