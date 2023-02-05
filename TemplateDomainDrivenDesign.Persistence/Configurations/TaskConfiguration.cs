using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            // table
            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);

            // properties
            builder.Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired();
            
        }
    }
}
