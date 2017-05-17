<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentsManagement.aspx.cs" Inherits="StudentsManagement" %>


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
        <div>إدارة الطلاب</div>
       
        <hr />

         <div id="alert_div" class="my-alert alert alert-success" runat="server">
          <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
      </div>
      

 <div class="form-horizontal" role="form" data-toggle="validator">
  
     <div class="form-group">
    <label class="control-label col-sm-2" for="txtName">الاسم الأول:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtFirstName"  CssClass="form-control required" runat="server" OnTextChanged="txtFirstName_TextChanged"></asp:TextBox>
       
     
    </div>
  </div>
     <div class="form-group">
    <label class="control-label col-sm-2" for="txtAccount">اسم الأب:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtSecondName"  CssClass="form-control required" runat="server"></asp:TextBox>
     
    </div>
  </div>
     <div class="form-group">
    <label class="control-label col-sm-2" for="txtPassword"> اسم العائلة:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtLastName"  CssClass="form-control required" runat="server"></asp:TextBox>

    </div>
  </div>
     <div class="form-group">
    <label class="control-label col-sm-2" for="txtConfirmPassword" >رقم الهوية:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtID"  CssClass="form-control required" runat="server"></asp:TextBox>
     
    </div>
  </div>


</div>


    
		
        <div class="clear"></div> 
        <div>
            <asp:TextBox ID="txtStudentCode" runat="server" Visible="False"></asp:TextBox>
            &nbsp;</div> 
    <div class="MyButtons">
                <asp:Button ID="btnSave" runat="server" Text="حفظ" class="btn btn-lg btn-primary" Width="125px" OnClick="btnSearch_Click1"/>
      </div>
    </div>
    
     <div class="grid-view">
        <asp:GridView ID="gvData" runat="server"   AutoGenerateColumns="False" Width="100%" DataKeyNames="Std_Code" OnSelectedIndexChanging="gvData_SelectedIndexChanging"  OnRowDeleting="gvData_RowDeleting">
             <%-- <FooterStyle BackColor="#2461BF" Font-Bold="True" ForeColor="White" />--%>
            <Columns>
                <asp:BoundField DataField="Std_Code" HeaderText="Std_Code" Visible="False" />
                <asp:BoundField DataField="Std_FirstName" HeaderText="الاسم الأول" />
                <asp:BoundField DataField="Std_SecondName" HeaderText="اسم الأب" />
             
                <asp:BoundField DataField="Std_LastName" HeaderText="اسم العائلة" />
             
                <asp:BoundField DataField="Std_ID" HeaderText="رقم الهوية" />
             
                <asp:CommandField ButtonType="Image" HeaderText="تعديل" SelectImageUrl="~/images/edit-48.png" SelectText="" ShowSelectButton="True" />
             
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/garbage-32.png" HeaderText="حذف" ShowDeleteButton="True" />
             
            </Columns>
           <%--  <PagerStyle  BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" CssClass="grid-paging"/>--%>
          <PagerStyle  CssClass="pagination-ys" HorizontalAlign="Center" BorderColor="White"/>
        </asp:GridView>
           
     </div>
    
    
</asp:Content>
