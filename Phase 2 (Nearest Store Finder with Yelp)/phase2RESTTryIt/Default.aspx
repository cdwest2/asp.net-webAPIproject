<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="phase2RESTTryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>
                <asp:Label ID="Label1" runat="server" Text="Nearest Store Finder"></asp:Label>
            </h2>
            <p>
                This service finds the nearest store within 20 miles and returns the name and address of the store.
            </p>
            <p>
                METHODS AND SERVICES USED: </p>
            <p>
                findNearestStore(string zip, string storeName): takes in the user inputs to call the Yelp API and parse the JSON for the first element in the business list (which is sorted by distance).</p>
            <p>
                zipToCoord(string zip): takes the user entered zip code and converts it into latitude and longitude, uses a REST API called OpenDataSoft to do this. The result is used for findNearestStore.</p>
        </div>
        <div class="col-md-4">
            <h2>
                <asp:Label ID="Label2" runat="server" Text="Enter Info"></asp:Label>
            </h2>
            <p>
                Zip Code:
                <asp:TextBox ID="textboxZip" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
            <p>
                &nbsp;Store Name:<asp:TextBox ID="textboxName" runat="server" OnTextChanged="textboxName_TextChanged"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>
                <asp:Label ID="Label3" runat="server" Text="Result:"></asp:Label>
            </h2>
            <p>
                <asp:Label ID="resultLabel" runat="server" Text="No info entered."></asp:Label>
            </p>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
