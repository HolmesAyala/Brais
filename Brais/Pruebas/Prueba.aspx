<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prueba.aspx.cs" Inherits="Pruebas_Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <style>

        ul{
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .img{
            width: 2.5rem;
        }

        #menu{
            display: flex;
            justify-content: center;
            align-content:center;
        }

        #menu > li{
            position: relative;
        }

        #menu > li > ul{
            background-color: antiquewhite;
            /*width: 100%;*/
            position: absolute;
            display: none;
        }
        #menu > li:hover > ul{
            width: 100%;
            display: block;
            background-color: aqua;
        }

        .configuracion{
            padding: 3px;
            border: none;
            border-radius: 10px;
            transition: all 0.5s ease;
        }
        .configuracion:hover{
            background-color: aqua;
        }

    </style>

    <form id="form1" runat="server">
        <div>

            <label id="LB_Prueba" runat="server">Soy un label</label>
            <br />
            <asp:Label ID="LB_Mensaje" runat="server" ></asp:Label>
            <br />
            
            <ul id="menu">
                <li>
                    
                    <ul>
                        <li><asp:Button ID="BTN_1" runat="server" Text="Boton 1" OnClick="BTN_Prueba_Click"></asp:Button></li>
                        <li><asp:Button ID="BTN_2" runat="server" Text="Boton 2" OnClick="BTN_Prueba_Click"></asp:Button></li>
                        <li><asp:Button ID="BTN_3" runat="server" Text="Boton 3" OnClick="BTN_Prueba_Click"></asp:Button></li>
                    </ul>
                </li>
                <li>
                    <button>Menu 2</button>
                </li>
                <li>
                    <button>Menu 3</button>
                </li>
            </ul>
            <label>Otra Cosa</label>
        </div>
    </form>
</body>
</html>
