using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim : System.Web.UI.Page
{
    Fonksiyon system = new Fonksiyon();
    string YazarId = "";
    string islem = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl1 = (Label)Master.FindControl("lblSayfaBaslik");
        lbl1.Text = "Üye Yönetimi";

        YazarId = Request.QueryString["YazarId"];
        islem = Request.QueryString["islem"];


        if (Session["KullaniciAdi"]==null)
        {
            Response.Redirect("Giris.aspx"); 
        }
        else
        {  
            DataTable dt = system.GetDataTable("select YazarId,AdSoyad,Sifre from Yazarlar");
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        if (islem=="Sil")
        {
            system.cmd("Delete From Yazarlar Where YazarId="+YazarId);
            Response.Redirect("Yonetim.aspx");
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}