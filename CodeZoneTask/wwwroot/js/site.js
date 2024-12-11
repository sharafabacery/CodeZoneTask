// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showDetails(id, name) {
 
    var detailsDiv = document.getElementById("myDIV");
    if (detailsDiv.style.display === "none") {

        const idField = document.getElementById("id");
        idField.value = id;

        const nameField = document.getElementById("name");
        nameField.value = name;

        detailsDiv.style.display = "block";
    } else {
        detailsDiv.style.display = "none";
    }
}