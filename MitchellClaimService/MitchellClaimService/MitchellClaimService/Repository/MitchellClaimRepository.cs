using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MitchellClaimService.DataContracts;
using MitchellClaimService.Utils;
using System.ServiceModel;

namespace MitchellClaimService.Repository
{
    public class MitchellClaimRepository: IMitchellClaimRepository
    {
        #region CreateClaim
        public void CreateNewClaimType(string xml)
        {
            var mitchellclaim = (MitchellClaim)Helper.CreateObject(xml, new MitchellClaim());

            if (mitchellclaim.ClaimNumber == null || mitchellclaim.Vehicles.Count == 0)
                throw new FaultException("Claimnumber or Vehicles should be provided to create a claim");

            using (MitchellClaimsDbEntities _db = new MitchellClaimsDbEntities())
            {
                var checkclaim = _db.mitchellClaims.Where(x => x.ClaimNumber == mitchellclaim.ClaimNumber).FirstOrDefault();
                
                if(checkclaim != null)
                    throw new FaultException("Cannot create duplicate claim numbers");

                lossInfo _newlossinfo = null;
                if (mitchellclaim.LossInfo != null)
                {
                    lossInfo _info = new lossInfo()
                    {
                        CauseOfLossId = (int)(mitchellclaim.LossInfo.CauseOfLoss),
                        ReportedDate = mitchellclaim.LossInfo.ReportedDate,
                        LossDescription = mitchellclaim.LossInfo.LossDescription
                    };
                    _newlossinfo = _db.lossInfoes.Add(_info);
                    _db.SaveChanges();
                }

                mitchellClaim _claim = new mitchellClaim()
                {
                    ClaimNumber = mitchellclaim.ClaimNumber,
                    ClaimantFirstName = mitchellclaim.ClaimantFirstName,
                    ClaimantLastName = mitchellclaim.ClaimantLastName,
                    Status = (int)mitchellclaim.Status,
                    LossDate = mitchellclaim.LossDate,
                    AssignedAdjusterID = mitchellclaim.AssignedAdjusterID
                };
                var _newclaim =  _db.mitchellClaims.Add(_claim);
                if (mitchellclaim.LossInfo != null)
                    _newclaim.LossInfoId = _newlossinfo.LossInfoId;
                _db.SaveChanges();



                foreach (var vehicle in mitchellclaim.Vehicles)
                {
                    vehicleInfo _vehicle = new vehicleInfo()
                    {
                        Vin = vehicle.Vin,
                        ModelYear = vehicle.ModelYear,
                        MakeDescription = vehicle.MakeDescription,
                        ModelDescription = vehicle.ModelDescription,
                        EngineDescription = vehicle.EngineDescription,
                        ExteriorColor = vehicle.EngineDescription,
                        LicPlate = vehicle.LicPlate,
                        LicPlateState = vehicle.LicPlateState,
                        LicPlateExpDate = vehicle.LicPlateExpDate,
                        DamageDescription = vehicle.DamageDescription,
                        Mileage = vehicle.Mileage,
                        ClaimNumber = mitchellclaim.ClaimNumber
                    };
                    _db.vehicleInfoes.Add(_vehicle);
                }
                _db.SaveChanges();
            }
        }
        #endregion

        #region GetClaimBy ClaimNumber
        public MitchellClaim GetClaimType(string ClaimNumber)
        {
            MitchellClaim mitchclaim = new MitchellClaim();

            using (MitchellClaimsDbEntities _db = new MitchellClaimsDbEntities())
            {
                var claimval = (from claim in _db.mitchellClaims
                                where claim.ClaimNumber == ClaimNumber
                                select claim).FirstOrDefault();
                if (claimval != null)
                {
                    LossInfo _info = null;
                    if (claimval.lossInfo != null)
                    {
                        _info = new LossInfo()
                        {
                            CauseOfLoss = (CauseOfLossCode)claimval.lossInfo.CauseOfLossId,
                            ReportedDate = (DateTime)claimval.lossInfo.ReportedDate,
                            LossDescription = claimval.lossInfo.LossDescription
                        };
                    }

                    List<VehicleDetails> _vehicles = new List<VehicleDetails>();
                    foreach (var item in claimval.vehicleInfoes)
                    {
                        VehicleDetails vehicle = new VehicleDetails()
                        {
                            Vin = item.Vin,
                            ModelYear = (int)item.ModelYear,
                            MakeDescription = item.MakeDescription,
                            ModelDescription = item.ModelDescription,
                            EngineDescription = item.EngineDescription,
                            ExteriorColor = item.ExteriorColor,
                            LicPlate = item.LicPlate,
                            LicPlateState = item.LicPlateState,
                            LicPlateExpDate = (DateTime)item.LicPlateExpDate,
                            DamageDescription = item.DamageDescription,
                            Mileage = (int)item.Mileage
                        };
                        _vehicles.Add(vehicle);
                    }

                    mitchclaim.ClaimNumber = claimval.ClaimNumber;
                    mitchclaim.ClaimantFirstName = claimval.ClaimantFirstName;
                    mitchclaim.ClaimantLastName = claimval.ClaimantLastName;
                    mitchclaim.Status = (StatusCode)claimval.Status;
                    mitchclaim.LossDate = (DateTime)claimval.LossDate;
                    mitchclaim.LossInfo = _info;
                    mitchclaim.AssignedAdjusterID = (int)claimval.AssignedAdjusterID;
                    mitchclaim.Vehicles = _vehicles;

                }

                return mitchclaim;
            }
        }
        #endregion

        #region GetClaimBy LossDateRange
        public List<String> GetClaimTypes(DateTime FromLossDate, DateTime ToLossDate)
        {
            using(MitchellClaimsDbEntities _db = new MitchellClaimsDbEntities())
            {
                 var claimval = _db.mitchellClaims.Where(claim => claim.LossDate >= FromLossDate && claim.LossDate<=ToLossDate).Select(claim => claim.ClaimNumber).ToList();
                 return claimval;
            }
        }
        #endregion

        #region GetClaim and VehicleDetail
        public VehicleDetails GetVehicleDetails(string ClaimNumber, string vin)
        {
            using (MitchellClaimsDbEntities _db = new MitchellClaimsDbEntities())
            {
                var vehicleval = (from claim in _db.mitchellClaims
                               from veh in claim.vehicleInfoes
                               where claim.ClaimNumber == ClaimNumber && veh.Vin == vin
                               select new VehicleDetails()
                               {
                                   Vin = veh.Vin,
                                   ModelYear = (int)veh.ModelYear,
                                   MakeDescription = veh.MakeDescription,
                                   ModelDescription = veh.ModelDescription,
                                   EngineDescription = veh.EngineDescription,
                                   ExteriorColor = veh.ExteriorColor,
                                   LicPlate = veh.LicPlate,
                                   LicPlateState = veh.LicPlateState,
                                   LicPlateExpDate = (DateTime)veh.LicPlateExpDate,
                                   DamageDescription = veh.DamageDescription,
                                   Mileage = (int)veh.Mileage
                               }).FirstOrDefault();
                return vehicleval;
            }
        }
        #endregion

        #region UpdateClaim
        public void UpdateClaimType(string xml)
        {
            var mitchellclaim = (MitchellClaim)Helper.CreateObject(xml, new MitchellClaim());

            if (mitchellclaim.ClaimNumber == null)
                throw new FaultException("Claimnumber should be provided to update a claim");

            using (MitchellClaimsDbEntities _db = new MitchellClaimsDbEntities())
            {
                var claimval = (from claim in _db.mitchellClaims
                                where claim.ClaimNumber == mitchellclaim.ClaimNumber
                                select claim).FirstOrDefault();

                if (claimval == null)
                    throw new FaultException("No claims found for specified claimnumber");

                if (claimval.LossInfoId !=null)
                {
                    if (mitchellclaim.LossInfo != null)
                    {
                        var lossinfo = claimval.lossInfo;
                        if (mitchellclaim.LossInfo.CauseOfLoss != 0)
                            lossinfo.CauseOfLossId = (int)mitchellclaim.LossInfo.CauseOfLoss;
                        if (mitchellclaim.LossInfo.ReportedDate != DateTime.MinValue)
                            lossinfo.ReportedDate = mitchellclaim.LossInfo.ReportedDate;
                        if (mitchellclaim.LossInfo.LossDescription != null)
                            lossinfo.LossDescription = mitchellclaim.LossInfo.LossDescription;

                        _db.SaveChanges();
                    }
                }
                else
                {
                    lossInfo _newlossinfo = null;
                    if (mitchellclaim.LossInfo != null)
                    {
                        lossInfo _info = new lossInfo()
                        {
                            CauseOfLossId = (int)(mitchellclaim.LossInfo.CauseOfLoss),
                            ReportedDate = mitchellclaim.LossInfo.ReportedDate,
                            LossDescription = mitchellclaim.LossInfo.LossDescription
                        };
                        _newlossinfo = _db.lossInfoes.Add(_info);
                        claimval.LossInfoId = _newlossinfo.LossInfoId;
                        _db.SaveChanges();
                    }
                }

                if (mitchellclaim.ClaimantFirstName != null)
                    claimval.ClaimantFirstName = mitchellclaim.ClaimantFirstName;
                if (mitchellclaim.ClaimantLastName != null)
                    claimval.ClaimantLastName = mitchellclaim.ClaimantLastName;
                if (mitchellclaim.Status != 0)
                    claimval.Status = (int)mitchellclaim.Status;
                if (mitchellclaim.LossDate != DateTime.MinValue)
                    claimval.LossDate = mitchellclaim.LossDate;
                if (mitchellclaim.AssignedAdjusterID != 0)
                    claimval.AssignedAdjusterID = mitchellclaim.AssignedAdjusterID;
                _db.SaveChanges();

                if(mitchellclaim.Vehicles.Count() != 0)
                {
                    List<vehicleInfo> _vehicles = new List<vehicleInfo>();
                    foreach (var item in mitchellclaim.Vehicles)
                    {
                        var vehicle = (from auto in claimval.vehicleInfoes
                                       where auto.Vin == item.Vin
                                       select auto).FirstOrDefault();
                        if (vehicle != null)
                        {
                            if (item.ModelYear != 0)
                                vehicle.ModelYear = (int)item.ModelYear;
                            if (item.MakeDescription != null)
                                vehicle.MakeDescription = item.MakeDescription;
                            if (item.ModelDescription != null)
                                vehicle.ModelDescription = item.ModelDescription;
                            if (item.EngineDescription != null)
                                vehicle.EngineDescription = item.EngineDescription;
                            if (item.ExteriorColor != null)
                                vehicle.ExteriorColor = item.ExteriorColor;
                            if (item.LicPlate != null)
                                vehicle.LicPlate = item.LicPlate;
                            if (item.LicPlateState != null)
                                vehicle.LicPlateState = item.LicPlateState;
                            if (item.LicPlateExpDate != DateTime.MinValue)
                                vehicle.LicPlateExpDate = (DateTime)item.LicPlateExpDate;
                            if (item.DamageDescription != null)
                                vehicle.DamageDescription = item.DamageDescription;
                            if (item.Mileage != 0)
                                vehicle.Mileage = (int)item.Mileage;
                        }
                        else
                        {
                            vehicleInfo _vehicle = new vehicleInfo()
                            {
                                Vin = item.Vin,
                                ModelYear = item.ModelYear,
                                MakeDescription = item.MakeDescription,
                                ModelDescription = item.ModelDescription,
                                EngineDescription = item.EngineDescription,
                                ExteriorColor = item.ExteriorColor,
                                LicPlate = item.LicPlate,
                                LicPlateState = item.LicPlateState,
                                LicPlateExpDate = item.LicPlateExpDate,
                                DamageDescription = item.DamageDescription,
                                Mileage = item.Mileage,
                                ClaimNumber = claimval.ClaimNumber
                            };  
                            _db.vehicleInfoes.Add(_vehicle);
                        }
                    }

                    _db.SaveChanges();
                }

            }
        }
        #endregion

        #region DeleteClaim
        public void DeleteClaimType(string ClaimNumber)
        {
            using (MitchellClaimsDbEntities _db = new MitchellClaimsDbEntities())
            {
                var claimval = (from claim in _db.mitchellClaims
                                where claim.ClaimNumber == ClaimNumber
                                select claim).FirstOrDefault();

                if (claimval == null)
                    throw new FaultException("No claims found for specified claimnumber");

                _db.vehicleInfoes.RemoveRange(_db.vehicleInfoes.Where(x => x.ClaimNumber == ClaimNumber));
                 var lossinfoid = _db.mitchellClaims.Where(x=>x.ClaimNumber==ClaimNumber).Select(x=>x.LossInfoId).FirstOrDefault();
                _db.mitchellClaims.RemoveRange(_db.mitchellClaims.Where(x => x.ClaimNumber == ClaimNumber));
                _db.lossInfoes.RemoveRange(_db.lossInfoes.Where(x => x.LossInfoId == lossinfoid));
                _db.SaveChanges();
            }
        }
        #endregion
    }
}