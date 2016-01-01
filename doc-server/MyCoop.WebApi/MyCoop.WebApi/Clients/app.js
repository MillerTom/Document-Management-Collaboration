//
App.current = (function() {
    "use strict";

    var config = App.config;

    function loadTemplate(url, callback) {
        if (!self.templates[url]) {
            var div = document.createElement("div");
            $(div).load(url, function() {
                callback($(div).html());
            });

        } else {
            callback(self.templates[url]);
        }
    }

    function template(panelId, templateUrl, callback, model) {
        var panel = document.getElementById(panelId);
        ko.cleanNode(panel);
        if (templateUrl) {
            templateUrl = config.templateFolder + templateUrl;
            loadTemplate(templateUrl, function(page) {
                self.templates[templateUrl] = page;
                panel.innerHTML = page;
                self.panels[panelId] = templateUrl;
                if (model) {
                    ko.applyBindings(model, panel);
                }
                if (callback) {
                    callback();
                }
            });

        } else {
            panel.innerHTML = "";
            this.panels[panelId] = "";
        }

    }

    var self =
    {

        panels: {},
        templates: {},

        isContent: function(templateId) {
            return this.panels["content"] == config.templateFolder + templateId;
        },

        isPage: function(templateId) {
            return this.panels["page"] == config.templateFolder + templateId;
        },

        navigate: function(url) {
            if (url) {
                var urls = url.split("/");
                self.model.navigate(urls.slice(1));
            } else {
                self.model.navigate();
            }
        },

        init: function() {
            window.onhashchange = function(e) {
                self.navigate(location.hash);
            };
            self.model.show(function () {
                self.navigate(location.hash);
            });
        },

        showSuccess: function(text) {
            self.model.showInfo(text);
        },

        showError: function(text) {
            self.model.showInfo(text, true);
        }
    };

    self.body = template.bind(self, "body");
    self.page = template.bind(self, "page");
    self.content = template.bind(self, "content");

    return self;

})();