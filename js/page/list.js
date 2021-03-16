$(document).ready(function(){
    loadData();
    // var tableJs = document.getElementById('tbl-customer');
    // var tableJq = $('#tbl-customer');
    var btnOpenFormAdd = $('#buttonAdd');
    var btnCloseForm = $('#btnCancel');
    var btnSave = $('#btnSave');
    btnOpenFormAdd.click(function(){
        document.getElementById('add-form').showModal();
    })
    //Add customer
    btnSave.click(function(){
        saveData();
    })
    //Close form
    btnCloseForm.click(function(){
        $('#add-form').hide();
    })
    var rowData = $("#body-data tr");
    // debugger
    rowData.click(function() {
        debugger
        // showRowOptions();
        $(this).hide(); 
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

function setCustomerInform(params) {
    
}

function showRowOptions() {
    $('#add-form').showModal();
}

function loadData(){
    
    $.ajax({
        url: "http://api.manhnv.net/api/customers",
        method: "GET"
    }).done(function(response){
        $('#tbl-customer tbody').empty();
        for(var i = 0; 0 <response.length; i++){
            var customerId = response[i].CustomerId;
            // debugger
            var trHtml = $(`<tr class="datarow" id=${response[i].CustomerId} >
                <td>${response[i].CustomerCode}</td>
                <td>${response[i].FullName}</td>
                <td>${response[i].Genger == null ? "" : formatGender(response[i].Gender)}</td>
                <td>${response[i].Address}</td>
                <td>${response[i].DateOfBirth /* == null ? "" : formartDate(response[i].DateOfBirth)*/}</td>
                <td>${response[i].Email == null ? "" : response[i].Email}</td>
                <td>${response[i].PhoneNumber}</td>
                <td>${response[i].CustomerGroupName}</td>
                <td>${response[i].CompanyName}</td>
                <td>${response[i].IsStopFollow == true ? "Đang theo dõi" : "Không"}</td>
                <td><button id="edit>Sửa</button><td>
            </tr>`);
            trHtml.data("id", response[i].CustomerId);
            // debugger
            $('#tbl-customer > tbody:last-child').append(trHtml);
            //Set style for datarow
            // $(customerId).css("color","red");
            document.getElementById(customerId).style.color = "red";
            //  debugger
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
            $('#add-form').hide();
            //reload data
            loadData();
        }).fail(function(res){
            //request fail
        })
    }
}

function validate(customer){
    if(customer.CustomerCode == null || customer.CustomerCode == ''){
        alert('Mã khách hàng không được bỏ trống');
        $('#customerCode')
        return false;
    }
    //....
    return true;
}