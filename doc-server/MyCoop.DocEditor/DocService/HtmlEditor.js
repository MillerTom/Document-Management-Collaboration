
$(function() {
    

    var docEditor;
    var fileName = "demo25.docx";
    var fileType = "docx";
    var fileUri = "";
    var key = "";
    var validateKey = "";

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
                     url: fileUri,
                     fileType: fileType,
                     key: key,
                     vkey: validateKey,

                     info: {
                         author: "Me",
                         created: "10.10.2012"
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
                         saveUrl: fileUri,
                         embedUrl: fileUri,
                         shareUrl: fileUri,
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


    $.ajax("webeditor.ashx?type=get&fileName=" + encodeURIComponent(fileName), {
        success: function (model) {
            model = JSON.parse(model);
            fileUri = model.fileUri;
            key = model.key;
            validateKey = model.validateKey;
            сonnectEditor();
        },
        error: function () {
            
        }
    });


});


