//using Domain.Aggrgates.HandlingEventAggregate;
//using Domain.Aggrgates.HandlingIncidentAggregate;
//using Domain.SeedWork;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Aggrgates.CargoAggregate
//{
//    /// <summary>
//    /// No identity -> ValueObject
//    /// </summary>
//    /// <param name="handlingIncidents"></param>
//    public class DeliveryHistory(Cargo cargo) : ValueObject
//    {
//        // Needed for EF
//        private DeliveryHistory() : this(null!) {}

//        private readonly Cargo _cargo = cargo;

//        public IEnumerable<HandlingEvent> HandlingIncidents => 
//            new HandlingEventRepository().FindByTrackingId(_cargo.TrackingId);
//    }
//}
