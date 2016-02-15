using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchellClaimService.DataContracts;

namespace MitchellClaimService.Repository
{
    public interface IMitchellClaimRepository
    {
        void CreateNewClaimType(string xml);
        MitchellClaim GetClaimType(string ClaimNumber);
        VehicleDetails GetVehicleDetails(string ClaimNumber, string vin);
        List<String> GetClaimTypes(DateTime FromLossDate, DateTime ToLossDate);
        void UpdateClaimType(string xml);
        void DeleteClaimType(string ClaimNumber);
    }
}
