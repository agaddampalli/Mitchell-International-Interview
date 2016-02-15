using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MitchellClaimService.Repository;
using System.IO;
using MitchellClaimService.DataContracts;
using MitchellClaimService.Utils;

namespace MitchellClaimService
{
    public class MitchellClaimService : IMitchellClaimService
    {
        IMitchellClaimRepository _repository;

        public MitchellClaimService() : this(new MitchellClaimRepository()) { }

        public MitchellClaimService(IMitchellClaimRepository repository)
        {
            _repository = repository;
        }

        #region CreateClaim
        public void CreateClaim(string createxml)
        {
            try
            {
                _repository.CreateNewClaimType(createxml);
            }
            catch (FaultException fault)
            {
                MitchellFault _fault = new MitchellFault();
                _fault.Message = fault.Message;
                throw new FaultException<MitchellFault>(_fault,"Unable to create the MitchellClaim");
            }
            
        }
        #endregion

        #region GetClaimBy ClaimNumber
        public MitchellClaim GetClaim(string ClaimNumber)
        {
            MitchellClaim _claim = new MitchellClaim();
            try
            {
                _claim = _repository.GetClaimType(ClaimNumber);
                if(_claim.ClaimNumber == null)
                {
                    throw new FaultException("There are no records for specific claim");
                }
                return _claim;  
            }
            catch (FaultException fault)
            {
                MitchellFault _fault = new MitchellFault();
                _fault.Message = fault.Message;
                throw new FaultException<MitchellFault>(_fault);
            }
        }
        #endregion

        #region GetClaimBy LossDate Range
        public List<string> GetClaimByDate(DateTime FromDate, DateTime ToDate)
        {
            List<string> claims;
            try
            {
                claims = _repository.GetClaimTypes(FromDate, ToDate);
                if(claims.Count() == 0)
                {
                    throw new FaultException("There are no records in the selected date range");
                }
                return claims;
            }
            catch (FaultException fault)
            {
                MitchellFault _fault = new MitchellFault();
                _fault.Message = fault.Message;
                throw new FaultException<MitchellFault>(_fault);
            }
        }
        #endregion

        #region GetVehicleDetails
        public VehicleDetails GetVehicleDetails(string ClaimNumber, string vin)
        {
            VehicleDetails _vehicle = new VehicleDetails();
            try
            {
                _vehicle = _repository.GetVehicleDetails(ClaimNumber, vin);
                if (_vehicle == null)
                {
                    throw new FaultException("There are no records for specific claim");
                }

                return _vehicle;
            }
            catch (FaultException fault)
            {
                MitchellFault _fault = new MitchellFault();
                _fault.Message = fault.Message;
                throw new FaultException<MitchellFault>(_fault);
            }
        }
        #endregion

        #region UpdateClaim
        public void UpdateClaim(string updatexml)
        {
            updatexml = File.ReadAllText(@"D:\Documents\update-claim.xml");
            try
            {
               _repository.UpdateClaimType(updatexml);
            }
            catch (FaultException fault)
            {
                MitchellFault _fault = new MitchellFault();
                _fault.Message = fault.Message;
                throw new FaultException<MitchellFault>(_fault, "Unable to update the MitchellClaim");
            }
        }
        #endregion

        #region DeleteClaim
        public void DeleteClaim(string ClaimNumber)
        {
            try
            {
                _repository.DeleteClaimType(ClaimNumber);
            }
            catch (FaultException fault)
            {
                MitchellFault _fault = new MitchellFault();
                _fault.Message = fault.Message;
                throw new FaultException<MitchellFault>(_fault, "Unable to delete the MitchellClaim");
            }
        }
        #endregion

    }
}
