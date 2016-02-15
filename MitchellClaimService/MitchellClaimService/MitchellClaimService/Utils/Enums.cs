using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MitchellClaimService.Utils
{
    public enum StatusCode
    {
        OPEN = 1,
        CLOSED
    }

    public enum CauseOfLossCode
    {
        Collision = 1,
        Explosion,
        Fire,
        Hail,
        MechanicalBreakdown,
        Other
    }
}