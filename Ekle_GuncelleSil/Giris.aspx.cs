using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Giris : System.Web.UI.Page
{
    Fonksiyon system = new Fonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl1 = (Label)Master.FindControl("lblSayfaBaslik");
        lbl1.Text = "Üye Giriş";
    }

    protected void btnGirisYap_Click(object sender, EventArgs e)
    {
        SqlConnection baglanti = system.baglan();
        SqlCommand cmdGirisYap = new SqlCommand("select AdSoyad='"+
            txtKullaniciAdi.Text + "',Sifre='" + txtSifre.Text + "' from Yazarlar", baglanti);
        //cmdKaydet.Parameters.Add("AdSoyad",txtKullaniciAdi.Text).ToString();
        //cmdKaydet.Parameters.Add("Sifre", txtSifre.Text).ToString();
        cmdGirisYap.ExecuteNonQuery();
        if (cmdGirisYap != null)
        {
            Session["KullaniciAdi"] = txtKullaniciAdi.Text.ToString();
           
        }
        Response.Redirect("Yonetim.aspx");
    }
}