// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showConfirm(evnt, url, id) {
    evnt.preventDefault();

    if (confirm("Are you sure want to delete it?")) {
        $.post(url, function (result) {
            $('.continent-delete-' + id).remove();
        });

    }

    return false;

}