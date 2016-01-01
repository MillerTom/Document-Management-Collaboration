/*
 * Copyright (c) Ascensio System SIA 2014. All rights reserved
 *
 * http://www.onlyoffice.com
 *
 * Version: 1.0 (build:1)
 */
if(Common===undefined)var Common={};Common.Gateway=new function(){var e=this,t=$(e),n={init:function(e){t.trigger("init",e)},openDocument:function(e){t.trigger("opendocument",e)},showMessage:function(e){t.trigger("showmessage",e)},applyEditRights:function(e){t.trigger("applyeditrights",e)},processSaveResult:function(e){t.trigger("processsaveresult",e)},processRightsChange:function(e){t.trigger("processrightschange",e)},processMouse:function(e){t.trigger("processmouse",e)},internalCommand:function(e){t.trigger("internalcommand",e)},resetFocus:function(e){t.trigger("resetfocus",e)}},r=function(e){window.parent&&window.JSON&&window.parent.postMessage(window.JSON.stringify(e),"*")},i=function(e){var t=e.data;if(Object.prototype.toString.apply(t)!=="[object String]"||!window.JSON)return;var r,i;try{r=window.JSON.parse(t)}catch(s){r=""}r&&(i=n[r.command],i&&i.call(this,r.data))},s=function(e){i(e)};return window.attachEvent?window.attachEvent("onmessage",s):window.addEventListener("message",s,!1),{ready:function(){r({event:"onReady"})},goBack:function(){r({event:"onBack"})},save:function(e){r({event:"onSave",data:e})},requestEditRights:function(){r({event:"onRequestEditRights"})},reportError:function(e,t){r({event:"onError",data:{errorCode:e,errorDescription:t}})},setDocumentModified:function(e){r({event:"onDocumentStateChange",data:e})},internalMessage:function(e,t){r({event:"onInternalMessage",data:{type:e,data:t}})},on:function(n,r){var i=function(t,n){r.call(e,n)};t.on(n,i)}}};if(Common===undefined)var Common={};Common.component=Common.component||{},Common.Analytics=Common.component.Analytics=new function(){var e;return{initialize:function(t,n){if(typeof t=="undefined")throw"Analytics: invalid id.";if(typeof n=="undefined"||Object.prototype.toString.apply(n)!=="[object String]")throw"Analytics: invalid category type.";e=n,$("head").append('<script type="text/javascript">var _gaq = _gaq || [];_gaq.push(["_setAccount", "'+t+'"]);'+'_gaq.push(["_trackPageview"]);'+"(function() {"+'var ga = document.createElement("script"); ga.type = "text/javascript"; ga.async = true;'+'ga.src = ("https:" == document.location.protocol ? "https://ssl" : "http://www") + ".google-analytics.com/ga.js";'+'var s = document.getElementsByTagName("script")[0]; s.parentNode.insertBefore(ga, s);'+"})();"+"</script>")},trackEvent:function(t,n,r){if(typeof t!="undefined"&&Object.prototype.toString.apply(t)!=="[object String]")throw"Analytics: invalid action type.";if(typeof n!="undefined"&&Object.prototype.toString.apply(n)!=="[object String]")throw"Analytics: invalid label type.";if(typeof r!="undefined"&&(Object.prototype.toString.apply(r)!=="[object Number]"||!isFinite(r)))throw"Analytics: invalid value type.";if(typeof _gaq=="undefined")return;if(e==="undefined")throw"Analytics is not initialized.";_gaq.push(["_trackEvent",e,t,n,r])}}};var ApplicationView=new function(){function e(){$("#id-btn-share").popover({trigger:"manual",template:'<div class="popover share" id="id-popover-share"><div class="arrow"></div><div class="popover-inner"><div class="popover-content"><p></p></div></div></div>',content:'<div class="share-link"><span class="caption">Link:</span><span id="id-short-url" class="input-medium uneditable-input"></span><button id="id-btn-copy-short" type="button" class="btn btn-mini btn-primary" style="width: 65px;" data-copied-text="Copied">Copy</button></div> <div class="share-buttons" style="height: 25px" id="id-popover-social-container" data-loaded="false"><ul></ul></div>'}).popover("show"),$("#id-btn-embed").popover({trigger:"manual",template:'<div class="popover embed" id="id-popover-embed"><div class="arrow"></div><div class="popover-inner"><div class="popover-content"><p></p></div></div></div>',content:'<div class="size-manual"><span class="caption">Width:</span><input id="id-input-embed-width" class="input-mini" type="text" value="400px"><input id="id-input-embed-height" class="right input-mini" type="text" value="600px"><span class="right caption">Height:</span></div><textarea id="id-textarea-embed" rows="4" readonly></textarea><button id="id-btn-copy-embed" type="button" class="btn btn-mini btn-primary" data-copied-text="Copied">Copy</button>'}).popover("show"),$("body").popover({trigger:"manual",animation:!1,template:'<div class="popover hyperlink" id="id-tip-hyperlink"><div class="popover-inner"><div class="popover-content"><p></p></div></div></div>',content:"<br><b>Press Ctrl and click link</b>"}).popover("show")}return{create:e}},ApplicationController=new function(){function d(){}function v(e){return $("<div/>").text(e).html()}function m(e,t,n,r){return function(){var i;return function(){var s=this;i&&(clearTimeout(i),i=null),i=setTimeout(function(){e.apply(n||s,r||arguments)},t)}}()}function g(){var e=$("#id-popover-social-container");e.length>0&&e.attr("data-loaded")=="false"&&(typeof FB!="undefined"&&FB.XFBML&&FB.XFBML.parse(),typeof twttr!="undefined"&&twttr.widgets&&twttr.widgets.load(),e.attr("data-loaded","true"))}function y(e){r=$.extend(r,e.config.embedded),$("#id-short-url").text(r.shareUrl||"Unavailable"),$("#id-textarea-embed").text(f.replace("{embed-url}",r.embedUrl).replace("{width}",u).replace("{height}",a)),typeof r.shareUrl!="undefined"&&r.shareUrl!=""&&$("#id-popover-social-container ul")&&($("#id-popover-social-container ul").append('<li><div class="fb-like" data-href="'+r.shareUrl+'" data-send="false" data-layout="button_count" data-width="450" data-show-faces="false"></div></li>'),$("#id-popover-social-container ul").append('<li class="share-twitter"><a href="https://twitter.com/share" class="twitter-share-button" data-url="'+r.shareUrl+'">Tweet</a></li>'),$("#id-popover-social-container ul").append('<li class="share-mail"><a class="btn btn-mini" href="mailto:?subject=I have shared a document with you: '+r.docTitle+"&body=I have shared a document with you: "+r.shareUrl+'"><i class="icon-envelope"></i>Email</a></li>')),typeof r.shareUrl=="undefined"&&$("#id-btn-share").hide(),typeof r.embedUrl=="undefined"&&$("#id-btn-embed").hide(),typeof r.fullscreenUrl=="undefined"&&$("#id-btn-fullscreen").hide(),(typeof e.config.canBackToFolder=="undefined"||!e.config.canBackToFolder)&&$("#id-btn-close").hide(),r.toolbarDocked==="top"?($("#toolbar").addClass("top"),$("#editor_sdk").addClass("top")):($("#toolbar").addClass("bottom"),$("#editor_sdk").addClass("bottom")),!$("#id-btn-fullscreen").is(":visible")&&!$("#id-btn-close").is(":visible")&&($("#toolbar .right .separator:last").hide(),$("#pages").css("margin-right","12px"))}function b(e){n=e.doc;if(n){i=$.extend(i,n.permissions);var r=new CDocInfo;r.put_Id(n.key),r.put_Url(n.url),r.put_Title(n.title),r.put_Format(n.fileType),r.put_VKey(n.vkey),t&&(t.LoadDocument(r),t.Resize(),t.zoomFitToWidth(),t.asc_enableKeyEvents(!0),t.SetViewMode(!0),Common.Analytics.trackEvent("Load","Start"))}}function w(e){s=e,$("#pages").text("of "+e)}function E(e){$("#page-number").val(e+1)}function S(e){if(e){var t=window.open(e,"_blank");t&&t.focus()}}function x(e,t){var n="";switch(t){case c_oAscAsyncAction.Print:n="Downloading document...";break;default:n="Please wait..."}e==c_oAscAsyncActionType["BlockInteraction"]&&($("#id-loadmask .cmd-loader-title").html(n),O())}function T(){M()}function N(){e.isHideBodyTip=!0}function C(){if(e.isHideBodyTip){var t=$("#id-tip-hyperlink");t.length>0&&t.hide()}}function k(t){if(t&&t.get_Type()==1){e.isHideBodyTip=!1;var n=$("#id-tip-hyperlink"),r=t.get_Hyperlink(),i=r.get_ToolTip()?r.get_ToolTip():r.get_Value();n.length>0&&(n.find(".popover-content p").html(v(i)+"<br><b>Press Ctrl and click link</b>"),n.show()),n.css({left:t.get_X()-10,top:t.get_Y()-25})}}function L(){$("#loading-mask").fadeOut("slow")}function A(){F($("#id-popover-share"),!1),F($("#id-popover-embed"),!1),$("#id-tip-hyperlink").hide(),H(),L(),Common.Analytics.trackEvent("Load","Complete")}function O(){$("#id-loadmask").modal({backdrop:"static",keyboard:!1})}function M(){$("#id-loadmask").modal("hide")}function _(e){$("#loadmask-text").html("LOADING DOCUMENT: "+Math.round(e)+"%")}function D(t,n,r){L();var i;switch(t){case c_oAscError.ID.Unknown:i=e.unknownErrorText;break;case c_oAscError.ID.ConvertationTimeout:i=e.convertationTimeoutText;break;case c_oAscError.ID.ConvertationError:i=e.convertationErrorText;break;case c_oAscError.ID.DownloadError:i=e.downloadErrorText;break;default:i=e.errorDefaultMessage.replace("%1",t)}n==c_oAscError.Level.Critical?(Common.Gateway.reportError(t,i),$("#id-critical-error-title").text(e.criticalErrorTitle),$("#id-critical-error-message").text(i),$("#id-critical-error-close").off(),$("#id-critical-error-close").on("click",function(){window.location.reload()})):($("#id-critical-error-title").text(e.notcriticalErrorTitle),$("#id-critical-error-message").text(i),$("#id-critical-error-close").off(),$("#id-critical-error-close").on("click",function(){$("#id-critical-error-dialog").modal("hide")})),$("#id-critical-error-dialog").modal("show"),Common.Analytics.trackEvent("Internal Error",t.toString())}function P(e){e&&(L(),$("#id-error-mask-title").text(e.title),$("#id-error-mask-text").text(e.msg),$("#id-error-mask").css("display","block"),Common.Analytics.trackEvent("External Error",e.title))}function B(){t&&t.Resize(),H()}function j(e){return e.hasClass("in")}function F(e,n,i){t&&t.asc_enableKeyEvents(!n);if(n){if(i){e.css("display","block");var s=i.data("popover"),o=s.tip(),u=s.getPosition(!1),a=o[0].offsetHeight,f=r.toolbarDocked==="top"?"bottom":"top",l;o.removeClass("fade in top bottom left right");switch(f){case"bottom":l={top:u.top+u.height,left:i.position().left+(i.width()-e.width())*.5};break;default:case"top":l={top:u.top-a,left:i.position().left+(i.width()-e.width())*.5}}o.css(l).addClass(f).addClass("in")}e.hasClass("embed")&&p.show(),e.hasClass("share")&&(h.show(),g())}else e.removeClass("in"),e.css("display","none"),e.hasClass("embed")&&p.hide(),e.hasClass("share")&&h.hide()}function I(){var e=parseInt($("#id-input-embed-width").val()),t=parseInt($("#id-input-embed-height").val());e<u&&(e=u),t<a&&(t=a),$("#id-textarea-embed").text(f.replace("{embed-url}",r.embedUrl).replace("{width}",e).replace("{height}",t)),$("#id-input-embed-width").val(e+"px"),$("#id-input-embed-height").val(t+"px")}function q(e){var t=window.open(e);t&&t.focus()}function R(){if(c)return e;e=this,c=!0;var n;return h.addEventListener("mousedown",function(){if($("#id-btn-copy-short").hasClass("copied"))return;$("#id-btn-copy-short").button("copied"),$("#id-btn-copy-short").addClass("copied"),h.setText($("#id-short-url").text()),setTimeout(function(){$("#id-btn-copy-short").button("reset"),$("#id-btn-copy-short").removeClass("copied")},2e3)}),p.addEventListener("mousedown",function(){if($("#id-btn-copy-embed").hasClass("copied"))return;$("#id-btn-copy-embed").button("copied"),$("#id-btn-copy-embed").addClass("copied"),p.setText($("#id-textarea-embed").text()),setTimeout(function(){$("#id-btn-copy-embed").button("reset"),$("#id-btn-copy-embed").removeClass("copied")},2e3)}),h.glue("id-btn-copy-short"),p.glue("id-btn-copy-embed"),$("#id-btn-copy").on("click",function(){var e=r.saveUrl;typeof e!="undefined"&&e.length>0?q(e):t&&t.asc_Print(),Common.Analytics.trackEvent("Save")}),$("#id-btn-share").on("click",function(e){F($("#id-popover-share"),!j($("#id-popover-share")),$("#id-btn-share")),F($("#id-popover-embed"),!1),e.preventDefault(),e.stopPropagation()}),$("#id-btn-embed").on("click",function(e){F($("#id-popover-embed"),!j($("#id-popover-embed")),$("#id-btn-embed")),F($("#id-popover-share"),!1),e.preventDefault(),e.stopPropagation()}),$("#id-input-embed-width").on("keypress",function(e){e.keyCode==13&&I()}),$("#id-input-embed-height").on("keypress",function(e){e.keyCode==13&&I()}),$("#id-input-embed-width").on("focusin",function(e){t&&t.asc_enableKeyEvents(!1)}),$("#id-input-embed-height").on("focusin",function(e){t&&t.asc_enableKeyEvents(!1)}),$("#id-input-embed-width").on("focusout",function(e){I(),t&&t.asc_enableKeyEvents(!0)}),$("#id-input-embed-height").on("focusout",function(e){I(),t&&t.asc_enableKeyEvents(!0)}),$("#page-number").on("keypress",function(e){if(e.keyCode==13){var n=parseInt($("#page-number").val());n>s&&(n=s);if(n<2||isNaN(n))n=1;t&&t.goToPage(n-1)}}),$("#id-btn-fullscreen").on("click",function(){q(r.fullscreenUrl)}),$("#id-btn-close").on("click",function(){Common.Gateway.goBack()}),$("#id-btn-zoom-in").on("click",function(){t&&t.zoomIn()}),$("#id-btn-zoom-out").on("click",function(){t&&t.zoomOut()}),$(window).resize(function(){B()}),$(document).click(function(e){if(e&&e.target&&$(e.target).closest(".popover").length>0)return;F($("#id-popover-share"),!1),F($("#id-popover-embed"),!1)}),$(document).mousemove(function(e){$("#id-btn-zoom-in").fadeIn(),$("#id-btn-zoom-out").fadeIn(),clearTimeout(n),n=setTimeout(function(){$("#id-btn-zoom-in").fadeOut(),$("#id-btn-zoom-out").fadeOut()},2e3)}),t=new asc_docs_api("editor_sdk"),t&&(t.CreateComponents(),t.SetFontsPath("../../../sdk/Fonts/"),t.Init(),t.asc_registerCallback("asc_onError",D),t.asc_registerCallback("asc_onDocumentContentReady",A),t.asc_registerCallback("asc_onOpenDocumentProgress2",_),t.asc_registerCallback("asc_onCountPages",w),t.asc_registerCallback("asc_onCurrentPage",E),t.asc_registerCallback("asc_onHyperlinkClick",S),t.asc_registerCallback("asc_onStartAction",x),t.asc_registerCallback("asc_onEndAction",T),t.asc_registerCallback("asc_onMouseMoveStart",N),t.asc_registerCallback("asc_onMouseMoveEnd",C),t.asc_registerCallback("asc_onMouseMove",k),Common.Gateway.on("init",y),Common.Gateway.on("opendocument",b),Common.Gateway.on("showerror",P),Common.Gateway.ready()),e}var e,t,n={},r={},i={},s=0,o=550,u=400,a=600,f='<iframe allowtransparency="true" frameborder="0" scrolling="no" src="{embed-url}" width="{width}" height="{height}"></iframe>',l=9090,c=!1;Common.Analytics.initialize("UA-12442749-13","Embedded ONLYOFFICE Document");if(typeof isBrowserSupported!="undefined"&&!isBrowserSupported()){Common.Gateway.reportError(undefined,"Your browser is not supported.");return}ZeroClipboard.setMoviePath("../../../3rdparty/ZeroClipboard/ZeroClipboard10.swf");var h=new ZeroClipboard.Client,p=new ZeroClipboard.Client;h.zIndex=l,p.zIndex=l;var H=m(function(e){var t=function(e,t){t?($(e+" button").addClass("no-caption"),$(e+" button span").css("display","none")):($(e+" button").removeClass("no-caption"),$(e+" button span").css("display","inline"))},n=$("#toolbar").width()<o;t("#id-btn-copy",n),t("#id-btn-share",n),t("#id-btn-embed",n)},10);return{create:R,errorDefaultMessage:"Error code: %1",unknownErrorText:"Unknown error.",convertationTimeoutText:"Convertation timeout exceeded.",convertationErrorText:"Convertation failed.",downloadErrorText:"Download failed.",criticalErrorTitle:"Error",notcriticalErrorTitle:"Warning"}};(function(e){e(function(){ApplicationView.create(),ApplicationController.create()})})(window.jQuery);