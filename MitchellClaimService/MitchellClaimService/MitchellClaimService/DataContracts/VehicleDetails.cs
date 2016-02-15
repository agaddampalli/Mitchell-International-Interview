using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MitchellClaimService.DataContracts
{
    [DataContract]
    public class VehicleDetails
    {
        [DataMember]
        public string Vin { get; set; }
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public string MakeDescription { get; set; }
        [DataMember]
        public string ModelDescription { get; set; }
        [DataMember]
        public string EngineDescription { get; set; }
        [DataMember]
        public string ExteriorColor { get; set; }
        [DataMember]
        public string LicPlate { get; set; }
        [DataMember]
        public string LicPlateState { get; set; }
        [DataMember]
        public DateTime LicPlateExpDate { get; set; }
        [DataMember]
        public string DamageDescription { get; set; }
        [DataMember]
        public int Mileage { get; set; }
    }
}