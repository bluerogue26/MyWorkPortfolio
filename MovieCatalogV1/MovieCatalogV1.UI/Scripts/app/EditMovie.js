var url = '/movieajax/addactors/';

$(document).ready(function () {
    $('#btnAddActor').click(addActorsToMovie);
});

function addActorsToMovie() {
    var obj = {};
    obj.SelectedActorIds = $('#actorsNotInMovie').val();

    $.post(url + movieId, obj)
        .done(function () {
            getActorsNotInMovie();
            getActorsInMovie();
        })
        .fail(function (jqXhr, status, err) {
            alert(status + ' - ' + err);
        });
};

function getActorsInMovie() {
    $.getJSON('/movieajax/getactorsinmovie/' + movieId)
    .done(function (data) {
        $('#actorsInMovie tbody tr').remove();

        $.each(data, function (index, actor) {
            $(createRow(actor)).appendTo($('#actorsInMovie tbody'));
        });
    });
};

function createRow(actor) {
    return '<tr><td>' + actor.LastName + ', ' + actor.FirstName + '</td><td><button class="btn btn-danger" onclick="deleteActor(' + actor.ActorID + ')">Delete</button></td></tr>';
};

function deleteActor(actorId) {
    var obj = {};
    obj.ActorID = actorId;

    if (confirm('Are you sure you want to remove this actor?')) {
        $.post('/movieajax/deleteactor/' + movieId, obj)
            .done(function () {
                getActorsNotInMovie();
                getActorsInMovie();
            })
            .fail(function (jqXhr, status, err) {
                alert(status + ' - ' + err);
            });
    }
};

function getActorsNotInMovie() {
    $.getJSON('/movieajax/getactorsnotinmovie/' + movieId)
    .done(function (data) {
        var selectbox = $('#actorsNotInMovie');
        selectbox.empty();

        var list = '';
        for (var i = 0; i < data.length; i++) {
            list += "<option value='" + data[i].ActorID + "'>" + data[i].FirstName + " " + data[i].LastName + "</option>";
        }
        selectbox.html(list);
    });
};