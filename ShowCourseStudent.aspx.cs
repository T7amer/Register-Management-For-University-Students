using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

public partial class ShowCourseStudent : System.Web.UI.Page
{
    string BaseAlertClass = "alert fade in ";
    string CloseAlrt = "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'></button>";
    string ErrorClass = " alert-danger ";
    string SuccessClass = " alert-success ";
   
    DataAccess DA = new DataAccess();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "الطلاب المسجلين في المادة";

        if (Request.QueryString["id"] != null)//التاكد من ان الرابط يحتوي رقم الكورس المارد عرض بياناته
        {
            BindGrid();//عرض البيانات
        }
    }
  
  
   
    private void BindGrid()//جلب البيانات وعرضها بالجدول
    {
        gvData.DataSource = DA.GetStudentOFCourse(int.Parse(Request.QueryString["id"].ToString()));
        gvData.DataBind();
    }
   
  
   
}