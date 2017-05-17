<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowCourseStudent.aspx.cs" Inherits="ShowCourseStudent" %>


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
        <div>عرض الطلاب المسجلين في المادة</div>
       
        <hr />

         <div id="alert_div" class="my-alert alert alert-success" runat="server">
          <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
      </div>
     
    
     <div class="grid-view">
        <asp:GridView ID="gvData" runat="server"   AutoGenerateColumns="False" Width="100%" DataKeyNames="Crs_Code" >
             <%-- <FooterStyle BackColor="#2461BF" Font-Bold="True" ForeColor="White" />--%>
            <Columns>
                <asp:BoundField DataField="Std_Code" HeaderText="Crs_Code" Visible="False" />
                <asp:BoundField DataField="Full_Name" HeaderText="اسم الطالب" />
                <asp:BoundField DataField="Crs_Name" HeaderText="اسم المادة" />
                <asp:BoundField DataField="Crs_No" HeaderText="رقم المادة" />
             
                <asp:BoundField DataField="Crs_Hours" HeaderText="عدد الساعات" />
             
            </Columns>
           <%--  <PagerStyle  BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" CssClass="grid-paging"/>--%>
          <PagerStyle  CssClass="pagination-ys" HorizontalAlign="Center" BorderColor="White"/>
        </asp:GridView>
           
     </div>
    </div>
    
    
</asp:Content>
