//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MitchellClaimService
{
    using System;
    using System.Collections.Generic;
    
    public partial class causeOfLossCode
    {
        public causeOfLossCode()
        {
            this.lossInfoes = new HashSet<lossInfo>();
        }
    
        public int CauseOfLossId { get; set; }
        public string LossCodeType { get; set; }
    
        public virtual ICollection<lossInfo> lossInfoes { get; set; }
    }
}