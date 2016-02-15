using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MitchellClaimService.Utils;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MitchellClaimService.DataContracts
{
    [DataContract]
    [XmlRoot(Namespace = "http://www.mitchell.com/examples/claim")]
    public class MitchellClaim
    {
        [DataMember(IsRequired=true)]
        [XmlElement(IsNullable=false)]
        public string ClaimNumber { get; set; }
        [DataMember]
        public string ClaimantFirstName { get; set; }
        [DataMember]
        public string ClaimantLastName { get; set; }
        [DataMember]
        public StatusCode Status { get; set; }
        [DataMember]
        public DateTime LossDate { get; set; }
        [DataMember]
        public long AssignedAdjusterID { get; set; }
        [DataMember]
        public LossInfo LossInfo { get; set; }
		
        [DataMember(IsRequired=true)]
        public List<VehicleDetails> Vehicles { get; set; }
    }
}