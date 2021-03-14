$(document).ready(function(){
    loadData();
    // $('#add-form').close();
    var tableJs = document.getElementById('tbl-customer');
    var tableJq = $('#tbl-customer');
    var btnOpenFormAdd = $('#buttonAdd');
    var btnCloseForm = $('#btnCancel');
    // debugger
    btnOpenFormAdd.click(function(){
        //  $(this).hide(); 
        debugger
        $('#add-form').show();
    })

    //event 
    btnCloseForm.click(function(){
        $('#add-form').hide();
    })
})

function loadData(){
    $.ajax({
        url: "http://api.manhnv.net/api/customer",
        method: "GET"
    }).done(function(response){
        $('#tblistdata tbody').empty();
        for(var i = 0; 0 <response.length; i++){
            var trHtml = $(`<tr class="firstline">
                <td>${response[i].Customercode}</td>
                <td>${response[i].FullName}</td>
                <td>${response[i].Genger == null ? "" : formatGender(response[i].Gender)}</td>
                <td>${response[i].DateOfBirth == null ? "" : formartDate(response[i].DateOfBirth)}</td>
                <td>${response[i].PhoneNumber}</td>
                <td>${response[i].Email == null ? "" : response[i].Email}</td>
                <td>${response[i].CustomerGroupName}</td>
            </tr>`);
            trHtml.data("id", response[i].CustomerId);
            $('#tblistdata > tbody:last-child').apend(trHtml);
        }
    }).fail(function(res){
        // request fail
    });
}

//format giới tính
function formatGender(gen){
    switch (gen){
        case 0:
            return "Nữ"
        case 1:
            return "Nam"

    }
}