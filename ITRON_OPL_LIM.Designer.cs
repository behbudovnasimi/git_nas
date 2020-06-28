namespace hesabat
{
    partial class ITRON_OPL_LIM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITRON_OPL_LIM));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cardView5 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.cE3 = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dE1 = new DevExpress.XtraEditors.DateEdit();
            this.dE2 = new DevExpress.XtraEditors.DateEdit();
            this.splashScreenManager3 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::hesabat.WaitForm1), true, true);
            this.button19 = new System.Windows.Forms.Button();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cE3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(655, 764);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 36);
            this.button2.TabIndex = 85;
            this.button2.Text = "Tərk et";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(556, 764);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 84;
            this.button1.Text = "Təsdiq et";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl4
            // 
            this.gridControl4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gridControl4.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl4.Location = new System.Drawing.Point(7, 175);
            this.gridControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl4.MainView = this.gridView4;
            this.gridControl4.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.Size = new System.Drawing.Size(1301, 581);
            this.gridControl4.TabIndex = 106;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4,
            this.cardView5});
            this.gridControl4.Visible = false;
            // 
            // gridView4
            // 
            this.gridView4.ActiveFilterEnabled = false;
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.Preview.BackColor = System.Drawing.Color.Transparent;
            this.gridView4.Appearance.Preview.Options.UseBackColor = true;
            this.gridView4.Appearance.Preview.Options.UseTextOptions = true;
            this.gridView4.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView4.Appearance.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.LightGreen;
            this.gridView4.Appearance.Row.BackColor2 = System.Drawing.Color.AliceBlue;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.GridControl = this.gridControl4;
            this.gridView4.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView4.IndicatorWidth = 10;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowGroup = false;
            this.gridView4.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView4.OptionsPrint.ExpandAllDetails = true;
            this.gridView4.OptionsSelection.MultiSelect = true;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowAutoFilterRow = true;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // cardView5
            // 
            this.cardView5.FocusedCardTopFieldIndex = 0;
            this.cardView5.GridControl = this.gridControl4;
            this.cardView5.Name = "cardView5";
            // 
            // cE3
            // 
            this.cE3.Location = new System.Drawing.Point(468, 27);
            this.cE3.Margin = new System.Windows.Forms.Padding(4);
            this.cE3.Name = "cE3";
            this.cE3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cE3.Properties.Appearance.Options.UseFont = true;
            this.cE3.Properties.Caption = "";
            this.cE3.Size = new System.Drawing.Size(27, 26);
            this.cE3.TabIndex = 109;
            this.cE3.CheckedChanged += new System.EventHandler(this.cE3_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(539, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 111;
            this.label2.Text = "1.Vaxt intervalı";
            // 
            // dE1
            // 
            this.dE1.EditValue = new System.DateTime(2016, 7, 8, 0, 0, 0, 0);
            this.dE1.Enabled = false;
            this.dE1.Location = new System.Drawing.Point(499, 27);
            this.dE1.Margin = new System.Windows.Forms.Padding(4);
            this.dE1.Name = "dE1";
            this.dE1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dE1.Properties.Appearance.Options.UseFont = true;
            this.dE1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dE1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dE1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dE1.Size = new System.Drawing.Size(112, 26);
            this.dE1.TabIndex = 113;
            this.dE1.Popup += new System.EventHandler(this.dE1_Popup);
            // 
            // dE2
            // 
            this.dE2.EditValue = new System.DateTime(2016, 7, 8, 0, 0, 0, 0);
            this.dE2.Enabled = false;
            this.dE2.Location = new System.Drawing.Point(619, 27);
            this.dE2.Margin = new System.Windows.Forms.Padding(4);
            this.dE2.Name = "dE2";
            this.dE2.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dE2.Properties.Appearance.Options.UseFont = true;
            this.dE2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dE2.Properties.DisplayFormat.FormatString = "d";
            this.dE2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dE2.Properties.Mask.EditMask = "G";
            this.dE2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dE2.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dE2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dE2.Size = new System.Drawing.Size(112, 26);
            this.dE2.TabIndex = 114;
            this.dE2.Popup += new System.EventHandler(this.dE2_Popup);
            // 
            // button19
            // 
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button19.Image = ((System.Drawing.Image)(resources.GetObject("button19.Image")));
            this.button19.Location = new System.Drawing.Point(744, 764);
            this.button19.Margin = new System.Windows.Forms.Padding(4);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(60, 36);
            this.button19.TabIndex = 116;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Visible = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Enabled = false;
            this.lookUpEdit1.Location = new System.Drawing.Point(499, 69);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lookUpEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpEdit1.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.lookUpEdit1.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUpEdit1.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DropDownRows = 16;
            this.lookUpEdit1.Properties.NullText = "Rayonu seç";
            this.lookUpEdit1.Properties.ShowPopupShadow = false;
            this.lookUpEdit1.Size = new System.Drawing.Size(232, 26);
            this.lookUpEdit1.TabIndex = 120;
            // 
            // ITRON_OPL_LIM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 812);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.gridControl4);
            this.Controls.Add(this.dE2);
            this.Controls.Add(this.dE1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cE3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ITRON_OPL_LIM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ITRON_OPL_LIM";
            this.Load += new System.EventHandler(this.ITRON_OPL_LIM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cE3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dE2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public DevExpress.XtraGrid.GridControl gridControl4;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Card.CardView cardView5;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.CheckEdit cE3;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.DateEdit dE1;
        public DevExpress.XtraEditors.DateEdit dE2;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        private System.Windows.Forms.Button button19;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager3;
    }
}