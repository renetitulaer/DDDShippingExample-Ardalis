//using Domain.Aggrgates.CustomerAggregate;
//using Domain.Aggrgates.HandlingEventAggregate;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Persistency.Configurations
//{
//    public class HandlingEventConfiguration : IEntityTypeConfiguration<HandlingEvent>
//    {
//        public void Configure(EntityTypeBuilder<HandlingEvent> builder)
//        {
//            builder.HasKey(x =>
//                new
//                {
//                    x.TrackingId,
//                    x.TimeStamp,
//                    x.Type
//                });
//        }
//    }
//}
