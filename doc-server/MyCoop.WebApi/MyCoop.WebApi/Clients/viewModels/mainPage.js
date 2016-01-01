//
App.ViewModels.MainPageModel = (function () {
    "use strict";

    // using


    // static

    var app = App.current;
    var config = App.config;


    // private


    // public

    function showInfo(text, isError) {
        var self = this;
        var publ = this.publ;

        text = text || isError ? "Sorry..." : "Well done";

        publ.infoStatus(isError ? "alert-error" : "alert-success");
        publ.infoMessage(text);
        publ.infoVisible(true);
        self.infoTimer = setTimeout(publ.closeInfo, 5000);
    }

    function closeInfo() {
        var self = this;
        var publ = this.publ;

        publ.infoVisible(false);
        clearTimeout(self.infoTimer);
    }

    function show(callback) {
        var self = this;
        var publ = this.publ;

        app.body("mainPage.html", callback, publ);
    }

    function navigate(url) {

        var self = this;
        var publ = this.publ;


        publ.show();
    }

    function go() {

        var self = this;
        var publ = this.publ;

        publ.result('Loading...');

        var body = publ.httpBody();
        var data = body ? JSON.parse(body) : null;

        $.ajax(publ.url(), {
            type: publ.selectedMethod().value,
            data: data,
            success: function (model) {
                publ.result(JSON.stringify(model));
                app.showSuccess();
            },
            error: function (e) {
                publ.result(JSON.stringify(e));
                app.showError();
            }
        });

    }

    // consructor

    function mainPageModel() {

        var self = {
            infoTimer: null
        };

        var publ = self.publ = {};

        publ.infoMessage = ko.observable("");
        publ.infoVisible = ko.observable(false);
        publ.infoStatus = ko.observable("");
        publ.show = show.bind(self);
        publ.navigate = navigate.bind(self);
        publ.closeInfo = closeInfo.bind(self);
        publ.showInfo = showInfo.bind(self);

        publ.url = ko.observable(config.apiPrefix);
        publ.httpBody = ko.observable("");
        publ.result = ko.observable("");

        var methods = [{ name: "GET", value: "GET" },
                   { name: "POST", value: "POST" },
                   { name: "DELETE", value: "DELETE" }];

        publ.methods = ko.observable(methods);
        publ.selectedMethod = ko.observable(methods[0]);
        publ.go = go.bind(self);


        var signTemplates = [
            {
                name: "sign-in",
                url: config.apiPrefix + "sign/in",
                method: methods[1],
                body: '{"email":"tomamiller@gmail.com", "password": "123"}'
            },
            {
                name: "sign-out",
                url: config.apiPrefix + "sign/out",
                method: methods[1],
                body: ''
            }];

        publ.signTemplates = ko.observable(signTemplates);
        
        var userTemplates = [
            {
                name: "user-current",
                url: config.apiPrefix + "user/current",
                method: methods[0],
                body: ''
            },
            {
                name: "user-history",
                url: config.apiPrefix + "user/history?startTime=08.08.2014",
                method: methods[0],
                body: ''
            }];

        publ.userTemplates = ko.observable(userTemplates);
        
        var groupTemplates = [
            {
                name: "group-gets",
                url: config.apiPrefix + "group",
                method: methods[0],
                body: ''
            },
           {
               name: "group-get",
               url: config.apiPrefix + "group/4",
               method: methods[0],
               body: ''
           }
        ];

        publ.groupTemplates = ko.observable(groupTemplates);
        
        var orgUnitTemplates = [
           {
               name: "org-unit-gets",
               url: config.apiPrefix + "orgunit",
               method: methods[0],
               body: ''
           },
           {
               name: "org-unit-get",
               url: config.apiPrefix + "orgunit/1",
               method: methods[0],
               body: ''
           },
           {
               name: "org-unit-add",
               url: config.apiPrefix + "orgunit",
               method: methods[1],
               body: '{"name":"sfasf", "location": { "lat":"54.55", "lng":"1.2", "address": "qwrqw" }, "ownerId": "1", "parentId": "1", "workspaceTemplateId":"1"}'
           },
           {
               name: "org-unit-update",
               url: config.apiPrefix + "orgunit/1",
               method: methods[1],
               body: '{"name":"vasja", "location": { "lat":"77.55", "lng":"5.2", "address": "qwrqw" }, "ownerId": "1", "parentId": "1", "workspaceTemplateId":"1"}'
           },
           {
               name: "org-unit-delete",
               url: config.apiPrefix + "orgunit/3",
               method: methods[2],
               body: ''
           },
            {
                name: "org-unit-user-permission-gets",
                url: config.apiPrefix + "orgunit/1016/user/1",
                method: methods[0],
                body: ''
            },
            {
                name: "org-unit-group-permission-gets",
                url: config.apiPrefix + "orgunit/1016/group/4",
                method: methods[0],
                body: ''
            },
            {
                name: "org-unit-user-permission-add",
                url: config.apiPrefix + "orgunit/1016/user/1/permission/1",
                method: methods[1],
                body: ''
            },
            {
                name: "org-unit-group-permission-add",
                url: config.apiPrefix + "orgunit/1016/group/4/permission/1",
                method: methods[1],
                body: ''
            },
            {
                name: "org-unit-user-permission-remove",
                url: config.apiPrefix + "orgunit/1016/user/1/permission/1",
                method: methods[2],
                body: ''
            },
            {
                name: "org-unit-group-permission-remove",
                url: config.apiPrefix + "orgunit/1016/group/4/permission/1",
                method: methods[2],
                body: ''
            },
            {
                name: "org-unit-users-permissions",
                url: config.apiPrefix + "orgunit/1029/user-permission",
                method: methods[0],
                body: ''
            },
            {
                name: "org-unit-groups-permissions",
                url: config.apiPrefix + "orgunit/1029/group-permission",
                method: methods[0],
                body: ''
            }];

        publ.orgUnitTemplates = ko.observable(orgUnitTemplates);
        
        var componentTemplates = [
            {
                name: "component-gets",
                url: config.apiPrefix + "component",
                method: methods[0],
                body: ''
            },
           {
               name: "component-get",
               url: config.apiPrefix + "component/1",
               method: methods[0],
               body: ''
           },
           {
               name: "component-add",
               url: config.apiPrefix + "component",
               method: methods[1],
               body: '{"name":"sfasf"}'
           },
           {
               name: "component-update",
               url: config.apiPrefix + "component/1",
               method: methods[1],
               body: '{"name":"vasja"}'
           },
           {
               name: "component-delete",
               url: config.apiPrefix + "component/3",
               method: methods[2],
               body: ''
           }];

        publ.componentTemplates = ko.observable(componentTemplates);

        var documentTemplateTemplates = [
            {
                name: "document-template-gets",
                url: config.apiPrefix + "document-template",
                method: methods[0],
                body: ''
            },
           {
               name: "document-template-get",
               url: config.apiPrefix + "document-template/1",
               method: methods[0],
               body: ''
           },
           {
               name: "document-template-update",
               url: config.apiPrefix + "document-template/1",
               method: methods[1],
               body: '{ "name" : "update-template", "reference" : "M0097", "purpose" : "bla-bal-bla", "componentId" : "1" }'
           },
           {
               name: "document-template-delete",
               url: config.apiPrefix + "document-template/3",
               method: methods[2],
               body: ''
           }];

        publ.documentTemplateTemplates = ko.observable(documentTemplateTemplates);
        
        var workspaceTemplateTemplates = [
           {
               name: "workspace-template-gets",
               url: config.apiPrefix + "workspace-template",
               method: methods[0],
               body: ''
           },
          {
              name: "workspace-template-get",
              url: config.apiPrefix + "workspace-template/1",
              method: methods[0],
              body: ''
          },
            {
                name: "workspace-template-add",
                url: config.apiPrefix + "workspace-template",
                method: methods[1],
                body: '{"name":"sfasf"}'
            },
          {
              name: "workspace-template-update",
              url: config.apiPrefix + "workspace-template/1",
              method: methods[1],
              body: '{ "name" : "update-template" }'
          },
          {
              name: "workspace-template-delete",
              url: config.apiPrefix + "workspace-template/3",
              method: methods[2],
              body: ''
          },
          {
              name: "workspace-template-get-document-template",
              url: config.apiPrefix + "workspace-template/1/document-template",
              method: methods[0],
              body: ''
          }];

        publ.workspaceTemplateTemplates = ko.observable(workspaceTemplateTemplates);
        

        var incidentTemplates = [
           {
               name: "incident-gets",
               url: config.apiPrefix + "incident",
               method: methods[0],
               body: ''
           },
          {
              name: "incident-get",
              url: config.apiPrefix + "incident/1",
              method: methods[0],
              body: ''
          },
            {
                name: "incident-add",
                url: config.apiPrefix + "incident",
                method: methods[1],
                body: '{"name":"vasja", "location": { "lat":"77.55", "lng":"5.2", "address": "qwrqw" }, "type": "1", "priority": "1", "facilityType":"1", "startTime": "30.08.2014", "duration":"100000", "description": "twetw" }'
            },
          {
              name: "incident-update",
              url: config.apiPrefix + "incident/1",
              method: methods[1],
              body: '{"name":"kolja", "location": { "lat":"77.55", "lng":"5.2", "address": "qwrqw" }, "type": "1", "priority": "1", "facilityType":"1", "startTime": "30.08.2014", "duration":"100000", "description": "twetw" }'
          },
          {
              name: "incident-delete",
              url: config.apiPrefix + "incident/3",
              method: methods[2],
              body: ''
          },
          {
              name: "incident-users",
              url: config.apiPrefix + "incident/1/user",
              method: methods[0],
              body: ''
          },
          {
              name: "incident-org-units",
              url: config.apiPrefix + "incident/1/org-unit",
              method: methods[0],
              body: ''
          },
          {
              name: "incident-user-add",
              url: config.apiPrefix + "incident/1/user/1",
              method: methods[1],
              body: ''
          },
          {
              name: "incident-org-unit-add",
              url: config.apiPrefix + "incident/1/org-unit/1016",
              method: methods[1],
              body: ''
          },
          {
              name: "remove-incident-user-delete",
              url: config.apiPrefix + "incident/1/user/1",
              method: methods[2],
              body: ''
          },
          {
              name: "incident-org-unit-delete",
              url: config.apiPrefix + "incident/1/org-unit/1016",
              method: methods[2],
              body: ''
          }];

        publ.incidentTemplates = ko.observable(incidentTemplates);
        

        var reportTemplates = [
           {
               name: "report-gets",
               url: config.apiPrefix + "report",
               method: methods[0],
               body: ''
           },
            {
                name: "report-add",
                url: config.apiPrefix + "report",
                method: methods[1],
                body: '{"name":"vasja", "dataSourceType": "data", "description": "twetw" }'
            },
          {
              name: "report-delete",
              url: config.apiPrefix + "report/3",
              method: methods[2],
              body: ''
          }];

        publ.reportTemplates = ko.observable(reportTemplates);


        publ.selectedTemplate = ko.observable();

        publ.selectedTemplate.subscribe(function (value) {
            if (!value) return;
            publ.selectedMethod(value.method);
            publ.url(value.url);
            publ.httpBody(value.body);
        });

        return publ;
    }

    return mainPageModel;

})();
