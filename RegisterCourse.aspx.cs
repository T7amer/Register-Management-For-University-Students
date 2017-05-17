using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

public partial class RegisterCourse : System.Web.UI.Page
{
    string BaseAlertClass = "alert";//تحديد كلاس التنبيه
    string CloseAlrt = "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'></button>";//اغلاق ديف التنبيه
    string ErrorClass = " alert-danger ";//تنبيه خطا
    string SuccessClass = " alert-success ";//تنبيه نجاح
   
    DataAccess DA = new DataAccess();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "تسجيل طالب في مادة";

        BindGrid();//رسم الجدول

        if (!IsPostBack)//رسم الكومبو فقط في حالة فتح الشاشة وليش عند البوست باك
        {
            BindStudents();
            BindCourses();
        }
    }
  
    private void BindStudents()//تعبئة الطلاب
    {
        ddlStudent.DataSource = DA.GetStudents();
        ddlStudent.DataBind();
    }
    private void BindCourses()
    {//تعبئة لبكورسات
        ddlCourse.DataSource = DA.GetCourses();
        ddlCourse.DataBind();
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {//حفظ البيانات
        DA.RegisterCourse(int.Parse(ddlStudent.SelectedValue.ToString()), int.Parse(ddlCourse.SelectedValue.ToString()));

                alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;//عرض رسالة النجاح
                alert_div.InnerHtml = "تم الحفظ بنجاح" + CloseAlrt;
        //اعادة رسم البيانات
                BindGrid();
                BindCourses();
                BindStudents();
              
}
    private void BindGrid()//جلب البيانات وعرضها بالجدول
    {
        gvData.DataSource = DA.GetRegisteredCourses();
        gvData.DataBind();
    }
   
   
   
}