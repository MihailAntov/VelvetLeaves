﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            var tagList = new List<Tag>
            {
                new Tag {Id = 1, Name = "Traditional Sewing Pattern"},
                new Tag {Id = 2, Name = "Silk Cocoons"}
            };

            builder.HasData(tagList);
        }
    }
}