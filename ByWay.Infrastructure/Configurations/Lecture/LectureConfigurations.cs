using ByWay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByWay.Infrastructure.Configurations.Lecture
{
    public class LectureConfigurations : IEntityTypeConfiguration<Lectur>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Lectur> builder)
        {
            throw new NotImplementedException();
        }
    }
}
