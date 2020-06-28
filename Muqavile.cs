using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Threading;
using System.Diagnostics;
using FastReport.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraBars.Docking;
using File = System.IO.File;


namespace tex_bax
{
    /// <summary>
    ///  Rəhman və Rəhim olan yalnız uca RƏBBİmdir
    /// (C.C) ALLAH 
    /// </summary>
    public partial class Form1 : Form
    {
        //public AgentObjects.IAgentCtlCharacterEx merlin;

        public Form1()
        {
            InitializeComponent();
            label5.Text  =" Aktlarda =>";
            p_var.n_form = "Form_akt";

//            tabPage3.Parent = null;        //скрыть  TabPage4
//            tabPage4.Parent = null;        //скрыть  TabPage4
        }

        //int i, j, v_reccount, m, n;
        Form2 Form_akt         = new Form2();     //AKTLAR 
        Form3 Form_cihaz       = new Form3();     //CIHAZLAR
        Form4 Pw               = new Form4();     //PAROL
        Form5 Find             = new Form5();     //Ünvanla və ya sayğacla axtariş
        Form53p Find53p        = new Form53p();
        Akt_leqv Aktleqv       = new Akt_leqv();
        AKT_ELAVE AktElave     = new AKT_ELAVE();
        AKTİ_AXTAR AktiAxtar   = new AKTİ_AXTAR();
        DOQ_AXTAR DoqAxtar     = new DOQ_AXTAR();
        Seal_leqv Sealleqv     = new Seal_leqv();
        Plomb_Axtar PlombAxtar = new Plomb_Axtar();
        Plomb_ELAVE PlombElave = new Plomb_ELAVE();
        Inzibat Inzibatci      = new Inzibat();
        AKT_ADD Aktadd         = new AKT_ADD();
        COX_YENI_C COXYENIC    = new COX_YENI_C();
        DOQOVOR DOQ            = new DOQOVOR();
        Doq_leqv Doqleqv       = new Doq_leqv();
        DOQ_ELAVE DoqElave     = new DOQ_ELAVE();
        VESTEL Ves_Tel         = new VESTEL();
        CLOSE_METER CL_ME      = new CLOSE_METER();
        CLM_AXTAR ClmAxtar     = new CLM_AXTAR();

        PLAN_AXTAR PlanAxtar   = new PLAN_AXTAR();

        Ferid Fer = new Ferid();
        Ferid_cox Fer_cox = new Ferid_cox();

        FORMAN1 Forma_N1       = new FORMAN1(); //FORMA N:1 
        FORMAN4 Forma_N4       = new FORMAN4(); //FORMA N:4
        FORMAN7 Forma_N7       = new FORMAN7(); //FORMA N:7
        FORMAN8 Forma_N8       = new FORMAN8(); //FORMA N:8
        FORMAN11 Forma_N11     = new FORMAN11();//FORMA N:11
        FORMAN13 Forma_N13     = new FORMAN13();//FORMA N:13
        FORMAN14 Forma_N14     = new FORMAN14();//FORMA N:14

        Forman1_F  Forma_N1_F = new Forman1_F();//Forman1_F
        Forman2_F  Forma_N3_F = new Forman2_F();//Forman2_F
        Forman4_F  Forma_N4_F = new Forman4_F();//Forman4_F
        FORMAN7F   Forma_N2_F = new FORMAN7F(); //FORMA N:7F
        Forman5_F  Forma_N5_F = new Forman5_F();//Forman4_F
        Forman6_F  Forma_N6_F = new Forman6_F();
        Forman7_F  Forma_N7_F = new Forman7_F();//
        Forman8_F  Forma_N8_F = new Forman8_F();//
        Forman9_F  Forma_N9_F = new Forman9_F();//
        Forman10_F Forma_N10_F= new Forman10_F();//
        Forman11_F Forma_N11_F = new Forman11_F();//
        Forman12_F Forma_N12_F = new Forman12_F();//

        FORMAZIPORA FORM_ZIP_ORA = new FORMAZIPORA(); //Klient yeni versiya hazirlamaq
        Asan_log         Asanlog = new Asan_log(); //Asan loqlar
        Sil_muq           Silmuq = new Sil_muq();//ASAN silinmiş müqavilələr 

        DATA_KORR DATAKORR = new DATA_KORR();
        BILDIRISH_F BIL_F  = new BILDIRISH_F();

        //var parse = new VisualFoxpro.Application;
        //var parse = new FoxApplication();

        private void Form1_Load(object sender, EventArgs e)
        {
            Process currentPr = Process.GetCurrentProcess(); 
            foreach (Process pr in Process.GetProcesses())
            {
                if ((pr.ProcessName == currentPr.ProcessName) && (pr.Id != currentPr.Id))
                {
                    Environment.Exit(0);  //"Приложение уже запущено!!!"
                }
            }

            GridLocalizer.Active = new MyGridLocalizer();

/*
   //--- Texniki baxış sözü Müqavilələrlə sözü ilə əvəz edilir Desktopda 
            string SPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (File.Exists(SPath + "\\Texniki Baxış.lnk"))
            {
                File.Copy(SPath + "\\Texniki Baxış.lnk", SPath + "\\Müqavilələr.lnk", true);
                File.Delete(SPath + "\\Texniki Baxış.lnk");
            }
            else
            {
                if (File.Exists("C:\\Users\\Public\\Desktop\\Texniki Baxış.lnk"))
                {
                    File.Copy("C:\\Users\\Public\\Desktop\\Texniki Baxış.lnk", "C:\\Users\\Public\\Desktop\\Müqavilələr.lnk", true);
                    File.Delete("C:\\Users\\Public\\Desktop\\Texniki Baxış.lnk");
                }
            }
   //---
*/
            //n_fun.my_conn("STEPƏ");
            //axAgent1.Characters.Load("merlin", "merlin.acs");
            //merlin = axAgent1.Characters["merlin"];
           
            txtbxSubscriberNo.Select();

            Pw.Text = "Texniki baxış ve Müqavileler ";
            Pw.ShowDialog();
            //MaximizeBox = false;
/*
            if (p_var.n_rol == "7" || p_var.n_rol == "8")
            {
                this.WindowState = FormWindowState.Maximized ;
            }
*/
//          if (p_var.n_rol != "4" || p_var.n_rol != "5")
            if (p_var.n_rol == "0" || p_var.n_rol == "1" || p_var.n_rol == "2" || p_var.n_rol == "3" || p_var.n_rol == "7" || p_var.n_rol == "8" || p_var.n_rol == "9")
            {
                tabPage5.Parent = null;  //скрыть TabPage5(inzibatçiliq) rol SuperAdmin deyil(<>4)
            }

            if (p_var.n_rol == "7" || p_var.n_rol == "8" || p_var.n_rol == "9") // rollar: "7" - Asan operetor,"8" - Asan admin,"9" - ASAN baxəş
            {
                tabPage6.Parent = null;  //скрыть TabPage5(inzibatçiliq) rol SuperAdmin deyil(<>4)
                tabPage3.Parent = null; 
            }

            if (p_var.n_uzer_name.Substring(0, 1) == "b")
            {
                tabPage10.Parent = null;
                tabPage11.Parent = null;
            }

            if (p_var.n_uzer_name.Substring(0, 1) == "N" || p_var.n_uzer_name.Substring(0, 1) == "b" || p_var.n_rol == "7" || p_var.n_rol == "8" || p_var.n_rol == "9")
            {
                tabPage1.Parent  = null;          //скрыть  TabPage1
                tabPage4.Parent  = null;          //скрыть  TabPage4
                tabPage7.Parent  = null;          //скрыть  TabPage7
                tabPage8.Parent  = null;          //скрыть  TabPage8
                tabPage9.Parent  = null;          //скрыть  TabPage9
                //tabPage11.Parent = null;
                grdXidmet.Visible = false;
                gridControl1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                label5.Visible = false;
                tabPage2.Text = "1.MÜQAVİLƏ işi";
                tabPage3.Text = "2.HESABATlar";
                tabPage5.Text = "3.İNZİBATÇIliq";
                Text = "Müqavileler";
                button24.Visible = true;
            }
            else
            {
                tabPage10.Parent = null;
                tabPage11.Parent = null;
            }

            if (p_var.n_rol == "7" || p_var.n_rol == "8" || p_var.n_rol == "9")      //Asan xidmet rolu
            {
                button2.Enabled = false; //Akt və ya Cihaz əlavəsi düyməsi
                button3.Enabled = false; //Akt və ya Cihaz dəyişmə düyməsi
                button4.Enabled = false; //Akt və ya Cihaz silimnmə düyməsi
                button11.Enabled = false; //Aktın ləğvi düyməsi
                button10.Enabled = false; //Akt bazasına əlavə düyməsi
                button13.Enabled = false; //Akt bazasından silinmə düyməsi
                button1.Enabled = false;  //Plomb ləğvi düyməsi
                button5.Enabled = false;  //Plomb bazasına əlavə düyməsi
                button6.Enabled = false;  //Plomb bazasından silinmə düyməsi
                button14.Enabled = false;  //Müqavilə ləğvi düyməsi
                button15.Enabled = false;  //Müqavilə bazasına əlavə düyməsi
                button16.Enabled = false;  //Müqavilə bazasından silinmə düyməsi
                button23.Enabled = false;  //Sayğaclarda baxış düyməsi
                button27.Enabled = false;  //Sayğaclarda çap düyməsi
                button24.Visible = false;  //Müqavilılırdə çox sətir
                //tabPage10.Parent = null;   //Asan müqavilə
                tabPage1.Parent = null;
                tabPage2.Parent = null;
                tabPage3.Parent = null;                //
                tabPage10.Text = "ASAN müqavilə";
                tabPage11.Text = "ASAN hesabatlar";
                MaximizeBox = true;
                //this.WindowState = FormWindowState.Maximized;

                //tabPage3.Text = "2.HESABATlar";
            }
            
            if (p_var.n_rol == "1")      //Baxış rolu
            {
                button2.Enabled  = false; //Akt və ya Cihaz əlavəsi düyməsi
                button3.Enabled  = false; //Akt və ya Cihaz dəyişmə düyməsi
                button4.Enabled  = false; //Akt və ya Cihaz silimnmə düyməsi
                button11.Enabled = false; //Aktın ləğvi düyməsi
                button10.Enabled = false; //Akt bazasına əlavə düyməsi
                button13.Enabled = false; //Akt bazasından silinmə düyməsi
                button1.Enabled  = false;  //Plomb ləğvi düyməsi
                button5.Enabled  = false;  //Plomb bazasına əlavə düyməsi
                button6.Enabled  = false;  //Plomb bazasından silinmə düyməsi
                button14.Enabled = false;  //Müqavilə ləğvi düyməsi
                button15.Enabled = false;  //Müqavilə bazasına əlavə düyməsi
                button16.Enabled = false;  //Müqavilə bazasından silinmə düyməsi
                button23.Enabled = false;  //Sayğaclarda baxış düyməsi
                button27.Enabled = false;  //Sayğaclarda çap düyməsi
                button24.Visible = false;  //Müqavilılırdə çox sətir
                tabPage10.Parent = null;   //
                tabPage11.Parent = null;
                tabPage3.Text = "2.HESABATlar";
            }

            if (p_var.n_rol == "2")      //Operator rolu
            {
                button11.Enabled = false; //Aktın ləğvi düyməsi
                button10.Enabled = false; //Akt bazasına əlavə düyməsi
                button13.Enabled = false; //Akt bazasından silinmə düyməsi
                button1.Enabled  = false;  //Plomb ləğvi düyməsi
                button5.Enabled  = false;  //Plomb bazasına əlavə düyməsi
                button6.Enabled  = false;  //Plomb bazasından silinmə düyməsi
                button14.Enabled = false;  //Müqavilə ləğvi düyməsi
                button15.Enabled = false;  //Müqavilə bazasına əlavə düyməsi
                button16.Enabled = false;  //Müqavilə bazasından silinmə düyməsi
                button23.Enabled = true;  //Sayğaclarda baxış düyməsi
                button27.Enabled = true;  //Sayğaclarda çap düyməsi
            }

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100; /// 1000;
            toolTip1.ReshowDelay  = 500;
            /// toolTip1.ForeColor = Color.DarkBlue;
            toolTip1.ShowAlways   = true;
            
            //Plomblarda düymələr
            toolTip1.SetToolTip(this.button7, "Plombların müəyyən şərtlərlə axtarış");
            toolTip1.SetToolTip(this.button6, "Yeni plombların əlavə edilməsi");
            toolTip1.SetToolTip(this.button5, "Plombların silinməsi");
            toolTip1.SetToolTip(this.button1, "Plombın ləğv edilməsi(3 vəziyyətinə keçirilməsi)");

            //Aktlarda düymələr
            toolTip1.SetToolTip(this.button9, "Aktların müəyyən şərtlərlə axtarış");
            toolTip1.SetToolTip(this.button10,"Yeni aktların əlavə edilməsi");
            toolTip1.SetToolTip(this.button11,"Aktların silinməsi");
            toolTip1.SetToolTip(this.button13,"Aktın ləğv edilməsi(3 vəziyyətinə keçirilməsi)");
            toolTip1.SetToolTip(this.textBox12,p_var.n_region);

        }

        private void btnSearch_Click(object sender, EventArgs e) //Axtariş
        {
            if (txtbxSubscriberNo.Text.Trim() == "")
               {
                   txtbxSubscriberNo.Text = my_metod_find("");

                   if (String.IsNullOrEmpty(txtbxSubscriberNo.Text.Trim()))
                      {
                         txtbxSubscriberNo.Focus();
                         return;
                      }
               }
            label2.Text = label6.Text = textBox2.Text = textBox3.Text = "";
            textBox4.Text = textBox1.Text = label18.Text = textBox13.Text=label22.Text=textBox15.Text="";
            label23.Text = label24.Text = "";

            p_var.n_kset = "";
            p_var.n_gpg = "";
            p_var.n_plomb = "";
            button12.Visible = false;
            button18.Visible = false;
            button22.Visible = false;
           // button24.Visible = false;
//*** Regiona aidliyini yoxlamaq
            if (p_var.n_region.IndexOf("'" + txtbxSubscriberNo.Text.Trim().Substring(2, 2) + "'") == -1)
            {
                MessageBox.Show(txtbxSubscriberNo.Text.Trim() + " Bu abonent kodu Sizin regiona aid deyil !");
                button2.Enabled = button3.Enabled=button4.Enabled=false;
                grdXidmet.Enabled = false;
                return;
            }
//***
//--------
            //Clipboard.SetText("TextFor Copy");  копировать TextFor Copy на буфер обмен.
//--------
            Form.ActiveForm.Refresh();

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Axtarıram...");
            SplashScreenManager.Default.SetWaitFormDescription(" ");
           
            //Thread.Sleep(1 * 500);
            //merlin.MoveTo(400,400);
            //merlin.Show(true);
            //merlin.Speak("Axtarıram...", "");
 //*********
            using (OleDbConnection oConn1 = new OleDbConnection())      // dataGridView1 - doldurmaq
            {
                DataTable dtAkt = new DataTable();
                DataSet dsAkt = new DataSet();
                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();
                    oCmd1.CommandText = @"select distinct subid Kodu , akt_num,akt_data
                                        from azqaz.tex_bax_akts where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "' order by akt_data desc"; //+"'";

                    dtAkt.Load(oCmd1.ExecuteReader());
                    dtAkt.TableName   = "akt";
                    oCmd1.CommandText = @"select akt_num, AKT_ID, azqaz.deffect_name(deffect_id) name, qeyd,
                                        azqaz.inspektor_name(inspektor_id) inspektorn,istehlakci,
                                        deffect_id,inspektor_id,akt_data,subid,akt_kscet,oper_date,user_name,azqaz.agis_user(user_name) Adi,songes,songese
                                        from azqaz.tex_bax_akts where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "' order by akt_num"; 

                    DataTable dtChild = new DataTable();
                    dtChild.Load(oCmd1.ExecuteReader());
                    dtChild.TableName = "Child";

                    //******* Sətrlər nömrələnir
                    dtChild.Columns.Add("SN", typeof(Int32)).SetOrdinal(0);

                    string v_AKT_NUM = "";
                    int v_KKKKKKK = 0;
                    if (dtChild.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtChild.Rows.Count; i++)
                        {
                            v_KKKKKKK = (v_AKT_NUM == dtChild.Rows[i]["AKT_NUM"].ToString()) ? v_KKKKKKK + 1 : 1;
                            dtChild.Rows[i]["SN"] = v_KKKKKKK;
                            v_AKT_NUM = dtChild.Rows[i]["AKT_NUM"].ToString();
                        }
                    }
                    //*******
                    dsAkt.Tables.Add(dtAkt);
                    dsAkt.Tables.Add(dtChild);

                    dsAkt.Relations.Add("AKTın_sətirləri", dtAkt.Columns["akt_num"], dtChild.Columns["akt_num"]);
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(0): " + ex.Message);
                    return;
                }
                oConn1.Close();

                grdXidmet.DataSource = dtAkt; //sourceDataSet.Tables[0];

                grdXidmet.ForceInitialize();
                grdXidmet.LevelTree.Nodes.Add("AKTın_sətirləri", grdvwXidmet);

                grdvwXidmet.Appearance.HeaderPanel.Options.UseTextOptions = true;
                grdvwXidmet.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grdvwXidmet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grdvwXidmet.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                grdvwXidmet.OptionsBehavior.Editable = false;

                //Griddə düymələr
                grdXidmet.UseEmbeddedNavigator = true;
                grdXidmet.EmbeddedNavigator.Buttons.Edit.Visible = false;
                grdXidmet.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                grdXidmet.EmbeddedNavigator.Buttons.Append.Visible = false;
                grdXidmet.EmbeddedNavigator.Buttons.Remove.Visible = false;
                grdXidmet.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                grdXidmet.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən ";

                grdXidmet.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
                grdXidmet.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
                grdXidmet.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

                grdXidmet.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
                grdXidmet.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
                grdXidmet.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";
                //
                //
                //grdvwXidmet.OptionsBehavior.Editable = true;// false;
                //****
                grdvwXidmet.OptionsView.ShowAutoFilterRow = true; // axtarış sətrini gizlət
                //****
                grdvwXidmet.BestFitColumns();

                grdvwXidmet.Columns["KODU"].Caption = "Abonent kodu";
                grdvwXidmet.Columns["KODU"].Visible = false;
                grdvwXidmet.Columns["AKT_NUM"].Caption = "Akt №";
                grdvwXidmet.Columns["AKT_DATA"].Caption = "Aktın tarixi";

                //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
                //grdvwXidmet.Columns["INSPEKTORN"].OptionsColumn.AllowEdit = true;
                //grdvwXidmet.Columns["AKT_NUM"].OptionsColumn.ReadOnly = false;

                //FocusFirstRecordInGroupRow("0274889");
//*********
            }

            using (OleDbConnection oConn1 = new OleDbConnection())      // dataGridView2 - doldurmaq
            {
                p_var.n_rez = my_metod_0(txtbxSubscriberNo.Text, p_var.n_textbox+p_var.n_uzer_name, "I"); //есть ли аппарат или нет
                if (p_var.n_rez == "E")
                {
                    return;
                }
                
                p_var.n_string = "";
                DataTable dtAkt1 = new DataTable();

                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    //MessageBox.Show("p_var.n_obj=" + p_var.n_obj + "/" + txtbxSubscriberNo.Text.Trim());

                    switch (p_var.n_obj)
                    {
                        case "A":
                            oCmd1.CommandText = @"select subid, apparat_id,azqaz.tex_bax_cihaz_name(apparat_id,'A') name,plomb_num,
                                                 say_id,azqaz.fio_A(subid) fio,azqaz.RAY_N_a(subid)||','||azqaz.unvan_A(subid) unvan,azqaz.meter_nom_a(subid,1) kscet, 
                                                 azqaz.METER_NaM_a(azqaz.METER_idN_a(subid,1)) Tip_name,azqaz.METER_idN_a(subid,1) Tip_KOD,plomb_date,akt_num,
cast(AHALI.PACK_SUBSCRIBER.GET_NUMBER_FROM_VSTRING
(AHALI.pack_subscriber.abone_string(trim(subid),to_date('19900101','YYYYMMDD'),
TRUNC(CURRENT_DATE)),'TDB') as number(12,2)) BORC,azqaz.plomb_a(subid) plomb,DATA_Ascet(subid,1) datascet 
                                                 from azqaz.tex_bax_apparats where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "'";
                            break;
                        case "S":
                            oCmd1.CommandText = @"select subid, apparat_id,azqaz.tex_bax_cihaz_name(apparat_id,'S') name,plomb_num,
                                                 say_id,azqaz.fio_S(subid) fio,azqaz.RAY_N_s(subid)||','||azqaz.unvan_s(subid) unvan,azqaz.meter_nom_s(subid,1) kscet, 
                                                 azqaz.METER_NaM_s(azqaz.meTER_idN_s(subid,1)) Tip_name,azqaz.METER_idN_s(subid,1) Tip_KOD,plomb_date,akt_num,
cast(qAHALI.PACK_SUBSCRIBER.GET_NUMBER_FROM_VSTRING
(qAHALI.pack_subscriber.abone_string(trim(subid),to_date('19900101','YYYYMMDD'),
TRUNC(CURRENT_DATE)),'TDB') as number(12,2)) BORC,azqaz.plomb_s(subid) plomb,DATA_Sscet(subid,1) datascet,
kp_s(subid) KP,tip_s(subid) TIP      
                                                 from azqaz.tex_bax_apparats where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "'";
                            break;
                        case "I":
                            oCmd1.CommandText = @"select subid, apparat_id,azqaz.tex_bax_cihaz_name(apparat_id,'I') name,plomb_num,
                                                 say_id,azqaz.fio_i(subid) fio,azqaz.RAY_N_i(subid)||','||azqaz.unvan_i(subid) unvan,azqaz.meter_nom_i(subid,1) kscet, 
                                                 azqaz.METER_NaM_i(azqaz.meTER_idN_i(subid,1)) Tip_name,azqaz.METER_idN_i(subid,1) Tip_KOD,plomb_date,akt_num,
cast(istixana.PACK_SUBSCRIBER.GET_NUMBER_FROM_VSTRING
(istixana.pack_subscriber.abone_string(trim(subid),to_date('19900101','YYYYMMDD'),
TRUNC(CURRENT_DATE)),'TDB') as number(12,2)) BORC,azqaz.plomb_i(subid) plomb,DATA_Iscet(subid,1) datascet 
                                                 from azqaz.tex_bax_apparats where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "'";
                            break;
                    }

                    dtAkt1.Load(oCmd1.ExecuteReader());
                    dtAkt1.Columns.Add("SN", typeof(Int32)).SetOrdinal(0);

                    if (dtAkt1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtAkt1.Rows.Count; i++)
                        {
                            textBox2.Text = dtAkt1.Rows[i]["FIO"].ToString();
                            p_var.n_fio   = dtAkt1.Rows[i]["FIO"].ToString();
                            textBox3.Text = dtAkt1.Rows[i]["UNVAN"].ToString();
                            p_var.n_unvan = dtAkt1.Rows[i]["UNVAN"].ToString();
                            textBox4.Text = dtAkt1.Rows[i]["KSCET"].ToString().Trim();
                            textBox13.Text= dtAkt1.Rows[i]["BORC"].ToString().Trim();
                            textBox15.Text= dtAkt1.Rows[i]["PLOMB"].ToString().Trim();
                            label23.Text = (p_var.n_obj == "S") ?"Kp: "+dtAkt1.Rows[i]["KP"].ToString().Trim() : "";
                            label24.Text = (p_var.n_obj == "S") ?"Tip:"+dtAkt1.Rows[i]["TIP"].ToString().Trim() : "";

                            label22.Text  = "Qur.tarixi:"+dtAkt1.Rows[i]["DATASCET"].ToString().Trim().Substring(0,10);
                            label18.Text  = (textBox4.Text.Length < 6) ? "GPG" : "GPG" + textBox4.Text.Substring(0, 2) + textBox4.Text.Substring(textBox4.Text.Length - 6);
                            //label18.Text  = "GPG"+textBox4.Text.Substring(0,2)+textBox4.Text.Substring(textBox4.Text.Length-6);
                            p_var.n_kset    = textBox4.Text;
                            p_var.n_gpg     = label18.Text;
                            p_var.n_plomb   = textBox15.Text;
                            p_var.n_datascet= label22.Text;
                            textBox1.Text = dtAkt1.Rows[i]["TIP_NAME"].ToString().Trim() + "(Id:" + dtAkt1.Rows[i]["TIP_KOD"].ToString().Trim()+")";
                            dtAkt1.Rows[i]["SN"] = i + 1; //Sətirlərin nömrələnməsi
                            p_var.n_string = p_var.n_string + ":" + dtAkt1.Rows[i]["APPARAT_ID"].ToString().Trim();
                        }
                    }
                    textBox13.Font = new Font(textBox13.Font, FontStyle.Bold);//жирный
                    textBox13.ForeColor = (textBox13.Text.IndexOf('-') == -1) ? Color.Black : Color.Red;
                    p_var.n_string = p_var.n_string + ":";
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(-1*): " + ex.Message);
                    return;
                }
                oConn1.Close();

                gridControl1.DataSource = dtAkt1;
                gridControl1.ForceInitialize();

                if (dtAkt1.Rows.Count > 0)
                {
                    gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
                    gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.OptionsBehavior.Editable = false;

                    gridView1.OptionsView.ShowAutoFilterRow = false; // axtarış sətrini gizlət

                    gridView1.BestFitColumns();

                    //Griddə düymələr
                    gridControl1.UseEmbeddedNavigator = true;
                    gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    gridControl1.EmbeddedNavigator.TextStringFormat = "Sətir sayı {1}";

                    gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;

                    gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
                    gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;

                    gridView1.Columns["SUBID"].Visible = false;
                    gridView1.Columns["FIO"].Visible = false;
                    gridView1.Columns["UNVAN"].Visible = false;
                    gridView1.Columns["KSCET"].Visible = false;
                    gridView1.Columns["TIP_NAME"].Visible = false;
                    gridView1.Columns["TIP_KOD"].Visible = false;
                    gridView1.Columns["SN"].Caption = " № ";
                    gridView1.Columns["SN"].Width = 35;
                    gridView1.Columns["APPARAT_ID"].Caption = "Cihazın kodu";
                    gridView1.Columns["NAME"].Caption = "Cihazın adı";
                    gridView1.Columns["NAME"].Width = 300;
                    gridView1.Columns["PLOMB_NUM"].Caption = "Plomb №";
                    gridView1.Columns["PLOMB_NUM"].Width = 100;
                    gridView1.Columns["PLOMB_DATE"].Caption = "Tarix";
                    gridView1.Columns["AKT_NUM"].Caption = "Akt №";

                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";

                    gridControl1.Enabled = false;                   
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    grdXidmet.Enabled = true;

                    p_var.n_subid = txtbxSubscriberNo.Text; //****************

                    //if (p_var.n_rol != "1")
                    //{
                        if (p_var.n_uzer_name.Substring(0,1)!="N" && p_var.n_uzer_name.Substring(0,1)!="b")
                        {
                            button2.Enabled = true; //Akt və ya Cihaz əlavəsi düyməsi
                            button3.Enabled = true; //Akt və ya Cihaz dəyişmə düyməsi
                            button4.Enabled = true; //Akt və ya Cihaz silimnmə düyməsi
                            button12.Visible = true; //Müqavilə
                            button18.Visible = true; //Vəsiqə
                            button22.Visible = true; //Bağlı sayğac
                        }
                        else
                        {
                            //button24.Visible = false;
                            //button24.Enabled = true; 
                            //MÜQAVİLLƏR burdan giriş
                            p_var.n_rez = my_metod_Ferid(txtbxSubscriberNo.Text); //Ferid_Müqavile
                        }
                    //}
                }
                else
                {
                    switch (p_var.n_obj)
                    {
                        case "A":
                            //merlin.Speak("Bu Əhali obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            MessageBox.Show("Bu Əhali obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...","");
                            break;
                        case "S":
                            //merlin.Speak("Bu Sənaye obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            MessageBox.Show("Bu Sənaye obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            break;
                        case "I":
                            //merlin.Speak("Bu Istixana obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            MessageBox.Show("Bu Istixana obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            break;
                    }
                    //merlin.Speak("Bu obyekt:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                    grdXidmet.Enabled = false;
                    
                    button2.Enabled = false; //Akt və ya Cihaz əlavəsi düyməsi
                    button3.Enabled = false; //Akt və ya Cihaz dəyişmə düyməsi
                    button4.Enabled = false; //Akt və ya Cihaz silimnmə düyməsi
                    button12.Visible = false;
                    button18.Visible = false;
                    button22.Visible = false;
                    //button24.Visible = false;

                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    return;
                }

                p_var.n_rez = my_metod_0(txtbxSubscriberNo.Text, p_var.n_textbox+p_var.n_uzer_name, "D"); //аппарат удалить
                if (p_var.n_rez == "E")
                {
                    return;
                }

            }
        }

        public string my_metod_1(string v_subid, string v_akt_num, string s3, string s4, string s5, 
               string s6, string s7, string s8,string s9,string s10, string user,string s11,string s12) //Aktlar Insert,Update,Delete
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "azqaz.tex_bax_Akt_iud";     // Name_function
            
            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_subid", OracleType.VarChar);
            cmd.Parameters["v_subid"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_subid"].Value = v_subid; // Abonentin kodu

            cmd.Parameters.Add("v_akt_num", OracleType.VarChar);
            cmd.Parameters["v_akt_num"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_num"].Value = v_akt_num; // aktin nomresi

            cmd.Parameters.Add("v_deffect_id", OracleType.VarChar);
            cmd.Parameters["v_deffect_id"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_deffect_id"].Value = s3; // qusurun kodu

            cmd.Parameters.Add("v_inspektor_id", OracleType.VarChar);
            cmd.Parameters["v_inspektor_id"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_inspektor_id"].Value = s4; // nezaretci kodu

            cmd.Parameters.Add("v_akt_data", OracleType.VarChar);
            cmd.Parameters["v_akt_data"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_data"].Value = s5; // akt tarixi

            cmd.Parameters.Add("v_istehlakci", OracleType.VarChar);
            cmd.Parameters["v_istehlakci"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_istehlakci"].Value = s6; // istehlakci

            cmd.Parameters.Add("v_qeyd", OracleType.VarChar);
            cmd.Parameters["v_qeyd"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_qeyd"].Value = s7; // qeyd

            cmd.Parameters.Add("v_priz", OracleType.VarChar);
            cmd.Parameters["v_priz"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_priz"].Value = s8; // İşarə I-insert,U-update,d-delete

            cmd.Parameters.Add("v_akt_id", OracleType.VarChar);
            cmd.Parameters["v_akt_id"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_id"].Value = s9; // aktin identifikasya kodu

            cmd.Parameters.Add("v_akt_kscet", OracleType.VarChar);
            cmd.Parameters["v_akt_kscet"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_kscet"].Value = s10; // sayğac nömrəsi

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = user; // user_name

            cmd.Parameters.Add("v_songes", OracleType.VarChar);
            cmd.Parameters["v_songes"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_songes"].Value = s11; // user_name

            cmd.Parameters.Add("v_songese", OracleType.VarChar);
            cmd.Parameters["v_songese"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_songese"].Value = s12; // user_name

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(-2): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return ("Y");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            /*    MessageBox.Show(e.KeyCode.ToString());
                  int scan = (int)e.KeyCode;
                  MessageBox.Show(scan.ToString());
            */
//                MessageBox.Show(p_var.n_region);
               // txtbxSubscriberNo.Text.Trim().Substring(2, 2) + ".";
                //textBox2.Text = p_var.n_region.IndexOf(':');
//                int www=0;
//                www=p_var.n_region.IndexOf(txtbxSubscriberNo.Text.Trim().Substring(2, 2) + ".");
               
                comboBoxEdit1.Properties.Items.Insert(0, txtbxSubscriberNo.Text.Trim());
                btnSearch.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e) //Yeni sətr
        {
            if (txtbxSubscriberNo.Text.Trim() == "")
            {
                return;
            }
            if (label5.Text == " Aktlarda =>")
            {
               Aktadd.Text = "Aktlar:Yeni AKTın elave olunması ";
               p_var.n_subid = txtbxSubscriberNo.Text;
               p_var.n_int = "I";
               //Form_akt.ShowDialog();
               Aktadd.ShowDialog();

               if (p_var.n_rez == "Y")
               {   /*
                   if (Aktadd.comboBox_1.Properties.Items.GetCheckedValues().Count > 0)
                   {
                       for (int i = 0; i <= Aktadd.comboBox_1.Properties.Items.Count - 1; i++)
                       {
                           if (Aktadd.comboBox_1.Properties.Items[i].CheckState.ToString() == "Checked")
                           {

                               Aktadd.textBox3.Text = Aktadd.comboBox_1.Properties.Items[i].ToString().Substring(Aktadd.comboBox_1.Properties.Items[i].ToString().IndexOf(':') + 1, 4).Trim();
                               p_var.n_string = String.Format("{0:ddMMyyyy}", Aktadd.dT1.Text);
                               p_var.n_rez = my_metod_1(txtbxSubscriberNo.Text, Aktadd.textBox1.Text, Aktadd.textBox3.Text,
                                                        Aktadd.textBox7.Text, p_var.n_string, Aktadd.textBox5.Text,
                                                        Aktadd.textBox6.Text.Trim(), "I", Aktadd.textBox8.Text.Trim(),
               Aktadd.textBox9.Text.Trim(), p_var.n_uzer_name, Aktadd.textBox10.Text.Trim(),Aktadd.textBox11.Text.Trim());
                           }
                       }
                   } */

               }
            }
            else
            {
               Form_cihaz.comboBox1.Enabled = true;
               Form_cihaz.Text = "Cihazlar:Yeni CİHAZin elave olunması ";
               p_var.n_subid = txtbxSubscriberNo.Text;
               p_var.n_int = "I";
               p_var.n_data = "";

               Form_cihaz.ShowDialog();
               if (p_var.n_rez == "Y") //təsdiq halı
                {
                    p_var.n_string = (Form_cihaz.textBox3.Text.Trim() == "" ) ? "":String.Format("{0:ddMMyyyy}", Form_cihaz.dT1.Text);
                    p_var.n_rez = my_metod_2(txtbxSubscriberNo.Text, Form_cihaz.textBox1.Text, "0",
                                             Form_cihaz.textBox3.Text, "I", p_var.n_uzer_name, p_var.n_string); //Form_cihaz.textBox4.Text
                    if (p_var.n_rez == "Y")
                        {
//                         btnSearch.PerformClick();
                        }
                }
            }
       btnSearch.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e) //Sətr dəyiş
        {
            if (txtbxSubscriberNo.Text.Trim() == "")
            {
                return;
            }
            
            if (label5.Text == " Aktlarda =>")
            {
                if (Form_akt.textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Sətr seçilməyib !");
                    return;
                }
                Form_akt.Text = "Aktlar:Seçilmiş AKTda melumatın deyişdirilmesi";
                p_var.n_subid = txtbxSubscriberNo.Text;
                p_var.n_int = "U";
                Form_akt.comboBox1.Enabled = true;
                Form_akt.ShowDialog();

                if (p_var.n_rez == "Y")
                {
                    p_var.n_string = String.Format("{0:ddMMyyyy}", Form_akt.dT1.Text);

                    p_var.n_rez = my_metod_1(txtbxSubscriberNo.Text, Form_akt.textBox1.Text, Form_akt.textBox3.Text,
                                             Form_akt.textBox7.Text, p_var.n_string, Form_akt.textBox5.Text,
                                             Form_akt.textBox6.Text.Trim(), "U", Form_akt.textBox8.Text.Trim(),
                                             Form_akt.textBox9.Text.Trim(), p_var.n_uzer_name, Form_akt.textBox10.Text.Trim(),
                                             Form_akt.textBox11.Text.Trim());
                    if (p_var.n_rez == "Y")
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
            else
            {
                Form_cihaz.Text = "Cihazlar:Seçilmiş CİHAZda melumatın deyişdirilmesi";
                p_var.n_subid = txtbxSubscriberNo.Text;
                p_var.n_int = "U";
                p_var.n_data = "";
/*
//))))))))
     label5.Text = "Cihazlarda=>";
     Form_cihaz.textBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["APPARAT_ID"]).ToString();
     p_var.n_textbox = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["APPARAT_ID"]).ToString();            Form_cihaz.textBox2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NAME"]).ToString();      Form_cihaz.textBox3.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PLOMB_NUM"]).ToString();
  Form_cihaz.textBox4.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["SAY_ID"]).ToString(); ;//Sira N
    p_var.n_data = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PLOMB_DATE"]).ToString();//Plomb data
//))))))))
 */
                if (p_var.n_textbox.Trim() == "") 
                {
                    MessageBox.Show("Sətr seçilməyib !");
                    return;
                }
                Form_cihaz.ShowDialog();
                if (p_var.n_rez == "Y") //təsdiq halı
                {
                    p_var.n_string = (Form_cihaz.textBox3.Text.Trim() == "") ? "":String.Format("{0:ddMMyyyy}", Form_cihaz.dT1.Text);
                    p_var.n_rez = my_metod_2(txtbxSubscriberNo.Text, Form_cihaz.textBox1.Text, Form_cihaz.textBox4.Text,
                                             Form_cihaz.textBox3.Text, "U", p_var.n_uzer_name, p_var.n_string);
                    if (p_var.n_rez == "Y")
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //Sətr sil
        {
            if (txtbxSubscriberNo.Text.Trim() == "")
            {
                return;
            }            
            
            if (label5.Text == " Aktlarda =>")
            {
                if (Form_akt.textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Sətr seçilməyib !");
                    return;
                }
                Form_akt.Text = "Aktlar:Seçilmiş AKTın silinmesi";
                p_var.n_subid = txtbxSubscriberNo.Text;
                p_var.n_int = "D";
                Form_akt.ShowDialog();
                if (p_var.n_rez == "Y")
                {
                    p_var.n_string = String.Format("{0:ddMMyyyy}", Form_akt.dT1.Text);
                    p_var.n_rez = my_metod_1(txtbxSubscriberNo.Text, Form_akt.textBox1.Text, Form_akt.textBox3.Text,
                                             Form_akt.textBox7.Text, p_var.n_string, Form_akt.textBox5.Text,
                                             Form_akt.textBox6.Text.Trim(), "D", Form_akt.textBox8.Text.Trim(),
                                             Form_akt.textBox9.Text.Trim(), p_var.n_uzer_name, Form_akt.textBox10.Text.Trim(),
                                             Form_akt.textBox11.Text.Trim());
                    if (p_var.n_rez == "Y")
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
            else
            {
                Form_cihaz.Text = "Cihazlar:Seçilmiş CİHAZin silinmesi";
                p_var.n_subid = txtbxSubscriberNo.Text;
                p_var.n_int = "D";
                p_var.n_data = "";
                if (p_var.n_textbox.Trim() == "")
                {
                    MessageBox.Show("Sətr seçilməyib !");
                    return;
                }
                Form_cihaz.ShowDialog();
                if (p_var.n_rez == "Y") //təsdiq halı
                {
                  p_var.n_string = (Form_cihaz.textBox3.Text.Trim() == "") ? String.Format("{0:ddMMyyyy}", Form_cihaz.dT1.Text) : "";
                    p_var.n_rez = my_metod_2(txtbxSubscriberNo.Text, Form_cihaz.textBox1.Text, Form_cihaz.textBox4.Text,
                                             Form_cihaz.textBox3.Text, "D", p_var.n_uzer_name, p_var.n_string);
                    if (p_var.n_rez == "Y")
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
        }

        private void txtbxSubscriberNo_TextChanged(object sender, EventArgs e)
        {
           // dataGridView1.Rows.Clear();
           // dataGridView2.Rows.Clear();   // очистить Grid
            checkBox1.Checked = false;
            label2.Text = "";
            label6.Text = "";
            label18.Text = "";
            label22.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            label23.Text = label24.Text = "";
            
            p_var.n_kset ="";
            p_var.n_gpg = "";
            p_var.n_plomb = "";
            button12.Visible = false;
            button18.Visible = false;
            button22.Visible = false;
           // button24.Visible = false; 
            //button2.Enabled = false;
            //button3.Enabled = false;
            //button4.Enabled = false;
          //////////// Form.ActiveForm.Refresh();
        }

        public string my_metod_2(string s1, string s2, string s3, string s4, string s5,string user,string s6)
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "azqaz.tex_bax_cihaz_iud";     // Name_function

            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_subid", OracleType.VarChar);
            cmd.Parameters["v_subid"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_subid"].Value = s1; // abonentin_kodu

            cmd.Parameters.Add("v_apparat_id", OracleType.VarChar);
            cmd.Parameters["v_apparat_id"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_apparat_id"].Value = s2; // cihazın kodu

            cmd.Parameters.Add("v_say_id", OracleType.VarChar);
            cmd.Parameters["v_say_id"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_say_id"].Value = s3; // cihazin sira nömrəsi

            cmd.Parameters.Add("v_plomb_num", OracleType.VarChar);
            cmd.Parameters["v_plomb_num"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_plomb_num"].Value = s4; // plomb nömrəsi

            cmd.Parameters.Add("v_priz", OracleType.VarChar);
            cmd.Parameters["v_priz"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_priz"].Value = s5; // əlamət (i-insert,u-update,d-delete)

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = user; // proqram istifadəçisinin kodu

            cmd.Parameters.Add("v_plomb_date", OracleType.VarChar);
            cmd.Parameters["v_plomb_date"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_plomb_date"].Value = s6; // plomb tarixi

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(-3): " + ex.Message);
                return ("E");
            }

            conn.Close();
            return ("Y");
        }
        public void my_metod_3(string s1,string s2)                     //s1-Selectin şərti və s2-ya "S"-baxış,ya "D"-silmə
        {
            using (OleDbConnection oConn1 = new OleDbConnection())      // DEV_dataGridView5 - doldurmaq
           {
               SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
               SplashScreenManager.Default.SetWaitFormCaption("(AKTlar)Bir qədər gözləyin,");
               SplashScreenManager.Default.SetWaitFormDescription("məlumat yüklənir...");                
                
                DataTable resultTable1 = new DataTable();
                resultTable1.Clear();
                gridControl2.DataSource = null;

                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    if (s2 == "S")                  //Sətirlərin gətrilməsi SELECT TEX_BAX_Inspektor_name
                    {
                        oCmd1.CommandText = @"select akt_number, sign, date_operation, azqaz.Region_n(subjectid) Reg , 
                        azqaz.Rayon_n(matrixid) Ray, note,azqaz.tex_bax_INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_NAME,doc_number, doc_date,
                        akt_id,subjectid, matrixid,object_name from azqaz.tex_bax_akt_base where " + s1;

                        p_var.n_chap_ucun_akt = oCmd1.CommandText;

                        resultTable1.Load(oCmd1.ExecuteReader());
                    }
                    if (s2 == "D")                 //Sətirlərin serverdən silinməsi DELETE
                    {
                        oCmd1.CommandText = @"delete from azqaz.tex_bax_akt_base where " + s1;
                        my_metod_del_akt(oCmd1.CommandText,p_var.n_uzer_name);
                    }
//                    resultTable1.Load(oCmd1.ExecuteReader());
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(-4): " + ex.Message);
                    SplashScreenManager.CloseForm(false);
                    return;
                }
                oConn1.Close();

                resultTable1.Columns.Add("SN", typeof(Int32)).SetOrdinal(0); // Sıra nömrəsinin əlavə edilməsi

                if (resultTable1.Rows.Count > 0)
                {
                    for (int i = 0; i < resultTable1.Rows.Count; i++)
                    {
                        resultTable1.Rows[i]["SN"] = i + 1; //Sətirlərin nömrələnməsi
                    } 
                }

                gridControl2.DataSource = null;
                gridControl2.DataSource = resultTable1;
                gridControl2.ForceInitialize();

                //Griddə düymələr
                gridControl2.UseEmbeddedNavigator = true;
                gridControl2.EmbeddedNavigator.Buttons.Edit.Visible = false;
                gridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                gridControl2.EmbeddedNavigator.Buttons.Append.Visible = false;
                gridControl2.EmbeddedNavigator.Buttons.Remove.Visible = false;
                gridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                gridControl2.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən";

                gridControl2.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
                gridControl2.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
                gridControl2.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

                gridControl2.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
                gridControl2.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
                gridControl2.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";
                //
                
                gridView2.RefreshData();

                if (resultTable1.Rows.Count > 0)
                   {
                       gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
                       gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                       gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                       gridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                       //gridView2.OptionsBehavior.Editable = false;

                       gridView2.OptionsBehavior.Editable = true; // false;

                       gridView2.BestFitColumns();
                    
                    // gridView2.Columns["AKT_NUMBER"].Visible = false;
                       gridView2.Columns["SN"].Caption = " № ";
                       gridView2.Columns["SN"].Width = 35;
                       gridView2.Columns["SN"].ToolTip = "Sətrin sıra nömrəsi";
                    gridView2.Columns["SN"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["AKT_NUMBER"].Caption = "Аkt  №";
                       gridView2.Columns["AKT_NUMBER"].Width = 70;
                    gridView2.Columns["AKT_NUMBER"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["SIGN"].Caption = "Status";
                       gridView2.Columns["SIGN"].Width = 50;
                    gridView2.Columns["SIGN"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["REG"].Caption = "Region";
                       gridView2.Columns["REG"].Width = 55;
                    gridView2.Columns["REG"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["RAY"].Caption  = "Rayon";
                       gridView2.Columns["RAY"].Width = 55;
                    gridView2.Columns["RAY"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["DATE_OPERATION"].Caption = "Əməliyyat tarixi";
                       gridView2.Columns["DATE_OPERATION"].Width = 110;
                    gridView2.Columns["DATE_OPERATION"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["NOTE"].Caption = "Qeyd";
                       gridView2.Columns["NOTE"].Width = 250;
                    gridView2.Columns["NOTE"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["INSPEKTOR_NAME"].Caption = "Mühəndis";
                    gridView2.Columns["INSPEKTOR_NAME"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["OBJECT_NAME"].Caption = "Obyekt";
                    gridView2.Columns["OBJECT_NAME"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["DOC_NUMBER"].Visible = false;
                       gridView2.Columns["DOC_DATE"].Visible = false;
                       gridView2.Columns["SUBJECTID"].Visible = false;
                       gridView2.Columns["MATRIXID"].Visible = false;
                    gridView2.Columns["AKT_ID"].OptionsColumn.ReadOnly = true;
                       gridView2.Columns["AKT_ID"].Visible = true;

                       gridView2.RefreshData();
                       //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                       //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";                  
                       SplashScreenManager.CloseForm(false);
                   }
            }

        }
        private void tabPage1_Enter(object sender, EventArgs e)   //Məlimatın ilkin yüklənməsi
        {
          p_var.n_string = " rownum <= 300"; // " akt_id >= 000 and akt_id <= 300 ";
          my_metod_3(p_var.n_string,"S");
        }

        private void tabPage3_Enter(object sender, EventArgs e) //Hesabatlar
        {
            TreeNode node;
            treeView1.Nodes.Clear();

            if (p_var.n_uzer_name.Substring(0, 1) != "N" && p_var.n_uzer_name.Substring(0, 1) != "b")//(p_var.n_uzer_name.Substring(0, 1) != "N")
            {
                node = treeView1.Nodes.Add("1. AKTlara aid hesabatlar");
                node.Nodes.Add("1.1 Yazılmış AKTlar haqqında məlumat(Forma № 1)");
                node.Nodes.Add("1.2 Seçilmiş vaxt intervalında təkrar baxış keçirilmiş obyektlər(Forma № 4)");
                node.Nodes.Add("1.3 Generasiya edilmiş AKTlar haqqında məlumat(Forma № 5)");
                node.Nodes.Add("1.4 Hesabat");
                node.Nodes.Add("1.5 Yazılmış AKTlar haqqında məlumat,sayğac məlumatları ile(Forma № 8)");
                if (p_var.n_rol == "3" || p_var.n_rol == "4") //Admin ve SuberAdmin baxa biler
                {
                    node.Nodes.Add("1.6 Texniki baxış aparmış mühendislerin aylıq yekun melumatı(Forma № 12)");
                }
                //node.Nodes.Add("1.6 Qüsurlar haqqinda yekun məlumat(Forma № 9)");
                //node.Nodes.Add("1.7 Cihazlar haqqinda yekun məlumat(Forma № 10)");
                node.Expand();
                node = treeView1.Nodes.Add("2. PLOMBlara aid hesabatları");
                //            if (p_var.n_uzer_name == "k229000002")
                //            {
                node.Nodes.Add("2.1 PLOMBlar və CİHAZlar haqqında yekun məlimat(Forma № 10)");
                node.Nodes.Add("2.2 PLOMB işlənmiş AKTlar haqqında məlimat(Forma № 11)");
                //            }
                node.Nodes.Add("2.3 Generasiya edilmiş PLOMBlar haqqında məlumat(Forma № 6)");
                //      node.Nodes.Add("2.4 Hesabat");
                //      node.Nodes.Add("2.5 Hesabat");
                //      node.Nodes.Add("2.6 Hesabat");

                node = treeView1.Nodes.Add("3. Mühəndislər");
                node.Nodes.Add("3.1 Mühəndislərin siyahısı(Forma № 2)");
                if (p_var.n_rol == "3" || p_var.n_rol == "4")
                {
                    node.Nodes.Add("3.2 Mühəndisin hesabatı(Forma № 7)");
                }
                node = treeView1.Nodes.Add("4. Qüsurlar");
                node.Nodes.Add("4.1 Qüsurların siyahısı(Forma № 3)");
                node.Nodes.Add("4.2 Qüsurlar haqqinda yekun məlumat(Forma № 9)");

                node = treeView1.Nodes.Add("5. MÜQAVİLƏlər");
                node.Nodes.Add("5.1 Müqavilələr haqqında məlimat(Forma № 13)");

                node = treeView1.Nodes.Add("6. Abonentlər");
                node.Nodes.Add("6.1 Abonentlər haqqında məlimat(Forma № 14)");
            }
            else
            {
                node = treeView1.Nodes.Add("1.Müqavilələrin hesabatı");
                node.Nodes.Add("1.1  Müqavilə bağlanmış abonentlər");
                node.Nodes.Add("1.2  Mühəndislərin hesabatı");
                node.Nodes.Add("1.3  Müqaviləsi olmayan abonentlər");
                node.Nodes.Add("1.4  Müqaviləli və müqaviləsiz abonentlər haqqında yekun məlumat");
                node.Nodes.Add("1.5  Problemli abonentlər haqqında məlumat");
                node.Nodes.Add("1.6  Boş xanaların doldurulması");
                node.Nodes.Add("1.7  Müqaviləli və sayğacı bloklaşdırılmış abonentlərin siyahısı");
                node.Nodes.Add("1.8  Müqavilesi bitmiş abonentler haqqında melumat(Sənaye)");
                node.Nodes.Add("1.9  Müqavilesiz abonentler haqqında melumat(Sənaye)");
                node.Nodes.Add("1.10 Blokda olan abonentler haqqında melumat(Sənaye)");
                node.Nodes.Add("1.11 Ehaliden keçen abonentler haqqında melumat(Senaye)");
                node.Nodes.Add("1.12 Bütün obyektlər(Senaye)");

                node.Expand();
                /*
                if (p_var.n_rol == "3" || p_var.n_rol == "4") //Admin ve SuberAdmin baxa biler
                {
                    node.Nodes.Add("1.6 Hesabat");
                }
                //node.Nodes.Add("1.6 Qüsurlar haqqinda yekun məlumat(Forma № 9)");
                //node.Nodes.Add("1.7 Cihazlar haqqinda yekun məlumat(Forma № 10)");
                node.Expand();
                node = treeView1.Nodes.Add("2. Hesabat");
                //            if (p_var.n_uzer_name == "k229000002")
                //            {
                node.Nodes.Add("2.1 Hesabat");
                node.Nodes.Add("2.2 Hesabat");
                //            }
                node.Nodes.Add("2.3 Hesabat");
                //      node.Nodes.Add("2.4 Hesabat");
                //      node.Nodes.Add("2.5 Hesabat");
                //      node.Nodes.Add("2.6 Hesabat");

                node = treeView1.Nodes.Add("3.Hesabat");
                node.Nodes.Add("3.1 Hesabat");
                if (p_var.n_rol == "3" || p_var.n_rol == "4")
                {
                    node.Nodes.Add("3.2 Hesabat");
                }
                node = treeView1.Nodes.Add("4. Hesabat");
                node.Nodes.Add("4.1 Hesabat");
                node.Nodes.Add("4.2 Hesabat");

                node = treeView1.Nodes.Add("5. Hesabat");
                node.Nodes.Add("5.1 Hesabat");

                node = treeView1.Nodes.Add("6. Hesabat");
                node.Nodes.Add("6.1 Hesabat");
                */
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (p_var.n_uzer_name.Substring(0, 1) == "N" || p_var.n_uzer_name.Substring(0, 1) == "b")
            {
                switch (e.Node.Text.Substring(0, 4).Trim())
                {
                 case "1.1":
                         Forma_N1_F.Text = "Müqavile bağlanmış abonentler(Forma № 1)";
                         Forma_N1_F.ShowDialog();
                         if (p_var.n_rez == "N" && p_var.n_subid != "") 
                         {
                            tabControl1.SelectTab(0); //TabControlda I punkta keçid
//                            this.Activate();
                            txtbxSubscriberNo.Text = p_var.n_subid;
//                           txtbxSubscriberNo.Select();
                            //btnSearch.Select();
//                            txtbxSubscriberNo.Focus();
                            //Keyboard.Focus(txtbxSubscriberNo);
//                            SendKeys.Send("{END}");
//                            btnSearch.PerformClick();
//                            SendKeys.Send("{ENTER}");
                         }
                     
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMA_DOQ_3.frx");
                        report1.SetParameterValue("Forma_N", "Forma № 1");

                        if (p_var.n_son.Trim() == "")
                        {
                            report1.SetParameterValue("Doq", "");
                        }

                        if (p_var.n_string.IndexOf("AKT_DATA") != -1) //Tarix
                        {
                            report1.SetParameterValue("dT1", "Aralıq:[" + Forma_N1_F.dT1.Text.Trim() + ",");
                            report1.SetParameterValue("dT2", Forma_N1_F.dT2.Text + "]");
                        }
                        else
                        {
                            report1.SetParameterValue("dT1", "");
                            report1.SetParameterValue("dT2", "");
                        }

                        if (p_var.n_string.IndexOf("INSPEKTOR_ID") != -1) //Mühəndis
                        {
                            report1.SetParameterValue("Muh", "Mühəndis:" + Forma_N1_F.comboBox2.Text.Substring(0, Forma_N1_F.comboBox2.Text.IndexOf(':')).Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Muh", "");
                        }

                        if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                        {
                            report1.SetParameterValue("Ray", "Rayon:" + Forma_N1_F.comboBox1.Text.Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Ray", "");
                        }

                        TableDataSource table11 = report1.GetDataSource("T") as TableDataSource;

                        p_var.n_string = p_var.n_string.Replace("AKT_DATA", "doq_data");

                        p_var.n_string = p_var.n_string.Replace("INSPEKTOR_ID", "USER_NAME");

                        table11.SelectCommand = @"SELECT 
CASE
  WHEN object_name='A' THEN AZQAZ.ray_n_a(SUBID)
  WHEN Object_name='S' THEN AZQAZ.ray_n_s(SUBID)
  WHEN Object_name='I' THEN AZQAZ.ray_n_i(SUBID)
END rayon,
CASE
  WHEN object_name='A' THEN azqaz.nezaretci_a(subid)
  WHEN Object_name='S' THEN azqaz.nezaretci_a(subid)
  WHEN Object_name='I' THEN azqaz.nezaretci_a(subid)
END  Nezaretci,subid kod,
CASE
  WHEN object_name='A' THEN AZQAZ.fio_a(SUBID)
  WHEN Object_name='S' THEN AZQAZ.fio_s(SUBID)
  WHEN Object_name='I' THEN AZQAZ.fio_i(SUBID)
END fio,
CASE
  WHEN object_name='A' THEN azqaz.status_a(subid)
  WHEN Object_name='S' THEN azqaz.status_s(subid)
  WHEN Object_name='I' THEN azqaz.status_i(subid)
END status,
CASE
  WHEN object_name='A' THEN azqaz.sahe_a(subid)
  WHEN Object_name='S' THEN '' /*azqaz.sahe_s(subid)*/
  WHEN Object_name='I' THEN '' /*azqaz.sahe_i(subid)*/
END sahe,
CASE
  WHEN object_name='A' THEN azqaz.unvan_a(subid)
  WHEN Object_name='S' THEN azqaz.unvan_s(subid)
  WHEN Object_name='I' THEN azqaz.unvan_i(subid)
END adres,
CASE
  WHEN object_name='A' THEN azqaz.meter_nam_a(azqaz.meter_idn_a(subid,1))
  WHEN Object_name='S' THEN azqaz.meter_nam_s(azqaz.meter_idn_s(subid,1))
  WHEN Object_name='I' THEN azqaz.meter_nam_i(azqaz.meter_idn_i(subid,1))
END saygac_marka,
CASE
  WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
  WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
  WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1)
END saygac_nomre,
/*
CASE
  WHEN object_name='A' THEN azqaz.reg_subid_a(subid)
  WHEN Object_name='S' THEN azqaz.reg_subid_s(subid)
  WHEN Object_name='I' THEN azqaz.reg_subid_i(subid)
END reg_date,
*/
CASE
  WHEN object_name='A' THEN azqaz.ev_tipi_n(subid)
  WHEN Object_name='S' THEN ''
  WHEN Object_name='I' THEN ''
END menzil_tipi,doq_data, doq_num , qeyd||'('||user_name||')' qeyd, doq_data_b FROM azqaz.tex_bax_doq_f where " + p_var.n_string + "  order by subid,doq_data ";
                        table11.Connection.ConnectionString = p_var.n_conn;
                        report1.Show();
                     }
                         break;
                    case "1.2":
                         Forma_N2_F.Text = "Mühendisin hesabatı(Forma № 2)";
                         Forma_N2_F.ShowDialog();
                         if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN7_F.frx");
                        report1.SetParameterValue("dT1", Forma_N2_F.dT1.Text);
                        report1.SetParameterValue("dT2", Forma_N2_F.dT2.Text);
                        report1.SetParameterValue("Muh", Forma_N2_F.comboBox2.Text.Substring(0, Forma_N2_F.comboBox2.Text.IndexOf('_')).Trim());
                        TableDataSource table7 = report1.GetDataSource("TEX_BAX_AKTS") as TableDataSource;
                        table7.SelectCommand = @"select subid,doq_num akt_num,doq_data akt_data,doq_data_b akt_data_b,oper_date, 
CASE
  WHEN object_name='A' THEN '(A) '||AZQAZ.UNVAN_A(SUBID)
  WHEN Object_name='S' THEN '(S) '||AZQAZ.UNVAN_S(SUBID)
  WHEN Object_name='I' THEN '(I) '||AZQAZ.UNVAN_I(SUBID)
END UNVAN,
CASE
  WHEN object_name='A' THEN azqaz.fio_A(subid)
  WHEN Object_name='S' THEN azqaz.fio_S(subid)
  WHEN Object_name='I' THEN azqaz.fio_I(subid)
END FIO,
CASE
  WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
  WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
  WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1) 
END KSCET,
CASE
  WHEN object_name='A' THEN trim(METER_NaM_a(METER_idN_a(subid,1)))||':'||azqaz.METER_idN_a(subid,1)
  WHEN Object_name='S' THEN trim(METER_NaM_s(METER_idN_s(subid,1)))||':'||azqaz.METER_idN_s(subid,1)
  WHEN Object_name='I' THEN trim(METER_NaM_i(METER_idN_i(subid,1)))||':'||azqaz.METER_idN_i(subid,1)
END TIP,qeyd from azqaz.tex_bax_doq_f where " + p_var.n_string + "  order by subid,AKT_DATA ";
                         table7.Connection.ConnectionString = p_var.n_conn;
                         report1.Show();
                     }
                         break;
                    case "1.3":
                         string n_obj="";
                         Forma_N3_F.Text = "Müqavilesi olmayan abonentler(Forma № 2)";
                         Forma_N3_F.ShowDialog();
                         if (p_var.n_rez == "Y")
                         {
                             report1.Load("FORMA_DOQ_2.frx");
                             report1.SetParameterValue("Forma_N", "Forma № 2");

                             TableDataSource table11 = report1.GetDataSource("T") as TableDataSource;

                             switch (p_var.n_obj)
                             {
                                 case "A":
                                       n_obj = "ahali.submeter";
                                       break;
                                 case "S":
                                       n_obj = "qahali.submeter";
                                       break;
                                 case "I":
                                       n_obj = "istixana.submeter";
                                       break;
                             }

                             table11.SelectCommand = @"SELECT 
CASE
  WHEN object_name='A' THEN AZQAZ.ray_n_a(SUBID)
  WHEN Object_name='S' THEN AZQAZ.ray_n_s(SUBID)
  WHEN Object_name='I' THEN AZQAZ.ray_n_i(SUBID)
END rayon,
CASE
  WHEN object_name='A' THEN azqaz.nezaretci_a(subid)
  WHEN Object_name='S' THEN azqaz.nezaretci_s(subid)
  WHEN Object_name='I' THEN azqaz.nezaretci_i(subid)
END  Nezaretci,subid kod,
CASE
  WHEN object_name='A' THEN AZQAZ.fio_a(SUBID)
  WHEN Object_name='S' THEN AZQAZ.fio_s(SUBID)
  WHEN Object_name='I' THEN AZQAZ.fio_i(SUBID)
END fio,
CASE
  WHEN object_name='A' THEN azqaz.status_a(subid)
  WHEN Object_name='S' THEN azqaz.status_s(subid)
  WHEN Object_name='I' THEN azqaz.status_i(subid)
END status,
CASE
  WHEN object_name='A' THEN azqaz.sahe_a(subid)
  WHEN Object_name='S' THEN azqaz.sahe_s(subid)
  WHEN Object_name='I' THEN azqaz.sahe_i(subid)
END sahe,
CASE
  WHEN object_name='A' THEN azqaz.unvan_a(subid)
  WHEN Object_name='S' THEN azqaz.unvan_s(subid)
  WHEN Object_name='I' THEN azqaz.unvan_i(subid)
END adres,
CASE
  WHEN object_name='A' THEN azqaz.meter_nam_a(azqaz.meter_idn_a(subid,1))
  WHEN Object_name='S' THEN azqaz.meter_nam_s(azqaz.meter_idn_s(subid,1))
  WHEN Object_name='I' THEN azqaz.meter_nam_i(azqaz.meter_idn_i(subid,1))
END saygac_marka,
CASE
  WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
  WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
  WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1)
END saygac_nomre,
CASE
  WHEN object_name='A' THEN azqaz.ev_tipi_n(subid)
  WHEN Object_name='S' THEN ''
  WHEN Object_name='I' THEN ''
END menzil_tipi,'' qeyd,substr(subid,8,4) ev_kodu FROM 
(
 select t1.subid,t1.code_1,'"+p_var.n_obj+@"' object_name from ahali.subscriber t1,
   (
     select distinct subid from "+n_obj+ @" where 
     subid not in (select subid from azqaz.tex_bax_doq_f) 
     and
     meterid not in (select meterid from azqaz.tex_bax_meter_f)
    ) t2 where t1.subid=t2.subid and t1.code_1 not in (select tipid from azqaz.TEX_BAX_EV_TIP_F)
)  where substr(subid,3,5) " + p_var.n_str_new + "  order by subid ";
                             table11.Connection.ConnectionString = p_var.n_conn;
                             report1.Show();
                         }
                         break;
                    case "1.4":
                         Forma_N4_F.Text = "Müqavileli ve müqavilesiz abonentler haqqında yekun melumat(Forma № 4)";
                         Forma_N4_F.ShowDialog();
                         break;
                    case "1.5":
                         Forma_N5_F.Text = "Problemli abonentler haqqında melumat";
                         Forma_N5_F.ShowDialog();
                         break;
                    case "1.6":
                         Forma_N6_F.Text = "Boş xanaların doldurulması";
                         Forma_N6_F.ShowDialog();
                         break;
                    case "1.7":
                         Forma_N7_F.Text = "Müqavileli ve sayğacı bloklaşdırılmış abonentlerin siyahısı";
                         Forma_N7_F.ShowDialog();
                         break;
                    case "1.8":
                         Forma_N8_F.Text = "Müqavilesi bitmiş abonentler haqqında melumat(Sənaye)";
                         Forma_N8_F.ShowDialog();
                         break;
                    case "1.9":
                         Forma_N9_F.Text = "Müqavilesiz abonentler haqqında melumat(Sənaye)";
                         Forma_N9_F.ShowDialog();
                         break;
                    case "1.10":
                         Forma_N10_F.Text = "Blokda olan abonentler haqqında melumat(Sənaye)";
                         Forma_N10_F.ShowDialog();
                         break;
                    case "1.11":
                         Forma_N11_F.Text = "Ehaliden keçen abonentler haqqında melumat(Senaye)";
                         Forma_N11_F.ShowDialog();
                         break;
                    case "1.12":
                         Forma_N12_F.Text = "Bütün obyektlər(Senaye)";
                         Forma_N12_F.ShowDialog();
                         break;
                }
                return;                
            }
           
            switch (e.Node.Text.Substring(0, 3).Trim())
            {
                case "6.1":
                     //Forma_N8.Text = "FORMA № 9:Qüsurlar haqqında yekun hesabat";
                     Forma_N14.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN14.frx");

                        //MessageBox.Show(Forma_N14.comboBox1.Text.Trim());

                        if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                        {
                            report1.SetParameterValue("Ray", "Rayon:" + Forma_N14.comboBox1.Text.Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Ray", "");
                        }

                        //MessageBox.Show(Forma_N14.comboBox1.Text.Trim());
                         
                        TableDataSource table14 = report1.GetDataSource("T") as TableDataSource;

                        table14.SelectCommand = @"select SUBID,azqaz.fio_a(subid) fio, AZQAZ.UNVAN_a(SUBID) UNVAN, telefon,vesiqe_ser||' '||vesiqe_nom ves,qeyd from azqaz.tex_bax_vesiqe T where " + p_var.n_string;

                       table14.Connection.ConnectionString = p_var.n_conn;
                       report1.Show();
                     }
                    break;
                case "1.1":
                    Forma_N1.Text = "FORMA № 1:Çap üçün seçim sertleri";
                    Forma_N1.ShowDialog();
                    if (p_var.n_rez == "Y")
                       {
                        report1.Load("FORMAN1.frx");
                        report1.SetParameterValue("Forma_N","Forma № 1");
                        TableDataSource table1 = report1.GetDataSource("T") as TableDataSource;
                        table1.SelectCommand = @"select SUBID,AKT_NUM,AZQAZ.TEX_BAX_LIST_QUSUR_akt(subid,AKT_NUM) DEFFECT_ID,
                                                INSPEKTOR_ID||'-'||AZQAZ.INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_ID,
                                                AKT_DATA,QEYD,ISTEHLAKCI,
CASE
   WHEN object_name='A' THEN AZQAZ.UNVAN_A(SUBID)
   WHEN Object_name='S' THEN AZQAZ.UNVAN_S(SUBID)
   WHEN Object_name='I' THEN AZQAZ.UNVAN_I(SUBID)
END UNVAN,  AZQAZ.TEX_BAX_LIST_CIHAZ_akt(akt_num) AKT_CIHAZ,AZQAZ.TEX_BAX_LIST_PLOMB_akt(akt_num) AKT_SEAL 
                                           from (
                                                  select SUBID,AKT_NUM,INSPEKTOR_ID,AKT_DATA,ISTEHLAKCI,QEYD,object_name from azqaz.tex_bax_akts where substr(subid,3,2) in (" + p_var.n_region.Substring(p_var.n_region.IndexOf(':') + 1) +
 @") group by subid,AKT_NUM,INSPEKTOR_ID,AKT_DATA,ISTEHLAKCI,QEYD,object_name order by AKT_DATA,AKT_NUM,SUBID
                                                ) where " + p_var.n_string;
                                                                      
                       table1.Connection.ConnectionString =p_var.n_conn;
                       report1.Show();
                      /* report1.Prepare(); Yadda saxlama .
                         FastReport.Export.Xml.XMLExport exp = new FastReport.Export.Xml.XMLExport();
                        //if(exp.ShowDialog())
                        exp.Export(report1, "c:\\AKTS.xls");*/
                     }
                    break;
                case "1.2":
                    Forma_N4.Text = "FORMA № 4:Çap üçün seçim sertleri";
                    Forma_N4.ShowDialog();

                    if (p_var.n_rez == "Y")
                    {
                        report1.Load("FORMAN4.frx");
                        report1.SetParameterValue("dT1", Forma_N4.dT1.Text);
                        report1.SetParameterValue("dT2", Forma_N4.dT2.Text);
                        TableDataSource table4 = report1.GetDataSource("TEX_BAX_AKTS") as TableDataSource;

                        table4.SelectCommand = @"select o.*,azqaz.TEX_BAX_list_qusur_akt(subid,akt_num) deff from 
                                            (select subid,akt_num,AKT_DATA,inspektor_id||'-'||azqaz.inspektor_name(inspektor_id) inspektor,
                                             TEX_BAX_list_cihaz_n(subid,object_name) cihaz,
CASE
  WHEN object_name='A' THEN AZQAZ.UNVAN_A(SUBID)
  WHEN Object_name='S' THEN AZQAZ.UNVAN_S(SUBID)
  WHEN Object_name='I' THEN AZQAZ.UNVAN_I(SUBID)
END UNVAN,
CASE
  WHEN object_name='A' THEN azqaz.fio_A(subid)
  WHEN Object_name='S' THEN azqaz.fio_S(subid)
  WHEN Object_name='I' THEN azqaz.fio_I(subid)
END FIO,
CASE
  WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
  WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
  WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1)
END KSCET,
CASE
  WHEN object_name='A' THEN trim(METER_NaM_a(METER_idN_a(subid,1)))||':'||azqaz.METER_idN_a(subid,1)
  WHEN Object_name='S' THEN trim(METER_NaM_s(METER_idN_s(subid,1)))||':'||azqaz.METER_idN_s(subid,1)
  WHEN Object_name='I' THEN trim(METER_NaM_i(METER_idN_i(subid,1)))||':'||azqaz.METER_idN_i(subid,1)
END TIP,
                                              azqaz.TEX_BAX_list_qeyd_akt(subid,akt_num) qeyd ,
                                              azqaz.TEX_BAX_list_dop_scet_akt(subid,akt_num) dopkscet 
                                         from 
                                               (select t1.* from azqaz.tex_bax_akts t1,
                                                  (select subid,akt_num,AKT_DATA,inspektor_id,object_name from azqaz.tex_bax_akts where subid in 
                                                   (  select subid from 
                                         (select subid,count(*) say from 
                                         ( select SUBID,akt_num oo from azqaz.tex_bax_akts 
                                    where " + p_var.n_string+

                                   @" group by subid,akt_num ) group by subid ) where say>1
                                    ) and " +p_var.n_string+
                                   @" group by subid,akt_num,AKT_DATA,inspektor_id,object_name order by subid,akt_num,AKT_DATA ) t2
                             where t1.subid=t2.subid and t1.akt_num=t2.akt_num and t1.akt_data=t2.akt_data
                    ) group by subid,akt_num,AKT_DATA,inspektor_id,object_name order by subid,akt_data DESC,akt_num  DESC) o";    //+ p_var.n_string;

                        table4.Connection.ConnectionString = p_var.n_conn;
                        report1.Show();
                    }
                    break;
                case "1.3":
                     report1.Load("FORMAN5.frx");
                     //report1.SetParameterValue("Forma_N","Forma № 1");
                     TableDataSource table5 = report1.GetDataSource("Table") as TableDataSource;
                     table5.SelectCommand = @"select user_name user_id,azqaz.agis_user(user_name) user_name,oper_date,
                              note ,object_name from azqaz.tex_bax_akt_base_l where sign_out='0' order by oper_date ";                                                                      
                     table5.Connection.ConnectionString =p_var.n_conn;
                     report1.Show();
                     break;
                case "2.2":
                     Forma_N1.Text = "FORMA № 11:Çap üçün seçim sertleri";
                     Forma_N1.ShowDialog();
                     if (p_var.n_rez == "Y")
                     {
                         report1.Load("FORMAN12.frx");
                         report1.SetParameterValue("Forma_N", "Forma № 11");
                         TableDataSource table1 = report1.GetDataSource("T") as TableDataSource;
                         table1.SelectCommand = @"select distinct akt_num,akt_data,subid,AZQAZ.TEX_BAX_LIST_QUSUR_akt(subid,AKT_NUM) DEFFECT_ID,
INSPEKTOR_ID||'-'||AZQAZ.INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_ID,istehlakci,
CASE
   WHEN object_name='A' THEN AZQAZ.UNVAN_A(SUBID)
   WHEN Object_name='S' THEN AZQAZ.UNVAN_S(SUBID)
   WHEN Object_name='I' THEN AZQAZ.UNVAN_I(SUBID)
END UNVAN,
AZQAZ.TEX_BAX_LIST_CIHAZ_akt(akt_num) AKT_CIHAZ,AZQAZ.TEX_BAX_LIST_PLOMB_akt(akt_num) AKT_SEAL, 
qeyd from 
(
select t1.inspektor_id,t2.akt_num,t1.subid,t1.akt_data,t2.plomb_num,t1.istehlakci,t1.qeyd,t2.object_name from azqaz.tex_bax_akts t1,
(select * from tex_bax_apparats where vsize(trim(plomb_num))>0) t2 
where t1.akt_num=t2.akt_num 
) where " + p_var.n_string;
                         table1.Connection.ConnectionString = p_var.n_conn;
                         report1.Show();
                         /* report1.Prepare(); Yadda saxlama .
                            FastReport.Export.Xml.XMLExport exp = new FastReport.Export.Xml.XMLExport();
                           //if(exp.ShowDialog())
                           exp.Export(report1, "c:\\AKTS.xls");*/
                     }
                     break;
                case "3.2":
                     Forma_N7.Text = "FORMA № 7:Mühendisin hesabatı";
                     Forma_N7.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN7.frx");
                        report1.SetParameterValue("dT1", Forma_N7.dT1.Text);
                        report1.SetParameterValue("dT2", Forma_N7.dT2.Text);
                        report1.SetParameterValue("Muh", Forma_N7.comboBox2.Text.Substring(0, Forma_N7.comboBox2.Text.IndexOf('_')).Trim());
                        TableDataSource table7 = report1.GetDataSource("TEX_BAX_AKTS") as TableDataSource;
 table7.SelectCommand = @"select deff,subid,akt_num,AKT_DATA,inspektor,cihaz,TIP,qeyd,dopkscet,fio,unvan,kscet from 
(
select azqaz.TEX_BAX_list_qusur_akt(subid,akt_num) deff,subid,akt_num,AKT_DATA,inspektor_id||'-'||azqaz.inspektor_name(inspektor_id) inspektor,
TEX_BAX_list_cihaz_akt(akt_num) cihaz,
CASE
  WHEN object_name='A' THEN '(A) '||AZQAZ.UNVAN_A(SUBID)
  WHEN Object_name='S' THEN '(S) '||AZQAZ.UNVAN_S(SUBID)
  WHEN Object_name='I' THEN '(I) '||AZQAZ.UNVAN_I(SUBID)
END UNVAN,
CASE
  WHEN object_name='A' THEN azqaz.fio_A(subid)
  WHEN Object_name='S' THEN azqaz.fio_S(subid)
  WHEN Object_name='I' THEN azqaz.fio_I(subid)
END FIO,
CASE
  WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
  WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
  WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1) 
END KSCET,
CASE
  WHEN object_name='A' THEN trim(METER_NaM_a(METER_idN_a(subid,1)))||':'||azqaz.METER_idN_a(subid,1)
  WHEN Object_name='S' THEN trim(METER_NaM_s(METER_idN_s(subid,1)))||':'||azqaz.METER_idN_s(subid,1)
  WHEN Object_name='I' THEN trim(METER_NaM_i(METER_idN_i(subid,1)))||':'||azqaz.METER_idN_i(subid,1)
END TIP, azqaz.TEX_BAX_list_qeyd_akt(subid,akt_num) qeyd ,azqaz.TEX_BAX_list_dop_scet_akt(subid,akt_num) dopkscet 
  from azqaz.tex_bax_akts where " + p_var.n_string + 
") group by deff,subid,akt_num,AKT_DATA,inspektor,cihaz,TIP,qeyd,dopkscet,fio,unvan,kscet order by AKT_DATA";
                         table7.Connection.ConnectionString = p_var.n_conn;
                         report1.Show();
                     }
                     break;
                case "1.5":
                     Forma_N8.Text = "FORMA № 8:Yazılmış AKTlar haqqında melumat,sayğac melumatlari ile";
                     Forma_N8.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN8.frx");
                        report1.SetParameterValue("Forma_N", "Forma № 8");
                        //report1.SetParameterValue("dT1", Forma_N8.dT1.Text);
                        //report1.SetParameterValue("dT2", Forma_N8.dT2.Text);
                 //report1.SetParameterValue("Muh", Forma_N8.comboBox2.Text.Substring(0,Forma_N8.comboBox2.Text.IndexOf('-')).Trim());
                        TableDataSource table8 = report1.GetDataSource("T") as TableDataSource;

                  table8.SelectCommand = @"select SUBID, ks, songes,songese,AKT_NUM,AZQAZ.TEX_BAX_LIST_QUSUR_akt(subid,akt_num) DEFFECT_ID,AZQAZ.INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_ID,AKT_DATA,QEYD,ISTEHLAKCI,
       CASE WHEN object_name='A' THEN AZQAZ.UNVAN_A(SUBID) 
            WHEN Object_name='S' THEN AZQAZ.UNVAN_S(SUBID)
            WHEN Object_name='I' THEN AZQAZ.UNVAN_I(SUBID)
       END UNVAN,AZQAZ.TEX_BAX_LIST_CIHAZ_akt(akt_num) AKT_CIHAZ,
            AZQAZ.TEX_BAX_LIST_PLOMB_akt(akt_num) AKT_SEAL  
            from (select SUBID,
       CASE WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
            WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
            WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1)
       END ks,songes,songese,AKT_NUM,INSPEKTOR_ID,AKT_DATA,ISTEHLAKCI,QEYD,object_name from azqaz.tex_bax_akts
                  group by subid,AKT_NUM,INSPEKTOR_ID,AKT_DATA,ISTEHLAKCI,QEYD,object_name,
                        CASE WHEN object_name='A' THEN azqaz.meter_nom_a(subid,1)
                             WHEN Object_name='S' THEN azqaz.meter_nom_s(subid,1)
                             WHEN Object_name='I' THEN azqaz.meter_nom_i(subid,1)
                        END ,songes,songese 
                  order by AKT_DATA,AKT_NUM,SUBID ) where " + p_var.n_string;
                  //MessageBox.Show(table8.SelectCommand);
                       table8.Connection.ConnectionString = p_var.n_conn;
                       report1.Show();
                     }
                     break;
                case "4.2":
                     Forma_N8.Text = "FORMA № 9:Qüsurlar haqqında yekun hesabat";
                     Forma_N8.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN9.frx");
                        report1.SetParameterValue("Forma_N", "Forma № 9");
                        
                        if (p_var.n_string.IndexOf("AKT_DATA") != -1) //Tarix
                        {
                            report1.SetParameterValue("dT1","Aralıq:["+Forma_N8.dT1.Text.Trim()+",");
                            report1.SetParameterValue("dT2",Forma_N8.dT2.Text+"]");
                        }
                        else
                        {
                            report1.SetParameterValue("dT1", "");
                            report1.SetParameterValue("dT2", "");
                        }

                        if (p_var.n_string.IndexOf("INSPEKTOR_ID") != -1) //Mühəndis
                        {
                            report1.SetParameterValue("Muh", "Mühəndis:" + Forma_N8.comboBox2.Text.Substring(0, Forma_N8.comboBox2.Text.IndexOf('-')).Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Muh", "");
                        }

                        if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                        {
                            report1.SetParameterValue("Ray", "Rayon:" + Forma_N8.comboBox1.Text.Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Ray", "");
                        }
                        
                       // MessageBox.Show(p_var.n_string);
                         
                        TableDataSource table8 = report1.GetDataSource("T") as TableDataSource;

                        table8.SelectCommand = @"select '                  ***  AKTların umumi  sayı  ***' name,999 id , count(*) say  from (select distinct akt_num from azqaz.tex_bax_akts  where "+ p_var.n_string+
                                     @") union all select '                  ***  Qusur AKTlarının sayı ***' name,999 id , count(*) say from (select distinct akt_num from azqaz.tex_bax_akts  where deffect_id<>'33' and " + p_var.n_string +
                                               @") union all select deffect_name(id) name,id,say from (select count(*) say,deffect_id id from (select * from azqaz.tex_bax_akts  where "+ p_var.n_string+
                                               @") group by deffect_id ) order by id";

                       table8.Connection.ConnectionString = p_var.n_conn;
                       report1.Show();
                     }
                     break;
                case "1.7":
                     Forma_N8.Text = "FORMA № 10:Qüsurlar AKTlar haqqında yekun hesabat";
                     Forma_N8.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN9.frx");
                        report1.SetParameterValue("Forma_N", "Forma № 10");
                        
                        if (p_var.n_string.IndexOf("AKT_DATA") != -1) //Tarix
                        {
                            report1.SetParameterValue("dT1","Aralıq:["+Forma_N8.dT1.Text.Trim()+",");
                            report1.SetParameterValue("dT2",Forma_N8.dT2.Text+"]");
                        }
                        else
                        {
                            report1.SetParameterValue("dT1", "");
                            report1.SetParameterValue("dT2", "");
                        }

                        if (p_var.n_string.IndexOf("INSPEKTOR_ID") != -1) //Mühəndis
                        {
                            report1.SetParameterValue("Muh", "Mühəndis:" + Forma_N8.comboBox2.Text.Substring(0, Forma_N8.comboBox2.Text.IndexOf('-')).Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Muh", "");
                        }

                        if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                        {
                            report1.SetParameterValue("Ray", "Rayon:" + Forma_N8.comboBox1.Text.Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Ray", "");
                        }
                        
                       // MessageBox.Show(p_var.n_string);
                         
                        TableDataSource table8 = report1.GetDataSource("T") as TableDataSource;
                        table8.SelectCommand = @"select deffect_name(id) name,id,say from
                                                 (select count(*) say,deffect_id id from 
                                                       (
                                                select * from azqaz.tex_bax_akts  where "+ p_var.n_string+
                                                      ")  group by deffect_id ) order by id" ;

                       table8.Connection.ConnectionString = p_var.n_conn;
                       report1.Show();
                     }

                     break;
                case "1.6":
                     Forma_N13.Text = "Texniki baxış aparmış mühendislerin aylıq yekun melumatı(Forma № 12)";
                     Forma_N13.ShowDialog();
                     if (p_var.n_rez == "Y")
                     {
                         report1.Load("FORMAN13.frx");
                         report1.SetParameterValue("Forma_N", "Forma № 12");

                         if (p_var.n_string.IndexOf("AKT_DATA") != -1) //Tarix
                         {
                             report1.SetParameterValue("dT1", "Aralıq:[" + Forma_N13.dT1.Text.Trim() + ",");
                             report1.SetParameterValue("dT2", Forma_N13.dT2.Text + "]");
                         }
                         else
                         {
                             report1.SetParameterValue("dT1", "");
                             report1.SetParameterValue("dT2", "");
                         }

                         if (p_var.n_string.IndexOf("INSPEKTOR_ID") != -1) //Mühəndis
                         {
                             report1.SetParameterValue("Muh", "Mühəndis:" + Forma_N13.comboBox2.Text.Substring(0, Forma_N13.comboBox2.Text.IndexOf(':')).Trim());
                         }
                         else
                         {
                             report1.SetParameterValue("Muh", "");
                         }

                         if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                         {
                             report1.SetParameterValue("Ray", "Rayon:" + Forma_N13.comboBox1.Text.Trim());
                         }
                         else
                         {
                             report1.SetParameterValue("Ray", "");
                         }
                         //                       MessageBox.Show(p_var.n_string);

                         TableDataSource table13 = report1.GetDataSource("TEX_BAX_AKTS") as TableDataSource;
                        //p_var.n_string = p_var.n_string.Replace("AKT_DATA", "doq_data");
                        // MessageBox.Show(p_var.n_string);                        
                         table13.SelectCommand = @"select t2.rrr||'.'||t1.inspektor_id inspektor_id,t1.day,t1.say from (
select azqaz.tex_bax_inspektor_name(inspektor_id)||'('||inspektor_id||')' inspektor_id,
say,to_char(akt_data,'DD') day from
(
select inspektor_id,akt_data,count(*) say from 
(
select distinct akt_num,inspektor_id,akt_data from azqaz.tex_bax_akts 
where " + p_var.n_string + @"
)  group by inspektor_id,akt_data
) order by inspektor_id ) t1,

(select rownum rrr,inspektor_id,0 say,' ' day from (
select inspektor_id,0 say,' ' day from (
select azqaz.tex_bax_inspektor_name(inspektor_id)||'('||inspektor_id||')' inspektor_id from
(
select distinct t.inspektor_id from azqaz.tex_bax_akts t 
where " +p_var.n_string +@"
) order by inspektor_id  )
                     )) t2 where t1.inspektor_id=t2.inspektor_id";
  
                         table13.Connection.ConnectionString = p_var.n_conn;
                         report1.Show();
                     }
                     break;
                case "5.1":
                     Forma_N11.Text = "Müqavileler haqqında melimat(Forma № 13)";
                     Forma_N11.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN11.frx");
                        report1.SetParameterValue("Forma_N", "Forma № 13");

                        if (p_var.n_son.Trim() == "")
                        {
                            report1.SetParameterValue("Doq", "");
                        }
                        else
                        {
                            switch (p_var.n_son)
                            {
                                case " 1=1 and ":
                                     report1.SetParameterValue("Doq", "Müqaviləsi olanlar və olmayanlar");
                                     break;
                                case " doq_tip='T' and ":
                                     report1.SetParameterValue("Doq", "Təzə müqavilələr");
                                     break;
                                case " doq_tip='K' and ":
                                     report1.SetParameterValue("Doq", "Köhnə müqavilələr");
                                     break;
                                case " doq_tip='Y' and ":
                                     report1.SetParameterValue("Doq", "Müqaviləsi olmayanlar");
                                     break;
                            }

                        }
                        
                        if (p_var.n_string.IndexOf("AKT_DATA") != -1) //Tarix
                        {
                            report1.SetParameterValue("dT1","Aralıq:["+Forma_N11.dT1.Text.Trim()+",");
                            report1.SetParameterValue("dT2",Forma_N11.dT2.Text+"]");
                        }
                        else
                        {
                            report1.SetParameterValue("dT1", "");
                            report1.SetParameterValue("dT2", "");
                        }

                        if (p_var.n_string.IndexOf("INSPEKTOR_ID") != -1) //Mühəndis
                        {
                            report1.SetParameterValue("Muh", "Mühəndis:" + Forma_N11.comboBox2.Text.Substring(0, Forma_N11.comboBox2.Text.IndexOf(':')).Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Muh", "");
                        }

                        if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                        {
                            report1.SetParameterValue("Ray", "Rayon:" + Forma_N11.comboBox1.Text.Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Ray", "");
                        }
                        
 //                       MessageBox.Show(p_var.n_string);

                        TableDataSource table11 = report1.GetDataSource("T") as TableDataSource;

                        p_var.n_string = p_var.n_string.Replace("AKT_DATA", "doq_data");

                        //p_var.n_string = p_var.n_string.Replace("INSPEKTOR_ID", "USER_NAME");

                        table11.SelectCommand = @"select SUBID,doq_data,doq_num ,QEYD, 
                                                AZQAZ.fio_a(subid) ISTEHLAKCI, AZQAZ.UNVAN_A(SUBID) UNVAN,
                                                user_name,azqaz.agis_user(user_name) user_fio
/*
CASE
   WHEN object_name='A' THEN AZQAZ.UNVAN_A(SUBID)
   WHEN Object_name='S' THEN AZQAZ.UNVAN_S(SUBID)
   WHEN Object_name='I' THEN AZQAZ.UNVAN_I(SUBID)
END UNVAN
*/                             from azqaz.tex_bax_doqovor where " + p_var.n_string;
                        if (p_var.n_son == " 1=1 and ")
                        {
                            table11.SelectCommand = @"select SUBID,doq_data,doq_num ,QEYD,AZQAZ.fio_a(subid) ISTEHLAKCI, 
       user_name,azqaz.agis_user(user_name) user_fio,doq_tip,azqaz.unvan_a(subid) unvan from azqaz.tex_bax_doqovor where " + p_var.n_string +
    @" union all
select Subid,doq_data,doq_num ,QEYD,
case when DOQ_tip='Y' then 'Y-Yoxdur' 
     when DOQ_tip='T' then 'T-Təzədir' 
     when DOQ_tip='K' then 'K-Kohnədir' end ISTEHLAKCI,user_name,user_fio,'' doq_tip ,to_nchar(unvan) unvan
  from
(select to_nchar('') SUBID ,
to_date('01.01.2000','dd.mm.yyyy') doq_data,'' doq_num ,to_nchar('') QEYD,'' ISTEHLAKCI,'' user_name,'' user_fio,doq_tip ,count(*) unvan
from azqaz.tex_bax_doqovor where " + p_var.n_string + "group by doq_tip)";
                        }
                        table11.Connection.ConnectionString = p_var.n_conn;
                        report1.Show();
                     }
                     break;
                case "2.1":
                     Forma_N8.Text = "PLOMBlar və CİHAZlar haqqında yekun məlimat(Forma № 10)";
                     Forma_N8.ShowDialog();
                     if (p_var.n_rez == "Y")
                      {
                        report1.Load("FORMAN10.frx");
                        report1.SetParameterValue("Forma_N", "Forma № 10");
                        
                        if (p_var.n_string.IndexOf("AKT_DATA") != -1) //Tarix
                        {
                            report1.SetParameterValue("dT1","Aralıq:["+Forma_N8.dT1.Text.Trim()+",");
                            report1.SetParameterValue("dT2",Forma_N8.dT2.Text+"]");
                        }
                        else
                        {
                            report1.SetParameterValue("dT1", "");
                            report1.SetParameterValue("dT2", "");
                        }

                        if (p_var.n_string.IndexOf("INSPEKTOR_ID") != -1) //Mühəndis
                        {
                            report1.SetParameterValue("Muh", "Mühəndis:" + Forma_N8.comboBox2.Text.Substring(0, Forma_N8.comboBox2.Text.IndexOf('-')).Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Muh", "");
                        }

                        if (p_var.n_string.IndexOf("SUBID") != -1) //Rayon
                        {
                            report1.SetParameterValue("Ray", "Rayon:" + Forma_N8.comboBox1.Text.Trim());
                        }
                        else
                        {
                            report1.SetParameterValue("Ray", "");
                        }
                        
                       // MessageBox.Show(p_var.n_string);

                        TableDataSource table10 = report1.GetDataSource("T") as TableDataSource;

                        p_var.n_string = p_var.n_string.Replace("AKT_DATA", "PLOMB_DATE");

                        table10.SelectCommand = @"select tex_bax_cihaz_name(apparat_id,'A') name,apparat_id,say from 
(
select count(*) say,apparat_id from (select * from azqaz.tex_bax_apparats where "+p_var.n_string+") group by apparat_id) " 
+
@"union all
select '                  *** Cihazların umumi sayi ***'name,999 apparat_id ,count(*) say from azqaz.tex_bax_apparats WHERE "+p_var.n_string
+
@"union all 
select '                  *** Aktlarin sayı *** 'name,999 apparat_id ,count(*) say  from 
(
select distinct akt_num  from azqaz.tex_bax_apparats WHERE "+p_var.n_string+")"
+
@"union all
select '                  *** Plomblu Aktların sayı *** 'name,999 apparat_id ,count(*) say from 
(
select distinct akt_num  from azqaz.tex_bax_apparats t where t.plomb_num is not null and "+p_var.n_string+")"
+
@"union all
select '                  *** Plombların sayı *** 'name,999 apparat_id ,count(*) say from azqaz.tex_bax_apparats t where t.plomb_num is not null and "+p_var.n_string;

                        table10.Connection.ConnectionString = p_var.n_conn;
                        report1.Show();
                     }
                     break;
                case "2.3":
                     report1.Load("FORMAN6.frx");
                     TableDataSource table6 = report1.GetDataSource("Table") as TableDataSource;
                     table6.SelectCommand = @"select user_name user_id,azqaz.agis_user(user_name) user_name, oper_date,
                              note ,object_name from azqaz.TEX_BAX_SEAL_BASE_L where sign_out='0' order by oper_date ";
                     table6.Connection.ConnectionString =p_var.n_conn;
                     report1.Show();
                     break;
                case "3.1":
                     report1.Load("FORMAN2.frx");
                     TableDataSource table2 = report1.GetDataSource("TEX_BAX_INSPEKTOR") as TableDataSource;
                     table2.SelectCommand = @"select inspektor_id, inspektor_name, req_ray, ind_num 
                                             from azqaz.tex_bax_inspektor order by inspektor_name";                                                                      
                     table2.Connection.ConnectionString =p_var.n_conn;
                     report1.Show();                    
                     break;
                case "4.1":
                     report1.Load("FORMAN3.frx");
                     TableDataSource table3 = report1.GetDataSource("TEX_BAX_DEFFECTS") as TableDataSource;
                     table3.SelectCommand = @"select deffect_id, deffect_name from azqaz.TEX_BAX_DEFFECTS order by deffect_name";
                     table3.Connection.ConnectionString = p_var.n_conn;
                     report1.Show();
                     break;
                default:
                    //MessageBox.Show("Proyekt hazır deyil");
                    break;
            }
        }

        public string my_metod_0(string s1,string user,string del_ins)  //Cihazlar haqda məlumat
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";
            label5.Text = " Aktlarda =>";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "AZQAZ.TEX_BAX_CIHAZ_NEW";     // Name_function ******************

//            MessageBox.Show(cmd.CommandText);
            
            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_subid", OracleType.VarChar);
            cmd.Parameters["v_subid"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_subid"].Value = s1; // subid

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = user; // user_name

            cmd.Parameters.Add("v_del", OracleType.VarChar);
            cmd.Parameters["v_del"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_del"].Value = del_ins; // Insert-I,Delete-D

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(-5): " + ex.Message);
                return ("E");
            }
            
            conn.Close();
            return ("Y");
        }

        public string my_metod_find(string s1)
        {
          Find.ShowDialog();
          return p_var.n_subid;
        }

        private void label1_Click(object sender, EventArgs e) //Axtarış parametirləri təmizlənir.
        {
            txtbxSubscriberNo.Text = "";
            checkBox1.Checked = false;
            txtbxSubscriberNo.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Proqramı bağlamağa əminsinizmi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OracleConnection conn = new OracleConnection(p_var.n_conn1);
                OracleCommand cmd = new OracleCommand();
                var v_EXIT = "$";

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AZQAZ.tex_bax_user_password_ip_BE"; // Name_function
                cmd.Parameters.Add("v_RETU", OracleType.VarChar); //Number);
                cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
                cmd.Parameters["v_RETU"].Size = 256;

                cmd.Parameters.Add("v_user_name", OracleType.VarChar);
                cmd.Parameters["v_user_name"].Direction = ParameterDirection.Input;
                cmd.Parameters["v_user_name"].Value = p_var.n_uzer_name; // user_name

                cmd.Parameters.Add("v_pass", OracleType.VarChar);
                cmd.Parameters["v_pass"].Direction = ParameterDirection.Input;
                cmd.Parameters["v_pass"].Value = "";

                cmd.Parameters.Add("v_app", OracleType.VarChar);
                cmd.Parameters["v_app"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["v_app"].Value = "";

                cmd.Parameters.Add("v_activ", OracleType.VarChar);
                cmd.Parameters["v_activ"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["v_activ"].Value = "E";

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
                    //p_var.n_uzer_name = textBox1.Text.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Serverə müraciətdə xəta yarandı: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button9_Click(object sender, EventArgs e) //Aktların şərt daxilində axtarışı
        {
            AktiAxtar.Text = "AKTlatın axtarışı";
            AktiAxtar.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                //Thread.Sleep(1 * 500);
                //merlin.MoveTo(400, 400);
                //merlin.Show(true);
                //merlin.Speak("Axtarıram...", "");
                //merlin.Play("Searching");
                
                button19.Enabled = true;
                
                gridControl2.DataSource = null;
                my_metod_3(p_var.n_string,"S");

                //merlin.Hide(true);
            }
        }

        private void button10_Click(object sender, EventArgs e) //Bu yeni Aktlarin əlavəsi düyməsidir
        {
            AktElave.ShowDialog();
            if (p_var.n_rez == "Y")
               {
                  MessageBox.Show("Aktların əlavəsi əməliyyat başa çatdı !!!");
                  my_metod_3(p_var.n_string,"S");
               }
        }

        private void button11_Click(object sender, EventArgs e) //Bu Aktlarin silinməsi düyməsidir
        {
            AktiAxtar.Text = "AKTlatın silinmesi";
            AktiAxtar.ShowDialog();
            if (p_var.n_rez == "Y")
               {
                   if (p_var.n_string.ToString().Contains("SIGN='2'") || p_var.n_string.ToString().Contains("SIGN='3'"))
                      {
                          MessageBox.Show("2 və ya 3 statuslu AKTlar silinə bilməz !!!");
                      }
                   else
                      {
                          p_var.n_string = p_var.n_string + " AND NOT (SIGN IN ('2','3'))";
                          my_metod_3(p_var.n_string, "D");
                      }
               }
        }

        private void button13_Click(object sender, EventArgs e) //Aktin Aktlar siyahısindan ləğv edilmesi(3 statusuna keçirilməsi)
        {
            if (Aktleqv.textBox2.Text.Trim() == "2") //1,3-statusundan ferqli akt ləğv edilə bilməz
            {
                MessageBox.Show("Diqqət,2(yaşıl) statuslu AKTlar ləğv edilə biməz !");
                return;
            }
            Aktleqv.ShowDialog();
            if (p_var.n_rez == "Y")
            {
//                p_var.n_rez = my_metod_status3(Aktleqv.textBox1.Text.Trim(), p_var.n_uzer_name, Aktleqv.textBox3.Text.Trim(), "3");
                p_var.n_rez = my_metod_status3(Aktleqv.textBox1.Text.Trim(), p_var.n_uzer_name, Aktleqv.textBox3.Text.Trim(), (Aktleqv.textBox2.Text.Trim() == "1") ? "3" : "1");
                if (p_var.n_rez == "Y")
                {
                    DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                    row[2] = (Aktleqv.textBox2.Text.Trim() == "1") ? "3" : "1";
                    //row[2] = "3"; // Aktleqv.textBox2.Text.Trim(); //Status dəyişir
                    row[6] = Aktleqv.textBox3.Text.Trim(); //Qeyd dəyişir
                    //gridView2.RefreshRow(2);
                }
            }
            button13.Enabled = false;
        }

        public string my_metod_status3(string s1, string user, string s3, string s4) //Ləğv etmədə statu 3 keçirmə
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_status_3";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_aktn", OracleType.VarChar);
            cmd.Parameters["v_aktn"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_aktn"].Value = s1; // akt nömrəsi

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = user; // proqram istifadəşisi

            cmd.Parameters.Add("v_qeyd", OracleType.VarChar);
            cmd.Parameters["v_qeyd"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_qeyd"].Value = s3; // qeyd

            cmd.Parameters.Add("v_status", OracleType.VarChar);
            cmd.Parameters["v_status"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_status"].Value = s4; // status

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(1): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return ("Y");
       }

        private void grdvwXidmet_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv == null) return;
            GridView detailView = null;

            detailView = gv.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            if (detailView == null || detailView.Columns.Count == 0) return;
       
            detailView.Columns["AKT_NUM"].Visible = false;
            detailView.Columns["AKT_ID"].Visible = false;
            detailView.Columns["AKT_DATA"].Visible = false;
            detailView.Columns["SUBID"].Visible = false;
            detailView.Columns["AKT_KSCET"].Visible = false;
            detailView.Columns["NAME"].Caption = "Qüsurun adı";
            detailView.Columns["NAME"].Width = 300;
            detailView.Columns["SN"].Caption = " № ";
            detailView.Columns["SN"].Width = 33;
            detailView.Columns["QEYD"].Caption = "Qeyd";
            detailView.Columns["QEYD"].Width = 300;
            detailView.Columns["INSPEKTORN"].Caption = "Mühəndis";
            detailView.Columns["INSPEKTORN"].Width = 150;
            detailView.Columns["ISTEHLAKCI"].Caption = "İstehlakçı";
            detailView.Columns["ISTEHLAKCI"].Width = 150;
            detailView.Columns["DEFFECT_ID"].Caption = "Deff_id";
            detailView.Columns["DEFFECT_ID"].ToolTip = "Deffekt_id";
            detailView.Columns["INSPEKTOR_ID"].Caption = "Insp_id";
            detailView.Columns["INSPEKTOR_ID"].ToolTip = "Inspektor_id";
            detailView.Columns["OPER_DATE"].Caption = "Əməliyyat tarixi";
            detailView.Columns["OPER_DATE"].Width = 150;
            detailView.Columns["OPER_DATE"].DisplayFormat.FormatType = FormatType.Custom;
            detailView.Columns["OPER_DATE"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            detailView.Columns["USER_NAME"].Caption = "Operator kodu";
            detailView.Columns["USER_NAME"].Width = 120;
            detailView.Columns["ADI"].Caption = "Operator Adı";
            detailView.Columns["ADI"].Width = 150;
            detailView.Columns["SONGES"].Visible = false;
            detailView.Columns["SONGESE"].Visible = false;

            //grdvwXidmet.GetRowCellValue(e.RowHandle, grdvwXidmet.Columns[1]).ToString().Trim();

            //MessageBox.Show(grdvwXidmet.GetRowCellValue(e.RowHandle, grdvwXidmet.Columns[1]).ToString().Trim());
            my_cihaz_aktla(grdvwXidmet.GetRowCellValue(e.RowHandle, grdvwXidmet.Columns[1]).ToString().Trim());
            gridControl1.Enabled = false; // true;
            //detailView.Columns["DEFFECT_NAME"].Width = detailView.Columns["DEFFECT_NAME"].GetBestWidth();
        }

        private void grdvwXidmet_MasterRowCollapsed(object sender, CustomMasterRowEventArgs e)
        {
            gridControl1.Enabled =false; //redaktəni baölamaq
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e) //Cihaz sətirlər
        {
            var view1 = sender as GridView;
            label5.Text = "Cihazlarda=>";
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        label5.Text = "Cihazlarda=>";
                        Form_cihaz.textBox1.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim();//Cihazın kodu
                        p_var.n_textbox          = view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim();//Cihazın kodu
                        Form_cihaz.textBox2.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[3]).ToString().Trim();//Cihazın adı
                        Form_cihaz.textBox3.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[4]).ToString().Trim();//Plobm N
                        Form_cihaz.textBox4.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[5]).ToString().Trim();//Sira N
                        p_var.n_data             = view1.GetRowCellValue(e.RowHandle, view1.Columns[11]).ToString().Trim();//Plomb data
                        Form_cihaz.dT1.Text      = (p_var.n_data == "") ? "" : p_var.n_data.Substring(0, 10);
                        
                    }
                }
            }
        }

        private void grdvwXidmet_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var view = sender as GridView;
            label5.Text = " Aktlarda =>";
            if (view != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view.Columns.Count > 3)
                    {
                        label5.Text = " Aktlarda =>";
                        Form_akt.textBox1.Text = view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString().Trim();//akt N:
                        p_var.n_textbox        = view.GetRowCellValue(e.RowHandle, view.Columns[7]).ToString().Trim();//Qusur id
                        p_var.n_string         = view.GetRowCellValue(e.RowHandle, view.Columns[8]).ToString().Trim();//Inspektor id
                        p_var.n_data           = view.GetRowCellValue(e.RowHandle, view.Columns[9]).ToString().Trim();//Plomb data
                        Form_akt.dT1.Text      = (p_var.n_data == "") ? "" : p_var.n_data.Substring(0, 10);
                        //Form_akt.dTtt1.Text    = view.GetRowCellValue(e.RowHandle, view.Columns[9]).ToString().Trim();//Akt data
                        Form_akt.textBox2.Text = view.GetRowCellValue(e.RowHandle, view.Columns[3]).ToString().Trim();//Qusur adi
                        Form_akt.textBox3.Text = view.GetRowCellValue(e.RowHandle, view.Columns[7]).ToString().Trim();//Qusur id
                        Form_akt.textBox4.Text = view.GetRowCellValue(e.RowHandle, view.Columns[5]).ToString().Trim();//Inspektor adi
                        Form_akt.textBox5.Text = view.GetRowCellValue(e.RowHandle, view.Columns[6]).ToString().Trim();//Istehlakci adi
                        Form_akt.textBox6.Text = view.GetRowCellValue(e.RowHandle, view.Columns[4]).ToString().Trim();//Qeyd
                        Form_akt.textBox7.Text = view.GetRowCellValue(e.RowHandle, view.Columns[8]).ToString().Trim();//Inspektor id
                        Form_akt.textBox8.Text = view.GetRowCellValue(e.RowHandle, view.Columns[2]).ToString().Trim();//akt_id
                        Form_akt.textBox9.Text = view.GetRowCellValue(e.RowHandle, view.Columns[11]).ToString().Trim();//sayğac nomresi
                        Form_akt.textBox10.Text = view.GetRowCellValue(e.RowHandle, view.Columns["SONGES"]).ToString().Trim(); //                        sayğac göst

                        Form_akt.textBox11.Text = view.GetRowCellValue(e.RowHandle, view.Columns["SONGESE"]).ToString().Trim(); //                        sayğac göst

                        Aktadd.textBox1.Text = view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString().Trim();//akt N:
                        p_var.n_textbox = view.GetRowCellValue(e.RowHandle, view.Columns[7]).ToString().Trim();//Qusur id
                        p_var.n_string = view.GetRowCellValue(e.RowHandle, view.Columns[8]).ToString().Trim();//Inspektor id
                        p_var.n_data = view.GetRowCellValue(e.RowHandle, view.Columns[9]).ToString().Trim();//Plomb data

                        //Aktadd.dT1.Text = (p_var.n_data == "") ? "" : p_var.n_data.Substring(0, 10);
                       // MessageBox.Show("buna bax=" + p_var.n_data.Substring(0, 10));
                        Aktadd.dT1.Text = view.GetRowCellValue(e.RowHandle, view.Columns["AKT_DATA"]).ToString().Trim().Substring(0, 10);//akt data
                        //Aktadd.dT1.Text = p_var.n_data.Substring(0, 10);
                        //MessageBox.Show("buna bax="+Aktadd.dT1.Text);
                        
                        Aktadd.textBox2.Text = view.GetRowCellValue(e.RowHandle, view.Columns[3]).ToString().Trim();//Qusur adi
                        Aktadd.textBox3.Text = view.GetRowCellValue(e.RowHandle, view.Columns[7]).ToString().Trim();//Qusur id
                        Aktadd.textBox4.Text = view.GetRowCellValue(e.RowHandle, view.Columns[5]).ToString().Trim();//Inspektor adi
                        Aktadd.textBox5.Text = view.GetRowCellValue(e.RowHandle, view.Columns[6]).ToString().Trim();//Istehlakci adi
                        Aktadd.textBox6.Text = view.GetRowCellValue(e.RowHandle, view.Columns[4]).ToString().Trim();//Qeyd
                        Aktadd.textBox7.Text = view.GetRowCellValue(e.RowHandle, view.Columns[8]).ToString().Trim();//Inspektor id
                        Aktadd.textBox8.Text = view.GetRowCellValue(e.RowHandle, view.Columns[2]).ToString().Trim();//akt_id
                        Aktadd.textBox9.Text = view.GetRowCellValue(e.RowHandle, view.Columns[11]).ToString().Trim();//sayğac nomresi
                        Aktadd.textBox10.Text = view.GetRowCellValue(e.RowHandle, view.Columns["SONGES"]).ToString().Trim();//sayğac göstəricisi
                        Aktadd.textBox11.Text = view.GetRowCellValue(e.RowHandle, view.Columns["SONGESE"]).ToString().Trim();//sayğac göstəricisi
//*********
                        DATAKORR.textEdit1.Text = view.GetRowCellValue(e.RowHandle, view.Columns["AKT_NUM"]).ToString().Trim();
                        DATAKORR.textEdit2.Text = view.GetRowCellValue(e.RowHandle, view.Columns["AKT_NUM"]).ToString().Trim();
                        DATAKORR.textEdit3.Text = view.GetRowCellValue(e.RowHandle, view.Columns["QEYD"]).ToString().Trim();
                        DATAKORR.dT1.Text= view.GetRowCellValue(e.RowHandle, view.Columns["AKT_DATA"]).ToString().Trim().Substring(0, 10);
//**********
                        p_var.n_str_new = "";
                        for (int i = 0; i <= view.RowCount - 1; i++)
                        {
                            p_var.n_str_new = p_var.n_str_new + "." + view.GetRowCellValue(i, view.Columns[7]).ToString().Trim() + ".";
                        }

                    }
                }
            }
        }

        private void grdvwXidmet_RowClick(object sender, RowClickEventArgs e)
        {
            //MessageBox.Show("X:"+e.X.ToString()+",Y"+e.Y.ToString());
            //MessageBox.Show(e.RowHandle.ToString()+"=:="+e.Handled.ToString());

            label5.Text = " Aktlarda =>";
            Form_akt.textBox1.Text ="";//akt N:
            p_var.n_textbox = "";      //Qusur id
            p_var.n_string = "";        //Inspektor id
            Form_akt.dT1.Text ="";     //Akt data
            Form_akt.textBox2.Text ="";//Qusur adi
            Form_akt.textBox3.Text ="";//Qusur id
            Form_akt.textBox4.Text ="";//Inspektor adi
            Form_akt.textBox5.Text ="";//Istehlakci adi
            Form_akt.textBox6.Text ="";//Qeyd
            Form_akt.textBox7.Text ="";//Inspektor id
            Form_akt.textBox8.Text ="";//akt_id
            Form_akt.textBox9.Text = "";//akt_id
            Form_akt.textBox10.Text = "";//akt_id
            Form_akt.textBox11.Text = "";//akt_id

            Aktadd.textBox1.Text = "";//akt N:
            Aktadd.dT1.Text = "";     //Akt data
            Aktadd.textBox2.Text = "";//Qusur adi
            Aktadd.textBox3.Text = "";//Qusur id
            Aktadd.textBox4.Text = "";//Inspektor adi
            Aktadd.textBox5.Text = "";//Istehlakci adi
            Aktadd.textBox6.Text = "";//Qeyd
            Aktadd.textBox7.Text = "";//Inspektor id
            Aktadd.textBox8.Text = "";//akt_id
            Aktadd.textBox9.Text = "";//akt_id
            Aktadd.textBox10.Text = "";//akt_id
            Aktadd.textBox11.Text = "";//akt_id

            if (e.RowHandle < 0)
            {
                button2.PerformClick(); //yeni akt yaratmaq düyməsini bas
            }
             
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e) //Cihaz
        {
            label5.Text = "Cihazlarda=>";
            Form_cihaz.textBox1.Text = "";//Cihazın kodu
            p_var.n_textbox          = "";
            Form_cihaz.textBox2.Text = "";//Cihazın adı
            Form_cihaz.textBox3.Text = "";//Plobm N
            Form_cihaz.textBox4.Text = "";//Sira N
            Form_cihaz.dT1.Text      = "";//Plomb data
        }

        private void gridView2_RowStyle(object sender, RowStyleEventArgs e) // Sətirlərin rənclənməsi:Sarı,Yaşıl,Girmızı
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
              {
                 //DateTime date = Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("AKT_DATA")));
                 //int aaa = Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("ROWNUM")));
                 //string BBB = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("SIGN"));
                 switch (View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("SIGN")))
                 {
                     case "1":
                          e.Appearance.BackColor = Color.Yellow; //1 sarı
                          break;
                     case "2":
                          e.Appearance.BackColor = Color.FromArgb(80, 240, 131);//ForestGreen; //GreenYellow; //Green; 2 yaşıl
                          break;
                     case "3":
                          e.Appearance.BackColor = Color.Red; //3 qırmızı
                          break;
                 }
             }
       }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e) //ləğv etməyə aid sətilər (3-Statusu)
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        Aktleqv.textBox1.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim(); //Akt N:
                        Aktleqv.textBox2.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim(); //Status
                        Aktleqv.textBox3.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim(); //Qeyd
                        Aktleqv.textBox4.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[0]).ToString().Trim(); //Sətir N:

                        if (p_var.n_rol == "3" || p_var.n_rol == "4") //rol Admin,SuperAdmin
                        {
                            button13.Enabled = true; 
                        }
                        
                    }
                }
            }
        }

        private void gridView2_RowClick(object sender, RowClickEventArgs e) //Aktlar siyahisinda sətrə Click 
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        my_metod_aktntosubid(view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim());//akta görə subid
                        if(MessageBox.Show(
                                "1. Sətir       №" + view1.GetRowCellValue(e.RowHandle, view1.Columns[0]).ToString().Trim()+"\n\n" +
                                "2. Akt         №" + view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim()+"\n\n" +
                                "3. Status      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim()+"\n\n" +
                                "4. Tarix       :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[3]).ToString().Trim().Substring(0, 10) +"\n\n" +
                                "5. Region      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[4]).ToString().Trim()+"\n\n" +
                                "6. Rayon       :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[5]).ToString().Trim()+"\n\n" +
                                "7. Qeyd        :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim()+"\n\n" +
                                "8. Mühəndis    :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[7]).ToString().Trim()+"\n\n" +
                                "9. Obyekt      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[13]).ToString().Trim() + "\n\n" +
                                "10.Abonent kodu:" + txtbxSubscriberNo.Text, "Açıqlama,davam etsin ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (!txtbxSubscriberNo.Text.Equals(string.Empty))
                            {
                                tabControl1.SelectTab(0); //TabControlda I punkta keçid
                                SendKeys.Send("{END}");
                                SendKeys.Send("{ENTER}");
                            }
                        }
                    }
                }
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e) // 1.setri nomreleme
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_RowCountChanged(object sender, EventArgs e) // 2.setri nomreleme
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f)
             + DevExpress.XtraGrid.Views.Grid.Drawing.GridPainter.Indicator.ImageSize.Width + 10;
        }
        
        public string my_metod_aktntosubid(string akt_num)  //Akta görə abonent kodunun tapılması
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_aktntosubid";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar); // OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 15;

            cmd.Parameters.Add("v_akt_num", OracleType.VarChar);
            cmd.Parameters["v_akt_num"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_num"].Value = akt_num; // aktın kodu

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(2): " + ex.Message);
                return ("E");
            }

            txtbxSubscriberNo.Text = (v_EXIT == "E") ? "" :v_EXIT; //Əgər tapırsa bu abonent kodu olacaq
            comboBoxEdit1.Properties.Items.Insert(0, txtbxSubscriberNo.Text.Trim());//Axrarış siyahısıns əlavə etmək

            conn.Close();
            return ("Y");
        }


        public void my_metod_3_SEAL(string s1, string s2)               //s1-Selectin şərti və s2-ya "S"-baxış,ya "D"-silmə
        {
            using (OleDbConnection oConn1 = new OleDbConnection())      // DEV_seal_BASE - doldurmaq
            {

                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("(PLOMBlar)Bir qədər gözləyin,");
                SplashScreenManager.Default.SetWaitFormDescription("məlumat yüklənir..."); 
                
                DataTable resultTable2 = new DataTable();
                resultTable2.Clear();
                gridControl3.DataSource = null;

                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    if (s2 == "S")                  //Sətirlərin gətrilməsi SELECT
                    {
                        oCmd1.CommandText = @"select SEAL_number, sign, date_operation, Region_n(subjectid) Reg , 
                        Rayon_n(matrixid) Ray, note,INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_NAME,doc_number, doc_date,
                        SEAL_id,subjectid, matrixid,object_name from azqaz.tex_bax_SEAL_base where " + s1;
                        resultTable2.Load(oCmd1.ExecuteReader());
                        p_var.n_chap_ucun_plomb = oCmd1.CommandText;
                    }
                    if (s2 == "D")                 //Sətirlərin serverdən silinməsi DELETE
                    {
                        oCmd1.CommandText = @"delete from azqaz.tex_bax_SEAL_base where " + s1;
                        my_metod_del_seal(oCmd1.CommandText, p_var.n_uzer_name);
                    }
//                    resultTable2.Load(oCmd1.ExecuteReader());
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(3): " + ex.Message);
                    SplashScreenManager.CloseForm(false);
                    return;
                }
                oConn1.Close();

                resultTable2.Columns.Add("SN", typeof(Int32)).SetOrdinal(0); // Sıra nömrəsinin əlavə edilməsi

                if (resultTable2.Rows.Count > 0)
                {
                    for (int i = 0; i < resultTable2.Rows.Count; i++)
                    {
                        resultTable2.Rows[i]["SN"] = i + 1; //Sətirlərin nömrələnməsi
                    }
                }

                gridControl3.DataSource = null;
                gridControl3.DataSource = resultTable2;
                gridControl3.ForceInitialize();

                //Griddə düymələr
                gridControl3.UseEmbeddedNavigator = true;
                gridControl3.EmbeddedNavigator.Buttons.Edit.Visible = false;
                gridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                gridControl3.EmbeddedNavigator.Buttons.Append.Visible = false;
                gridControl3.EmbeddedNavigator.Buttons.Remove.Visible = false;
                gridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                gridControl3.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən";

                gridControl3.EmbeddedNavigator.Buttons.First.Hint    = "Ilk sətir";
                gridControl3.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
                gridControl3.EmbeddedNavigator.Buttons.Prev.Hint     = "Əvvəlki sətir";

                gridControl3.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
                gridControl3.EmbeddedNavigator.Buttons.Next.Hint     = "Növbəti sətir";
                gridControl3.EmbeddedNavigator.Buttons.Last.Hint     = "Son sətir";
                //

                gridView3.RefreshData();

                if (resultTable2.Rows.Count > 0)
                {
                    gridView3.Appearance.HeaderPanel.Options.UseTextOptions = true;
                    gridView3.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    gridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView3.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView3.OptionsBehavior.Editable = true;


                    gridView3.BestFitColumns();

                    // gridView2.Columns["AKT_NUMBER"].Visible = false;
                    gridView3.Columns["SN"].Caption = " № ";
                    gridView3.Columns["SN"].Width = 35;
                    gridView3.Columns["SN"].ToolTip = "Sətrin sıra nömrəsi";
                    gridView3.Columns["SN"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["SEAL_NUMBER"].Caption = "Plomb №";
                    gridView3.Columns["SEAL_NUMBER"].Width = 70;
                    gridView3.Columns["SEAL_NUMBER"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["SIGN"].Caption = "Status";
                    gridView3.Columns["SIGN"].Width = 50;
                    gridView3.Columns["SIGN"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["REG"].Caption = "Region";
                    gridView3.Columns["REG"].Width = 55;
                    gridView3.Columns["REG"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["RAY"].Caption = "Rayon";
                    gridView3.Columns["RAY"].Width = 55;
                    gridView3.Columns["RAY"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["DATE_OPERATION"].Caption = "Əməliyyat tarixi";
                    gridView3.Columns["DATE_OPERATION"].Width = 110;
                    gridView3.Columns["DATE_OPERATION"].OptionsColumn.ReadOnly = true;


                    gridView3.Columns["NOTE"].Caption = "Qeyd";
                    gridView3.Columns["NOTE"].Width = 250;
                    gridView3.Columns["NOTE"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["INSPEKTOR_NAME"].Caption = "Mühəndis";
                    gridView3.Columns["INSPEKTOR_NAME"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["OBJECT_NAME"].Caption = "Obyekt";
                    gridView3.Columns["OBJECT_NAME"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["SEAL_ID"].OptionsColumn.ReadOnly = true;

                    gridView3.Columns["MATRIXID"].Visible = false;
                    gridView3.Columns["SUBJECTID"].Visible = false;
                    gridView3.Columns["DOC_NUMBER"].Visible = false;
                    gridView3.Columns["DOC_DATE"].Visible = false;
                    gridView3.Columns["SEAL_ID"].Visible = true;

                    gridView3.RefreshData();
                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";  

                    SplashScreenManager.CloseForm(false);

                }
            }

        }

        private void tabPage4_Enter(object sender, EventArgs e)  //SEAL_BASE dev_grid ilki doldurma
        {
            p_var.n_string = " rownum <= 300 ";// " SEAL_id >= 000 and SEAL_id <= 300 ";
            my_metod_3_SEAL(p_var.n_string, "S");
        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e) //SEAL_base
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                switch (View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("SIGN")))
                {
                    case "1":
                        e.Appearance.BackColor = Color.Yellow; //1 sarı
                        break;
                    case "2":
                        e.Appearance.BackColor = Color.FromArgb(80, 240, 131);//ForestGreen; //GreenYellow; //Green; 2 yaşıl
                        break;
                    case "3":
                        e.Appearance.BackColor = Color.Red; //3 qırmızı
                        break;
                }
            }
        }

        private void gridView3_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e) // plombda setirler
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e) // plombda setirler
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f)
             + DevExpress.XtraGrid.Views.Grid.Drawing.GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void button1_Click(object sender, EventArgs e) //Plombda siyahısindan ləğv edilmesi(3 statusuna keçirilməsi)
        {

            if (Sealleqv.textBox2.Text.Trim() == "2") //1,3-statusundan fərqli akt ləğv edilə bilməz
            {
                MessageBox.Show("Diqqət,2(yaşıl) statuslu PLOMBlar ləğv edilə bilməz !");
                return;
            }
            
            Sealleqv.ShowDialog();

            if (p_var.n_rez == "Y")
            {
                //p_var.n_rez = my_metod_status3_seal(Sealleqv.textBox1.Text.Trim(), p_var.n_uzer_name, Sealleqv.textBox3.Text.Trim(), "3");
                p_var.n_rez = my_metod_status3_seal(Sealleqv.textBox1.Text.Trim(), p_var.n_uzer_name, Sealleqv.textBox3.Text.Trim(), (Sealleqv.textBox2.Text.Trim() == "1") ? "3" : "1");
                if (p_var.n_rez == "Y")
                {
                    DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                    row[2] = (Sealleqv.textBox2.Text.Trim() == "1") ? "3" : "1"; ////Status dəyişir
                    //row[2] = "3"; // Sealleqv.textBox2.Text.Trim(); //Status dəyişir
                    row[6] = Sealleqv.textBox3.Text.Trim(); //Qeyd dəyişir
                    //gridView2.RefreshRow(2);
                }
            }
            button1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e) //Plomb əlavəsi
        {
            PlombElave.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                MessageBox.Show("PLOMBların əlavəsi əməliyyat başa çatdı !!!");
                my_metod_3_SEAL(p_var.n_string, "S");
            }
        }

        private void button5_Click(object sender, EventArgs e) //Plomb silinməsi
        {
            PlombAxtar.Text = "PLOMBun silinmesi";
            PlombAxtar.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                if (p_var.n_string.ToString().Contains("SIGN='2'") || p_var.n_string.ToString().Contains("SIGN='3'"))
                {
                    MessageBox.Show("2 və ya 3 statuslu PLOMBlar silinə bilməz !!!");
                }
                else
                {
                    p_var.n_string = p_var.n_string + " AND NOT (SIGN IN ('2','3'))";
                    my_metod_3_SEAL(p_var.n_string, "D");
                }
            }
 
        }

        private void button7_Click(object sender, EventArgs e) //Plomb axtarışı
        {
            PlombAxtar.Text = "PLOMBın axtarışı";
            PlombAxtar.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                gridControl3.DataSource = null;
                my_metod_3_SEAL(p_var.n_string, "S");
                button20.Enabled = true;
            }

        }

        public string my_metod_status3_seal(string s1, string user, string s3, string s4) //Plombda ləğv etmədə statu 3 keçirmə
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_status_seal_3";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_aktn", OracleType.VarChar);
            cmd.Parameters["v_aktn"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_aktn"].Value = s1; // plomb nömrəsi

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = user; // proqram istifadəşisi

            cmd.Parameters.Add("v_qeyd", OracleType.VarChar);
            cmd.Parameters["v_qeyd"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_qeyd"].Value = s3; // qeyd

            cmd.Parameters.Add("v_status", OracleType.VarChar);
            cmd.Parameters["v_status"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_status"].Value = s4; // status

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(4): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return ("Y");
        }

        private void gridView3_RowClick(object sender, RowClickEventArgs e) //Plomblar siyahısında klik
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        my_metod_sealtosubid(view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim());//plomba görə subid
                        if(MessageBox.Show(
                                "1. Sətir       №" + view1.GetRowCellValue(e.RowHandle, view1.Columns[0]).ToString().Trim() + "\n\n" +
                                "2. Plomb       №" + view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim() + "\n\n" +
                                "3. Status      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim() + "\n\n" +
                                "4. Tarix       :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[3]).ToString().Trim().Substring(0, 10) + "\n\n" +
                                "5. Region      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[4]).ToString().Trim() + "\n\n" +
                                "6. Rayon       :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[5]).ToString().Trim() + "\n\n" +
                                "7. Qeyd        :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim() + "\n\n" +
                                "8. Mühəndis    :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[7]).ToString().Trim() + "\n\n" +
                                "9. Obyekt      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[13]).ToString().Trim() + "\n\n" +
                                "10.Abonent kodu:" + txtbxSubscriberNo.Text, "Açıqlama,davam etsin ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (!txtbxSubscriberNo.Text.Equals(string.Empty))
                            {
                                tabControl1.SelectTab(0); //TabControlda I punkta keçid
                                SendKeys.Send("{END}");
                                SendKeys.Send("{ENTER}");
                            }
                        }
                    }
                }
            }
        }

        private void gridView3_RowCellClick(object sender, RowCellClickEventArgs e) //Plomblarda ləğv sətirlər
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        Sealleqv.textBox1.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim(); //Plomb N:
                        Sealleqv.textBox2.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim(); //Status
                        Sealleqv.textBox3.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim(); //Qeyd
                        Sealleqv.textBox4.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[0]).ToString().Trim(); //Sətir N:
                        if (p_var.n_rol == "3" || p_var.n_rol == "4") //rol Admin,SuperAdmin
                        {
                            button1.Enabled = true;
                        }
                    }
                }
            }
        }

        public string my_metod_sealtosubid(string plomb_num)  //Plomba görə abonent kodunun tapılması
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_sealtosubid";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 15;

            cmd.Parameters.Add("v_akt_num", OracleType.VarChar);
            cmd.Parameters["v_akt_num"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_num"].Value = plomb_num; // plomb kodu

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(5): " + ex.Message);
                return ("E");
            }

            txtbxSubscriberNo.Text = (v_EXIT == "E") ? "" : v_EXIT; //Əgər tapırsa bu abonent kodu olacaq

            conn.Close();
            return ("Y");
        }

        private void tabPage5_Enter(object sender, EventArgs e) //inzibatçılığa giriş və doldurmaq
        {
            using (OleDbConnection oConn1 = new OleDbConnection())      // DEV_inzibatçiliq - doldurmaq
            {
                DataTable resultTable4 = new DataTable();
                resultTable4.Clear();
                gridControl4.DataSource = null;
                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    oCmd1.CommandText = @"insert into AZQAZ.tex_bax_user_permissions (user_id,user_name)
                                          select user_id,user_name from 
                                            ( select user_id,user_name from ahali.inf_users t1
                                               MINUS
                                              select user_id,user_name from azqaz.tex_bax_user_permissions t2
                                            )";
                    resultTable4.Load(oCmd1.ExecuteReader()); //Yeni istifadəçiləri əlavə etmək
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(-6): " + ex.Message);
                    return;
                }
                oConn1.Close();
                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    oCmd1.CommandText = @"select user_id, user_name, read_only,
                                          operator, admin,superadmin,obyekt,azqaz.agis_user(user_name) fio,region from AZQAZ.tex_bax_user_permissions 
                                          order by read_only,operator, admin,superadmin ASC";
                   
                    resultTable4.Load(oCmd1.ExecuteReader());
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(6): " + ex.Message);
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
                //

                gridView4.RefreshData();

                if (resultTable4.Rows.Count > 0)
                {
                    gridView4.Appearance.HeaderPanel.Options.UseTextOptions = true;
                    gridView4.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    gridView4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView4.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    gridView4.OptionsBehavior.Editable = false;

                    //gridView4.OptionsView.ShowAutoFilterRow = false; // axtarış sətrini gizlət                   

                    gridView4.BestFitColumns();

                    gridView4.Columns["USER_ID"].Caption = " № ";
                    gridView4.Columns["USER_ID"].Width = 35;
                    
                    gridView4.Columns["USER_NAME"].Caption = "Istifadəçi";
                    gridView4.Columns["USER_NAME"].Width = 150;

                    gridView4.Columns["SUPERADMIN"].Caption = "SuperAdmin(4)";
                    gridView4.Columns["SUPERADMIN"].Width = 120;

                    gridView4.Columns["ADMIN"].Caption = "Admin(3)";
                    gridView4.Columns["ADMIN"].Width = 80;

                    gridView4.Columns["OPERATOR"].Caption = "Operator(2)";
                    gridView4.Columns["OPERATOR"].Width = 100;

                    gridView4.Columns["READ_ONLY"].Caption = "Baxış(1)";
                    gridView4.Columns["READ_ONLY"].Width = 80;

                    gridView4.Columns["OBYEKT"].Caption = "Obyekt(A-Əhali,S-Sənaye,I-Istixana)";
                    gridView4.Columns["OBYEKT"].Width = 140; // 285;

                    gridView4.Columns["FIO"].Caption = "Adı";
                    gridView4.Columns["FIO"].Width = 150;

                    gridView4.Columns["REGION"].Caption = "Region";
                    gridView4.Columns["REGION"].Width = 125;

                    gridView4.RefreshData();
              
                }
            }
        }

        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        Inzibatci.textBox1.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim(); //Istifadəci adı
                        Inzibatci.textBox2.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim(); //Baxış rolu
                        Inzibatci.textBox3.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[3]).ToString().Trim(); //Operator rolu
                        Inzibatci.textBox4.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[4]).ToString().Trim(); //Admin rolu
                        Inzibatci.textBox5.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[5]).ToString().Trim(); //SuperAdmin rolu
                        Inzibatci.textBox6.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim(); //Obyek
                        Inzibatci.label7.Text   = view1.GetRowCellValue(e.RowHandle, view1.Columns[7]).ToString().Trim(); //Adı
                        Inzibatci.textBox7.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[8]).ToString().Trim(); //Obyek

                        Inzibatci.Text = "İstifadeçiye rolun teyin edilmesi";
                        Inzibatci.ShowDialog();

                        if (p_var.n_rez == "Y")
                        {
                            p_var.n_rez = my_metod_inzibetci(Inzibatci.textBox1.Text.Trim(),
                                                             Inzibatci.textBox2.Text.Trim(),
                                                             Inzibatci.textBox3.Text.Trim(),
                                                             Inzibatci.textBox4.Text.Trim(),
                                                             Inzibatci.textBox5.Text.Trim(),
                                                             Inzibatci.textBox6.Text.Trim(),
                                                             Inzibatci.textBox7.Text.Trim()
                                                             );

                            if (p_var.n_rez == "Y")
                            {
                                DataRow row = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                                row[2] = Inzibatci.textBox2.Text.Trim();
                                row[3] = Inzibatci.textBox3.Text.Trim();
                                row[4] = Inzibatci.textBox4.Text.Trim();
                                row[5] = Inzibatci.textBox5.Text.Trim();
                                row[6] = Inzibatci.textBox6.Text.Trim();
                                row[8] = Inzibatci.textBox7.Text.Trim();
                                p_var.n_region = Inzibatci.textBox7.Text.Trim();
                            }
                        }
                    }
                }
            }
        }
        public string my_metod_inzibetci(string s1, string s2, string s3, string s4, string s5, string s6,string s7) //Rolun təyini
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_inzibatci_rol";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_user_name", OracleType.VarChar);
            cmd.Parameters["v_user_name"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user_name"].Value = s1; // User_name

            cmd.Parameters.Add("v_xana1", OracleType.VarChar);
            cmd.Parameters["v_xana1"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_xana1"].Value = s2; // Baxış rolu

            cmd.Parameters.Add("v_xana2", OracleType.VarChar);
            cmd.Parameters["v_xana2"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_xana2"].Value = s3; // Operator rolu

            cmd.Parameters.Add("v_xana3", OracleType.VarChar);
            cmd.Parameters["v_xana3"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_xana3"].Value = s4; // Admin rolu

            cmd.Parameters.Add("v_xana4", OracleType.VarChar);
            cmd.Parameters["v_xana4"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_xana4"].Value = s5; // Superadmin rolu

            cmd.Parameters.Add("v_xana5", OracleType.VarChar);
            cmd.Parameters["v_xana5"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_xana5"].Value = s6; // A-S-I(Ahali,Sanaye,Istixana) Obyekt

            cmd.Parameters.Add("v_reg", OracleType.VarChar);
            cmd.Parameters["v_reg"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_reg"].Value = s7; // A-S-I(Ahali,Sanaye,Istixana) Obyekt
            
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(7): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return ("Y");
     }

        private void tabPage6_Enter(object sender, EventArgs e)  // ? giriş
     {
            comboBox1.Visible = (p_var.n_rol == "3" || p_var.n_rol == "4") ? true : false;

            textBox5.Text = p_var.n_uzer_name;
            switch (p_var.n_rol)
                {
                    case "1":
                        textBox6.Text ="1-Baxış";
                        break;
                    case "2":
                        textBox6.Text ="2-Operator";
                        break;
                    case "3":
                        textBox6.Text ="3-Admin";
                        break;
                    case "4":
                        textBox6.Text ="4-SuperAdmin";
                        break;
                }
            textBox7.Text = my_metod_ip(p_var.n_uzer_name); //local IP
            textBox8.Text = Application.ProductVersion;     //proqramın versiyası
            switch (p_var.n_obj)
                {
                    case "A":
                        textBox9.Text ="Əhali";
                        break;
                    case "S":
                        textBox9.Text ="Sənaye";
                        break;
                    case "I":
                        textBox9.Text ="Istixana";
                        break;
                }


            //******
            comboBox1.SelectedIndex=comboBox1.FindString(p_var.n_obj);
//******
            textBox10.Text =(System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)) == 8)? ",MP_64x" : ",MP_32x";

            string n_maj_min = String.Empty;
            int majorVer     = System.Environment.OSVersion.Version.Major;
            int minorVer     = System.Environment.OSVersion.Version.Minor;

            switch (majorVer)
            {
                case 5:
                     n_maj_min = (minorVer == 1) ? "Windows Xp 32x " : n_maj_min;
                     n_maj_min = (minorVer == 2) ? "Windows Xp 64x " : n_maj_min;
                     break;
                case 6:
                     n_maj_min = (minorVer == 0) ? "Windows Vista  " : n_maj_min;
                     n_maj_min = (minorVer == 1) ? "Windows 7      " : n_maj_min;
                     n_maj_min = (minorVer == 2) ? "Windows 8      " : n_maj_min;
                     n_maj_min = (minorVer == 3) ? "Windows 10     " : n_maj_min;
                     break;
            }

            textBox10.Text = n_maj_min + textBox10.Text;// Environment.OSVersion.Platform.ToString();//ƏS in tipi 32 və ya 64

            textBox11.Text = p_var.n_conn1.Substring(160,12);           //SID ORACLE
            textBox12.Text = p_var.n_region.Substring(0,p_var.n_region.IndexOf(':'));
            textBox14.Text = Clipboard.GetText();
                //p_var.n_region;
     }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text=comboBox1.SelectedItem.ToString();
            p_var.n_obj = comboBox1.SelectedItem.ToString().Substring(0, 1);

            p_var.n_rez = my_metod_inzibetci(p_var.n_uzer_name,             // User_name
                                             "",                            // Baxış rolu
                                             "",                            // Operator rolu
                                            (p_var.n_rol == "3") ? "3" : "",// Admin rolu
                                            (p_var.n_rol == "4") ? "4" : "",// Superadmin rolu
                                             p_var.n_obj,                   // A-S-I(Ahali,Sanaye,Istixana) Obyekt
                                             p_var.n_region                 // Region
                                            );
        }

        public string my_metod_ip(string s1) //Local IP təyini
     {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_ip";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 20;

            cmd.Parameters.Add("v_user_name", OracleType.VarChar);
            cmd.Parameters["v_user_name"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user_name"].Value = s1; // User_name

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(8): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return (v_EXIT);
     }

        private void button8_Click(object sender, EventArgs e)
        {
            FORM_ZIP_ORA.Text = "Proqramın yeni versiyasının klient üçün hazırlanmasl";
            FORM_ZIP_ORA.ShowDialog();
        }


        public void my_cihaz_aktla(string s1)
        {
            using (OleDbConnection oConn1 = new OleDbConnection())      // dataGridView2 - doldurmaq
            {
               /* p_var.n_rez = my_metod_0(txtbxSubscriberNo.Text, p_var.n_uzer_name); //есть ли аппарат или нет
                if (p_var.n_rez == "E")
                {
                    return;
                }
                */
                p_var.n_string = "";
                DataTable dtAkt1 = new DataTable();

                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                     switch (p_var.n_obj)
                    {
                        case "A":
                            oCmd1.CommandText = @"select subid, apparat_id,azqaz.tex_bax_cihaz_name(apparat_id,'A') name,plomb_num,
                                                 say_id,azqaz.fio_A(subid) fio,azqaz.unvan_A(subid) unvan,azqaz.meter_nom_a(subid,1) kscet, 
                                                 azqaz.METER_NaM_a(azqaz.METER_idN_a(subid,1)) Tip_name,azqaz.METER_idN_a(subid,1) Tip_KOD,plomb_date,akt_num 
                                                 from azqaz.tex_bax_apparats where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "' and akt_num='" + s1.Trim() + "'";
                            break;
                        case "S":
                            oCmd1.CommandText = @"select subid, apparat_id,azqaz.tex_bax_cihaz_name(apparat_id,'S') name,plomb_num,
                                                 say_id,azqaz.fio_S(subid) fio,azqaz.unvan_s(subid) unvan,azqaz.meter_nom_s(subid,1) kscet, 
                                                 azqaz.METER_NaM_s(azqaz.meTER_idN_s(subid,1)) Tip_name,azqaz.METER_idN_s(subid,1) Tip_KOD,plomb_date,akt_num  
                                                 from azqaz.tex_bax_apparats where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj +"' and akt_num='" + s1.Trim() + "'";
                            break;
                        case "I":
                            oCmd1.CommandText = @"select subid, apparat_id,azqaz.tex_bax_cihaz_name(apparat_id,'I') name,plomb_num,
                                                 say_id,azqaz.fio_i(subid) fio,azqaz.unvan_i(subid) unvan,azqaz.meter_nom_i(subid,1) kscet, 
                                                 azqaz.METER_NaM_i(azqaz.meTER_idN_i(subid,1)) Tip_name,azqaz.METER_idN_i(subid,1) Tip_KOD,plomb_date,akt_num
                                                 from azqaz.tex_bax_apparats where subid = '" + txtbxSubscriberNo.Text.Trim() + "' and object_name='" + p_var.n_obj + "' and akt_num='" + s1.Trim() + "'";
                            break;
                    }

                    dtAkt1.Load(oCmd1.ExecuteReader());

                    dtAkt1.Columns.Add("SN", typeof(Int32)).SetOrdinal(0);
                    if (dtAkt1.Rows.Count > 0)
                    {
                        for (int i = 0 ; i < dtAkt1.Rows.Count ; i++)
                        {
                            textBox2.Text = dtAkt1.Rows[i]["FIO"].ToString();
                            p_var.n_fio = dtAkt1.Rows[i]["FIO"].ToString();
                            textBox3.Text = dtAkt1.Rows[i]["UNVAN"].ToString();
                            textBox4.Text = dtAkt1.Rows[i]["KSCET"].ToString();
                            //textBox13.Text = dtAkt1.Rows[i]["BORC"].ToString().Trim();
                            textBox1.Text = dtAkt1.Rows[i]["TIP_NAME"].ToString().Trim() + "(Id:" + dtAkt1.Rows[i]["TIP_KOD"].ToString().Trim() + ")";
                            dtAkt1.Rows[i]["SN"] = i + 1; //Sətirlərin nömrələnməsi
                            p_var.n_string = p_var.n_string + ":" + dtAkt1.Rows[i]["APPARAT_ID"].ToString().Trim();
                        }
                    }
                    p_var.n_string = p_var.n_string + ":";
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(9): " + ex.Message);
                    return;
                }
                oConn1.Close();

                gridControl1.DataSource = dtAkt1;
                gridControl1.ForceInitialize();

                if (dtAkt1.Rows.Count > 0)
                {
                    gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
                    gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.OptionsBehavior.Editable = false;

                    gridView1.OptionsView.ShowAutoFilterRow = false; // axtarış sətrini gizlət

                    gridView1.BestFitColumns();

                    gridView1.Columns["SUBID"].Visible = false;
                    gridView1.Columns["FIO"].Visible = false;
                    gridView1.Columns["UNVAN"].Visible = false;
                    gridView1.Columns["KSCET"].Visible = false;
                    gridView1.Columns["TIP_NAME"].Visible = false;
                    gridView1.Columns["TIP_KOD"].Visible = false;
                    gridView1.Columns["SN"].Caption = " № ";
                    gridView1.Columns["SN"].Width = 35;
                    gridView1.Columns["APPARAT_ID"].Caption = "Cihazın kodu";
                    gridView1.Columns["NAME"].Caption = "Cihazın adı";
                    gridView1.Columns["NAME"].Width = 350;
                    gridView1.Columns["PLOMB_NUM"].Caption = "Plomb №";
                    gridView1.Columns["PLOMB_NUM"].Width = 100;
                    gridView1.Columns["PLOMB_DATE"].Caption = "Tarix";
                    gridView1.Columns["AKT_NUM"].Caption = "Akt №";

                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";

                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                }
                else
                {
                    switch (p_var.n_obj)
                    {
                        case "A":
                            //merlin.Speak("Bu Əhali obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            MessageBox.Show("Bu Əhali obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            break;
                        case "S":
                            //merlin.Speak("Bu Sənaye obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            MessageBox.Show("Bu Sənaye obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            break;
                        case "I":
                            //merlin.Speak("Bu Istixana obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            MessageBox.Show("Bu Istixana obyekti:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                            break;
                    }
                    //merlin.Speak("Bu obyekt:" + txtbxSubscriberNo.Text.Trim() + " tapılmadı...", "");
                    //merlin.Hide(true);
                    SplashScreenManager.CloseForm(false);
                    return;
                }
            }
        
        }

        private void comboBoxEdit1_Properties_Click(object sender, EventArgs e)
        {
            comboBoxEdit1.Width = 100;//genişləndirmək
        }

        private void comboBoxEdit1_Properties_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            comboBoxEdit1.Width = 18;//qisaltmaq
            if (comboBoxEdit1.SelectedIndex != -1)
            {
                /*
                  for (int i = comboBoxEdit1.Properties.Items.Count - 1 ; i >= 0 ; i--)
                  {
                    if (comboBoxEdit1.SelectedItem.ToString().Trim() == comboBoxEdit1.Properties.Items[i].ToString())
                       {
                          comboBoxEdit1.Properties.Items.RemoveAt(i);
                          //MessageBox.Show(i.ToString());
                       }
                  }
                  comboBoxEdit1.Properties.Items.Insert(0, txtbxSubscriberNo.Text.Trim());
                */
                txtbxSubscriberNo.Text = comboBoxEdit1.SelectedItem.ToString().Trim();
                comboBoxEdit1.Refresh();
                btnSearch.PerformClick();
            }

        }

        private void comboBoxEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            comboBoxEdit1.Width = 18;//qisaltmaq
        }

        private void txtbxSubscriberNo_DoubleClick(object sender, EventArgs e)
        {
            if (p_var.n_uzer_name.Substring(0,1)=="N" || p_var.n_uzer_name.Substring(0,1)=="b") //(p_var.n_uzer_name.Substring(0, 1) == "N")
            {
                return;
            }
            
            if ((p_var.n_rol == "3") || (p_var.n_rol == "4")) // ancaq admin və superadmin
            {
                DATAKORR.Text = "AKT(lar)ın düzelişi";
                p_var.n_subid = txtbxSubscriberNo.Text.Trim();
                DATAKORR.ShowDialog();
            }
        }

        public string my_metod_del_akt(string s1, string s2)          //delete akt_base 
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_akt_del";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 20;

            cmd.Parameters.Add("v_s1", OracleType.VarChar);
            cmd.Parameters["v_s1"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_s1"].Value = s1;            // göndərilən əmir

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = s2;            // göndərilən əmir

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
                //MessageBox.Show(v_EXIT);
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(10): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return (v_EXIT);
        }

        public string my_metod_del_seal(string s1, string s2)          //delete akt_base 
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_akt_seal";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 20;

            cmd.Parameters.Add("v_s1", OracleType.VarChar);
            cmd.Parameters["v_s1"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_s1"].Value = s1;            // göndərilən əmir

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = s2;            // göndərilən əmir

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(11): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return (v_EXIT);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DOQ.ShowDialog();
        }

        public void my_metod_doq(string s1, string s2)                   //s1-Selectin şərti və s2-ya "S"-baxış,ya "D"-silmə
        {
            using (OleDbConnection oConn1 = new OleDbConnection())       // DEV_dataGridView5 - doldurmaq
            {

                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("(MÜQAVİLƏlər)Bir qədər gözləyin,");
                SplashScreenManager.Default.SetWaitFormDescription("məlumat yüklənir...");               
                
                
                DataTable resultTable1 = new DataTable();
                resultTable1.Clear();
                gridControl5.DataSource = null;

                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    if (s2 == "S")                  //Sətirlərin gətrilməsi SELECT TEX_BAX_Inspektor_name
                    {
                        oCmd1.CommandText = @"select DOQ_number, sign, date_operation, azqaz.Region_n(subjectid) Reg , 
                        azqaz.Rayon_n(matrixid) Ray, note,azqaz.tex_bax_INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_NAME,doc_number, doc_date,
                        DOQ_id,subjectid, matrixid,object_name from azqaz.tex_bax_DOQOVOR_BASE where " + s1;

                        p_var.n_chap_ucun_doq = oCmd1.CommandText;
                        resultTable1.Load(oCmd1.ExecuteReader());
                    }
                    if (s2 == "D")                 //Sətirlərin serverdən silinməsi DELETE
                    {
                        oCmd1.CommandText = @"delete from azqaz.tex_bax_DOQOVOR_BASE where " + s1;
                        my_metod_del_doq(oCmd1.CommandText, p_var.n_uzer_name);
                    }
                    //                    resultTable1.Load(oCmd1.ExecuteReader());
                }
                catch (Exception ex)
                {
                    //merlin.Hide(true);
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(12): " + ex.Message);
                    SplashScreenManager.CloseForm(false);
                   
                    return;
                }
                oConn1.Close();

                resultTable1.Columns.Add("SN", typeof(Int32)).SetOrdinal(0); // Sıra nömrəsinin əlavə edilməsi

                if (resultTable1.Rows.Count > 0)
                {
                    for (int i = 0 ; i < resultTable1.Rows.Count ; i++)
                    {
                        resultTable1.Rows[i]["SN"] = i + 1; //Sətirlərin nömrələnməsi
                    }
                }

                gridControl5.DataSource = null;
                gridControl5.DataSource = resultTable1;
                gridControl5.ForceInitialize();

                //Griddə düymələr
                gridControl5.UseEmbeddedNavigator = true;
                gridControl5.EmbeddedNavigator.Buttons.Edit.Visible = false;
                gridControl5.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                gridControl5.EmbeddedNavigator.Buttons.Append.Visible = false;
                gridControl5.EmbeddedNavigator.Buttons.Remove.Visible = false;
                gridControl5.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                gridControl5.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən";

                gridControl5.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
                gridControl5.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
                gridControl5.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

                gridControl5.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
                gridControl5.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
                gridControl5.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";
                //

                gridView5.RefreshData();

                if (resultTable1.Rows.Count > 0)
                {
                    gridView5.Appearance.HeaderPanel.Options.UseTextOptions = true;
                    gridView5.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    gridView5.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView5.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    //gridView2.OptionsBehavior.Editable = false;

                    gridView5.OptionsBehavior.Editable = true; // false;

                    gridView5.BestFitColumns();

                    // gridView2.Columns["AKT_NUMBER"].Visible = false;
                    gridView5.Columns["SN"].Caption = " № ";
                    gridView5.Columns["SN"].Width = 35;
                    gridView5.Columns["SN"].ToolTip = "Sətrin sıra nömrəsi";
                    gridView5.Columns["SN"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["DOQ_NUMBER"].Caption = "Müqavilə №";
                    gridView5.Columns["DOQ_NUMBER"].Width = 90;
                    gridView5.Columns["DOQ_NUMBER"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["SIGN"].Caption = "Status";
                    gridView5.Columns["SIGN"].Width = 50;
                    gridView5.Columns["SIGN"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["REG"].Caption = "Region";
                    gridView5.Columns["REG"].Width = 55;
                    gridView5.Columns["REG"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["RAY"].Caption = "Rayon";
                    gridView5.Columns["RAY"].Width = 55;
                    gridView5.Columns["RAY"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["DATE_OPERATION"].Caption = "Əməliyyat tarixi";
                    gridView5.Columns["DATE_OPERATION"].Width = 110;
                    gridView5.Columns["DATE_OPERATION"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["NOTE"].Caption = "Qeyd";
                    gridView5.Columns["NOTE"].Width = 250;
                    gridView5.Columns["NOTE"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["INSPEKTOR_NAME"].Caption = "Mühəndis";
                    gridView5.Columns["INSPEKTOR_NAME"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["OBJECT_NAME"].Caption = "Obyekt";
                    gridView5.Columns["OBJECT_NAME"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["DOC_NUMBER"].Visible = false;
                    gridView5.Columns["DOC_DATE"].Visible = false;
                    gridView5.Columns["SUBJECTID"].Visible = false;
                    gridView5.Columns["MATRIXID"].Visible = false;
                    gridView5.Columns["DOQ_ID"].OptionsColumn.ReadOnly = true;
                    gridView5.Columns["DOQ_ID"].Visible = true;

                    gridView5.RefreshData();

                    SplashScreenManager.CloseForm(false);
                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                    //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";                   
                }
            }

        }

        private void tabPage7_Enter(object sender, EventArgs e)   // Müqavilələr bazası
        {
            p_var.n_string = " rownum <= 300"; // " doq_id >= 000 and doq_id <= 300 ";
            my_metod_doq(p_var.n_string, "S");
        }

        private void gridView5_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView5_RowCountChanged(object sender, EventArgs e)  //Müqavilədə say
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f)
             + DevExpress.XtraGrid.Views.Grid.Drawing.GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void gridView5_RowStyle(object sender, RowStyleEventArgs e)  //Müqavilədə say
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                switch (View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("SIGN")))
                {
                    case "1":
                        e.Appearance.BackColor = Color.Yellow; //1 sarı
                        break;
                    case "2":
                        e.Appearance.BackColor = Color.FromArgb(80, 240, 131);//ForestGreen; //GreenYellow; //Green; 2 yaşıl
                        break;
                    case "3":
                        e.Appearance.BackColor = Color.Red; //3 qırmızı
                        break;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e) //müqavilə ləğv 3
        {
            if (Doqleqv.textBox2.Text.Trim() == "2") //1,3-statusundan ferqli akt ləğv edilə bilməz
            {
                MessageBox.Show("Diqqət,2(yaşıl) statuslu Müqavilə ləğv edilə biməz !");
                return;
            }
            Doqleqv.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                p_var.n_rez = my_metod_doq3(Doqleqv.textBox1.Text.Trim(), p_var.n_uzer_name, Doqleqv.textBox3.Text.Trim(), 
                                               (Doqleqv.textBox2.Text.Trim() == "1") ? "3" : "1");
                if (p_var.n_rez == "Y")
                {
                    DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                    row[2] = (Doqleqv.textBox2.Text.Trim() == "1") ? "3" : "1";
                    row[6] = Doqleqv.textBox3.Text.Trim(); //Qeyd dəyişir
                }
            }
            button14.Enabled = false;
        }

        private void gridView5_RowCellClick(object sender, RowCellClickEventArgs e) //
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        Doqleqv.textBox1.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim(); //Plomb N:
                        Doqleqv.textBox2.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim(); //Status
                        Doqleqv.textBox3.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim(); //Qeyd
                        Doqleqv.textBox4.Text = view1.GetRowCellValue(e.RowHandle, view1.Columns[0]).ToString().Trim(); //Sətir N:
                        if (p_var.n_rol == "3" || p_var.n_rol == "4") //rol Admin,SuperAdmin
                        {
                            button14.Enabled = true;
                        }
                    }
                }
            }

        }

        private void gridView5_RowClick(object sender, RowClickEventArgs e)
        {
            var view1 = sender as GridView;
            if (view1 != null)
            {
                if (e.RowHandle != -999997)
                {
                    if (view1.Columns.Count > 0)
                    {
                        //MessageBox.Show(view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim());
                        my_metod_doqtosubid(view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim());//müq görə subid
                        if (MessageBox.Show(
                                "1. Sətir       №" + view1.GetRowCellValue(e.RowHandle, view1.Columns[0]).ToString().Trim() + "\n\n" +
                                "2. Müqavilə    №" + view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim() + "\n\n" +
                                "3. Status      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[2]).ToString().Trim() + "\n\n" +
                                "4. Tarix       :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[3]).ToString().Trim().Substring(0, 10) + "\n\n" +
                                "5. Region      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[4]).ToString().Trim() + "\n\n" +
                                "6. Rayon       :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[5]).ToString().Trim() + "\n\n" +
                                "7. Qeyd        :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[6]).ToString().Trim() + "\n\n" +
                                "8. Mühəndis    :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[7]).ToString().Trim() + "\n\n" +
                                "9. Obyekt      :" + view1.GetRowCellValue(e.RowHandle, view1.Columns[13]).ToString().Trim() + "\n\n" +
                                "10.Abonent kodu:" + txtbxSubscriberNo.Text, "Açıqlama,davam etsin ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (!txtbxSubscriberNo.Text.Equals(string.Empty))
                            {
                                tabControl1.SelectTab(0); //TabControlda I punkta keçid
                                SendKeys.Send("{END}");
                                SendKeys.Send("{ENTER}");
                            }
                        }
                    }
                }
            }
        }

        public string my_metod_doqtosubid(string akt_num)  //Muq görə abonent kodunun tapılması
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_doqtosubid";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar); // OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 15;

            cmd.Parameters.Add("v_akt_num", OracleType.VarChar);
            cmd.Parameters["v_akt_num"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_akt_num"].Value = akt_num; // aktın kodu

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(13): " + ex.Message);
                return ("E");
            }

            txtbxSubscriberNo.Text = (v_EXIT == "E") ? "" : v_EXIT; //Əgər tapırsa bu abonent kodu olacaq
            comboBoxEdit1.Properties.Items.Insert(0, txtbxSubscriberNo.Text.Trim());//Axrarış siyahısıns əlavə etmək

            conn.Close();
            return ("Y");
        }

        public string my_metod_doq3(string s1, string user, string s3, string s4) //Ləğv etmədə statu 3 keçirmə Müqavilədə
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_doq_3";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.Number);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_doqn", OracleType.VarChar);
            cmd.Parameters["v_doqn"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_doqn"].Value = s1; // akt nömrəsi

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = user; // proqram istifadəşisi

            cmd.Parameters.Add("v_qeyd", OracleType.VarChar);
            cmd.Parameters["v_qeyd"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_qeyd"].Value = s3; // qeyd

            cmd.Parameters.Add("v_status", OracleType.VarChar);
            cmd.Parameters["v_status"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_status"].Value = s4; // status

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(14): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return ("Y");
        }

        private void button16_Click(object sender, EventArgs e) // müqavilə elavə +
        {
            DoqElave.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                MessageBox.Show("Müqvilə əlavəsi əməliyyat başa çatdı !!!");
                my_metod_doq(p_var.n_string, "S");
            }

        }

        private void button17_Click(object sender, EventArgs e) // Müqavilədə axtarış
        {
            DoqAxtar.Text = "Müqavilələrin axtarışı";
            DoqAxtar.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                gridControl5.DataSource = null;
                my_metod_doq(p_var.n_string, "S");
                button21.Enabled = true;
            }
        }

        private void button15_Click(object sender, EventArgs e) // Müavilədə silinmə
        {
            DoqAxtar.Text = "Müqavilələrin silinmesi";
            DoqAxtar.ShowDialog();
            if (p_var.n_rez == "Y")
            {
                if (p_var.n_string.ToString().Contains("SIGN='2'") || p_var.n_string.ToString().Contains("SIGN='3'"))
                {
                    MessageBox.Show("2 və ya 3 statuslu Müqavilələr silinə bilməz !!!");
                }
                else
                {
                    p_var.n_string = p_var.n_string + " AND NOT (SIGN IN ('2','3'))";
                    my_metod_doq(p_var.n_string, "D");
                }
            }
        }
        public string my_metod_del_doq(string s1, string s2)          //delete doqovor_base 
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AZQAZ.tex_bax_doq_del";     // Name_function
            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 20;

            cmd.Parameters.Add("v_s1", OracleType.VarChar);
            cmd.Parameters["v_s1"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_s1"].Value = s1;            // göndərilən əmir

            cmd.Parameters.Add("v_user", OracleType.VarChar);
            cmd.Parameters["v_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_user"].Value = s2;            // göndərilən əmir

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
                //MessageBox.Show(v_EXIT);
            }
            catch (Exception ex)
            {
                //merlin.Hide(true);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Serverə müraciətdə xəta yarandı(15): " + ex.Message);
                return ("E");
            }
            conn.Close();
            return (v_EXIT);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            textBox12.Text = p_var.n_region;
        }

        private void button18_Click(object sender, EventArgs e) // Vesiqe,telefon...
        {
            Ves_Tel.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e) //Aklarda seçimin çapı
        {
                //MessageBox.Show(p_var.n_chap_ucun_akt);
                report1.Load("FORMAN15.frx");
                //MessageBox.Show(Forma_N14.comboBox1.Text.Trim());
                TableDataSource table15 = report1.GetDataSource("T") as TableDataSource;

                table15.SelectCommand = p_var.n_chap_ucun_akt;
                table15.Connection.ConnectionString = p_var.n_conn;
                report1.Show();
          return;
        }

        private void button20_Click(object sender, EventArgs e) //Plomblarda seçimin çapı
        {
            //MessageBox.Show(p_var.n_chap_ucun_plomb);
            report1.Load("FORMAN16.frx");
            //MessageBox.Show(Forma_N14.comboBox1.Text.Trim());
            TableDataSource table16 = report1.GetDataSource("T") as TableDataSource;

            table16.SelectCommand = p_var.n_chap_ucun_plomb;
            table16.Connection.ConnectionString = p_var.n_conn;
            report1.Show();
        }

        private void button21_Click(object sender, EventArgs e) //Müqavilərdə seçimin çapı
        {
            //MessageBox.Show(p_var.n_chap_ucun_doq);
            report1.Load("FORMAN17.frx");
            //MessageBox.Show(Forma_N14.comboBox1.Text.Trim());
            TableDataSource table17 = report1.GetDataSource("T") as TableDataSource;

            table17.SelectCommand = p_var.n_chap_ucun_doq;
            table17.Connection.ConnectionString = p_var.n_conn;
            report1.Show();
        }

        private void button22_Click(object sender, EventArgs e) //Closed meter
        {
            CL_ME.ShowDialog();
        }
      
      
        public void my_metod_CLOSE_METER(string s1, string s2)          //s1-Selectin şərti və s2-ya "S"-baxış,ya "D"-silmə
        {

            using (OleDbConnection oConn1 = new OleDbConnection())  // DEV_dataGridView5 - doldurmaq
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("(SAYĞAClar)Bir qədər gözləyin,");
                SplashScreenManager.Default.SetWaitFormDescription("məlumat yüklənir...");


                DataTable resultTable1 = new DataTable();
                resultTable1.Clear();
                gridControl6.DataSource = null;

                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = p_var.n_conn;
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();

                    if (s2 == "S")                  //Sətirlərin gətrilməsi SELECT TEX_BAX_Inspektor_name
                    {
                        /*
                        oCmd1.CommandText = @"select subid, oper_date, meter_nom, gpg_nom,close_date,azqaz.tex_bax_INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_NAME,
CASE when tip=0 then 'Siyahı' else 'Kəsim aktı' end 
tip,
sign, open_akt_nom, open_akt_data,qeyd, object_name, user_name ,GET_DATE from azqaz.tex_bax_close_meter where  " + s1;
                        */
                        oCmd1.CommandText = @" select * from (select subid,meter_nom,gpg_nom,Close_date,
CASE WHEN (azqaz.tex_bax_3e_opl(gpg_nom,GET_DATE)>0) THEN '4' ELSE SIGN END SIGN,
tip,oper_date,GET_DATE,
INSPEKTOR_NAME,open_akt_nom,open_akt_data,qeyd,azqaz.ray_n_a(subid) rayon,azqaz.fio_a(subid) fio,azqaz.unvan_a(subid) unvan,object_name,user_name,blocked_flag,rdp_id,
azqaz.tex_bax_3e_opl(gpg_nom,GET_DATE) opl ,
CASE WHEN sign='3' THEN azqaz.VPS_blok_data(rdp_id) ELSE '' END blok_data,INSPEKTOR_ID 
from (
select subid, oper_date, meter_nom, gpg_nom,close_date,INSPEKTOR_NAME,tip,
CASE WHEN blocked_flag=1 then '3' ELSE sign END sign,
open_akt_nom, open_akt_data,qeyd, object_name, user_name,t4.blocked_flag,t4.location_id,GET_DATE,t4.rdp_id,INSPEKTOR_ID  
from 
(select subid, oper_date, meter_nom, gpg_nom,close_date,azqaz.tex_bax_INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_NAME,
INSPEKTOR_ID,
CASE when tip=0 then 'Siyahı' else 'Kəsim aktı' end tip,
sign, open_akt_nom, open_akt_data,qeyd, object_name, user_name,GET_DATE
,t2.* from tex_bax_close_meter t1,(select location_id,msno from VPS.meter@AGIS_3E) t2 where gpg_nom=t2.msno) t3,
(select blocked_flag,location_id,rdp_id from VPS.rdp@AGIS_3E) t4 where t3.location_id=t4.location_id )) where " + s1;

                        p_var.n_chap_ucun_doq = oCmd1.CommandText;
                        resultTable1.Load(oCmd1.ExecuteReader());
                    }
                    if (s2 == "D")                 //Sətirlərin serverdən silinməsi DELETE
                    {
                        oCmd1.CommandText = @"delete from azqaz.tex_bax_DOQOVOR_BASE where " + s1;
                        my_metod_del_doq(oCmd1.CommandText, p_var.n_uzer_name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Serverə müraciətdə xəta yarandı(-7): " + ex.Message);
                    SplashScreenManager.CloseForm(false);
                    return;
                }
                oConn1.Close();
                SplashScreenManager.CloseForm(false);
                gridControl6.DataSource = null;
                gridControl6.DataSource = resultTable1;
                gridControl6.ForceInitialize();

                //Griddə düymələr
                gridControl6.UseEmbeddedNavigator = true;
                gridControl6.EmbeddedNavigator.Buttons.Edit.Visible = false;
                gridControl6.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                gridControl6.EmbeddedNavigator.Buttons.Append.Visible = false;
                gridControl6.EmbeddedNavigator.Buttons.Remove.Visible = false;
                gridControl6.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                gridControl6.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən";

                gridControl6.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
                gridControl6.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
                gridControl6.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

                gridControl6.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
                gridControl6.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
                gridControl6.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";
                //

                gridView6.RefreshData();

                if (resultTable1.Rows.Count > 0)
                {
                    gridView6.Appearance.HeaderPanel.Options.UseTextOptions = true;
                    gridView6.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    gridView6.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView6.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    //gridView2.OptionsBehavior.Editable = false;

                    gridView6.OptionsBehavior.Editable = true; // false;

                    gridView6.BestFitColumns();

                    gridView6.Columns["SUBID"].Caption = "Abonent kod" ;
                    gridView6.Columns["SUBID"].Width = 120;
                    gridView6.Columns["SUBID"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["SIGN"].Caption = "Status";
                    gridView6.Columns["SIGN"].Width = 50;
                    gridView6.Columns["SIGN"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["TIP"].Width = 65;
                    gridView6.Columns["TIP"].OptionsColumn.ReadOnly = true;

                    gridView6.Columns["METER_NOM"].Caption = "Sayğac №";
                    gridView6.Columns["METER_NOM"].Width = 130;
                    gridView6.Columns["METER_NOM"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["GPG_NOM"].Caption = "GPG №";
                    gridView6.Columns["GPG_NOM"].Width = 85;
                    gridView6.Columns["GPG_NOM"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["CLOSE_DATE"].Caption = "Bağlanış tarixi";
                    gridView6.Columns["CLOSE_DATE"].Width = 80;
                    gridView6.Columns["CLOSE_DATE"].OptionsColumn.ReadOnly = true;

                    gridView6.Columns["OPER_DATE"].Caption = "Əməliyyat tarixi";
                    gridView6.Columns["OPER_DATE"].Width = 80;
                    gridView6.Columns["OPER_DATE"].OptionsColumn.ReadOnly = true;

                    gridView6.Columns["QEYD"].Caption = "Qeyd";
                    gridView6.Columns["QEYD"].Width = 250;
                    gridView6.Columns["QEYD"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["INSPEKTOR_NAME"].Caption = "Mühəndis";
                    gridView6.Columns["INSPEKTOR_NAME"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["OBJECT_NAME"].Caption = "Obyekt";
                    gridView6.Columns["OBJECT_NAME"].OptionsColumn.ReadOnly = true;
                    
                    gridView6.Columns["OPEN_AKT_NOM"].Caption = "Açış akt №";
                    gridView6.Columns["OPEN_AKT_NOM"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["OPEN_AKT_NOM"].Visible = true;
                    gridView6.Columns["OPEN_AKT_NOM"].Width = 80;

                    gridView6.Columns["OPEN_AKT_DATA"].Caption = "Açış akt tarixi";
                    gridView6.Columns["OPEN_AKT_DATA"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["OPEN_AKT_DATA"].Width = 80;
                    gridView6.Columns["OPEN_AKT_DATA"].Visible = true;

                    gridView6.Columns["GET_DATE"].Caption = "Getmə tarixi";
                    gridView6.Columns["GET_DATE"].OptionsColumn.ReadOnly = true;
                    gridView6.Columns["GET_DATE"].Width = 80;
                    gridView6.Columns["GET_DATE"].Visible = true;
                    gridView6.Columns["GET_DATE"].DisplayFormat.FormatType = FormatType.Custom;
                    gridView6.Columns["GET_DATE"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";

                    gridView6.RefreshData();
              
                }
            }
        }

    private void tabPage8_Enter(object sender, EventArgs e)
    {
        p_var.n_string = " rownum <= 300";
        my_metod_CLOSE_METER(p_var.n_string, "S");
    }

    private void gridView6_RowStyle(object sender, RowStyleEventArgs e)
    {
        GridView View = sender as GridView;
        if (e.RowHandle >= 0)
        {
            switch (View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("SIGN")))
            {
                case "1":
                    e.Appearance.BackColor = Color.Yellow; //1 sarı
                    break;
                case "2":
                    e.Appearance.BackColor = Color.FromArgb(Color.Lime.ToArgb());//80,240,131);//Green; 2 yaşıl
                    break;
                case "3":
                    e.Appearance.BackColor = Color.FromArgb(Color.DeepSkyBlue.ToArgb());//3 göy Zaur blok etdi
                    break;
                case "4":
                    e.Appearance.BackColor = Color.Red; //4 qırmızı //Tex_Bax dan xəbərsiz aktivləşib
                    break;
            }
        }
    }

    private void gridView6_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
    {
        if (e.Info.IsRowIndicator && e.RowHandle >= 0)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }

    private void gridView6_RowCountChanged(object sender, EventArgs e)
    {
        DevExpress.XtraGrid.Views.Grid.GridView gridView = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);
        if (!gridView.GridControl.IsHandleCreated) return;
        Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
        SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
        gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f)
         + DevExpress.XtraGrid.Views.Grid.Drawing.GridPainter.Indicator.ImageSize.Width + 10;
    }


    private void gridView6_RowClick(object sender, RowClickEventArgs e)
    {
        var view1 = sender as GridView;
        if (view1 != null)
        {
            if (e.RowHandle != -999997)
            {
                if (view1.Columns.Count > 0)
                {
           //MessageBox.Show(view1.GetRowCellValue(e.RowHandle, view1.Columns[1]).ToString().Trim());
                    txtbxSubscriberNo.Text=view1.GetRowCellValue(e.RowHandle, view1.Columns["SUBID"]).ToString().Trim();
                    if (MessageBox.Show(
                            "1.Abonent kodu    :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["SUBID"]).ToString().Trim() + "\n\n"+ 
                            "2.Status          :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["SIGN"]).ToString().Trim() + "\n\n" +
                            "3.Tip             :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["TIP"]).ToString().Trim() + "\n\n" +
                            "4.Sayğac №        :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["METER_NOM"]).ToString().Trim().Substring(0, 10) + "\n\n" +
                            "5.GPG    №        :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["GPG_NOM"]).ToString().Trim() + "\n\n" +
                            "6.Bağlanış tarixi :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["CLOSE_DATE"]).ToString().Trim() + "\n\n" +
                            "7.Əməliyyat tarixi:" + view1.GetRowCellValue(e.RowHandle, view1.Columns["OPER_DATE"]).ToString().Trim() + "\n\n" +
                            "8.Qeyd            :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["QEYD"]).ToString().Trim() + "\n\n" +
                            "9.Mühəndis        :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["INSPEKTOR_NAME"]).ToString().Trim() + "\n\n" +
                            "10.Açış akt №     :" + view1.GetRowCellValue(e.RowHandle, view1.Columns["OPEN_AKT_NOM"]).ToString().Trim() + "\n\n" +
                            "11.Açış akt tarixi:" + view1.GetRowCellValue(e.RowHandle, view1.Columns["OPEN_AKT_DATA"]).ToString().Trim() + "\n\n"+
                            "11.Bloklama tarixi:" + view1.GetRowCellValue(e.RowHandle, view1.Columns["BLOK_DATA"]).ToString().Trim() + "\n\n"
                            , "Açıqlama davam etsin ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!txtbxSubscriberNo.Text.Equals(string.Empty))
                        {
                            tabControl1.SelectTab(0); //TabControlda I punkta keçid
                            SendKeys.Send("{END}");
                            SendKeys.Send("{ENTER}");
                        }
                    }
                }
            }
        }
 
    }

    private void button27_Click(object sender, EventArgs e) //sayğaclarda axtarış
    {
        ClmAxtar.Text = "Axtarışı";
        ClmAxtar.ShowDialog();
        if (p_var.n_rez == "Y")
        {
            gridControl6.DataSource = null;
            my_metod_CLOSE_METER(p_var.n_string, "S");
            button23.Enabled = true;
        }
    }

    private void button23_Click(object sender, EventArgs e)  //sayğaclarda çap
    {
        //MessageBox.Show(p_var.n_chap_ucun_doq);
        if (ClmAxtar.cE10.Checked)
        {
//          my_metod_CLOSE_METER_get((ClmAxtar.dE1.Text=="") ? "" : ClmAxtar.dE1.Text.Substring(0, 10), p_var.n_string);
            my_metod_CLOSE_METER_get((ClmAxtar.dE1.Text=="") ? "" : ClmAxtar.dE1.Text, p_var.n_string);
        }

        report1.Load("FORMAN18.frx");
        TableDataSource table18 = report1.GetDataSource("T") as TableDataSource;
        table18.SelectCommand = p_var.n_chap_ucun_doq;
        table18.Connection.ConnectionString = p_var.n_conn;
        report1.Show();

       // my_metod_CLOSE_METER(p_var.n_string, "S");

    }

    public void my_metod_CLOSE_METER_get(string s1,string s2)     //s1-Selectin şərti ,blokirova üçün hazırlamaq
    {
        using (OleDbConnection oConn1 = new OleDbConnection())  // DEV_dataGridView5 - doldurmaq
        {

            DataTable resultTable1 = new DataTable();
            resultTable1.Clear();
            try
            {
                OleDbCommand oCmd1 = oConn1.CreateCommand();
                oConn1.ConnectionString = p_var.n_conn;
                oConn1.Open();
                oCmd1 = oConn1.CreateCommand();
      oCmd1.CommandText = @"update azqaz.tex_bax_close_meter set GET_DATE = TO_DATE('" + s1 + "','DD.MM.YYYY HH24:MI:SS') where  " + s2;
                resultTable1.Load(oCmd1.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serverə müraciətdə xəta yarandı(17): " + ex.Message);
                return;
            }
            oConn1.Close();
        }
    }

//******************__Fərid_Müqavillər*********************************
    public string my_metod_Ferid(string v_subid)  //Müqavillər gridi
    {
        //MessageBox.Show(this.Left.ToString() + ":" + this.Top.ToString());
        Fer.Left = this.Left+10;
        Fer.Top = this.Top+164;
        Fer.Width = 1005;
        Fer.Height = 536;
        Fer.ShowDialog();
        this.Refresh();
        if (p_var.n_subid == "")
        {
            txtbxSubscriberNo.Text = "";
        }
        SendKeys.Send("{END}");
   //     SendKeys.Send("{ENTER}");
        txtbxSubscriberNo.Select();
        return ("Y");
    }


    public void my_metod_plan(string s1, string s2)                   //s1-Selectin şərti və s2-ya "S"-baxış,ya "D"-silmə
    {
        using (OleDbConnection oConn1 = new OleDbConnection())       // DEV_dataGridView5 - doldurmaq
        {

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("(PLANlaşma)Bir qədər gözləyin,");
            SplashScreenManager.Default.SetWaitFormDescription("məlumat yüklənir...");
            
            
            DataTable resultTable1 = new DataTable();
            resultTable1.Clear();
            gridControl7.DataSource = null;

            try
            {
                OleDbCommand oCmd1 = oConn1.CreateCommand();
                oConn1.ConnectionString = p_var.n_conn;
                oConn1.Open();
                oCmd1 = oConn1.CreateCommand();

                if (s2 == "S")                  //Sətirlərin gətrilməsi SELECT TEX_BAX_Inspektor_name
                {
                    oCmd1.CommandText = @"select subid, sign, oper_date, 
                 azqaz.Rayon_n(substr(subid,3,2)) Ray,azqaz.Unvan_a(subid) unvan,
                 azqaz.tex_bax_INSPEKTOR_NAME(INSPEKTOR_ID) INSPEKTOR_NAME,azqaz.fio_a(subid) fio,qeyd,
                 INSPEKTOR_ID,object_name,USER_NAME from azqaz.tex_bax_plan where " + s1;

                    p_var.n_chap_ucun_doq = oCmd1.CommandText;
                    resultTable1.Load(oCmd1.ExecuteReader());
                }
                if (s2 == "D")                 //Sətirlərin serverdən silinməsi DELETE
                {
                    oCmd1.CommandText = @"delete from azqaz.tex_bax_plan where " + s1;
                    my_metod_del_doq(oCmd1.CommandText, p_var.n_uzer_name);
                }
                //                    resultTable1.Load(oCmd1.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serverə müraciətdə xəta yarandı(18): " + ex.Message);
                SplashScreenManager.CloseForm(false);
                return;
            }
            oConn1.Close();

            gridControl7.DataSource = null;
            gridControl7.DataSource = resultTable1;
            gridControl7.ForceInitialize();

            //Griddə düymələr
            gridControl7.UseEmbeddedNavigator = true;
            gridControl7.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl7.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl7.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl7.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl7.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl7.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən";

            gridControl7.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
            gridControl7.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
            gridControl7.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

            gridControl7.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
            gridControl7.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
            gridControl7.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";
            //

            gridView7.RefreshData();

            if (resultTable1.Rows.Count > 0)
            {
                gridView7.Appearance.HeaderPanel.Options.UseTextOptions = true;
                gridView7.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView7.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView7.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                gridView7.OptionsBehavior.Editable = true; // false;

                gridView7.BestFitColumns();

                // gridView2.Columns["AKT_NUMBER"].Visible = false;
                /*
                gridView7.Columns["SN"].Caption = " № ";
                gridView7.Columns["SN"].Width = 35;
                gridView7.Columns["SN"].ToolTip = "Sətrin sıra nömrəsi";
                gridView7.Columns["SN"].OptionsColumn.ReadOnly = true;
                */
                gridView7.Columns["SUBID"].Caption = "Abonent kodu";
                gridView7.Columns["SUBID"].Width = 120;
                gridView7.Columns["SUBID"].OptionsColumn.ReadOnly = true;
                gridView7.Columns["SIGN"].Caption = "Status";
                gridView7.Columns["SIGN"].Width = 50;
                gridView7.Columns["SIGN"].OptionsColumn.ReadOnly = true;
                gridView7.Columns["RAY"].Caption = "Rayon";
                gridView7.Columns["RAY"].Width = 55;
                gridView7.Columns["RAY"].OptionsColumn.ReadOnly = true;

                gridView7.Columns["UNVAN"].Caption = "Ünvan";
                gridView7.Columns["UNVAN"].Width = 250;
                gridView7.Columns["UNVAN"].OptionsColumn.ReadOnly = true;

                gridView7.Columns["OPER_DATE"].Caption = "Əməliyyat tarixi";
                gridView7.Columns["OPER_DATE"].Width = 80;
                gridView7.Columns["OPER_DATE"].OptionsColumn.ReadOnly = true;
                gridView7.Columns["QEYD"].Caption = "Qeyd";
                gridView7.Columns["QEYD"].Width = 250;
                gridView7.Columns["QEYD"].OptionsColumn.ReadOnly = true;
                gridView7.Columns["INSPEKTOR_NAME"].Caption = "Mühəndis";
                gridView7.Columns["INSPEKTOR_NAME"].OptionsColumn.ReadOnly = true;
                gridView7.Columns["FIO"].Caption = "Soyadı,Adı,ataadı";
                gridView7.Columns["FIO"].Width = 180;
                gridView7.Columns["FIO"].OptionsColumn.ReadOnly = true;
                gridView7.Columns["OBJECT_NAME"].Caption = "Obyekt";
                gridView7.Columns["OBJECT_NAME"].OptionsColumn.ReadOnly = true;
                //  gridView7.Columns["USER_NAME"].Visible = false;
                //gridView7.Columns["SUBJECTID"].Visible = false;
                //gridView7.Columns["MATRIXID"].Visible = false;
                //gridView7.Columns["DOQ_ID"].OptionsColumn.ReadOnly = true;
                //gridView7.Columns["DOQ_ID"].Visible = true;

                gridView7.RefreshData();
                SplashScreenManager.CloseForm(false);
                //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatType = FormatType.Custom;
                //grdvwXidmet.Columns["AKT_DATA"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";                   
            }
        }
    }

    private void tabPage9_Enter(object sender, EventArgs e)
    {
        p_var.n_string = " rownum <= 300"; // " doq_id >= 000 and doq_id <= 300 ";
        my_metod_plan(p_var.n_string, "S");
    }

    private void gridView7_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
    {
        if (e.Info.IsRowIndicator && e.RowHandle >= 0)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }

    private void gridView7_RowCountChanged(object sender, EventArgs e)
    {
        DevExpress.XtraGrid.Views.Grid.GridView gridView = ((DevExpress.XtraGrid.Views.Grid.GridView)sender);
        if (!gridView.GridControl.IsHandleCreated) return;
        Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
        SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
        gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f)
         + DevExpress.XtraGrid.Views.Grid.Drawing.GridPainter.Indicator.ImageSize.Width + 10;
    }

    private void gridView7_RowStyle(object sender, RowStyleEventArgs e)
    {
        GridView View = sender as GridView;
        if (e.RowHandle >= 0)
        {
            switch (View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByFieldName("SIGN")))
            {
                case "1":
                    e.Appearance.BackColor = Color.Yellow; //1 sarı
                    break;
                case "2":
                    e.Appearance.BackColor = Color.FromArgb(80, 240, 131);//ForestGreen; //GreenYellow; //Green; 2 yaşıl
                    break;
                case "3":
                    e.Appearance.BackColor = Color.Red; //3 qırmızı
                    break;
            }
        }
    }

    public string my_metod_Ferid_cox(string v_subid)  //Müqavillər gridi cox setir
    {
        this.Refresh();
        Fer_cox.Left   = this.Left+5; //10;
        Fer_cox.Top = this.Top+28;//30 // 164; 56
        Fer_cox.Width = 1012; // 1010;1005;
        Fer_cox.Height = 536 + 140;// 133; // 536 + 110;
        Fer_cox.ShowDialog();
        this.Refresh();
        //SendKeys.Send("{END}");
        //     SendKeys.Send("{ENTER}");
        //txtbxSubscriberNo.Select();
        return ("Y");
    }

    private void button24_Click(object sender, EventArgs e) //Çox sətir Fərid
    {
        Find53p.ShowDialog();
        if (p_var.n_rez == "Y")
        {
            my_metod_Ferid_cox("100803000700000");
        }
        this.Refresh();
        SendKeys.Send("{END}");
        txtbxSubscriberNo.Select();
        return;
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void button25_Click(object sender, EventArgs e) //Planda axtar
    {
        PlanAxtar.Text = "Planlaşmada axtarışı";
        PlanAxtar.ShowDialog();
        if (p_var.n_rez == "Y")
        {
            button26.Enabled = true;
            gridControl7.DataSource = null;
            my_metod_plan(p_var.n_string, "S");
        }
    }

    private void button26_Click(object sender, EventArgs e) //Planda Hesabat EXCEL
    {
        report1.Load("FORMAN19.frx");
        TableDataSource table19 = report1.GetDataSource("T") as TableDataSource;
        table19.SelectCommand = p_var.n_chap_ucun_doq;
        table19.Connection.ConnectionString = p_var.n_conn;
        report1.Show();
    //    my_metod_plan(p_var.n_string, "S");
    }

    private void memoExEdit1_EditValueChanged(object sender, EventArgs e)
    {

    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }
    private void tabPage2_Click(object sender, EventArgs e)
    {
        if (txtbxSubscriberNo.Text.Trim() != "")
        {
            txtbxSubscriberNo.Select();
            btnSearch.Select();
            btnSearch.PerformClick();
       //     txtbxSubscriberNo.Focus();
             SendKeys.Send("{END}");
       //     SendKeys.Send("{ENTER}");
        }
       // txtbxSubscriberNo.Select();
    }

    private void tabPage2_Enter(object sender, EventArgs e)
    {
//        label16.Text = "";
//        label17.Text = "";        
        //tabPage2_Click(null,null);
        //txtbxSubscriberNo.Text = p_var.n_subid;
        //btnSearch.PerformClick();
        //MessageBox.Show(Focused.ToString());
        //txtbxSubscriberNo.Text = p_var.n_subid;
        //txtbxSubscriberNo.Select();
        //SendKeys.Send("{END}");
        //SendKeys.Send("{ENTER}");
        //MessageBox.Show("0000000");
    }

    private void textBox14_TextChanged(object sender, EventArgs e)
    {
        p_var.n_clipboard = (String.IsNullOrEmpty(textBox14.Text.Trim())) ? " " : textBox14.Text.Trim();
        Clipboard.SetText(p_var.n_clipboard);
    }

    private void tabPage10_Enter(object sender, EventArgs e)
    {
        my_bildirish("0");
    }

    public void my_bildirish(string str)
    {
        if (p_var.n_rol == "9") //ASAN_baxış
        {
            contextMenuStrip1.Items[0].Enabled = false;
            //contextMenuStrip1.Items[2].Enabled = false;
            //contextMenuStrip1.Items[4].Enabled = false;
            contextMenuStrip1.Items[1].Enabled = false;
            contextMenuStrip1.Items[3].Enabled = false;
        }
        else
        {
            contextMenuStrip1.Items[0].Enabled = true;
            contextMenuStrip1.Items[2].Enabled = true;
            contextMenuStrip1.Items[4].Enabled = true;
            contextMenuStrip1.Items[1].Enabled = true;
            contextMenuStrip1.Items[3].Enabled = true;
        }

        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
        using (OleDbConnection oConn1 = new OleDbConnection())
        {
            DataTable resultTable4 = new DataTable();
            resultTable4.Clear();
            gridControl8.DataSource = null;
            try
            {
                OleDbCommand oCmd1 = oConn1.CreateCommand();
                oConn1.ConnectionString = p_var.n_conn;
                oConn1.Open();
                oCmd1 = oConn1.CreateCommand();
                oCmd1.CommandText = @"select '' N,bil_num,bil_data,subid,
rayon,
Fio,
unvan,user_name,
say_marka,say_nom,
say_qur_tar,
say_dov_yox,
say_plomb,
telefon,
sv,ii_shaxs,muq_baq_yer,Object_name,qeyd,oper_date,sysdate,n_id 
FROM azqaz.tex_bax_bil_f  where object_name='" + p_var.n_obj + "' and sysdate-oper_date<=tex_bax_gun_asan() order by oper_date desc ";

                resultTable4.Load(oCmd1.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serverə müraciətdə xəta yarandı(19): " + ex.Message);
                SplashScreenManager.CloseForm(false);
                return;
            }

            oConn1.Close();

            gridControl8.DataSource = null;
            gridControl8.DataSource = resultTable4;
            gridControl8.ForceInitialize();

            //Griddə düymələr
            gridControl8.UseEmbeddedNavigator = true;
            gridControl8.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl8.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl8.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl8.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl8.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;

            switch (p_var.n_rol)
            {
                case "7":
                    gridControl8.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən,[Istifadəçi:" + p_var.n_uzer_name + ",Rol:Operator,"+"Ip:"+p_var.n_ip+"]";
                    break;
                case "8":
                    gridControl8.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən,[Istifadəçi:" + p_var.n_uzer_name + ",Rol:Admin,"+"Ip:"+p_var.n_ip+"]";
                    break;
                case "9":
                    gridControl8.EmbeddedNavigator.TextStringFormat = "Sətir {0}, {1} dən,[Istifadəçi:" + p_var.n_uzer_name + ",Rol:Baxış,"+"Ip:"+p_var.n_ip+"]";
                    break;
            }

            gridControl8.EmbeddedNavigator.Buttons.First.Hint = "Ilk sətir";
            gridControl8.EmbeddedNavigator.Buttons.PrevPage.Hint = "Əvvəlki səhifə";
            gridControl8.EmbeddedNavigator.Buttons.Prev.Hint = "Əvvəlki sətir";

            gridControl8.EmbeddedNavigator.Buttons.NextPage.Hint = "Növbəti səhifə";
            gridControl8.EmbeddedNavigator.Buttons.Next.Hint = "Növbəti sətir";
            gridControl8.EmbeddedNavigator.Buttons.Last.Hint = "Son sətir";

            gridView8.RefreshData();
            SplashScreenManager.CloseForm(false);
            if (resultTable4.Rows.Count > 0)
            {
                
                gridView8.Appearance.HeaderPanel.Options.UseTextOptions = true;
                gridView8.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView8.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView8.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView8.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;// .Center;

                //**
                gridControl8.UseEmbeddedNavigator = true;
                DevExpress.XtraEditors.NavigatorCustomButton button;
                gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Clear();
                gridControl8.EmbeddedNavigator.Buttons.ImageList = imageList1;

                    button = gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Add();
                    button.Tag = "Edit";
                    button.Hint = "Müqaviləyə düzəliş";
                    button.ImageIndex = 69; // 82;                

                    button = gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Add();
                    button.Tag = "Add";
                    button.Hint = "Yeni müqavilənin yaradılması";
                    button.ImageIndex = 1; // 82;

                    button = gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Add();
                    button.Tag = "Sil";
                    button.Hint = "Seçilmiş müqavilənin silinməsi";
                    button.ImageIndex = 24; // 82;

                button = gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Add();
                button.Tag  = "Print";
                button.Hint = "Seçilmiş müqavilənin çapı";
                button.ImageIndex = 114; // 82;

                button = gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Add();
                button.Tag = "Log";
                button.Hint = "Seçilmiş müqavilənin düzəliş tarixcəsi";
                button.ImageIndex = 115; // 82;

                button = gridControl8.EmbeddedNavigator.Buttons.CustomButtons.Add();
                button.Tag = "New_New";
                button.Hint = "Siyahının yenilənməsi";
                button.ImageIndex = 86; // 82;

                if (p_var.n_rol == "9") //ASAN baxış
                {
                    gridControl8.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false; //Edit
                    gridControl8.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false; //Add
                    gridControl8.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false; //Del
                }
                //**
                gridView8.OptionsBehavior.Editable = false;

                gridView8.OptionsView.ShowViewCaption = false;
                //gridView4.OptionsView.ShowAutoFilterRow = false; // axtarış sətrini gizlət  

                gridView8.OptionsPrint.PrintDetails     = true;
                gridView8.OptionsPrint.ExpandAllDetails = true;
                gridView8.OptionsPrint.AutoWidth        = false;// true;

                gridView8.BestFitColumns();

                gridView8.Columns["N"].Caption = "№";
                gridView8.Columns["RAYON"].Caption = "Şayğacin qur.yeri";
                gridView8.Columns["RAYON"].Width = 150;
                //gridView8.Columns["NEZARETCI"].Caption = "Nəzarətçi";
                //gridView4.Columns["RAYON"].Width = 70;
                gridView8.Columns["SUBID"].Caption = "Abonent kodu";
                //gridView4.Columns["SUBID"].Width = 120;
                gridView8.Columns["BIL_NUM"].Caption = "Müqavilə №";
                gridView8.Columns["BIL_NUM"].Width = 150;
                gridView8.Columns["BIL_DATA"].Caption = "Müqavilə tarixi";
                gridView8.Columns["BIL_DATA"].Width = 180;
                gridView8.Columns["FIO"].Caption = "Sayad Ad Ataadı";
                //gridView4.Columns["FIO"].Width = 250;
                //gridView8.Columns["STATUS"].Caption = "Status";
                //gridView4.Columns["STATUS"].Width = 35;
                //gridView4.Columns["SAHE"].Width = 120;                        
                gridView8.Columns["UNVAN"].Caption = "Ünvan";
                //gridView4.Columns["UNVAN"].Width = 250;
                gridView8.Columns["MUQ_BAQ_YER"].Caption = "Müqavilə bağlanma yer";
                gridView8.Columns["MUQ_BAQ_YER"].Width = 180;
                gridView8.Columns["SAY_MARKA"].Caption = "Sayğac markası";
                //gridView4.Columns["SAYGAC_MARKA"].Width = 100;
                gridView8.Columns["SAY_NOM"].Caption = "Sayğac №";
                //gridView4.Columns["SAYGAC_NOMER"].Width = 160;
                // gridView4.Columns["MENZIL_TIPI"].Width = 180;
                gridView8.Columns["SAY_QUR_TAR"].Caption = "Sayğac qur.tarixi";
                gridView8.Columns["SAY_QUR_TAR"].Width = 120;
                gridView8.Columns["SAY_DOV_YOX"].Caption = "Dövlət yoxl.tarixi";
                gridView8.Columns["SAY_DOV_YOX"].Width = 120;
                gridView8.Columns["SAY_PLOMB"].Caption = "Plomb №";
                gridView8.Columns["SAY_PLOMB"].Width = 100;
                gridView8.Columns["TELEFON"].Caption = "Telefon №";
                gridView8.Columns["TELEFON"].Width = 100;
                gridView8.Columns["SV"].Caption = "Şəxsiyət vəs.№";
                gridView8.Columns["SV"].Width = 150;
                gridView8.Columns["II_SHAXS"].Caption = "II Şəxs";
                gridView8.Columns["II_SHAXS"].Width = 120;
                        
                gridView8.Columns["QEYD"].Caption = "Qeyd";
                // gridView4.Columns["QEYD"].Width = 160;
                gridView8.Columns["USER_NAME"].Caption = "Operator";
                //gridView4.Columns["USER_NAME"].Width = 60;                        
                gridView8.Columns["OPER_DATE"].Caption = "Əməliyat tarixi";
                gridView8.Columns["OPER_DATE"].Width = 150;
                //gridView4.Columns["OPER_DATE"].DisplayFormat.FormatType = FormatType.Custom;
                gridView8.Columns["OPER_DATE"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
                //gridView8.Columns["REG_DATE"].Caption = "Qeydiyat tarixi";
                //gridView8.Columns["REG_DATE"].Width = 150;
                gridView8.Columns["OBJECT_NAME"].Caption = "Obyekt";
                gridView8.Columns["SYSDATE"].Visible=false;

                // int row = gridView8.LocateByValue("SUBID", p_var.n_subid, null);//tapmaq qridde subid=p_var.n_subid
                //int row = gridView8.LocateByValue("BIL_NUM", p_var.n_bil_nom, null);//tapmaq qridde p_var.n_bil_nom

                int row = gridView8.LocateByValue("N_ID", p_var.n_int, null);//tapmaq qridde p_var.n_bil_nom
                gridView8.OptionsSelection.EnableAppearanceFocusedRow = true;                
                gridView8.FocusedRowHandle = row;
                 //int row = gridView1.LocateByValue("Code", textEdit1.EditValue, null);
                 //gridView1.FocusedRowHandle = row

                int Day   = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SYSDATE"]).ToString().Trim().Substring(0, 2));
                int Month = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SYSDATE"]).ToString().Trim().Substring(3, 2));
                int Year  = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SYSDATE"]).ToString().Trim().Substring(6, 4));
                p_var.n_cur_data = new System.DateTime(Year,Month,Day);


                if (p_var.n_rol == "7" || p_var.n_rol == "8" || p_var.n_rol == "9")
                {
                    gridControl8.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;
                    this.WindowState = FormWindowState.Maximized;
                    /*
                    if (p_var.n_ASAN == "")
                    {
                        MessageBox.Show("ASAN xidm't");
                    }
                    */
                }
                
                gridView8.RefreshData();
            }
        }
   }

    public class MyGridLocalizer : GridLocalizer //Gridde Поиск-Axdar,Очистить-Təmizlə
    {
        public override string GetLocalizedString(GridStringId id)
        {
            if (id == GridStringId.FindControlFindButton)
                return "Axtar";
            if (id == GridStringId.FindControlClearButton)
                return "Təmizlə";
            return base.GetLocalizedString(id);
        }
    }

    private void gridView8_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e) //Sətrin nömrələnməsi-Bildirişlərdə
    {
      if (e.Column.Caption == "№")
        {
          e.DisplayText = (e.RowHandle + 1==-999996) ? "":(e.RowHandle + 1).ToString();
        }
    }

    private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        contextMenuStrip1.Visible = false;
        /*
        if (p_var.n_rol == "9")
        {
            contextMenuStrip1.Items[1].Enabled = false;
            contextMenuStrip1.Items[2].Enabled = false;
            contextMenuStrip1.Items[4].Enabled = false;
        }
        */
        if (p_var.n_rol == "9" && (e.ClickedItem.Text == "1.Müqavilenin deyişdirilmesi" || e.ClickedItem.Text == "2.Seçilmiş müqavilenin silinmesi" || e.ClickedItem.Text == "4.Yeni müqavile"))
        {
            MessageBox.Show("Diqqət,Sizin malik olduğunuz rol bu əməlyata içazə vermir !!!");
            return;
        }

        if (e.ClickedItem.Text == "1.Müqavilenin deyişdirilmesi" || e.ClickedItem.Text == "2.Seçilmiş müqavilenin silinmesi")
        {
            int Day = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(0, 2));
            int Month = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(3, 2));
            int Year = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(6, 4));
            DateTime n_dT1 = new System.DateTime(Year, Month, Day);

            if ((p_var.n_cur_data - n_dT1).TotalDays > 0 && p_var.n_rol != "8")
            {
                if (e.ClickedItem.Text == "1.Müqavilenin deyişdirilmesi")
                {
                    MessageBox.Show("Köhnə müqavilə məlumatları dəyişdirilə bilməz !!!");
                }
                else
                {
                    MessageBox.Show("Köhnə müqavilə məlumatları silinə bilməz !!!");
                }
                return;
            }
        }

        switch (e.ClickedItem.Text)
        {
            case "1.Müqavilenin deyişdirilmesi":
                if (gridControl8.FocusedView != null)
                {
                    p_var.n_subid = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                    p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                    p_var.n_int = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";
                    BIL_F.ShowDialog();
                    my_bildirish("0");//refresh gridView
                }
                 break;
            case "2.Seçilmiş müqavilenin silinmesi":
                 DialogResult result1 = MessageBox.Show("Təsdiqləyirsiz ?", "Seçilmiş mqüavilenin silinmesi(Kod:" +
                 gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() + ",Setir №" + (gridView8.FocusedRowHandle+1).ToString()+")",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                 if (result1 == DialogResult.Yes)
                 {
                    p_var.n_rez = my_bil_f(
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_DATA"]).ToString().Substring(0, 10),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["QEYD"]).ToString(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["USER_NAME"]).ToString(),
                    p_var.n_obj, "D","","","","","","",
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString());
                    if (p_var.n_rez == "D")
                    {
                        gridView8.DeleteRow(gridView8.FocusedRowHandle);
                    }
                 }
                 break;
            case "3.Seçilmiş siyahının EXCELə göndərilməsi":
                  gridView8.OptionsView.ShowViewCaption = false;
                  gridView8.Columns["N"].Visible = false;
                  XlsxExportOptions options = new XlsxExportOptions();
                  options.SheetName = string.Format("List1-{0:ddMMyyyy_HHmmss}", DateTime.Now);
                  options.ShowGridLines = true;
                  //var fileName = string.Format("sample-{0:ddMMyyyy_HHmmss}", DateTime.Now) + ".xlsx";
                  var FileName = "MUQAVILELER.xlsx";
                  options.ExportMode = XlsxExportMode.SingleFile;//.SingleFilePageByPage;
                  gridView8.ExportToXlsx(FileName, options);
                  Process.Start("EXCEL.EXE", " /e " + FileName);
                  gridView8.OptionsView.ShowViewCaption = true;
                  gridView8.Columns["N"].Visible = true;
                  break;
            case "4.Yeni müqavile":
                  p_var.n_subid  = "";
                  p_var.n_bil_nom ="";
                  p_var.n_int="*";
                  BIL_F.ShowDialog();
                  my_bildirish("0");//refresh gridView
                  break;
            case "5.Seçilmiş müqavilenin çapı":
                  if (gridControl8.FocusedView != null)
                  {
                      p_var.n_subid = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                      p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                      contract newContract = new contract();
                      string pdfDocumentName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
                      //@"d:\ITRON_BORC\contactPRI\contract.pdf";
                      newContract.contract_Print(pdfDocumentName);
                      return;
                  }
                  break;
        }
        contextMenuStrip1.Visible = true;
    }

    public string my_bil_f(string subid, string bil_num, string bil_dat, string qeyd, string user, string obj, string tip
        , string muq_baq_yer, string fio1, string unvan, string telfon, string ii_shaxs,string sv,string n_id)
    {
       if (bil_num == "" && tip != "D")
        {
            XtraMessageBox.Show("Müqavilə nömrəsi və ya tarixi boş ola bilməz !");
            return ("E");
        }
        OracleConnection conn = new OracleConnection(p_var.n_conn1);
        OracleCommand cmd = new OracleCommand();
        var v_EXIT = "$";

        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "AZQAZ.tex_bax_bil_ferid";     // Name_function
        cmd.Parameters.Add("v_RETU", OracleType.VarChar);
        cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
        cmd.Parameters["v_RETU"].Size = 1200;

        cmd.Parameters.Add("v_subid", OracleType.VarChar);
        cmd.Parameters["v_subid"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_subid"].Value = subid; // Abon kod

        cmd.Parameters.Add("v_bil_num", OracleType.VarChar);
        cmd.Parameters["v_bil_num"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_bil_num"].Value = bil_num;

        cmd.Parameters.Add("v_bil_data", OracleType.VarChar);
        cmd.Parameters["v_bil_data"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_bil_data"].Value = bil_dat;

        cmd.Parameters.Add("v_qeyd", OracleType.NVarChar);
        cmd.Parameters["v_qeyd"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_qeyd"].Value = qeyd;

        cmd.Parameters.Add("v_user_name", OracleType.VarChar);
        cmd.Parameters["v_user_name"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_user_name"].Value = user;

        cmd.Parameters.Add("v_obj", OracleType.VarChar);
        cmd.Parameters["v_obj"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_obj"].Value = obj;

        cmd.Parameters.Add("v_tip", OracleType.VarChar);
        cmd.Parameters["v_tip"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_tip"].Value = tip;

        cmd.Parameters.Add("v_muq_baq_yer", OracleType.VarChar);
        cmd.Parameters["v_muq_baq_yer"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_muq_baq_yer"].Value = muq_baq_yer;

        cmd.Parameters.Add("v_fio1", OracleType.VarChar);
        cmd.Parameters["v_fio1"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_fio1"].Value = fio1;

        cmd.Parameters.Add("v_unvan", OracleType.VarChar);
        cmd.Parameters["v_unvan"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_unvan"].Value = unvan;

        cmd.Parameters.Add("v_telfon", OracleType.VarChar);
        cmd.Parameters["v_telfon"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_telfon"].Value = telfon;

        cmd.Parameters.Add("v_ii_shaxs", OracleType.VarChar);
        cmd.Parameters["v_ii_shaxs"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_ii_shaxs"].Value = ii_shaxs;

        cmd.Parameters.Add("v_sv", OracleType.VarChar);
        cmd.Parameters["v_sv"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_sv"].Value = sv;

        cmd.Parameters.Add("v_n_id", OracleType.VarChar);
        cmd.Parameters["v_n_id"].Direction = ParameterDirection.Input;
        cmd.Parameters["v_n_id"].Value = n_id;

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Serverə müraciətdə xəta yarandı(20): " + ex.Message);
            return ("E");
        }
        conn.Close();
        return (v_EXIT);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
       p_var.n_textbox = (checkBox1.Checked) ? "1" : "0";
    }
   
    private void gridControl8_KeyPress(object sender, KeyPressEventArgs e) //BLOKlanalarda menu
    {

        if (p_var.n_rol == "9" && ((int)e.KeyChar == 13 || e.KeyChar == '+' || e.KeyChar == '-'))
        {
            MessageBox.Show("Diqqət,Sizin malik olduğunuz rol bu əməlyata içazə vermir !!!");
            return;
        }

        if ((int)e.KeyChar == 13) // Enter-basmaq
        {
            if (gridControl8.FocusedView != null)
            {
                int Day       = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(0, 2));
                int Month     = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(3, 2));
                int Year      = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(6, 4));
                DateTime n_dT1 = new System.DateTime(Year, Month, Day);

                if ((p_var.n_cur_data - n_dT1).TotalDays > 0 && p_var.n_rol != "8")
                {
                    MessageBox.Show("Köhnə müqavilə məlumatları dəyişdirilə bilməz !!!");
                    return;
                }
                               
                p_var.n_subid   = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                p_var.n_int = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";
                BIL_F.ShowDialog();
                my_bildirish("0");//refresh gridView
                return;
            }
        }
        if ((int)e.KeyChar == 27) // Esc-basmaq
        {
            // Prog();
            /*
            if (gridControl8.FocusedView != null)
            {
                this.Close();
                e.Handled = true;
                //p_var.n_subid = "00";
                return;
            }
           */
        }

        if (e.KeyChar == '+') // yeni müqavilə
        {
            p_var.n_subid = "";// (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
            p_var.n_bil_nom =  "";
            p_var.n_int = "*";
            BIL_F.ShowDialog();
            my_bildirish("0");
        }

        if (e.KeyChar == '-') // müqavilənin silinməsi
        {
            if (gridControl8.FocusedView != null)
            {
                int Day = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(0, 2));
                int Month = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(3, 2));
                int Year = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(6, 4));
                DateTime n_dT1 = new System.DateTime(Year, Month, Day);

                if ((p_var.n_cur_data - n_dT1).TotalDays > 0 && p_var.n_rol != "8")
                {
                    MessageBox.Show("Köhnə müqavilə məlumatları silinə bilməz !!!");
                    return;
                }
                
                p_var.n_subid = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_int  = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";

                DialogResult result1 = MessageBox.Show("Təsdiqləyirsiz ?", "Seçilmiş müqavilenin silinmesi(Kod:" +
                gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() + ",Setir №" + (gridView8.FocusedRowHandle + 1).ToString() + ")",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result1 == DialogResult.Yes)
                {
                    p_var.n_rez = my_bil_f(
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_DATA"]).ToString().Substring(0, 10), gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["QEYD"]).ToString(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["USER_NAME"]).ToString(),
                    p_var.n_obj, "D", "", "", "", "", "", "",
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim());
                    if (p_var.n_rez == "D")
                    {
                        gridView8.DeleteRow(gridView8.FocusedRowHandle);
                    }
                }
                return;
            }
        }

    }

    private void gridControl8_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
    {
        if (p_var.n_rol == "9" && ("Edit".Equals(e.Button.Tag) || "Add".Equals(e.Button.Tag) || "Sil".Equals(e.Button.Tag)))
        {
            MessageBox.Show("Diqqət,Sizin malik olduğunuz rol bu əməlyata içazə vermir !!!");
            return;
        }
        
        
        if ("New_New".Equals(e.Button.Tag)) //refresh grid
        {
            if (gridControl8.FocusedView != null)
            {
                /*p_var.n_subid   = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                p_var.n_int = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";
                BIL_F.ShowDialog();
                */
                my_bildirish("0");//refresh gridView
                e.Handled = true;
                return;
            }
        }
        
        if ("Log".Equals(e.Button.Tag)) // || (e.Button.ButtonType == NavigatorButtonType.CancelEdit)) // Print 
        {
            if (gridControl8.FocusedView != null)
            {

                p_var.n_subid = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                p_var.n_int = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";
//                MessageBox.Show("Seçilmiş müqavilə:" + p_var.n_bil_nom);
                Asanlog.ShowDialog();
                e.Handled = true;
                return;
            }
        }
        
        if ("Print".Equals(e.Button.Tag)) // || (e.Button.ButtonType == NavigatorButtonType.CancelEdit)) // Print 
        {
            if (gridControl8.FocusedView != null)
            {
                p_var.n_subid =(gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                contract newContract = new contract();
                //string hhh = System.IO.Path.GetTempPath() + "contract.docx";
                //"C:\Users\Nasimi\AppData\Local\Temp\contract.docx"
                //File.WriteAllBytes(System.IO.Path.GetTempPath()+"contract.docx", Properties.Resources.contract);
                //File.WriteAllBytes("c:\\Program Files\\TEX_BAX\\contract.docx", Properties.Resources.contract);
                string pdfDocumentName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";  
                //@"d:\ITRON_BORC\contactPRI\contract.pdf";
                newContract.contract_Print(pdfDocumentName);
                //MessageBox.Show("Print:" + p_var.n_subid);
                e.Handled = true;
                return;
            }
        }

        if ("Edit".Equals(e.Button.Tag))
        {
//***
            int Day = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(0, 2));
            int Month = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(3, 2));
            int Year = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(6, 4));
            DateTime n_dT1 = new System.DateTime(Year, Month, Day);

            if ((p_var.n_cur_data - n_dT1).TotalDays > 0 && p_var.n_rol != "8")
            {
                MessageBox.Show("Köhnə müqavilə məlumatları dəyişdirilə bilməz !!!");
                return;
            }
//***            
            if (gridControl8.FocusedView != null)
            {
                p_var.n_subid   = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_bil_nom = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim() : "";
                p_var.n_int = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";
                BIL_F.ShowDialog();
                my_bildirish("0");//refresh gridView
                e.Handled = true;
                return;
            }
        }

        if ("Add".Equals(e.Button.Tag)) //
        {
            if (gridControl8.FocusedView != null)
            {
                p_var.n_subid = "";
                p_var.n_bil_nom = "";
                p_var.n_int = "*";
                BIL_F.ShowDialog();
                my_bildirish("0");
                e.Handled = true;
                return;
            }
        }

        if ("Sil".Equals(e.Button.Tag))
        {
            if (gridControl8.FocusedView != null)
            {
                //***
                int Day = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(0, 2));
                int Month = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(3, 2));
                int Year = Int32.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["OPER_DATE"]).ToString().Trim().Substring(6, 4));
                DateTime n_dT1 = new System.DateTime(Year, Month, Day);

                if ((p_var.n_cur_data - n_dT1).TotalDays > 0 && p_var.n_rol != "8")
                {
                    MessageBox.Show("Köhnə müqavilə məlumatları silinə bilməz !!!");
                    return;
                }
                //***    

                p_var.n_subid = (gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() : "";
                p_var.n_int =(gridView8.RowCount != 0) ? gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim() : "";
                DialogResult result1 = MessageBox.Show("Təsdiqləyirsiz ?", "Seçilmiş mqüavilenin silinmesi(Kod:" +
                gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim() + ",Setir №" + (gridView8.FocusedRowHandle + 1).ToString() + ")",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result1 == DialogResult.Yes)
                {
                    p_var.n_rez = my_bil_f(
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["SUBID"]).ToString().Trim(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_NUM"]).ToString().Trim(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["BIL_DATA"]).ToString().Substring(0, 10), gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["QEYD"]).ToString(),
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["USER_NAME"]).ToString(),
                    p_var.n_obj, "D", "", "", "", "", "", "",
                    gridView8.GetRowCellValue(gridView8.FocusedRowHandle, gridView8.Columns["N_ID"]).ToString().Trim());
                    if (p_var.n_rez == "D")
                    {
                        gridView8.DeleteRow(gridView8.FocusedRowHandle);
                    }
                }
                e.Handled = true;
                return;
            }
        }
    }

    private void gridView8_KeyPress(object sender, KeyPressEventArgs e)
    {

    }

    private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }

    private void Item5_Click(object sender, EventArgs e)
    {

    }

    private void tabPage11_Enter(object sender, EventArgs e)
    {
        TreeNode node;
            treeView2.Nodes.Clear();
//            if (p_var.n_uzer_name.Substring(0, 1) != "N" && p_var.n_uzer_name.Substring(0, 1) != "b")//(p_var.n_uzer_name.Substring(0, 1) != "N")
                node = treeView2.Nodes.Add("1.Müqavilələrin hesabatı");
                node.Nodes.Add("1.1  Siyahıdan silinmiş müqavilələr");
        /*
                node.Nodes.Add("1.2  Mühəndislərin hesabatı");
                node.Nodes.Add("1.3  Müqaviləsi olmayan abonentlər");
                node.Nodes.Add("1.4  Müqaviləli və müqaviləsiz abonentlər haqqında yekun məlumat");
                node.Nodes.Add("1.5  Problemli abonentlər haqqında məlumat");
                node.Nodes.Add("1.6  Boş xanaların doldurulması");
                node.Nodes.Add("1.7  Müqaviləli və sayğacı bloklaşdırılmış abonentlərin siyahısı");
                node.Nodes.Add("1.8  Müqavilesi bitmiş abonentler haqqında melumat(Sənaye)");
                node.Nodes.Add("1.9  Müqavilesiz abonentler haqqında melumat(Sənaye)");
                node.Nodes.Add("1.10 Blokda olan abonentler haqqında melumat(Sənaye)");
                node.Nodes.Add("1.11 Ehaliden keçen abonentler haqqında melumat(Senaye)");
                node.Nodes.Add("1.12 Bütün obyektlər(Senaye)");
        */
                node.Expand();
    }

    private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        switch (e.Node.Text.Substring(0, 4).Trim())
        {
            case "1.1":
                if (p_var.n_rol != "8")
                {
                    MessageBox.Show("Bu bölmə Admin roluna aiddir !!!");
                    return;
                }
                Silmuq.ShowDialog();
                break;
            case "1.2":
                MessageBox.Show("1.2");
                break;
        }

    }

    }
 }


