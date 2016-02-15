using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MitchellClaimService.Utils;
using System.Runtime.Serialization;

namespace MitchellClaimService.DataContracts
{
    [DataContract]
    public class LossInfo
    {
        [DataMember]
        public CauseOfLossCode CauseOfLoss { get; set; }

        [DataMember]
        public DateTime ReportedDate { get; set; }

        [DataMember]
        public string LossDescription { get; set; }
    }
}