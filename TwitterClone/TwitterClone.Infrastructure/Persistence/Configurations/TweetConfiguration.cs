using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable("tweets");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.Content).IsRequired();

            builder.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId).IsRequired();
        }
    }
}
