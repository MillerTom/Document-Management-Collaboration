<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DocEditor._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ONLYOFFICE™</title>

    <style>
        html {
            height: 100%;
            width: 100%;
        }

        body {
            background: #fff;
            color: #333;
            font-family: Arial, Tahoma,sans-serif;
            font-size: 12px;
            font-weight: normal;
            height: 100%;
            margin: 0;
            overflow-y: hidden;
            padding: 0;
            text-decoration: none;
        }

        form {
            height: 100%;
        }

        div {
            margin: 0;
            padding: 0;
        }
    </style>

    <script language="javascript" type="text/javascript" src="http://localhost:1923/OfficeWeb/apps/api/documents/api.js"></script>

    <script type="text/javascript" language="javascript">

        var docEditor;
        var fileName = "demo5.docx";
        var fileType = "docx";

        var innerAlert = function (message) {
            if (console && console.log)
                console.log(message);
            ;
        };

        var onReady = function () {
            innerAlert("Document editor ready");
        };

        var onBack = function () {
            location.href = "default.aspx";
        };

        var onDocumentStateChange = function (event) {
            var title = document.title.replace(/\*$/g, "");
            document.title = title + (event.data ? "*" : "");
        };

        var onDocumentSave = function (event) {
            SaveFileRequest(fileName, fileType, event.data);
        };

        var onError = function (event) {
            if (console && console.log && event)
                console.log(event.data);
        };

        var сonnectEditor = function () {

            docEditor = new DocsAPI.DocEditor("iframeEditor",
                {
                    width: "100%",
                    height: "100%",

                    type: 'desktop',
                    documentType: "text",
                    document: {
                        title: fileName,
                        url: "http://localhost:1923/ResourceService.ashx?deletepath=temp_-1967265030&path=temp_-1967265030%2f-1967265030.tmp",
                        fileType: fileType,
                        key: "725184013",
                        vkey: "OEZFYjRlZ1VJbDBQMkVCTEtCYTUzTjltQlRmWmt5N1FxTnlRU2Z1Q3RrOD0_eyJleHBpcmUiOiJcL0RhdGUoMTQxMDYzOTg5ODY4MilcLyIsImtleSI6IjcyNTE4NDAxMyIsImtleV9pZCI6Il9Db250YWN0VXNfIiwidXNlcl9jb3VudCI6MCwiaXAiOiIxIn01",

                        info: {
                            author: "Me",
                            created: "<%= DateTime.Now.ToShortDateString() %>"
                        },

                        permissions: {
                            edit: true,
                            download: true
                        }
                    },
                    editorConfig: {
                        mode: 'edit',
                        canBackToFolder: true,

                        lang: "en",

                        canCoAuthoring: false,

                        embedded: {
                            saveUrl: "http://localhost:1923/ResourceService.ashx?deletepath=temp_-1967265030&path=temp_-1967265030%2f-1967265030.tmp",
                            embedUrl: "http://localhost:1923/ResourceService.ashx?deletepath=temp_-1967265030&path=temp_-1967265030%2f-1967265030.tmp",
                            shareUrl: "http://localhost:1923/ResourceService.ashx?deletepath=temp_-1967265030&path=temp_-1967265030%2f-1967265030.tmp",
                            toolbarDocked: "top"
                        }
                    },
                    events: {
                        'onReady': onReady,
                        'onBack': onBack,
                        'onDocumentStateChange': onDocumentStateChange,
                        'onSave': onDocumentSave,
                        'onError': onError
                    }
                });
        };

        if (window.addEventListener) {
            window.addEventListener("load", сonnectEditor);
        } else if (window.attachEvent) {
            window.attachEvent("load", сonnectEditor);
        }

        function getXmlHttp() {
            var xmlhttp;
            try {
                xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e) {
                try {
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (ex) {
                    xmlhttp = false;
                }
            }
            if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
                xmlhttp = new XMLHttpRequest();
            }
            return xmlhttp;
        }

        function SaveFileRequest(fileName, fileType, fileUri) {
            var req = getXmlHttp();
            if (console && console.log) {
                req.onreadystatechange = function () {
                    if (req.readyState == 4) {
                        console.log(req.statusText);
                        if (req.status == 200) {
                            console.log(req.responseText);
                        }
                    }
                };
            }

            var requestAddress = "webeditor.ashx"
                + "?type=save"
                + "&filename=" + encodeURIComponent(fileName)
                + "&filetype=" + encodeURIComponent(fileType)
                + "&fileuri=" + encodeURIComponent(fileUri);
            req.open('get', requestAddress, true);

            req.send(fileUri);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="iframeEditor">
        </div>
    </form>
</body>
</html>

