var app = app || {};

(function TabsModule($, doc) {

    app.Tabs = Object.create(app.BaseView);

    app.Tabs.name = "Tabs";

    /***
     * Start tabs functionality
     * returns void
     */
    app.Tabs.init = function () {
        this.bindEvents();
    };

    //bind this
    app.Tabs.init = app.Tabs.init.bind(app.Tabs);

    app.Tabs.els.tabs = {
        allTabs: doc.querySelectorAll('.single-tab'),
        allFaq: doc.querySelectorAll('.faq-heading'),
        boxClick: doc.querySelectorAll('.box-click'),
        nav: doc.querySelector('.nav-btn')
    };

    app.Tabs.bindEvents = function () {

        // console.log('tabs binded');

        if (this.els.tabs.allTabs.length > 0) {
            for(var i = 0; i < this.els.tabs.allTabs.length; i++) {
                this.events.on(this.els.tabs.allTabs[i], 'click', this.initTabs);
            }
        }

        if (this.els.tabs.allFaq.length > 0) {
            for(var j = 0; j < this.els.tabs.allFaq.length; j++) {
                this.events.on(this.els.tabs.allFaq[j], 'click', this.initFaq);
            }
        }

        if (this.els.tabs.boxClick.length > 0) {
            for(var k = 0; k < this.els.tabs.boxClick.length; k++) {
                this.events.on(this.els.tabs.boxClick[k], 'click', this.initBoxClick);
            }
        }

        if (this.els.tabs.nav) {
            // console.log('in if');
            this.events.on(this.els.tabs.nav, 'click', this.initNav);
        }
    };


    app.Tabs.initTabs = function() {

        var self = app.Tabs,
            clickedTabId = this.getAttribute('data-id'),
            clickedTabContent = doc.querySelector('#tab-' + clickedTabId),
            selectedTabContent = doc.querySelector('.tabs-content.active'),
            selectedTab = doc.querySelector('.single-tab.active');

        if (!selectedTab) {
            self.addActive(this, 'active');
            self.addActive(clickedTabContent, 'active');
        } else {
            self.removeActive(selectedTab, 'active');
            self.removeActive(selectedTabContent, 'active');
            self.addActive(this, 'active');
            self.addActive(clickedTabContent, 'active');
        }
    };


    app.Tabs.initFaq = function() {

        var self = app.Tabs,
            clickedFaqId = this.getAttribute('data-faq'),
            clickedFaqContent = $('#faq-' + clickedFaqId);

        clickedFaqContent.slideToggle('fast');
        self.toggleActive(this, 'active');

    };

    app.Tabs.initBoxClick = function() {

        var self = app.Tabs,
            activeBox = doc.querySelector('.box-click.active');

        self.removeActive(activeBox, 'active');
        self.addActive(this, 'active');
    };

    app.Tabs.init();
})(jQuery, document);