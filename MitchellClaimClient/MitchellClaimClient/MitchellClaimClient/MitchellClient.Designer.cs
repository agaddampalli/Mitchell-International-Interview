namespace MitchellClaimClient
{
    partial class MitchellClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.claimNumber = new System.Windows.Forms.TextBox();
            this.errortext = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.claimDetails = new System.Windows.Forms.ListBox();
            this.lossInfoDetails = new System.Windows.Forms.ListBox();
            this.vehicleDetails = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblerror = new System.Windows.Forms.Label();
            this.fromdatepick = new System.Windows.Forms.DateTimePicker();
            this.todatepick = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.claimsList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.createclaim = new System.Windows.Forms.Button();
            this.updateclaim = new System.Windows.Forms.Button();
            this.deleteclaim = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.vinnumber = new System.Windows.Forms.TextBox();
            this.vehdetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Claim Number";
            // 
            // claimNumber
            // 
            this.claimNumber.Location = new System.Drawing.Point(124, 22);
            this.claimNumber.Name = "claimNumber";
            this.claimNumber.Size = new System.Drawing.Size(273, 20);
            this.claimNumber.TabIndex = 1;
            // 
            // errortext
            // 
            this.errortext.AutoSize = true;
            this.errortext.ForeColor = System.Drawing.Color.DarkRed;
            this.errortext.Location = new System.Drawing.Point(16, 236);
            this.errortext.Name = "errortext";
            this.errortext.Size = new System.Drawing.Size(0, 13);
            this.errortext.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Get Claim";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // claimDetails
            // 
            this.claimDetails.FormattingEnabled = true;
            this.claimDetails.HorizontalScrollbar = true;
            this.claimDetails.Location = new System.Drawing.Point(280, 275);
            this.claimDetails.Name = "claimDetails";
            this.claimDetails.ScrollAlwaysVisible = true;
            this.claimDetails.Size = new System.Drawing.Size(197, 82);
            this.claimDetails.TabIndex = 4;
            // 
            // lossInfoDetails
            // 
            this.lossInfoDetails.FormattingEnabled = true;
            this.lossInfoDetails.HorizontalScrollbar = true;
            this.lossInfoDetails.Location = new System.Drawing.Point(280, 379);
            this.lossInfoDetails.Name = "lossInfoDetails";
            this.lossInfoDetails.ScrollAlwaysVisible = true;
            this.lossInfoDetails.Size = new System.Drawing.Size(197, 95);
            this.lossInfoDetails.TabIndex = 5;
            // 
            // vehicleDetails
            // 
            this.vehicleDetails.FormattingEnabled = true;
            this.vehicleDetails.HorizontalScrollbar = true;
            this.vehicleDetails.Location = new System.Drawing.Point(504, 275);
            this.vehicleDetails.Name = "vehicleDetails";
            this.vehicleDetails.ScrollAlwaysVisible = true;
            this.vehicleDetails.Size = new System.Drawing.Size(381, 212);
            this.vehicleDetails.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Claim Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Loss Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(501, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vehicle Details";
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(39, 477);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(29, 13);
            this.lblerror.TabIndex = 10;
            this.lblerror.Text = "Error";
            this.lblerror.Visible = false;
            // 
            // fromdatepick
            // 
            this.fromdatepick.Location = new System.Drawing.Point(64, 103);
            this.fromdatepick.Name = "fromdatepick";
            this.fromdatepick.Size = new System.Drawing.Size(200, 20);
            this.fromdatepick.TabIndex = 11;
            // 
            // todatepick
            // 
            this.todatepick.Location = new System.Drawing.Point(376, 103);
            this.todatepick.Name = "todatepick";
            this.todatepick.Size = new System.Drawing.Size(200, 20);
            this.todatepick.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "From:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "To:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Get Claims";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // claimsList
            // 
            this.claimsList.FormattingEnabled = true;
            this.claimsList.HorizontalScrollbar = true;
            this.claimsList.Location = new System.Drawing.Point(33, 275);
            this.claimsList.Name = "claimsList";
            this.claimsList.ScrollAlwaysVisible = true;
            this.claimsList.Size = new System.Drawing.Size(197, 186);
            this.claimsList.TabIndex = 16;
            this.claimsList.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Claims";
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(58, 176);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(676, 20);
            this.filePath.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Path:";
            // 
            // createclaim
            // 
            this.createclaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createclaim.Location = new System.Drawing.Point(19, 212);
            this.createclaim.Name = "createclaim";
            this.createclaim.Size = new System.Drawing.Size(135, 23);
            this.createclaim.TabIndex = 20;
            this.createclaim.Text = "Create Claim";
            this.createclaim.UseVisualStyleBackColor = true;
            this.createclaim.Click += new System.EventHandler(this.createclaim_Click);
            // 
            // updateclaim
            // 
            this.updateclaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateclaim.Location = new System.Drawing.Point(170, 212);
            this.updateclaim.Name = "updateclaim";
            this.updateclaim.Size = new System.Drawing.Size(135, 23);
            this.updateclaim.TabIndex = 21;
            this.updateclaim.Text = "Update Claim";
            this.updateclaim.UseVisualStyleBackColor = true;
            this.updateclaim.Click += new System.EventHandler(this.updateclaim_Click);
            // 
            // deleteclaim
            // 
            this.deleteclaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteclaim.Location = new System.Drawing.Point(170, 60);
            this.deleteclaim.Name = "deleteclaim";
            this.deleteclaim.Size = new System.Drawing.Size(135, 23);
            this.deleteclaim.TabIndex = 22;
            this.deleteclaim.Text = "Delete Claim";
            this.deleteclaim.UseVisualStyleBackColor = true;
            this.deleteclaim.Click += new System.EventHandler(this.deleteclaim_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(403, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "VIN";
            // 
            // vinnumber
            // 
            this.vinnumber.Location = new System.Drawing.Point(442, 22);
            this.vinnumber.Name = "vinnumber";
            this.vinnumber.Size = new System.Drawing.Size(273, 20);
            this.vinnumber.TabIndex = 24;
            // 
            // vehdetail
            // 
            this.vehdetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehdetail.Location = new System.Drawing.Point(326, 60);
            this.vehdetail.Name = "vehdetail";
            this.vehdetail.Size = new System.Drawing.Size(135, 23);
            this.vehdetail.TabIndex = 25;
            this.vehdetail.Text = "Vehicle Details";
            this.vehdetail.UseVisualStyleBackColor = true;
            this.vehdetail.Click += new System.EventHandler(this.vehdetail_Click);
            // 
            // MitchellClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 499);
            this.Controls.Add(this.vehdetail);
            this.Controls.Add(this.vinnumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.deleteclaim);
            this.Controls.Add(this.updateclaim);
            this.Controls.Add(this.createclaim);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.claimsList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.todatepick);
            this.Controls.Add(this.fromdatepick);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vehicleDetails);
            this.Controls.Add(this.lossInfoDetails);
            this.Controls.Add(this.claimDetails);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errortext);
            this.Controls.Add(this.claimNumber);
            this.Controls.Add(this.label1);
            this.Name = "MitchellClient";
            this.Text = "Mitchell Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox claimNumber;
        private System.Windows.Forms.Label errortext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox claimDetails;
        private System.Windows.Forms.ListBox lossInfoDetails;
        private System.Windows.Forms.ListBox vehicleDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.DateTimePicker fromdatepick;
        private System.Windows.Forms.DateTimePicker todatepick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox claimsList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button createclaim;
        private System.Windows.Forms.Button updateclaim;
        private System.Windows.Forms.Button deleteclaim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox vinnumber;
        private System.Windows.Forms.Button vehdetail;
    }
}

