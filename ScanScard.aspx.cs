using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FinishGoodSMT
{
    public partial class ScanScard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlbl.Visible = true;
            userlabel.Text = Session["user"].ToString(); 
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = Session["workOrder"].ToString();
            txtWorkOrder.Text = str;
            dataModel.Text = Session["modelWO"].ToString();
            dataQtyWO.Text = Session["qty"].ToString();
            string str2 = Session["modelWO"].ToString();
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetAccumulatedWOScardFG", connection1);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection1.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand2.CommandTimeout = 9000;
            SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            sqlDataReader1.Read();
            int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Accumulated"));
            connection1.Close();
            dataAcumWO.Text = int32_1.ToString();
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand sqlCommand3 = new SqlCommand("GetAccumulatedDayScardFG", connection2);
            sqlCommand3.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand4 = sqlCommand3;
            connection2.Open();
            sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand4.CommandTimeout = 9000;
            SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            sqlDataReader2.Read();
            int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("Accumulated"));
            connection2.Close();
            dataAcumDia.Text = int32_2.ToString();
            SqlConnection connection3 = new SqlConnection(connectionString);
            SqlCommand sqlCommand5 = new SqlCommand("GetTotalMainFG", connection3);
            sqlCommand5.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand6 = sqlCommand5;
            connection3.Open();
            sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand6.CommandTimeout = 9000;
            SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
            sqlDataReader3.Read();
            int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Repair"));
            connection3.Close();
            dataQtyRepair.Text = int32_3.ToString();
            SqlConnection connection4 = new SqlConnection(connectionString);
            SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedWOScrapScard", connection4);
            sqlCommand7.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand8 = sqlCommand7;
            connection4.Open();
            sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
            sqlDataReader4.Read();
            int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Accumulated"));
            connection4.Close();
            dataQtyScrap.Text = int32_4.ToString();
            SqlConnection connection5 = new SqlConnection(connectionString);
            SqlCommand sqlCommand9 = new SqlCommand("GetPiecesPerPanel", connection5);
            sqlCommand9.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand10 = sqlCommand9;
            connection5.Open();
            sqlCommand10.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = str2;
            SqlDataReader sqlDataReader5 = sqlCommand10.ExecuteReader();
            sqlDataReader5.Read();
            int int32_5 = sqlDataReader5.GetInt32(sqlDataReader5.GetOrdinal("PiecesPerPanel"));
            connection5.Close();
            dataPieces.Text = int32_5.ToString();
            
            txtQRMain.Focus();

        }

        protected void txtQRMain_TextChanged(object sender, EventArgs e)
        {
            txtQty.Enabled = true;
            txtQRMain.Enabled = false;
        }

  
        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str2 = Session["modelWO"].ToString();
            string str3 = Session["workOrder"].ToString();
            if (str2.ToString() == txtQRMain.Text.ToString())
            {
                
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlCommand sqlCommand3 = new SqlCommand("AddScardPanelFG", connection2);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand4 = sqlCommand3;
                connection2.Open();
                sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str3;
                sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = str2;
                sqlCommand4.Parameters.Add("@Pieces", SqlDbType.Int, 32).Value = Convert.ToInt32(txtQty.Text.ToString());
                sqlCommand4.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = DateTime.Now;
                sqlCommand4.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = userlabel.Text.ToLower();
                sqlCommand4.CommandTimeout = 9000;
                SqlDataReader sqlDataReader10 = sqlCommand4.ExecuteReader();
                sqlDataReader10.Read();
                int rowsInserted = sqlDataReader10.GetInt32(sqlDataReader10.GetOrdinal("RowAffected"));
                //
                if (rowsInserted == 1)
                {
                    res.Attributes.Add("class", "alert alert-success");
                    res.Attributes.Add("role", "alert");
                    res.Text = "PANEL INGRESADO";
                    res.ForeColor = System.Drawing.Color.Green;
                    dataQRSN.Text = txtQRMain.Text.ToString();
                    txtQRMain.Text = "";
                    txtQty.Enabled = false;
                    txtQRMain.Enabled = true;
                    txtQRMain.Focus();
                    txtQty.Text = "";

                }
                else
                {
                    res.Attributes.Add("class", "alert alert-danger font-weight-bold");
                    res.Attributes.Add("role", "alert");
                    res.Text = "CONTACTAR A IT";
                    res.ForeColor = System.Drawing.Color.Red;
                    dataQRSN.Text = txtQRMain.Text.ToString();
                    txtQRMain.Text = "";
                    txtQty.Enabled = false;
                    txtQRMain.Enabled = true;
                    // txtCodeDefect.Text = "";
                    txtQty.Text = "";
                    txtQRMain.Focus();
                }
                connection2.Close();
            }
            else
            {
                res.Attributes.Add("class", "alert alert-danger font-weight-bold");
                res.Attributes.Add("role", "alert");
                res.Text = "PANEL NO INGRESADO, REVISA EL CODIGO QR DEL MODELO ";
                res.ForeColor = System.Drawing.Color.Red;
                dataQRSN.Text = txtQRMain.Text.ToString();
                txtQty.Enabled = false;
                txtQRMain.Enabled = true;
                txtQRMain.Text = "";
                // txtCodeDefect.Text = "";
                txtQRMain.Focus();
                txtQty.Text = "";
            }

            SqlConnection connection3 = new SqlConnection(connectionString);
            SqlCommand sqlCommand5 = new SqlCommand("GetAccumulatedWOScardFG", connection3);
            sqlCommand5.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand6 = sqlCommand5;
            connection3.Open();
            sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str3;
            sqlCommand6.CommandTimeout = 9000;
            SqlDataReader sqlDataReader2 = sqlCommand6.ExecuteReader();
            sqlDataReader2.Read();
            int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("Accumulated"));
            connection3.Close();
            dataAcumWO.Text = int32_2.ToString();
            SqlConnection connection4 = new SqlConnection(connectionString);
            SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedDayScardFG", connection4);
            sqlCommand7.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand8 = sqlCommand7;
            connection4.Open();
            sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str3;
            sqlCommand8.CommandTimeout = 9000;
            SqlDataReader sqlDataReader3 = sqlCommand8.ExecuteReader();
            sqlDataReader3.Read();
            int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Accumulated"));
            connection4.Close();
            dataAcumDia.Text = int32_3.ToString();
            SqlConnection connection5 = new SqlConnection(connectionString);
            SqlCommand sqlCommand9 = new SqlCommand("GetTotalMainFG", connection5);
            sqlCommand9.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand10 = sqlCommand9;
            connection5.Open();
            sqlCommand10.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str3;
            sqlCommand10.CommandTimeout = 9000;
            SqlDataReader sqlDataReader4 = sqlCommand10.ExecuteReader();
            sqlDataReader4.Read();
            int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Repair"));
            connection5.Close();
            dataQtyRepair.Text = int32_4.ToString();
            SqlConnection connection6 = new SqlConnection(connectionString);
            SqlCommand sqlCommand11 = new SqlCommand("GetAccumulatedWOScrapScard", connection6);
            sqlCommand11.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand12 = sqlCommand11;
            connection6.Open();
            sqlCommand12.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str3;
            SqlDataReader sqlDataReader5 = sqlCommand12.ExecuteReader();
            sqlDataReader5.Read();
            int int32_5 = sqlDataReader5.GetInt32(sqlDataReader5.GetOrdinal("Accumulated"));
            connection6.Close();
            dataQtyScrap.Text = int32_5.ToString();
            txtQRMain.Focus();
            txtQRMain.Text = "";
        }
    }
}