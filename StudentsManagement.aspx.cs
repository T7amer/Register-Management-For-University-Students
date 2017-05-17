using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

public partial class StudentsManagement : System.Web.UI.Page
{

    string BaseAlertClass = "alert";//تحديد كلاس التنبيه
    string CloseAlrt = "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'></button>";//اغلاق ديف التنبيه
    string ErrorClass = " alert-danger ";//تنبيه خطا
    string SuccessClass = " alert-success ";//تنبيه نجاح
   
    DataAccess DA = new DataAccess();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        Title = "إدارة الطلاب";
        BindGrid();//عرض البيانات


    }
   
   
  
    protected void btnSearch_Click1(object sender, EventArgs e)
    {//التاكد من ادخال البيانات
        if(txtFirstName.Text.Trim() =="")
        {
            alert_div.Attributes["class"] = BaseAlertClass + ErrorClass;
            alert_div.InnerHtml = "أدخل الاسم الأول" + CloseAlrt;

             
        }
        else if (txtSecondName.Text.Trim() == "")
        {
            alert_div.Attributes["class"] = BaseAlertClass + ErrorClass;
            alert_div.InnerHtml = "أدخل اسم الأب" + CloseAlrt;


        }
        else if (txtLastName.Text.Trim() == "")
        {
            alert_div.Attributes["class"] = BaseAlertClass + ErrorClass;
            alert_div.InnerHtml = "أدخل اسم العائلة" + CloseAlrt;


        }
        else if (txtID.Text.Trim() == "")
        {
            alert_div.Attributes["class"] = BaseAlertClass + ErrorClass;
            alert_div.InnerHtml = "أدخل رقم الهوية" + CloseAlrt;


        }
        else
        {
            if (btnSave.Text == "حفظ")//مود الحفظ
            {
                //تنفيذ الاضافة
                DA.AddNewStudent(txtFirstName.Text, txtSecondName.Text, txtLastName.Text, txtID.Text);

                alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;//عرض الرسالة
                alert_div.InnerHtml = "تم الحفظ بنجاح" + CloseAlrt;
            }
            else if (btnSave.Text == "تعديل")//مود التعديل
            {
                DA.UpdateStudent(int.Parse(txtStudentCode.Text),txtFirstName.Text, txtSecondName.Text, txtLastName.Text, txtID.Text);
                alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;
                alert_div.InnerHtml = "تم التعديل بنجاح" + CloseAlrt;
                btnSave.Text = "حفظ";
            }

            BindGrid();//اعادة رسم الجدول
            ClearForm();//تفريغ الحقول

        }
       
    }
    private void BindGrid()//جلب البيانات ورسم الجدول
    {
        gvData.DataSource = DA.GetStudents();
        gvData.DataBind();
    }
    protected void ClearForm()//تفريغ الحقول
    {
        txtFirstName.Text = "";
        txtSecondName.Text = "";
        txtLastName.Text = "";
        txtID.Text = "";
        txtStudentCode.Text = "";
    }
   
    protected void gvData_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
    {//عرض البيانات في الحقول تمهيدا لتعديلها
        int UserID = int.Parse(gvData.DataKeys[e.NewSelectedIndex]["Std_Code"].ToString());
        txtFirstName.Text = gvData.Rows[e.NewSelectedIndex].Cells[1].Text;
        txtSecondName.Text = gvData.Rows[e.NewSelectedIndex].Cells[2].Text;
        txtLastName.Text = gvData.Rows[e.NewSelectedIndex].Cells[3].Text;
        txtID.Text = gvData.Rows[e.NewSelectedIndex].Cells[4].Text;
        txtStudentCode.Text = UserID.ToString();
       

        btnSave.Text = "تعديل";

    }
   
  
   
    protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {//تم الضغط على زر حذف
        int StdID = int.Parse(gvData.DataKeys[e.RowIndex]["Std_Code"].ToString());

        //تنفيذ الحذف
        DA.DeleteStudent(StdID);
        alert_div.Attributes["class"] = BaseAlertClass + SuccessClass;
        alert_div.InnerHtml = "تم الحذف بنجاح" + CloseAlrt;
        BindGrid();
    }

    protected void txtFirstName_TextChanged(object sender, EventArgs e)
    {

    }
}