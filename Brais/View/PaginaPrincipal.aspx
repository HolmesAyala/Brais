<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/PaginaPrincipal.aspx.cs" Inherits="View_PaginaPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style>
        section{
            margin: 10px 0;
            height: 300px;
        }

        section h2{
            text-align: center;
            background-color: teal;
            color: white;
            border-radius: 5px;
            padding: 5px;
        }

        .auto-style1 {
            width: 100%;
            height: 251px;
            margin-bottom: 160;
        }
        .auto-style2 {
            height: 298px;
        }
        .auto-style3 {
            width: 20%;
        }

        .auto-style4 {
            text-align: justify;
        }
        #profesionals1{
            background-color:darkseagreen;
        }
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            height: 50%;
        }
        .auto-style7 {
            height: 50%;
            width: 183px;
        }
        .auto-style8 {
           
        }
        .auto-style9 {
            height: 50%;
            text-align: center;
        }
        .button{
            border-radius:5px;
        }
    </style>

    <section>

        <asp:Image ID="Image1" runat="server" Height="307px" ImageUrl="~/View/Images/index_ban_1.jpg" Width="33.3%" />
        <asp:Image ID="Image2" runat="server" Height="306px" ImageUrl="~/View/Images/index_ban_2.jpg" Width="33.3%" />
        <asp:Image ID="Image3" runat="server" Height="305px" ImageUrl="~/View/Images/index_ban_3.jpg" Width="32.3%" />

    </section>

    <section class="auto-style2">
        <h2>Conoce a nuestros profesionales</h2>
        <div id="profesionals" style="height:86%">

            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Image ID="Image4" runat="server" Height="239px" ImageUrl="~/View/Images/index_ban2_1.jpg" Width="268px" />
                    </td>
                    <td style="width:80%;margin-right:6%" class="auto-style4">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vestibulum arcu sem, id viverra urna mollis sit amet. Aenean eleifend vel ipsum ac eleifend. In condimentum sagittis dolor id fermentum. Sed ultricies, ipsum eget ultrices laoreet, velit nisi dictum nibh, sit amet sagittis erat odio sed nisi. Nulla lobortis sem urna. Pellentesque condimentum arcu et dui pellentesque pellentesque. Ut laoreet elit eget erat sollicitudin placerat.
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>

        </div>
    </section>

    <section>
        <h2>Una breve informacion sobre nosotros</h2>
        <div id="profesionals1" style="height:86%;">

            <table class="auto-style5">
                <tr>
                    <td class="auto-style7">
                        <video class="auto-style8" controls height="60%">
                            <source src="Video/big_buck_bunny.mp4" type="video/mp4" />
                        </video></td>
                    <td class="auto-style6">
                        <p style="margin:auto 5%" class="auto-style4">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum vitae tellus quam. Donec faucibus lacinia tortor, eget fringilla purus tempus quis. Nunc molestie in elit at eleifend. Nunc dapibus nisl elit, quis dapibus mauris sollicitudin vel. Suspendisse facilisis risus sit amet fermentum tincidunt. Suspendisse vitae elementum eros, a tempor nunc. Nulla nec porta odio. Fusce risus leo, ultrices et rhoncus at, faucibus quis arcu. Aliquam erat volutpat. Curabitur at consectetur lacus.
</p>
                        <br />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style9">
                        <asp:Button ID="Button1" runat="server" Text="Crear Cuenta" Height="30px" OnClick="Button1_Click" Width="115px" BackColor="#33CCFF" ForeColor="White" CssClass="button" />
                    </td>
                </tr>

                </table>

        </div>
    </section>

</asp:Content>

