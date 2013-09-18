namespace Students.Data
{
    using System;
    using System.Data.Common.CommandTrees.ExpressionBuilder;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using Students.Models;

    public class MarkMappings : EntityTypeConfiguration<Mark>
    {
        public MarkMappings()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.Id).HasColumnName("MarkId");

            this.Property(m => m.Subject).IsUnicode(true);
            this.Property(m => m.Subject).HasMaxLength(50);
            this.Property(m => m.Subject).HasColumnName("Subject");
            this.Property(m => m.Subject).HasMaxLength(50);
            this.Property(m => m.Subject).IsRequired();

            this.Property(m => m.Value).HasColumnName("Value");
            this.Property(m => m.Value).IsRequired();
        }
    }
}
