<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="phase3Elective2TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Restaurant Preference Search</h1>
        <p class="lead">This service will take in two user preferences for restaurants (such as &quot;Mexican&quot; or &quot;Chinese&quot;) and compile a list of the top restaurants that match either of the preferences in the user&#39;s area.</p>
        <p class="lead">string[] restaurants(string zip, string preference1, string preference2): This method takes in the zip and the preferences and calls the Yelp API to get a list of matches. It will give the top 5 rated restaurants, but can give less if there are less than 5 matches for the search. </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Enter Zip Code</h2>
            <p>ZIP:
                <asp:TextBox ID="textboxZip" runat="server"></asp:TextBox>
            </p>
        </div>
        <div class="col-md-4">
            <h2>User Preferences</h2>
            <p>
                Preference 1:
                <asp:TextBox ID="textboxPref1" runat="server"></asp:TextBox>
            </p>
            <p>
                Preference 2:<asp:TextBox ID="textboxPref2" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GO" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Top 5 Restaurants</h2>
            <p>Restaurant #1:
                <asp:TextBox ID="textboxRest1" runat="server" Width="189px"></asp:TextBox>
            </p>
            <p>Restaurant #2:<asp:TextBox ID="textboxRest2" runat="server" Width="189px"></asp:TextBox>
            </p>
            <p>Restaurant #3:<asp:TextBox ID="textboxRest3" runat="server" Width="189px"></asp:TextBox>
            </p>
            <p>Restaurant #4:<asp:TextBox ID="textboxRest4" runat="server" Width="189px"></asp:TextBox>
            </p>
            <p>Restaurant #5:<asp:TextBox ID="textboxRest5" runat="server" Width="189px"></asp:TextBox>
            </p>
        </div>
    </div>

</asp:Content>
