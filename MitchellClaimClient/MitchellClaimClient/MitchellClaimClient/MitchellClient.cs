using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MitchellClaimClient
{
    public partial class MitchellClient : Form
    {
        MitchellService.MitchellClaimServiceClient client;

        public MitchellClient()
        {
            InitializeComponent();
            client = new MitchellService.MitchellClaimServiceClient();
        }

        #region GetClaimBy ClaimNumber
        private void button1_Click(object sender, EventArgs e)
        {
            string claimnumber = claimNumber.Text;
            bindListBoxData(claimnumber);
        }
        #endregion

        #region GetClaimBy Lost Date DateRange
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fromdate = fromdatepick.Value;
            DateTime todate = todatepick.Value;
            List<string> claimnumbers;
            if (fromdate != DateTime.MinValue && todate != DateTime.MinValue)
            {
                try
                {
                    claimnumbers = client.GetClaimByDate(fromdate, todate);
                    claimsList.Items.Clear();
                    claimsList.DataSource = claimnumbers;
                }
                catch (FaultException<MitchellService.MitchellFault> excep)
                {
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.Text = excep.Detail.Message;
                    client = new MitchellService.MitchellClaimServiceClient();
                }
            }
        }
        #endregion

        #region GetClaim On SelectedItem in ClaimsList
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string claimnumber = claimsList.SelectedValue.ToString();
            bindListBoxData(claimnumber);
        }
        #endregion

        #region BindClaim to ListBoxes
        public void bindListBoxData(string claimnumber)
        {
            
            MitchellService.MitchellClaim _claim;
            if (claimnumber != null && claimnumber != "")
            {
                try
                {
                    _claim = client.GetClaim(claimnumber);

                    IList<string> claimitems = new List<string>();
                    claimitems.Add(_claim.ClaimantFirstName ?? "");
                    claimitems.Add(_claim.ClaimantLastName ?? "");
                    claimitems.Add(_claim.Status.ToString());
                    claimitems.Add(_claim.LossDate != null ? _claim.LossDate.ToString() : "");
                    claimitems.Add(_claim.AssignedAdjusterID.ToString());
                    claimDetails.Items.AddRange(claimitems.Where(x => x != "").ToArray());

                    if (_claim.LossInfo != null)
                    {
                        IList<string> lossitems = new List<string>();
                        lossitems.Add(_claim.LossInfo.CauseOfLoss.ToString());
                        lossitems.Add(_claim.LossInfo.ReportedDate != null ? _claim.LossInfo.ReportedDate.ToString() : "");
                        lossitems.Add(_claim.LossInfo.LossDescription != null ? _claim.LossInfo.LossDescription.ToString() : "");
                        lossInfoDetails.Items.AddRange(lossitems.Where(x => x != "").ToArray());
                    }

                    foreach (var vehicle in _claim.Vehicles)
                    {
                        IList<string> vehicleitems = new List<string>();
                        vehicleitems.Add(vehicle.Vin);
                        vehicleitems.Add(vehicle.ModelYear.ToString());
                        vehicleitems.Add(vehicle.ModelDescription != null ? vehicle.ModelDescription.ToString() : "");
                        vehicleitems.Add(vehicle.EngineDescription != null ? vehicle.EngineDescription.ToString() : "");
                        vehicleitems.Add(vehicle.ExteriorColor != null ? vehicle.ExteriorColor.ToString() : "");
                        vehicleitems.Add(vehicle.LicPlate != null ? vehicle.LicPlate.ToString() : "");
                        vehicleitems.Add(vehicle.LicPlateState != null ? vehicle.LicPlateState.ToString() : "");
                        vehicleitems.Add(vehicle.LicPlateExpDate != null ? vehicle.LicPlateExpDate.ToString() : "");
                        vehicleitems.Add(vehicle.DamageDescription != null ? vehicle.DamageDescription.ToString() : "");
                        vehicleitems.Add(vehicle.Mileage.ToString());
                        vehicleDetails.Items.AddRange(vehicleitems.Where(x => x != "").ToArray());
                        vehicleDetails.Items.Add("");
                    }
                }
                catch (FaultException<MitchellService.MitchellFault> excep)
                {
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.Text = excep.Detail.Message;
                }
            }
            else
            {
                ClearUI();
                lblerror.Visible = true;
                lblerror.Text = "Please enter a valid claim number";
            }
            
        }
        #endregion

        #region Create Claim
        private void createclaim_Click(object sender, EventArgs e)
        {
            
            string xml;
            string filepath = filePath.Text;
            if (filepath == null || filepath == "" || Path.GetExtension(filepath)!=".xml")
            {
                lblerror.Visible = true;
                lblerror.ForeColor = System.Drawing.Color.Red;
                lblerror.Text = "Please specify valid file path";
            }
            else
            {
                FileInfo info = new FileInfo(filepath);
                if (info.Exists)
                {
                    xml = File.ReadAllText(filepath);
                    try
                    {
                        client.CreateClaim(xml);
                        ClearUI();
                        lblerror.Visible = true;
                        lblerror.ForeColor = System.Drawing.Color.Green;
                        lblerror.Text = "Successfully created the claim";
                    }
                    catch (FaultException<MitchellService.MitchellFault> excep)
                    {
                        ClearUI();
                        lblerror.Visible = true;
                        lblerror.ForeColor = System.Drawing.Color.Red;
                        lblerror.Text = excep.Detail.Message;
                    }
                }
                else
                {
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.ForeColor = System.Drawing.Color.Red;
                    lblerror.Text = "Please specify valid file path";
                }
            }
        }
        #endregion

        #region UpdateClaim
        private void updateclaim_Click(object sender, EventArgs e)
        {
            string xml;
            string filepath = filePath.Text;
            if (filepath == null || filepath == "" || Path.GetExtension(filepath) != ".xml")
            {
                lblerror.Visible = true;
                lblerror.Text = "Please specify valid file path";
            }
            else
            {
                FileInfo info = new FileInfo(filepath);
                if (info.Exists)
                {
                    xml = File.ReadAllText(filepath);
                    try
                    {
                        client.UpdateClaim(xml);
                        ClearUI();
                        lblerror.Visible = true;
                        lblerror.ForeColor = System.Drawing.Color.Green;
                        lblerror.Text = "Successfully updated the claim";
                    }
                    catch (FaultException<MitchellService.MitchellFault> excep)
                    {
                        ClearUI();
                        lblerror.Visible = true;
                        lblerror.Text = excep.Detail.Message;
                    }
                }
                else
                {
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.Text = "Please specify valid file path";
                }
            }
        }
        #endregion

        #region DeleteClaim
        private void deleteclaim_Click(object sender, EventArgs e)
        {
            string claimnumber = claimNumber.Text;
            if (claimnumber != null && claimnumber != "")
            {
                try
                {
                    client.DeleteClaim(claimnumber);
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.ForeColor = System.Drawing.Color.Green;
                    lblerror.Text = "Successfully deleted the claim";
                }
                catch (FaultException<MitchellService.MitchellFault> excep)
                {
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.Text = excep.Detail.Message;
                }
            }
            else
            {
                ClearUI();
                lblerror.Visible = true;
                lblerror.Text = "Please enter a valid claim number";
            }
        }
        #endregion

        #region clearcontrol fields
        public void ClearUI()
        {
            lblerror.Text = "";
            claimsList.Items.Clear();
            claimDetails.Items.Clear();
            lossInfoDetails.Items.Clear();
            vehicleDetails.Items.Clear();
        }
        #endregion

        #region Vehicle Details
        private void vehdetail_Click(object sender, EventArgs e)
        {
            string claimnumber = claimNumber.Text;
            string vin = vinnumber.Text;
            if (claimnumber == null || claimnumber == "" || vin == null || vin == null)
            {
                ClearUI();
                lblerror.Visible = true;
                lblerror.Text = "Please enter a valid claim number and Vehicle VIN";
            }
            else
            {
                try
                {
                    MitchellService.VehicleDetails vehicle = client.GetVehicleDetails(claimnumber, vin);
                    ClearUI();
                    IList<string> vehicleitems = new List<string>();
                    vehicleitems.Add(vehicle.Vin);
                    vehicleitems.Add(vehicle.ModelYear.ToString());
                    vehicleitems.Add(vehicle.ModelDescription != null ? vehicle.ModelDescription.ToString() : "");
                    vehicleitems.Add(vehicle.EngineDescription != null ? vehicle.EngineDescription.ToString() : "");
                    vehicleitems.Add(vehicle.ExteriorColor != null ? vehicle.ExteriorColor.ToString() : "");
                    vehicleitems.Add(vehicle.LicPlate != null ? vehicle.LicPlate.ToString() : "");
                    vehicleitems.Add(vehicle.LicPlateState != null ? vehicle.LicPlateState.ToString() : "");
                    vehicleitems.Add(vehicle.LicPlateExpDate != null ? vehicle.LicPlateExpDate.ToString() : "");
                    vehicleitems.Add(vehicle.DamageDescription != null ? vehicle.DamageDescription.ToString() : "");
                    vehicleitems.Add(vehicle.Mileage.ToString());
                    vehicleDetails.Items.AddRange(vehicleitems.Where(x => x != "").ToArray());
                }
                catch (FaultException<MitchellService.MitchellFault> excep)
                {
                    ClearUI();
                    lblerror.Visible = true;
                    lblerror.Text = excep.Detail.Message;
                }
            }
        }
        #endregion
    }
}
