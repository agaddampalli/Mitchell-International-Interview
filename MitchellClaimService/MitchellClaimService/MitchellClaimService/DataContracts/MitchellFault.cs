using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaimService.DataContracts
{
    [DataContract]
    public class MitchellFault
    {
        [DataMember]
        public string Message { get; set;}
    }
}
