using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.OracleClient;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;

using DevExpress.XtraExport;

namespace hesabat
{
    public partial class ITRON_OPL_LIM : Form
    {
        public ITRON_OPL_LIM()
        {
            InitializeComponent();
        }
        string n_d1, n_d2, n_str, n_mmgg, n_mmgg_b, n_mmgg_s = "";
        string n_str0,  n_str4,n_str5 = "";

        private DataSet myDataSet;
        private OleDbDataAdapter myAdapter;

        int  iii,n_mes = 0;
        DateTime S_Date, E_Date;
        DataTable resultTable4 = new DataTable();
        DataTable resultTable0 = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            E_Date = new DateTime(Int32.Parse(dE2.EditValue.ToString().Substring(6, 4)),Int32.Parse(dE2.EditValue.ToString().Substring(3, 2)), 28);
            int Month = E_Date.Month;
            int Year = E_Date.Year;
            int allDayMonth = DateTime.DaysInMonth(Year, Month);
            DateTime Begin = new DateTime(Year, Month, 1);
            DateTime End = new DateTime(Year, Month, allDayMonth);
            S_Date = new DateTime(Int32.Parse(dE1.EditValue.ToString().Substring(6, 4)),
                                Int32.Parse(dE1.EditValue.ToString().Substring(3, 2)), 1);
            E_Date = End;

            if (DateTime.Compare(S_Date, E_Date) > 0)
            {
                MessageBox.Show("Interval arlığını yoxlayın");
                return;
            }

            DialogResult result1 = MessageBox.Show("Məlumatın hazırlanmasını təsdiqləyirsiz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result1 == DialogResult.Yes)
            {
                gridControl4.Visible = false;
                using (OleDbConnection oConn1 = new OleDbConnection())      // DEV_inzibatçiliq - doldurmaq
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Bir qədər gözləyin,");
                    SplashScreenManager.Default.SetWaitFormDescription("məlumat hazırlanır..."); 

                    resultTable4.Clear();
                    resultTable4.Columns.Clear();
                    gridView4.Columns.Clear();
                    gridControl4.DataSource = null;

                    try
                    {
                        OleDbCommand oCmd1 = oConn1.CreateCommand();
                        oConn1.ConnectionString = p_var.n_conn;
                        oConn1.Open();
                        oCmd1 = oConn1.CreateCommand();
                        oCmd1.CommandText = "";
                        n_d1 = (cE3.Checked) ? dE1.EditValue.ToString().Substring(0,10).Replace(".",""): "01012017"; //Tarix aktiv,passiv
                        n_d2 = (cE3.Checked) ? dE2.EditValue.ToString().Substring(0,10).Replace(".",""): "31012017"; //Tarix aktiv,passiv

         n_str5="";
         n_str = "";
         iii = 0;
/*
         E_Date = new DateTime(Int32.Parse(dE2.EditValue.ToString().Substring(6, 4)),
              Int32.Parse(dE2.EditValue.ToString().Substring(3, 2)), 28);

         int Month = E_Date.Month;
         int Year  = E_Date.Year;
         int allDayMonth = DateTime.DaysInMonth(Year,Month);
         DateTime Begin = new DateTime (Year,Month,1);
         DateTime End = new DateTime (Year,Month,allDayMonth);

         S_Date = new DateTime(Int32.Parse(dE1.EditValue.ToString().Substring(6, 4)),
                             Int32.Parse(dE1.EditValue.ToString().Substring(3, 2)), 1);
         E_Date = End;

         if (DateTime.Compare(E_Date, S_Date) < 0)
         {
             MessageBox.Show("Intervalı yoxlayın");
             return;
         }
*/
         n_mes = 12 * (E_Date.Year - S_Date.Year) + (E_Date.Month - S_Date.Month)+1;
         n_mmgg   = S_Date.AddMonths(-1).ToString().Substring(3, 7).Replace(".", "");
         n_mmgg_s = E_Date.ToString().Substring(3, 7).Replace(".", "");
         n_mmgg_b = S_Date.ToString().Substring(3, 7).Replace(".", "");
         n_str0 = @"select substr(azqaz.itron_rayon_3e_63(location_ref),1,60) rayon,location_ref subid,substr(azqaz.itron_rayon_3e_63(location_ref)||' '||azqaz.itron_kuce_3e_63(location_ref),1,80) unvan,
                    substr(azqaz.itron_subidtogpg_3e(location_ref),1,48) saygac,azqaz.itron_ks_ins_dat(location_ref) saygac_qur_tarix,substr(azqaz.itron_trf_63(azqaz.itron_rdptotrf_63(location_id)),1,60) trf,";
                while(DateTime.Compare(E_Date,S_Date)>0)
                {
                  n_mmgg=S_Date.ToString().Substring(3, 7).Replace(".","");
                  n_str = n_str + @"azqaz.itron_pul_sum_63(azqaz.itron_subidtogpg_3e_63(location_ref),to_char(TO_DATE ('" + n_mmgg + "','mmyyyy'),'ddmmyyyy'), to_char(LAST_DAY(TO_DATE ('" + n_mmgg + "','mmyyyy')),'ddmmyyyy')) " +
                  @" OPL_" + n_mmgg + " ,\n"+
                  @"azqaz.ITRON_GPG_limit_3e_63(location_ref, to_char(TO_DATE ('" + n_mmgg + "','mmyyyy'),'ddmmyyyy'), to_char(LAST_DAY(TO_DATE ('" + n_mmgg + "','mmyyyy')),'ddmmyyyy')) " +
                  @" LIM_" + n_mmgg + " ,\n";
                  iii=iii+1;
                  S_Date = new DateTime(Int32.Parse(dE1.EditValue.ToString().Substring(6,4)),Int32.Parse(dE1.EditValue.ToString().Substring(3,2)), 1);
                  S_Date = S_Date.AddMonths(iii);
                }
                n_str = n_str0 + " " + n_str;
                n_mmgg = n_mmgg.Replace(".", "");
                n_str4 = @"substr(azqaz.ev_tipi_na(location_ref),1,50) ev_tip,substr(azqaz.sahe_a(location_ref),1,50) sahe,substr(azqaz.nezaretci_a(location_ref),1,50) nez" +
                          " from vps.location@agis_3e_63 where (location_ref like '"+lookUpEdit1.EditValue.ToString()+ "%') ";
                n_str = n_str+" "+ n_str4;              
       oCmd1.CommandText = n_str;
       Clipboard.SetText(oCmd1.CommandText);
       resultTable4.Load(oCmd1.ExecuteReader()); 
                    }
                    catch (Exception ex)
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show("Serverə müraciətdə xəta yarandı: " + ex.Message);
                        return;
                    }
                    oConn1.Close();

                    gridControl4.DataSource = null;
                    gridControl4.DataSource = resultTable4;
                    gridControl4.ForceInitialize();
                    //Griddə düymələr
                    gridControl4.UseEmbeddedNavigator = true;
                    gridControl4.EmbeddedNavigator.Buttons.Edit.Visible = false;
                    gridControl4.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    gridControl4.EmbeddedNavigator.Buttons.Append.Visible = false;
                    gridControl4.EmbeddedNavigator.Buttons.Remove.Visible = false;
                    gridControl4.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    gridControl4.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən";

                    gridControl4.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
                    gridControl4.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
                    gridControl4.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

                    gridControl4.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
                    gridControl4.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
                    gridControl4.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";

                    gridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    gridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;

                    gridView4.OptionsView.ShowViewCaption = true;
    
                    gridView4.ViewCaption = "Seçilmış vaxt intervalı:" + "[" + n_d1 + "," + n_d2 + "]";

                    gridView4.ViewCaptionHeight = 2;
                    
                    gridView4.RefreshData();

                    if (resultTable4.Rows.Count > 0)
                    {
                        gridControl4.Visible = true;

                        gridView4.Appearance.HeaderPanel.Options.UseTextOptions = true;
                        gridView4.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        gridView4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridView4.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                        gridView4.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near; //.Default;
                        
                        gridView4.OptionsBehavior.Editable = false;

                        gridView4.BestFitColumns();

                        gridView4.OptionsPrint.PrintDetails = true;
                        gridView4.OptionsPrint.ExpandAllDetails = true;
                        gridView4.OptionsPrint.AutoWidth = false;// true;

                        button19.Visible = true;
                        gridControl4.BringToFront();
                        gridView4.RefreshData();
                        this.WindowState = FormWindowState.Normal;
                        SplashScreenManager.CloseForm(false);
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show("Məlumat tapılmadı !");
                        p_var.n_rez = "N";
                        return;
                    }
                }
                p_var.n_rez = "Y";
                return;
            }
            else
            {
                p_var.n_rez = "N";
                this.Close();
                return;
            }

            gridControl4.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p_var.n_rez = "N";
            this.Close();
            return;
        }

        DateTime now_DT = DateTime.Now;

        private void ITRON_OPL_LIM_Load(object sender, EventArgs e)
        {
            gridControl4.Visible = false;
            cE3.CheckState = 0;
            button1.Enabled = false;

            DateTime now = DateTime.Now;
            var S_Date = new DateTime(now.Year, now.Month, 1);
            var E_Date = S_Date.AddMonths(1).AddDays(-1);

            dE1.EditValue = S_Date; // now_DT;
            dE2.EditValue = E_Date; // now_DT;

            dE1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dE1.Properties.Mask.EditMask = "dd.MM.yyyy"; //"dd.MM.yyyy";
            dE1.Properties.Mask.UseMaskAsDisplayFormat = true;

            dE2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dE2.Properties.Mask.EditMask = "dd.MM.yyyy"; //"dd.MM.yyyy"; // HH:mm:ss";
            dE2.Properties.Mask.UseMaskAsDisplayFormat = true; 

            using (OleDbConnection oConn1 = new OleDbConnection())      // Tree ni GMQKI - doldurmaq
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Bir qədər gözləyin,");
                SplashScreenManager.Default.SetWaitFormDescription("məlumat hazırlanır...");

                resultTable0.Clear(); 
                resultTable0.Columns.Clear();
                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();
                    oCmd1.CommandText = @"select name RAYONLAR,subjectid||matrixid RAYON_ID from ahali.matrix order by subjectid,matrixid";
                    Clipboard.SetText(oCmd1.CommandText);
                    resultTable0.Load(oCmd1.ExecuteReader());
                }
                catch (Exception ex)
                {
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(1): " + ex.Message);
                    return;
                }
                oConn1.Close();
                SplashScreenManager.CloseForm(false);
            }
            if (resultTable0.Rows.Count == 0)
            {
                return;
            }
            lookUpEdit1.Properties.DataSource    = resultTable0;
            lookUpEdit1.Properties.DisplayMember = "RAYONLAR";
            lookUpEdit1.Properties.ValueMember   = "RAYON_ID"; // "FORM_TITLE";
        }

        private void button19_Click(object sender, EventArgs e) //EXCELə
        {
            XlsxExportOptions options = new XlsxExportOptions();
            options.ExportMode = XlsxExportMode.SingleFilePageByPage;// XlsxExportMode.SingleFile; //.SingleFilePageByPage;
            options.SheetName = string.Format("List1-{0:ddMMyyyy_HHmmss}", DateTime.Now);
            options.ShowGridLines = true;
            //var fileName = string.Format("sample-{0:ddMMyyyy_HHmmss}", DateTime.Now) + ".xlsx";
            var FileName = "ITRONopllim.xlsx";

            options.ExportMode = XlsxExportMode.SingleFile;//.SingleFilePageByPage;
            //options.ExportMode = XlsxExportMode.SingleFilePageByPage; //.DifferentFiles;
            gridView4.ExportToXlsx(FileName, options);
            SplashScreenManager.CloseForm(false);
            Process.Start("EXCEL.EXE", " /e " + FileName);
            return;

            /*
            string path = "output.xlsx";

            //DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.DataAware;

            //Customize export options
            (gridControl4.MainView as GridView).OptionsPrint.PrintHeader = false;
            XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            advOptions.SheetName = "Exported from Data Grid";

            gridControl4.ExportToXlsx(path, advOptions);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        
            */

        }

        private void cE3_CheckedChanged(object sender, EventArgs e)
        {
            dE1.Enabled         = (cE3.Checked) ? true : false; //Tarix aktiv,passiv
            dE2.Enabled         = (cE3.Checked) ? true : false; //Tarix aktiv,passiv
            button1.Enabled     = (cE3.Checked) ? true : false; //Düymə aktiv,passiv
            lookUpEdit1.Enabled = (cE3.Checked) ? true : false; //Düymə aktiv,passiv
            dE1.Select();
        }

        private void dE1_Popup(object sender, EventArgs e)
        {
            DateEdit edit = sender as DateEdit;
            PopupDateEditForm form = (edit as IPopupControl).PopupWindow as PopupDateEditForm;
            form.Calendar.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.YearInfo;
        }

        private void dE2_Popup(object sender, EventArgs e)
        {
            DateEdit edit = sender as DateEdit;
            PopupDateEditForm form = (edit as IPopupControl).PopupWindow as PopupDateEditForm;
            form.Calendar.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.YearInfo;
        }

     }
}
