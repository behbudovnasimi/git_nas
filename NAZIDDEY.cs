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
    public partial class NAZIDDEY : Form
    {
        public NAZIDDEY()
        {
            InitializeComponent();
        }
        
        DataTable DT = new DataTable();
        string n_str = "";
        
        MT_err mt_err = new MT_err();

        private void button1_Click(object sender, EventArgs e) //Təsdiq 
        {
            if (DT.Rows.Count > 0)
            {
                if (MessageBox.Show("Nazirlik tipi dəyışdirilsin?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { return; }
                this.Refresh();

                System.IO.File.Delete(@"Text.txt"); //Silinmə
                this.WindowState = FormWindowState.Minimized;

                string n_dat1 = DateTime.Now.ToString();
                if (n_logs.my_logs(p_var.n_uzer_name, "qahali.subscriber-nəzarətçi id", n_dat1) == "E") //Loqlama ilkin
                { return; }// Bazada sehv

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Text.txt", true))
                {
                    file.WriteLine("SUBID NAZ_ID");
                }

                for (int i = 0; i <= DT.Rows.Count-1; i++)
                {
                    if (DT.Rows[i]["SUBID"].ToString() != "")
                    {
                        p_var.n_rez = my_metod_0(DT.Rows[i]["SUBID"].ToString(), DT.Rows[i]["NAZ_ID"].ToString()); //Subscriber de NAZIDDEY deyiş.

                        if (p_var.n_rez.Substring(0, 1) != "Y")
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Text.txt", true))
                            {
                                file.WriteLine(p_var.n_rez + " " + DT.Rows[i]["NAZ_ID"].ToString());
                            }
                        }
                    }
                    this.Text = "SUBID : " + DT.Rows[i]["SUBID"].ToString();
                    this.Refresh();
                }

                if (n_logs.my_logs(p_var.n_uzer_name, "qahali.subscriber-nəzarətçi id", n_dat1) == "E") //Loqlama ilkin
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

        private void NAZIDDEY_Load(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"Text.txt"); //Silinmə
            textEdit1.Text="";
            button1.Enabled = false;
            if (File.Exists("Text.txt"))
            {
                button4.Enabled = true;
            }

            OleDbConnection oConn = new OleDbConnection();
            OleDbCommand oCmd = oConn.CreateCommand();
            DataTable resultTable = new DataTable();
            string field_1, field_2 = "";

            try
            {
                oConn.ConnectionString = p_var.n_conn;
                oConn.Open();
                oCmd = oConn.CreateCommand();
                comboBox1.Sorted = true;
                oCmd.CommandText = @"select id_seq ,name from QAHALI.TBL_CODE_3 order by name";

                resultTable.Load(oCmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serverə müraciətdə xəta yarandı: " + ex.Message);
                this.Close();
                return;
            }

            comboBox1.Items.Clear();
            for (int m = 1 ; m <= resultTable.Rows.Count ; m++)  //comboboxsu doldurmaq
            {
                DataRow rowi = resultTable.Rows[resultTable.Rows.Count - m];
                    field_1 = rowi["name"].ToString().Trim();
                    field_2 = rowi["id_seq"].ToString().Trim();
                    comboBox1.Items.Add(field_1 + ":" + field_2);
            }
            comboBox1.SelectedIndex = 0;
            comboBox1.Focus();
            oConn.Close();
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
                this.Refresh();
                DT.Columns.Clear();
                try
                {
                    OleDbCommand oCmd1 = oConn1.CreateCommand();
                    oConn1.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + OPF.FileName +
                                            ";Extended Properties=Excel 12.0 Xml";
                    oConn1.Open();
                    oCmd1 = oConn1.CreateCommand();
                    oCmd1.CommandText = @"select * from [List1$]";
                    DT.Load(oCmd1.ExecuteReader());
                    n_str = DT.Rows[0]["SUBID"].ToString()+DT.Rows[1]["NAZ_ID"].ToString();
                }
                catch (Exception ex)
                {
                    DT.Columns.Clear();
                    if (ex.Message.IndexOf("does not belong to table") > 0 || ex.Message.IndexOf("не принадлежит таблице") > 0)
                    {
                        button1.Enabled = false;
                        MessageBox.Show(@"Seçilmiş xlsx ın xanaları Nəzarətç tipi şablonuna uyğun gəlmir,xanaların adlarını yoxla! ", "Şablonda sehv var !");
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
        public string my_metod_0(string s1, string s2)
        {
            OracleConnection conn = new OracleConnection(p_var.n_conn1);
            OracleCommand cmd = new OracleCommand();
            var v_EXIT = "$";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AHALI.H_NAZ_ID_xlsx"; // Name_function

            cmd.Parameters.Add("v_RETU", OracleType.VarChar);
            cmd.Parameters["v_RETU"].Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["v_RETU"].Size = 1024;

            cmd.Parameters.Add("v_SUBID", OracleType.VarChar);
            cmd.Parameters["v_SUBID"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_SUBID"].Value = s1;

            cmd.Parameters.Add("v_NAZ_ID", OracleType.VarChar);
            cmd.Parameters["v_NAZ_ID"].Direction = ParameterDirection.Input;
            cmd.Parameters["v_NAZ_ID"].Value = s2;
            
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
            File.WriteAllBytes("Naziddey.xlsx", Properties.Resources.Naziddey);
        }

         private void NAZIDDEY_FormClosed(object sender, FormClosedEventArgs e)
         {
             p_var.n_rez = "N";
             this.Close();
             return;
         }

         private void textEdit1_Click(object sender, EventArgs e)
         {
             Process.Start("EXCEL.EXE", " /e " + OPF.FileName);
         }

         private void button5_Click(object sender, EventArgs e)
         {
             comboBox1.Visible = (comboBox1.Visible) ? false : true;
         }

         private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (comboBox1.SelectedIndex >=0)
             {
                 Clipboard.SetText(comboBox1.SelectedItem.ToString().Substring(comboBox1.SelectedItem.ToString().IndexOf(':') + 1).Trim());
             }
         }


    }
}
