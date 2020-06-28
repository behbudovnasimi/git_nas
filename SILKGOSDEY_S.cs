using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraEditors.Controls;
using System.Data.OracleClient;
using System.IO;
using System.Diagnostics;

namespace hesabat
{
    public partial class SILKGOSDEY_S : Form
    {
        public SILKGOSDEY_S()
        {
            InitializeComponent();
        }
        
        DataTable DT = new DataTable();
        string n_str1, n_str, n_str2, n_str3, n_str4, n_str5 = "";
        
        MT_err mt_err = new MT_err();

        private void button1_Click(object sender, EventArgs e) //Təsdiq 
        {
            if (DT.Rows.Count > 0)
            {
                if (MessageBox.Show("Ilkin göstərici dəyışdirilsin?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { return; }
                this.Refresh();

                System.IO.File.Delete(@"Text.txt"); //Silinmə
                this.WindowState = FormWindowState.Minimized;

                string n_dat1 = DateTime.Now.ToString();
                if (n_logs.my_logs(p_var.n_uzer_name, "qahali.submeter,ahali.subcontrol,pok", n_dat1) == "E") //Loqlama ilkin
                { return; }// Bazada sehv
                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Text.txt", true))
                {
                    file.WriteLine("SUBID  DATA  OLD_POK_M NEW_POK_M  OLD_POK_E NEW_POK_E ");
                }

                for (int i = 0; i <= DT.Rows.Count-1; i++)
                {
                    if (DT.Rows[i]["SUBID"].ToString() != "")
                    {
                        p_var.n_rez = my_metod_0(DT.Rows[i]["SUBID"].ToString(), DT.Rows[i]["DATA"].ToString(), DT.Rows[i]["OLD_POK_M"].ToString(), DT.Rows[i]["NEW_POK_M"].ToString(), DT.Rows[i]["OLD_POK_E"].ToString(), DT.Rows[i]["NEW_POK_E"].ToString()); //SUBMETER,SUBCONTROL da POK deyiş.

                        if (p_var.n_rez.Substring(0, 1) != "Y")
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Text.txt", true))
                            {
                                file.WriteLine(p_var.n_rez + "   " + DT.Rows[i]["DATA"].ToString() + "   " + DT.Rows[i]["OLD_POK_M"].ToString() + "   " + DT.Rows[i]["NEW_POK_M"].ToString() + "   " + DT.Rows[i]["OLD_POK_E"].ToString() + "   " + DT.Rows[i]["NEW_POK_E"].ToString());
                            }
                        }
                    }
                    this.Text = "SUBID : " + DT.Rows[i]["SUBID"].ToString();
                    this.Refresh();
                }

                if (n_logs.my_logs(p_var.n_uzer_name, "ahali.submeter,ahali.subcontrol,pok", n_dat1) == "E") //Loqlama ilkin
                { return; }// Bazada sehv

                if (File.Exists("Text.txt"))
                {
                    button4.Enabled = true;
                }
                this.WindowState = FormWindowState.Normal;
                MessageBox.Show("Əməliyyat yekunlaşdı.");
                this.Text = p_var.n_form;
            }
            DT.Clear();
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p_var.n_rez = "N";
            this.Close();
            return;
        }

        private void SILKGOSDEY_S_Load(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"Text.txt"); //Silinmə
            textEdit1.Text="";
            button1.Enabled = false;
            if (File.Exists("Text.txt"))
            {
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fun_I_D("I");
        }

        OpenFileDialog OPF = new OpenFileDialog();
        public void Fun_I_D(string s1)
        {
            OPF.Title = "xlsx faylı seç "; //OPF.Filter = "Файлы  txt|*.txt |Файлы cs|Form1.cs";//OPF.FileName = "lll";
            OPF.Filter = "Yalnız xlsx|*.xlsx";

            if (OPF.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            textEdit1.ToolTip = OPF.FileName;
            textEdit1.Text    = OPF.FileName;

            using (OleDbConnection oConn1 = new OleDbConnection())      // DT - doldurmaq
            {
                DT.Columns.Clear();
                this.Refresh();
                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + OPF.FileName +
                                            ";Extended Properties=Excel 12.0 Xml";
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();
                    oCmd1.CommandText = @"select * from [List1$]";
                    DT.Load(oCmd1.ExecuteReader());
                    n_str  = DT.Rows[0]["SUBID"].ToString();
                    n_str1 = DT.Rows[1]["DATA"].ToString();
                    n_str2 = DT.Rows[2]["OLD_POK_M"].ToString();
                    n_str3 = DT.Rows[3]["NEW_POK_M"].ToString();
                    n_str4 = DT.Rows[2]["OLD_POK_E"].ToString();
                    n_str5 = DT.Rows[3]["NEW_POK_E"].ToString();
                }
                catch (Exception ex)
                {
                    DT.Columns.Clear();
                    if (ex.Message.IndexOf("does not belong to table") > 0 || ex.Message.IndexOf("не принадлежит таблице") > 0)
                    {
                        button1.Enabled = false;
                        MessageBox.Show(@"Seçilmiş xlsx in xanaları SILKGOSDEY_S şablonuna uyğun gəlmir,xanaların adlarını yoxla! ", "Şablonda sehv var !");
                        oConn1.Close();
                        return;
                    }
                    else if (ex.Message.IndexOf("' is not a valid name") > 0 || ex.Message.IndexOf("[List1$]") > 0)
                    {
                        button1.Enabled = false;
                        MessageBox.Show("Seçilmiş xlsx faylının birinci səhifəsi List1 adlandırılmalıdır !", "Şablonda sehv var !");
                        oConn1.Close();
                        return;
                    }
                    else
                    {
                        button1.Enabled = false;
                        MessageBox.Show(OPF.FileName + " faylına müraciətdə xəta yarandı: " + ex.Message);
                        oConn1.Close();
                        return;
                    }
                }
                button1.Enabled = true;
                oConn1.Close();
                return;
            }
        }
        public string my_metod_0(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AHALI.H_SILKGOS_S_DEY_xlsx"; // Name_function

            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 1024;

            cmd.Parameters.Add("v_SUBID", OracleType.VarChar);
            cmd.Parameters["v_SUBID"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_SUBID"].Value = s1;

            cmd.Parameters.Add("v_DATA", OracleType.VarChar);
            cmd.Parameters["v_DATA"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_DATA"].Value = s2;

            cmd.Parameters.Add("v_POK_OLD_M", OracleType.VarChar);
            cmd.Parameters["v_POK_OLD_M"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_POK_OLD_M"].Value = s3;

            cmd.Parameters.Add("v_POK_NEW_M", OracleType.VarChar);
            cmd.Parameters["v_POK_NEW_M"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_POK_NEW_M"].Value = s4;

            cmd.Parameters.Add("v_POK_OLD_E", OracleType.VarChar);
            cmd.Parameters["v_POK_OLD_E"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_POK_OLD_E"].Value = s5;

            cmd.Parameters.Add("v_POK_NEW_E", OracleType.VarChar);
            cmd.Parameters["v_POK_NEW_E"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_POK_NEW_E"].Value = s6;
            
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                v_EXIT = cmd.Parameters["v_RETU"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serverə müraciətdə xəta yarandı: " + ex.Message);
                return ("E");
            }

            conn.Close();
            p_var.n_nez = v_EXIT;
            return (v_EXIT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mt_err.Text = "Deqiqleşdirilecek melumatlar !";
            mt_err.ShowDialog();
        }

         private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = pictureBox1.Visible ? false : true;
            File.WriteAllBytes("SILKGOSDEY_S.xlsx", Properties.Resources.SILKGOSDEY_S);
        }

         private void SILKGOSDEY_S_FormClosed(object sender, FormClosedEventArgs e)
         {
             p_var.n_rez = "N";
             this.Close();
             return;
         }

         private void textEdit1_Click(object sender, EventArgs e)
         {
             Process.Start("EXCEL.EXE", " /e " + OPF.FileName);
         }
    }
}
