<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CourseManagement.aspx.cs" Inherits="CourseManagement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.css" rel="stylesheet" />
     <link href="../css/StyleSheet.css" rel="stylesheet" />
    <link href="../css/fonts.css" rel="stylesheet" />
    <script src="../js/jquery-1.11.3.min.js"></script>
  
      <style type="text/css">
          .auto-style1 {
              width: 70%;
          }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
    <div>&nbsp;&nbsp;</div>
    <div class="search-parameters">
        <div>إدارة المواد</div>
       
        <hr />

         <div id="alert_div" class="my-alert alert alert-success" runat="server">
          <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
      </div>
     

 <div class="form-horizontal" role="form" data-toggle="validator">
  
     <div class="form-group">
    <label class="control-label col-sm-2" for="txtName">اسم الماده:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtCourseName"  CssClass="form-control required" runat="server"></asp:TextBox>
       
     
    </div>
  </div>
     <div class="form-group">
    <label class="control-label col-sm-2" for="txtAccount">رقم الماده:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtCourseNO"  CssClass="form-control required" runat="server"></asp:TextBox>
     
    </div>
  </div>
   <div class="form-group">
    <label class="control-label col-sm-2" for="txtName">عدد الساعات:</label>
    <div class="col-sm-10">
        <asp:DropDownList ID="ddlHrs" runat="server"  CssClass="form-control btn btn-default dropdown-toggle combo-box-form" DataTextField="Type_Name" DataValueField="Type_Code">
            <asp:ListItem Selected="True">1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
     
    </div>
          </div>
  


</div>


    
		
        <div class="clear"></div> 
        <div>
            <asp:TextBox ID="txtCourseCode" runat="server" Visible="False"></asp:TextBox>
            &nbsp;</div> 
    <div class="MyButtons">
                <asp:Button ID="btnSave" runat="server" Text="حفظ" class="btn btn-lg btn-primary" Width="125px" OnClick="btnSearch_Click1"/>
      </div>
    
     <div class="grid-view">
        <asp:GridView ID="gvData" runat="server"  AutoGenerateColumns="False" Width="100%" DataKeyNames="Crs_Code" OnSelectedIndexChanging="gvData_SelectedIndexChanging" OnRowDeleting="gvData_RowDeleting" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
             <%-- <FooterStyle BackColor="#2461BF" Font-Bold="True" ForeColor="White" />--%>
            <Columns>
                <asp:BoundField DataField="Std_Code" HeaderText="Crs_Code" Visible="False" />
                <asp:BoundField DataField="Crs_Name" HeaderText="اسم المادة" />
                <asp:BoundField DataField="Crs_No" HeaderText="رقم المادة" />
             
                <asp:BoundField DataField="Crs_Hours" HeaderText="عدد الساعات" />
             
                <asp:HyperLinkField DataNavigateUrlFields="Crs_Code" DataNavigateUrlFormatString="ShowCourseStudent.aspx?id={0}" HeaderText="عرض الطلاب المسجلين" Text="عرض" />
             
                <asp:CommandField ButtonType="Image" HeaderText="تعديل" SelectImageUrl="~/images/edit-48.png" SelectText="" ShowSelectButton="True" />
             
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/garbage-32.png" HeaderText="حذف" ShowDeleteButton="True" />
             
            </Columns>
           <%--  <PagerStyle  BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" CssClass="grid-paging"/>--%>
          <PagerStyle  CssClass="pagination-ys" HorizontalAlign="Center" BorderColor="White"/>
        </asp:GridView>
           
     </div>
    </div>
    
    
</asp:Content>
