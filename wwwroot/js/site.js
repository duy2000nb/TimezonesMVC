// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const apiBaseUrl = 'https://localhost:7244/Timezone/Name' //đây là đường dấn tới controller của bạn

let input = $("#Search")
input.keyup(event => {
    if (event.keyCode == 13) {
        window.location.href = "Search?name=" + input[0].value;
    }
})

function search_product() {
    let keySearch = document.getElementById("Search").value;
    $.ajax({
        url: apiBaseUrl,
        type : "Get",
        datatype : "json",
        data : { name: keySearch }
    }).done(function (result) {
        var contents = result.content;
        var arrayName = []
        contents.forEach(item => {
            arrayName.push(item.name);
        })
        //console.log(arrayName)
        $("#Search").autocomplete({
            source: arrayName
        });
        }).fail(function (error) {
            console.log(error);
        });
};