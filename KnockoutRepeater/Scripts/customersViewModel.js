/// <reference path="~/Scripts/knockout-2.2.1.js"/>
/// <reference path="~/Scripts/knockout.mapping-latest.js"/>

var CustomersViewModel = function (model) {
    var mapping = {
        'customers' : {
            create: function (options) {
                return new CustomerViewModel(options.data);
            }
        }
    };
    
    ko.mapping.fromJS(model, mapping, this);
};

var CustomerViewModel = function (model) {
    ko.mapping.fromJS(model, {}, this);

    this.fee = ko.computed(function () {
        if (this.exclusiveMember()) {
            return "65";
        } else {
            return "100";
        }
    }, this);
};