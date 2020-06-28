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
    public partial class STIPDEY_S : Form
    {
        public STIPDEY_S()
        {
            InitializeComponent();
        }
        
        DataTable DT = new DataTable();
        string n_str1,n_str,n_str2,n_str3 = "";
        
        MT_err mt_err = new MT_err();

        private void button1_Click(object sender, EventArgs e) //Təsdiq 
        {
            if (DT.Rows.Count > 0)
            {
                if (MessageBox.Show("Nəzarətçi kodu dəyışdirilsin?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { return; }
                this.Refresh();

                System.IO.File.Delete(@"Text.txt"); //Silinmə
                this.WindowState = FormWindowState.Minimized;

                string n_dat1 = DateTime.Now.ToString();
                if (n_logs.my_logs(p_var.n_uzer_name, "ahali.submeter,meter_base-sayğac id", n_dat1) == "E") //Loqlama ilkin
                { return; }// Bazada sehv
                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Text.txt", true))
                {
                    file.WriteLine("SUBID   OLD_ID   NEW_ID  KS");
                }

                for (int i = 0; i <= DT.Rows.Count-1; i++)
                {
                    if (DT.Rows[i]["SUBID"].ToString() != "")
                    {
                        p_var.n_rez = my_metod_0(DT.Rows[i]["SUBID"].ToString(), DT.Rows[i]["OLD_ID"].ToString(), DT.Rows[i]["NEW_ID"].ToString(), DT.Rows[i]["KS"].ToString()); //Subscriber de STIPDEY_S deyiş.

                        if (p_var.n_rez.Substring(0, 1) != "Y")
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Text.txt", true))
                            {
                                file.WriteLine(p_var.n_rez + "   " + DT.Rows[i]["OLD_ID"].ToString() + "   " + DT.Rows[i]["NEW_ID"].ToString() + "   " + DT.Rows[i]["KS"].ToString());
                            }
                        }
                    }
                    this.Text = "SUBID : " + DT.Rows[i]["SUBID"].ToString();
                    this.Refresh();
                }

                if (n_logs.my_logs(p_var.n_uzer_name, "ahali.submeter,meter_base-sayğac id", n_dat1) == "E") //Loqlama ilkin
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

        private void STIPDEY_S_Load(object sender, EventArgs e)
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
                    n_str1 = DT.Rows[1]["OLD_ID"].ToString();
                    n_str2 = DT.Rows[2]["NEW_ID"].ToString();
                    n_str3 = DT.Rows[3]["KS"].ToString();
                }
                catch (Exception ex)
                {
                    DT.Columns.Clear();
                    if (ex.Message.IndexOf("does not belong to table") > 0 || ex.Message.IndexOf("не принадлежит таблице") > 0)
                    {
                        button1.Enabled = false;
                        MessageBox.Show(@"Seçilmiş xlsx ın xanaları STIPDEY_S şablonuna uyğun gəlmir,xanaların adlarını yoxla! ", "Şablonda sehv var !");
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
        public string my_metod_0(string s1, string s2, string s3, string s4)
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AHALI.HS_STIPDEY_S_xlsx"; // Name_function

            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 1024;

            cmd.Parameters.Add("v_SUBID", OracleType.VarChar);
            cmd.Parameters["v_SUBID"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_SUBID"].Value = s1;

            cmd.Parameters.Add("v_OLD_ID", OracleType.VarChar);
            cmd.Parameters["v_OLD_ID"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_OLD_ID"].Value = s2;

            cmd.Parameters.Add("v_NEW_ID", OracleType.VarChar);
            cmd.Parameters["v_NEW_ID"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_NEW_ID"].Value = s3;

            cmd.Parameters.Add("v_KS", OracleType.VarChar);
            cmd.Parameters["v_KS"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_KS"].Value = s4;

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
            File.WriteAllBytes("STIPDEY_S.xlsx", Properties.Resources.STIPDEY);
        }

         private void STIPDEY_S_FormClosed(object sender, FormClosedEventArgs e)
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
