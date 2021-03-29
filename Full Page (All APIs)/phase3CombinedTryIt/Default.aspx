<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="phase3CombinedTryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>&nbsp;Restaurants, Stores, and Commute</h1>
        <p class="lead">This site will allow the user to enter an address or ZIP for a possible home and the web services find the nearest store of their choice, the top 5 restaurants nearby that fit their preferences, calculate what the commute would be to a work address or ZIP, and rate that commute out of 10.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Home Address (* means required)</h2>
            <p>
                Street Address:
                <asp:TextBox ID="textboxHomeStreet" runat="server" Width="181px"></asp:TextBox>
            </p>
            <p>
                City:<asp:TextBox ID="textboxHomeCity" runat="server" Width="153px"></asp:TextBox>
            </p>
            <p>
                State:<asp:TextBox ID="textboxHomeState" runat="server" Width="148px"></asp:TextBox>
            </p>
            <p>
                *ZIP:<asp:TextBox ID="textboxHomeZip" runat="server" Width="154px"></asp:TextBox>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Work Address (* means required)</h2>
            <p>Street Address:<asp:TextBox ID="textboxWorkStreet" runat="server" Width="177px"></asp:TextBox>
            </p>
            <p>City:<asp:TextBox ID="textboxWorkCity" runat="server" Width="170px"></asp:TextBox>
            </p>
            <p>State:<asp:TextBox ID="textboxWorkState" runat="server" Width="165px"></asp:TextBox>
            </p>
            <p>*ZIP:<asp:TextBox ID="textboxWorkZip" runat="server" Width="168px"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GO" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Restaurant Preferences (Chinese, Mexican, etc.) and Preferred Store Name</h2>
            <p>
                Preference 1:<asp:TextBox ID="textboxPref1" runat="server"></asp:TextBox>
            </p>
            <p>
                Preference 2:<asp:TextBox ID="textboxPref2" runat="server"></asp:TextBox>
            </p>
            <p>
                Store Name:
                <asp:TextBox ID="textboxStoreName" runat="server"></asp:TextBox>
            </p>
        <div class="col-md-4">
            <h2>Results:</h2>
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <p>
                Commute (in minutes):<asp:TextBox ID="textboxResultCommute" runat="server" ReadOnly="True" Width="165px"></asp:TextBox>
            </p>
            <p>
                Commute Rating (out of 10):<asp:TextBox ID="textboxResultCommuteRating" runat="server" ReadOnly="True" Width="174px"></asp:TextBox>
            </p>
            <p>
                Store:<asp:TextBox ID="textboxResultStore" runat="server" ReadOnly="True" Width="1287px"></asp:TextBox>
            </p>
            <p>
                Top 5 Restaurants:<asp:TextBox ID="textboxResultTop5" runat="server" ReadOnly="True" Width="1188px"></asp:TextBox>
&nbsp;</p>
        </div>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
