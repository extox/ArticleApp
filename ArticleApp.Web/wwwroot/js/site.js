// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#articlelist').DataTable({
        processing: true,
        ordering: true,
        paging: true,
        searching: true,
        ajax: "https://localhost:5001/api/Article3",
        columns: [
            { "data": "id" },
            { "data": "name" },
            { "data": "description" },
            { "data": "regDate" }
        ]
    });
});