$(document).ready(function(){
    loadData();
    // var tableJs = document.getElementById('tbl-customer');
    // var tableJq = $('#tbl-customer');
    
    var btnOpenFormAdd = $('#buttonAdd');
    btnOpenFormAdd.click(function(){
        document.getElementById('add-form').showModal();
    })
    //Add customer
    var btnSave = $('#btnSave');
    btnSave.click(function(){
        saveData();
    })
    //Close form
    var btnCloseForm = $('#btnCancel');
    btnCloseForm.click(function(){
        $('#add-form').hide();
    })
    
    //Delete customer

    
    //Custom dbclick in row -- delete
    // $("#tbl-customer").on('dblclick', 'tr', function () {
    //     var id = $(this).attr('id');
    //     deleteData(id);
    // })

    //Custom dblclick in row -- edit
    $("#tbl-customer").on('dblclick', 'tr', function () {
        var customerEditable = {
            CustomerId : $(this).attr('id'),
            CustomerCode : this.cells[0].textContent,
            FullName : this.cells[1].textContent,
            Gender : this.cells[2].textContent,
            Address : this.cells[3].textContent,
            DateOfBirth : this.cells[4].textContent,
            PhoneNumber : this.cells[5].textContent,
            Email : this.cells[6].textContent,
            CustomerGroupName : this.cells[7].textContent,
            CompanyName : this.cells[8].textContent,
        }
        editData(customerEditable);
    })

})
// get form data
function getCustomerInForm(){
    var customer = {
        CustomerCode : $('#customerCode').val(),
        FullName :$('#fullName').val(), 
        Gender : $('input[name=gender]:checked').val(),
        Address: $('#address').val(), 
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
            var trHtml = $(`<tr class="datarow" id="${customerId}" >
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
                
            </tr>`);
            trHtml.data("id", response[i].CustomerId);
            // debugger
            $('#tbl-customer > tbody:last-child').append(trHtml);
            //Set style for datarow
            document.getElementById(customerId).style.color = "red";
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
    if(1){ //validate
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
function showFormEdit(customerEditable) {
    document.getElementById('add-form').showModal();
    $('#customerCode').val(customerEditable.CustomerCode);
    $('#fullName').val(customerEditable.FullName);
    // $('#memberCode').val(customerEditable.MemberCode);
    $('#dateOfBirth').val(customerEditable.DateOfBirth);
    $('#email').val(customerEditable.Email);
    $('#phoneNumber').val(customerEditable.PhoneNumber);
    $('#address').val(customerEditable.Address);

    //get data in form
    var btnConfirmEdit = $('#btnConfirmEdit');
    btnConfirmEdit.click(function(){
        editData(customerEditable);
    })
}

function editData(customerEditable) {
    if(1){ //validate
        $.ajax({
            url: "http://api.manhnv.net/api/customers/" + customerEditable.CustomerId,
            method: "PUT",
            data: JSON.stringify(customerEditable),
            contentType: "application/json"
        }).done(function(response){
            //thong bao nguoi dung
            alert("Cập nhật dữ liệu thành công");
            // dong dialog
            $('#add-form').hide();
            //reload data
            loadData();
        }).fail(function(res){
            //request fail
        })
    }
    // alert(id);
    debugger
}

function deleteData(id) {
    // debugger
    $.ajax({
        url: "http://api.manhnv.net/api/customers/" + id,
        method: "DELETE"
    }).done(function (response) {
        //Thông báo người dùng
        debugger
        alert("Xóa người dùng thành công");
        //reload data
        loadData();
    }).fail(function (res) {
        alert("Xóa không thành công. Mã lỗi : " + res);
        
    })
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