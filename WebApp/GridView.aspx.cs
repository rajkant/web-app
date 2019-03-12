using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class GridView : System.Web.UI.Page
    {
        OleDbConnection objConn;
        OleDbCommand objCmd;
        String strSQL;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Microsoft.ACE.OLEDB.12.0;            
            objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\WebApp.mdb"));
            objConn.Open();

            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        
        protected void BindData()
        {
            String strSQL;
            strSQL = "SELECT * FROM customer";

            OleDbDataReader dtReader;
            objCmd = new OleDbCommand(strSQL, objConn);
            dtReader = objCmd.ExecuteReader();

            //*** BindData to GridView ***//
            myGridView.DataSource = dtReader;
            myGridView.DataBind();

            dtReader.Close();
            dtReader = null;

        }

        protected void Page_UnLoad()
        {
            objConn.Close();
            objConn = null;
        }

        protected void modEditCommand(object sender, GridViewEditEventArgs e)
        {
            myGridView.EditIndex = e.NewEditIndex;
            myGridView.ShowFooter = false;
            BindData();
        }

        protected void modCancelCommand(object sender, GridViewCancelEditEventArgs e)
        {
            myGridView.EditIndex = -1;
            myGridView.ShowFooter = true;
            BindData();
        }

        protected void modDeleteCommand(object sender, GridViewDeleteEventArgs e)
        {
            strSQL = "DELETE FROM customer WHERE CustomerID = '" + myGridView.DataKeys[e.RowIndex].Value + "'";
            objCmd = new OleDbCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            myGridView.EditIndex = -1;
            BindData();
        }

        protected void modUpdateCommand(object sender, GridViewUpdateEventArgs e)
        {
            //*** CustomerID ***//
            TextBox txtCustomerID = (TextBox)myGridView.Rows[e.RowIndex].FindControl("txtEditCustomerID");
            //*** Name ***//
            TextBox txtName = (TextBox)myGridView.Rows[e.RowIndex].FindControl("txtEditName");
            //*** Email ***//
            TextBox txtEmail = (TextBox)myGridView.Rows[e.RowIndex].FindControl("txtEditEmail");
            //*** CountryCode ***//
            TextBox txtCountryCode = (TextBox)myGridView.Rows[e.RowIndex].FindControl("txtEditCountryCode");
            //*** Budget ***//
            TextBox txtBudget = (TextBox)myGridView.Rows[e.RowIndex].FindControl("txtEditBudget");
            //*** Used ***//
            TextBox txtUsed = (TextBox)myGridView.Rows[e.RowIndex].FindControl("txtEditUsed");

            strSQL = "UPDATE customer SET CustomerID = '" + txtCustomerID.Text + "' " +
                " ,Name = '" + txtName.Text + "' " +
                " ,Email = '" + txtEmail.Text + "' " +
                " ,CountryCode = '" + txtCountryCode.Text + "' " +
                " ,Budget = '" + txtBudget.Text + "' " +
                " ,Used = '" + txtUsed.Text + "' " +
                " WHERE CustomerID = '" + myGridView.DataKeys[e.RowIndex].Value + "'";
            objCmd = new OleDbCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            myGridView.EditIndex = -1;
            myGridView.ShowFooter = true;
            BindData();
        }

        protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                //*** CustomerID ***//
                TextBox txtCustomerID = (TextBox)myGridView.FooterRow.FindControl("txtAddCustomerID");
                //*** Name ***//
                TextBox txtName = (TextBox)myGridView.FooterRow.FindControl("txtAddName");
                //*** Email ***//
                TextBox txtEmail = (TextBox)myGridView.FooterRow.FindControl("txtAddEmail");
                //*** CountryCode ***//
                TextBox txtCountryCode = (TextBox)myGridView.FooterRow.FindControl("txtAddCountryCode");
                //*** Budget ***//
                TextBox txtBudget = (TextBox)myGridView.FooterRow.FindControl("txtAddBudget");
                //*** Used ***//
                TextBox txtUsed = (TextBox)myGridView.FooterRow.FindControl("txtAddUsed");

                strSQL = "INSERT INTO customer (CustomerID,Name,Email,CountryCode,Budget,Used) " +
                    " VALUES ('" + txtCustomerID.Text + "','" + txtName.Text + "','" + txtEmail.Text + "' " +
                    " ,'" + txtCountryCode.Text + "','" + txtBudget.Text + "','" + txtUsed.Text + "') ";
                objCmd = new OleDbCommand(strSQL, objConn);
                objCmd.ExecuteNonQuery();

                BindData();
            }
        }
    }
}