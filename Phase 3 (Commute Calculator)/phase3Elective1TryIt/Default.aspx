<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="phase3Elective1TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Phase 3 - Commute Calculator Try It</h1>
        <p class="lead">This service takes two user-entered addresses or zip codes, calculates the route time, and rates it out of 10 based on how long the optimal route is in minutes.</p>
        <p class="lead">string getCommute(string address1, string address2): returns a string array with two elements. Element 1 is the commute time in minutes, element 2 is the rating calculated.</p>
        <p class="lead">string calculateRating(string address1, string address2): returns the rating out of 10 based on the route length.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Home Address or ZIP</h2>
            <p>
                Address 1:
                <asp:TextBox ID="textboxAddress1" runat="server"></asp:TextBox>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Commute Address or ZIP</h2>
            <p>
                Address 2:<asp:TextBox ID="textboxAddress2" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Results</h2>
            <p>
                Commute Time (minutes):
                <asp:TextBox ID="textBoxTime" runat="server"></asp:TextBox>
            </p>
            <p>
                Commute Rating (out of 10):<asp:TextBox ID="textboxRating" runat="server"></asp:TextBox>
            </p>
        </div>
    </div>

</asp:Content>
