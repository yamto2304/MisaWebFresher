$(document).ready(function () {
    //Vì dùng 1 form cho cả sửa và thêm mới nên phải để trạng thái cho form là add/edit
    var status = "add";
    loadData();
    $(document).on("click", function () {
        $('#option-detail').hide();
    }); 
    //reload
    $('#reload').on("click", function () {
        window.location.reload();
    })
    // set event 
    //Thêm
    $("#btn-add").on("click", openDialog);
    //Hủy
    $("#btn-cancel").on("click", closeDialog);
    //Lưu
    $("#btn-save").on("click", saveCustomer);
    //Sửa
    $("#btn-edit").on("click", editCustomer);
    //Xóa
    $("#btn-delete").on("click", deleteCustomer); 

    $(".ui-icon-closethick").on("click", closeDialog);
    // event chọn row
    $("#tblistdata").on("click", "tbody tr", function (e) {
        this.classList.add("row-selected");
        $(this).siblings().removeClass("row-selected");
    });
    // event double click vào row để hiện sửa xóa
    $("#tblistdata").on("dblclick", "tbody tr", function (e) {
        $('#option-detail').hide();
        $('#option-detail').css({ 'top': e.pageY + 5, 'left': e.pageX });
        $('#option-detail').show();
        e.stopPropagation();
    });


    /**
     * MỞ FORM
     * */
    function openDialog() {
        //dialog.dialog("open");
        document.getElementById('customer-dialog').showModal();
    }

    /**
     * ĐÓNG FORM
     * */
    function closeDialog() {
        // đóng lại dialog
        // dialog.dialog("close");
        document.getElementById('customer-dialog').close();

        // xoá dữ liệu trên form
        $("#customer-dialog input").val("");
        $("#customer-dialog select").val("-1");

        // đặt lại trạng thái về mặc định
        status = "add";
    }

    // Hàm getall
    function loadData() {
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            method: "GET"
        }).done(function (response) { 
            $('#tblistdata tbody').empty();
            for (var i = 0; i < response.length; i++) {
                var trHtml = $(`<tr class="firstline">
                        <td>${response[i].CustomerCode}</td>
                        <td>${response[i].FullName}</td>
                        <td>${response[i].Gender == null ? "" : formatGender(response[i].Gender)}</td>
                        <td>${response[i].DateOfBirth == null ? "" : formatDate(response[i].DateOfBirth)}</td>
                        <td>${response[i].PhoneNumber}</td> 
                        <td>${response[i].Email == null ? "" : response[i].Email}</td> 
                        <td>${response[i].CustomerGroupName}</td>  
                    </tr>`);
                trHtml.data("id", response[i].CustomerId);
                $('#tblistdata > tbody:last-child').append(trHtml);
            }
        }).fail(function (res) {
        });
    } 

    function saveCustomer() {

        // lấy dữ liệu từ form
        var customer = getCustomerInForm();

        // validate dữ liệu
        if (validate(customer) != false) {
            var url = "http://api.manhnv.net/api/customers";
            var method = "POST";
            var mess = "Thêm mới thành công";

            if (status == "edit") {
                // lấy dòng được chọn
                var rowSelected = $("tr.row-selected");

                var customerID = rowSelected.data('id');

                url = url + "/" + customerID;

                method = "PUT";

                mess = "Cập nhật thông tin thành công";
            }
            $.ajax({
                url: url,
                method: method,
                dataType: "json",
                data: JSON.stringify(customer),
                contentType: "application/json"
            }).done(function (response) {
                // Đóng lại form
                alert(mess);

                closeDialog();

                // load lại dữ liệu
                loadData();
            }).fail(function (res) {
                if (res.responseText == "Trùng mã") {
                    alert("Mã khách hàng đã tồn tại");
                }
                else {
                    alert("Có lỗi xảy ra, vui lòng thử lại");
                }
            });
        }

    }

    /**
     * validate dữ liệu
     * @param {any} customer
     */
    function validate(customer) {
        // kiểm tra trường mã khách hàng xem có trông không?: focus vào
        if (customer.CustomerCode == "") {
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
                alert("Email kông hợp lệ");
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

    /**
     * LẤY DỮ LIỆU TỪ FORM NHẬP LIỆU
     * created by vtthien
     * */
    function getCustomerInForm() {
        var customer = {
            CustomerCode: $("#customerCode").val(),
            FullName: $("#fullName").val(),
            DateOfBirth: $("#birthDay").val() || null,
            Gender: $("#gender").val(), 
            Email: $("#email").val() || "",
            PhoneNumber: $("#phoneNumber").val(), 
            CustomerGroupId: $("#customerGroup").val(), 
            IsStopFollow: $("#isStopFollow").is(":checked")
        };
        return customer;
    }

    function editCustomer() { 
        // show dialog
        openDialog(); 

        // đặt trạng thái
        status = "edit";

        // lấy dòng được chọn
        var rowSelected = $("tr.row-selected");

        var customerID = rowSelected.data('id');

        // gọi api lấy thông tin
        $.ajax({
            url: "http://api.manhnv.net/api/customers/" + customerID,
            method: "GET"
        }).done(function (response) {
            $("#customerCode").val(response.CustomerCode);
            $("#fullName").val(response.FullName);
            $("#birthDay").val(formatDefaultDate(response.DateOfBirth));
            $("#gender").val(response.Gender); 
            $("#email").val(response.Email);
            $("#phoneNumber").val(response.PhoneNumber); 
            $("#customerGroup").val(response.CustomerGroupId); 
            $("#isStopFollow").prop('checked', response.IsStopFollow);
        }).fail(function (res) {

        });
    }
    /**
     * Xóa khách hàng
     * */
    function deleteCustomer() {
        var rowSelected = $("tr.row-selected");
        var customerID = rowSelected.data('id');
        var fullName = rowSelected[0].cells[1].innerText;

        if (confirm("Bạn có chắc chắn muốn xóa khách hàng " + fullName + " không?")) {
            $.ajax({
                url: "http://api.manhnv.net/api/customers/" + customerID,
                method: "DELETE"
            }).done(function (response) {
                alert("Đã xóa khách hàng " + fullName + "!");
                loadData();
            }).fail(function (res) {
                alert("Có lỗi xảy ra! Vui lòng thử lại !");
            });
        }
    }

    /**
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

    /**
     * chuyển thời gian về dạng mặc định YYYY-MM-dd
     * Vì khi đọc từ form để sửa nó lỗi
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
    /**
     * định dạng số 
     * @param {any} num
     */
    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.')
    }

    ///format giới tính
    function formatGender(gen) {
        switch (gen) {
            case 0:
                return "Nữ"
            case 1:
                return "Nam"
            case 2:
               return "Khác"
            default:
                return ""
        }
    }

    /**
     * Kiểm tra định dạng email hợp lệ
     * @param {any} email
     */
    function validateEmail(email) {
            const re = /\S+@\S+\.\S+/;
        return re.test(String(email).toLowerCase()); 
    }
});