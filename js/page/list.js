$(document).ready(function(){
    loadData();
    // $('#add-form').close();
    // var tableJs = document.getElementById('tbl-customer');
    // var tableJq = $('#tbl-customer');
    var btnOpenFormAdd = $('#buttonAdd');
    var btnCloseForm = $('#btnCancel');
    var btnSave = $('#btnSave');
    // debugger
    btnOpenFormAdd.click(function(){
        //  $(this).hide(); 
        // debugger
        $('#add-form').show();
    })

    btnSave.click(function(){
        saveData();
    })
    //event 
    btnCloseForm.click(function(){
        $('#add-form').hide();
    })
})
// get form data
function getCustomerInForm(){
    var customer = {
        CustomerCode : $('#customerCode').val(),
        FullName :$('#fullName').val(), 
        Gender : $('input[name=gender]:checked').val(),
        DateOfBirth : $('#dateOfBirth').val() || null,
        PhoneNumber : $('#phoneNumber').val(),
        Email : $('#email').val(),  
        CustomerGroupName : $('#customerGroupName').val()
    }
    return customer;
}

function loadData(){
    $.ajax({
        url: "http://api.manhnv.net/api/customers",
        method: "GET"
    }).done(function(response){
        $('#tbl-customer tbody').empty();
        for(var i = 0; 0 <response.length; i++){
            var trHtml = $(`<tr class="firstline">
                <td>${response[i].CustomerCode}</td>
                <td>${response[i].FullName}</td>
                <td>${response[i].Genger == null ? "" : formatGender(response[i].Gender)}</td>
                <td>${response[i].DateOfBirth /* == null ? "" : formartDate(response[i].DateOfBirth)*/}</td>
                <td>${response[i].PhoneNumber}</td>
                <td>${response[i].Email == null ? "" : response[i].Email}</td>
                <td>${response[i].CustomerGroupName}</td>
            </tr>`);
            trHtml.data("id", response[i].CustomerId);
            $('#tbl-customer > tbody:last-child').append(trHtml);
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

function saveData(){
    var customer = getCustomerInForm();
    if(1){
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            method: "POST",
            data: JSON.stringify(customer),
            contentType: "application/json"
        }).done(function(response){
            //thong bao nguoi dung
            alert("Thêm mới khách hàng thành công");
            // dong dialog
            document.getElementById('#add-form').closest();
            //reload data
            loadData();
        }).fail(function(res){
            //request fail
        })
    }
}

// function validate(customer){
//     if(customer.CustomerCode == null) || customer.CustomerCode == ''){
//         alert('Mã khách hàng không được bỏ trống');
//         $('#customerCode')
//         return false;
//     }
//     //....
//     return true;
// }