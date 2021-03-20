$(document).ready(function(){
    var status = "add";
    loadData();    

    //Set event click
    //Tắt option khi click ra bên ngoài
    $('body').click(function (e) {
        $('#option-detail').hide();
        // e.stopPropagation();
    })

    //Refresh
    $('#refresh').click(function(){
        // loadData();
        window.location.reload();
    })
    //Mở form thêm customer
    $('#buttonAddCustomer').click(function(){
        openForm();
    })

    //Đóng form
        $('#btnCancel').click(function(){
        closeForm();
        // xoá dữ liệu trên form
        $("#add-form input").val("");
        $("#add-form select").val("-1");
        // đặt lại trạng thái về mặc định
        status = "add";
    })

    //Button save customer
    $('#btnSave').click(function(){
        // alert(status);
        if(status == "add"){
            saveData();
        }
        else if (status == "edit"){
            updateData()
        } else {
            alert("Có lỗi xảy ra, vui lòng thử lại");
        }
    })

    // event chọn row
    $("#tbl-customer").on("click", "tbody tr", function (e) {
        this.classList.add("row-selected");
        $(this).siblings().removeClass("row-selected");
        // debugger
    });

    //Hiện Option sửa/xóa
    $("#tbl-customer").on('dblclick', 'tbody tr', function (e) {
        $('#option-detail').hide();
        $('#option-detail').css({ 'top': e.pageY + 5, 'left': e.pageX });
        $('#option-detail').show();
        e.stopPropagation();
    })
        
    //Xóa customer
    $('#btnDelete').click(function() {
        deleteData();
    })

    //Sửa customer
    $('#btnEdit').click(function() {
        status = "edit";
        showFormEdit();
    })
})

/**
 * Mở form
 */
function openForm() {
    document.getElementById('add-form').showModal();
}

/**
 * Đóng form
 */
function closeForm() {
    document.getElementById('add-form').close();
}

/**
 * Lấy dữ liệu từ API và append vào bảng
 */
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
                <td>${response[i].DateOfBirth == null ? "" : formatDate(response[i].DateOfBirth)}</td>
                <td>${response[i].Email == null ? "" : response[i].Email}</td>
                <td>${response[i].PhoneNumber}</td>
                <td>${response[i].CustomerGroupName}</td>
                <td>${response[i].CompanyName}</td>
                <td>${response[i].IsStopFollow == true ? "Đang theo dõi" : "Không"}</td>    
            </tr>`);
            trHtml.data("id", response[i].CustomerId);
            $('#tbl-customer > tbody:last-child').append(trHtml);
            //Set style for datarow
            document.getElementById(customerId).style.color = "red";
        }
    }).fail(function(res){
        alert("Server gặp vấn đề rồi, thử lại sau nhé !")
    });
}

/**
 * Lấy dữ liệu từ form
 * @returns object customer
 */
function getCustomerInForm(){
    var customer = {
        CustomerCode : $('#customerCode').val(),
        FullName :$('#fullName').val(), 
        Gender : $('input[name=gender]:checked').val(),
        Address: $('#address').val(), 
        DateOfBirth : $('#dateOfBirth').val() || null,
        PhoneNumber : $('#phoneNumber').val(),
        Email : $('#email').val(),
        CustomerGroupName : $('#customerGroupName').val(),
        CompanyName : $('#companyName').val()
    }
    return customer;
}

/**
 * Thêm mới khách hàng
 */
function saveData(){
    //Lấy dữ liệu từ formư
    
    var customer = getCustomerInForm();
    
    if(validate(customer)){ //validate
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            method: "POST",
            dataType: "json",
            data: JSON.stringify(customer),
            contentType: "application/json"
        }).done(function(response){
            //Thông báo người dùng
            alert("Thêm mới khách hàng thành công");
            // Đóng form
            closeForm();
            //reload data
            loadData();
        }).fail(function(res){
            if (res.responseText == "Trùng mã") {
                alert("Mã khách hàng đã tồn tại");
            }
            else {
                alert("Có lỗi xảy ra khi thêm khách hàng, vui lòng thử lại");
            }
        })
    }
}

function updateData() {
    var rowSelected = $("tr.row-selected");
    var customerID = rowSelected.data('id');
    //Lấy dữ liệu từ form
    var customer = getCustomerInForm();
    
    if(validate(customer)){
        $.ajax({
            url: "http://api.manhnv.net/api/customers/" + customerID,
            method: "PUT",
            dataType: "json",
            data: JSON.stringify(customer),
            contentType: "application/json"
        }).done(function(response){
            //Thông báo người dùng
            alert("Cập nhật thông tin thành công");
            // Đóng form
            closeForm();
            //reload data
            loadData();
        }).fail(function(res){
            alert("Có lỗi xảy ra khi cập nhật dữ liệu, vui lòng thử lại");
        })
    }
}
    
/**
 * Show form và đẩy dữ liệu cần sửa vào form
 * @param {object} customerEditable 
 */
function showFormEdit() {
    var rowSelected = $("tr.row-selected");
    var customerID = rowSelected.data('id');
    document.getElementById('add-form').showModal();
    // gọi api lấy thông tin
    $.ajax({
        url: "http://api.manhnv.net/api/customers/" + customerID,
        method: "GET"
    }).done(function (response) {
        $('#customerCode').val(response.CustomerCode);
        $('#fullName').val(response.FullName);
        // $('#gender').val(response.MemberCode);
        $('#address').val(response.Address);
        $('#dateOfBirth').val(formatDefaultDate(response.DateOfBirth));
        $('#phoneNumber').val(response.PhoneNumber);
        $('#email').val(response.Email);
        $('#customerGroupName').val(response.CustomerGroupName);
        $('#companyName').val(response.CompanyName);
        // debugger
    }).fail(function(res){
        alert("Tải dữ liệu thất bại, vui lòng thử lại sau");
    })
}


/**********************************************************************
     * validate dữ liệu
     * @param {any} customer
     */
function validate(customer){
    if(customer.CustomerCode == null || customer.CustomerCode == ''){
        alert("Mã khách hàng không được để trống!");
        $("#customerCode").focus();
        return false;
    }
    // kiểm tra trường họ tên
    if (customer.FullName == "") {
        alert("Họ tên không được để trống!");
        $("#fullName").focus();
        return false;
    }
    
    // kiểm tra trường email
    if (customer.Email == "") {
        alert("Email không được để trống!");
        $("#email").focus();
        return false;
    } else {
        if (validateEmail(customer.Email) == false) {
            alert("Email không hợp lệ");
            $("#email").focus();
            return false;
        }
    }

    // kiểm tra trường sđt
    if (customer.PhoneNumber == "") {
        alert("Số điện thoại không được để trống!");
        $("#phoneNumber").focus();
        return false;
    }
    
    return true;
}

/***********************************
 * Format giới tính
 * @param {number} gen 
 * @returns Nam || Nữ
 */
function formatGender(gen){
    switch (gen){
        case 0:
            return "Nữ"
        case 1:
            return "Nam"  
            }
        }

/***********************************
 * Xóa người dùng
 */     
function deleteData() {
    // debugger
    var rowSelected = $("tr.row-selected");
    var customerID = rowSelected.data('id');
    $.ajax({
        url: "http://api.manhnv.net/api/customers/" + customerID,
        method: "DELETE"
    }).done(function (response) {
        //Thông báo người dùng
        alert("Xóa người dùng thành công");
        //reload data
        loadData();
    }).fail(function (res) {
        alert("Xóa không thành công. Mã lỗi : " + res);
        
    })
}

/***********************************
 * Kiểm tra định dạng email hợp lệ
 * @param {any} email
 */
function validateEmail(email) {
    const re = /\S+@\S+\.\S+/;
    return re.test(String(email).toLowerCase()); 
}

/************************************************
 * định dạng ngày tháng về dạng dd/mm/yyyy
 * @param {any} date
 */
function formatDate(date) {
    var date = new Date(date);

    var day = date.getDate();
    if (day < 10) day = '0' + day;
    var month = date.getMonth() + 1;
    if (month < 10) month = '0' + month;
    var year = date.getFullYear();
    return day + '/' + month + '/' + year;
} 

/*****************************************************************
 * chuyển thời gian về dạng mặc định YYYY-MM-dd
 * @param {any} date
 */
 function formatDefaultDate(date) {
    if (date != null) {
        var d = new Date(date.split("/").reverse().join("-"));
        var dd = '' + d.getDate();
        var mm = '' + (d.getMonth() + 1);
        var yyyy = d.getFullYear();

        if (mm.length < 2) mm = '0' + mm;
        if (dd.length < 2) dd = '0' + dd;

        var newdate = yyyy + "-" + mm + "-" + dd;
        return newdate;
    }
    return null;
}  