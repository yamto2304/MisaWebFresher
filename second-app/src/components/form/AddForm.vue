<template>
    <!-- <div style="display:flex"> -->
        <div class="form-add-customer" id="add-form">
            <div class="form-header">
                <div class="heading">
                    <b>Thông tin khách hàng</b>
                </div>
            </div>
            <div class="basic-info">
                <div class="insert-image">
                    <div class="avatar"></div>
                    <div class="hint">Vui lòng chọn ảnh có định dạng <b>.jpg, .jpeg, .png, .gif.</b></div>
                </div>
                <div class="col-left-1">
                    <div class="input-customer-field">
                        <label >Mã khách hàng</label>
                        <input type="text" name ="customer-code" id="customerCode" onblur="validate(getCustomerInForm())" class="input-box-small" required>
                    </div>  
                    <div class="input-customer-field">
                        <label >Mã thẻ thành viên</label>
                        <input name="member-code" id="memberCode" class="input-box-small">
                    </div>
                    <div class="input-customer-field">
                        <label >Ngày sinh</label>
                        <input type="date" name="date-of-birth" id="dateOfBirth" class="input-box-small input-date">
                    </div>  
                </div>
                <div class="col-right">
                    <div class="input-customer-field">
                        <label>Họ và tên</label>
                        <input type="text" class="input-box-small" id="fullName" required>
                    </div> 
                    <div class="input-customer-field">
                        <label>Nhóm khách hàng</label>
                        <select class="group-customer" id=".customerGroupName">
                            <option value="1">Nhóm1</option>
                            <option value="2">Nhóm2</option>
                        </select>
                    </div> 
                    <div class="input-customer-field">
                        <label>Giới tính</label>
                        <div class="radio-box-small" id="gender">
                            <label><input  type="radio"  name="gender" value="1"><span>Nam</span></label>
                            <label><input  type="radio"  name="gender" value="2"><span>Nữ</span></label>
                            <label><input  type="radio"  name="gender" value="3"><span>Khác</span></label>
                        </div>
                    </div> 
                </div>

            </div>
            <div class="contact-info">
                <div class="col-left-2">
                    <div class="input-customer-field">
                        <label>Email</label>
                        <input type="email" id="email" placeholder="example@domain.com" class="input-box-medium" >
                    </div>
                    <div class="input-customer-field">
                        <label>Nhóm khách hàng</label>
                        <input type="text" id="customerGroupName" class="input-box-medium" >
                    </div>
                    <div class="input-customer-field">
                        <label>Địa chỉ</label>
                        <input type="text" id="address" class="input-box-large">
                    </div>
                </div>
                <!-- SDT -->
                <div class="col-right">
                    <div class="input-customer-field">
                        <label>Số điện thoại</label>
                        <input type="text" class="input-box-small" id="phoneNumber" required>
                    </div> 
                    <!-- Ms thue -->
                    <div class="input-customer-field">
                        <label>Tên công ty</label>
                        <input type="text" placeholder="Tên công ty" id="companyName" class="input-box-small">
                    </div>   
                </div>

            </div>
            <div class="form-footer">
                <div class="btn-cancel" id="btnCancel">
                    <button class="btn-seconds" style="background-color:#BBBBBB;">Hủy</button>
                </div>
                <div class="btn-save"  id="btnSave" >
                    <button class="btn-with-icon" style="width:100px">
                        <div class="icon-btn icon-save"></div>
                        <div class="text-btn">Lưu</div>
                    </button>
                </div>
            </div>
        </div>
    <!-- </div> -->
</template>
