using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MitchellClaimService.DataContracts;

namespace MitchellClaimService
{
    [ServiceContract]
    public interface IMitchellClaimService
    {
        [OperationContract]
        [FaultContract(typeof(MitchellFault))]
        void CreateClaim(string createxml);

        [OperationContract]
        [FaultContract(typeof(MitchellFault))]
        MitchellClaim GetClaim(string ClaimNumber);

        [OperationContract]
        [FaultContract(typeof(MitchellFault))]
        List<string> GetClaimByDate(DateTime FromDate, DateTime ToDate);

        [OperationContract]
        [FaultContract(typeof(MitchellFault))]
        VehicleDetails GetVehicleDetails(string ClaimNumber,string vin);

        [OperationContract]
        [FaultContract(typeof(MitchellFault))]
        void UpdateClaim(string updatexml);

        [OperationContract]
        [FaultContract(typeof(MitchellFault))]
        void DeleteClaim(string ClaimNumber);
    }

}
