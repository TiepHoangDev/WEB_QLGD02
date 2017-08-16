var map = {};
var navBarCompletions = {};

// Override typeahead render and select to eliminate auto select first item
var newRender = function(items) {
    var that = this;

    items = $(items).map(function (i, item) {
        i = $(that.options.item).attr('data-value', item);
        i.find('a').html(that.highlighter(item));
        return i[0]
    });
    if(that.options.shouldSelectFirstItem) {
        items.first().addClass('active')
    }
    this.$menu.html(items);
    return this
};

$.fn.typeahead.Constructor.prototype.render = newRender;

$.fn.typeahead.Constructor.prototype.select = function() {
    var val = this.$menu.find('.active').attr('data-value');
    if (val) {
        this.$element
            .val(this.updater(val))
            .change();
    } else {
        $('button.typeahead').trigger('click');
    }
    return this.hide()
};


// Override typeahead mouseleave to eliminate hiding
$.fn.typeahead.Constructor.prototype.mouseleave = function (e) {
    this.mousedover = false;
    this.$menu.find('.active').removeClass('active');
    // if (!this.focused && this.shown) this.hide()
};


function typeaheadSource(query, process) {
    $.ajax({
        url: '/api/search/typeahead/' + encodeURIComponent(query),
        dataType: 'json',
        error: function( data ) {
        },
        success: function(data) {
            handleTypeahead(data, function(err, proposals){
                if(err)return process(err);
                return process(proposals);
            });
        }
    });
}

function handleTypeahead(data, callback){
    var proposals = [];
    for (var i in data) {
        var parts = data[i].split(':');
        var proposal;
        if (parts.length > 1) {
            proposal = parts[1];
            map[proposal] = parts[0];
        } else {
            proposal = data[i];
        }
        proposals.push(proposal);
    }
    return callback(null, proposals);
}

$(document).ready(function() {
    $('.nonaccount-typeahead').attr('autocomplete','off');
    $('.nonaccount-typeahead').typeahead({
        source: typeaheadSource,
        items: 20,
        sorter: function(items) {return items},
        updater : function(item) {
            if (item in map) {
                var taskId = map[item];
                window.location = '/android/tasks/' + taskId + '?source=typeahead';
            }
            else {
                submitSearchQuery(item, $(".search-filter-element .dropdown-toggle").text());
            }
            return item;
        }
    });

    $('.account-typeahead').attr('autocomplete','off');
    $('.account-typeahead').typeahead({
        source: function(query, callback){
            // This is a patch for getting the code pack - we take if from the url (this is used only in sourceViewer
            // were the url is <domain>/xref/#/<codePack>/...
            var pack = window.location.hash.split("/")[1];
            $.ajax({
                url: '/api/search/navbarTypeahead/' + encodeURIComponent(query)+'?codePack='+pack,
                dataType: 'json',
                error: function( data ) {
                    navBarCompletions = {};
                    return callback([]);
                },
                success: function(data) {
                    navBarCompletions = data;
                    return callback(Object.keys(data));
                }
            });
        },
        items: 30,
        sorter: function(items) {return items},
        updater : function(item) {
            if(!(item in navBarCompletions)){
                return item;
            }
            var selectedItem = navBarCompletions[item];
            //TODO: fix this
            //reload from angular/other page
            navigateToRichSearch(item);
            return item;
        }
    })
    //When user press enter in typeahead and no item has been updated,
    // then this event should take him to findUsages page
    .on('keyup', this, function (event) {
        //keyCode 13 means Enter
        if (event.keyCode == 13) {
            var selectedItem = $('.account-typeahead').val();
            navigateToRichSearch(selectedItem);
        }
    });



    $(".search-filter-element .dropdown-menu").on('click', 'li a', function(){
        submitSearchQuery($('input.typeahead').val(), $(this).text());
    });

    $("div#rich-search").keyup(function(event){
        if(event.keyCode == 13){
            navigateToRichSearch($(this).find("input").val());
        }
    });

    $("div#rich-search button").on('click', function(event){
        navigateToRichSearch($(this).parent().find("input").val());
    });

    $('form[id^=search]').on('submit',function(){
        if($("form[id^=search] input[name='target']").length == 0) {
            $(this).append($("<input>").attr("type", "hidden").attr("name", "target").val("all"));
        }
    });
});

function navigateToRichSearch(searchQuery) {
    // This is a patch for getting the code pack - we take if from the url (this is used only in sourceViewer
    // were the url is <domain>/xref/#/<codePack>/...
    var pack = window.location.hash.split("/")[1];
    window.location.href = '/xref/#/'+pack+'/findUsages?query=' + encodeURIComponent(searchQuery);
}

function submitSearchQuery(searchQuery, target){
    var $form = $('form[id^=search]');
    setSearchForm($form, searchQuery, target);
    $form.submit();
}

function setSearchForm($form, searchQuery, target) {
    var lastSearchQuery = $('a.search-filter').attr('data-last-search');
    // Set source for analytics
    var sourceInput = $("<input>").attr("type", "hidden").attr("name", "source").val("typeahead");
    $form.append($(sourceInput));

    // Set search target to codebox only CodeBox is selected and search query was not changed
    var searchTarget = 'all';
    if(lastSearchQuery == searchQuery && target == 'Search My CodeBox') {
        searchTarget = 'codebox';
    }
    var targetInput = $("<input>").attr("type", "hidden").attr("name", "target").val(searchTarget);
    $form.append($(targetInput));

    // Set search query
    if(searchTarget == 'codebox') {
        $('input.typeahead').val(lastSearchQuery);
    }
    else {
        $('input.typeahead').val(searchQuery);
    }

}
