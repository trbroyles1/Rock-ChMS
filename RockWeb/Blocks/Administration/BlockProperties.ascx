﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockProperties.ascx.cs" Inherits="RockWeb.Blocks.Administration.BlockProperties" %>

<div class="admin-dialog">

    <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="alert alert-error block-message error"/>

    <asp:PlaceHolder ID="phContent" runat="server">

        <asp:ValidationSummary ID="valSummaryTop" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-error block-message error"/>

        <fieldset>
            <legend>Settings</legend>
            <Rock:DataTextBox ID="tbBlockName" runat="server" SourceTypeName="Rock.Model.Block, Rock" PropertyName="Name" Required="true" />
            <Rock:DataTextBox ID="tbCacheDuration" runat="server" SourceTypeName="Rock.Model.Block, Rock" PropertyName="OutputCacheDuration" LabelText="Cache Duration" />
        </fieldset>

        <asp:placeholder id="phAttributes" runat="server"></asp:placeholder>

        <asp:ValidationSummary ID="valSummaryBottom" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-error block-message error"/>

    </asp:PlaceHolder>

</div>

