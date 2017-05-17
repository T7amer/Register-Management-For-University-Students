using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

public partial class CourseManagement : System.Web.UI.Page
{
    string BaseAlertClass = "alert";//تحديد كلاس التنبيه
    string CloseAlrt = "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'></button>";//اغلاق ديف التنبيه
    string ErrorClass = " alert-danger ";//تنبيه خطا
    string SuccessClass = " alert-success ";//تنبيه نجاح
   
    DataAccess DA = new DataAccess();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "إدارة المواد";
        BindGrid();
    }
  
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        //فحص ادخال البيانات
        if(txtCourseName.Text.Trim() =="")
        {
            alert_div.Attributes["class"] = BaseAlertClass + ErrorClass;
            alert_div.InnerHtml = "أدخل اسم المادة" + CloseAlrt;

             
        }
        else if (txtCourseNO.Text.Trim() == "")
        {
            alert_div.Attributes["class"] = BaseAlertClass + ErrorClass;
            alert_div.InnerHtml = "أدخل رقم المادة" + CloseAlrt;


        }
       
        else
        {
            if (btnSave.Text == "حفظ")//مود الحفظ
            {
                DA.AddNewCourse(txtCourseName.Text, txtCourseNO.Text, int.Parse(ddlHrs.SelectedValue.ToString()));//تنفيذ الاضافة
                alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;//اظهار رسالة النجاح
                alert_div.InnerHtml = "تم الحفظ بنجاح" + CloseAlrt;
            }
            else if (btnSave.Text == "تعديل")//مود التعديل
            {//تنفيذ اتعديل
                DA.UpdateCourse(int.Parse(txtCourseCode.Text), txtCourseName.Text, txtCourseNO.Text, int.Parse(ddlHrs.SelectedValue.ToString()));
                alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;//اظهار رسالة النجاح
                alert_div.InnerHtml = "تم التعديل بنجاح" + CloseAlrt;
                btnSave.Text = "حفظ";//ارجاع المود للحفظ
            }

            BindGrid();//رسم الجدول
            ClearForm();//تفريغ الحقول

        }
       
    }
    private void BindGrid()//جلب البيانات ورسم الجدول
    {
        gvData.DataSource = DA.GetCourses();
        gvData.DataBind();
    }
    protected void ClearForm()//تفريغ الحقول
    {
        
        txtCourseNO.Text = "";
        txtCourseName.Text = "";
        txtCourseCode.Text = "";
    }
   
    protected void gvData_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
    {//تم الضغط على زر تعديل
        int CourseID = int.Parse(gvData.DataKeys[e.NewSelectedIndex]["Crs_Code"].ToString());//عرض البيانات في الحقول تمهيدا لتعديلها
        txtCourseName.Text = gvData.Rows[e.NewSelectedIndex].Cells[1].Text;
        txtCourseNO.Text = gvData.Rows[e.NewSelectedIndex].Cells[2].Text;
        ddlHrs.SelectedValue = gvData.Rows[e.NewSelectedIndex].Cells[3].Text;
        txtCourseCode.Text = CourseID.ToString();
       

        btnSave.Text = "تعديل";

    }
   
  
  
    protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {//تم الضغط على زر الحذف
        int CrsID = int.Parse(gvData.DataKeys[e.RowIndex]["Crs_Code"].ToString());
        //تنفيذ الحذف
        DA.DeleteCourse(CrsID);
        alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;//عرض رسالة النجاح
        alert_div.InnerHtml = "تم الحذف بنجاح" + CloseAlrt;
        BindGrid();//اعادة رسم الجدول
    }

    protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}