<style scoped>
.isHide {
  display: none;
}
.isBlurAlert {
  border-color: red;
}
.red-text {
  color: red;
}
.dialog-modal {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
  z-index: 999;
}
.m-dialog {
  z-index: 998;
}
.dialog-content {
  position: fixed;
  width: 700px;
  height: 583px;
  left: calc(50% - 400px);
  top: calc(50% - 300px);
  border-radius: 5px;
  background-color: #fff;
  border: 1px solid #bbbbbb;
  z-index: 1000;
}
.btn-close-form {
  position: absolute;
  top: 16px;
  right: 16px;
  width: 24px;
  height: 24px;
  border-radius: 50%;
  cursor: pointer;
  top: 10px;
  align-items: center;
  border: none;
  background-color: transparent;
  font-size: 24px;
  line-height: 24px;
}
.form-header {
  position: relative;
  height: 54px;
  line-height: 60px;
  padding-left: 16px;
  display: flex;
  font-size: 24px;
}

.basic-info {
  width: 100%;
  height: 228px;
  display: flex;
}
.insert-image {
  width: 200px;
  height: 100%;
  /* margin-right: 16px; */
  margin-left: 24px;
  /* border: 1px solid yellow; */
}

.insert-image .avatar {
  border: 1px solid #bbbbbb;
  border-radius: 50%;
  width: 100%;
  height: 188px;
  background-image: url("../../assets/img/default-avatar.jpg");
  background-position: center;
  background-repeat: no-repeat;
  background-size: contain;
}
.insert-image .hint {
  text-align: center;
  width: 100%;
}

.basic-info .col-left-1 {
  width: 200px;
  height: 100%;
  margin-left: 24px;
  margin-right: 16px;
}

.input-customer-field {
  margin-top: 12px;
}

.input-box-small {
  width: 200px;
  margin-top: 4px;
}

.input-date {
  width: 201px;
  height: 40px;
}

.input-box-medium {
  width: 424px;
  margin-top: 4px;
}

.input-box-large {
  margin-top: 4px;
  width: 640px;
}

.radio-box-small {
  margin-top: 4px;
  align-items: center;
  text-align: left;
  height: 36px;
  line-height: 36px;
}

.col-right {
  width: 200px;
  height: 100%;
  margin-right: 24px;
}
.group-customer {
  border: none;
  margin-top: 4px;
  width: 202px;
  height: 36px;
  border-radius: 4px;
  border: 1px solid #bbbbbb;
  color: #000000;
}

.contact-info .col-left-2 {
  width: 424px;
  height: 100%;
  margin-left: 24px;
  margin-right: 16px;
}

.contact-info {
  display: flex;
  width: 100%;
  height: 242px;
}

.form-footer {
  display: flex;
  width: 100%;
  height: 60px;
  background-color: #bbbbbb;
  margin-top: 0px;
  outline: none;
  line-height: 60px;
  /* align-self: center;
    align-content: center; */
  border-bottom-right-radius: 5px;
  border-bottom-left-radius: 5px;
}
.btn-cancel {
  position: absolute;
  left: 424px;
  align-self: center;
  background-color: #bbbbbb;
  height: 40px;
  width: 100px;
  border-radius: 4px;
  border: none;
  line-height: 60px;
  /* background-color: red; */
}
.btn-another {
  display: flex;
  background-color: #019160;
  align-items: center;
  border-radius: 4px;
  height: 40px;
  width: 100px;
  color: #000000;
  text-align: center;
  border: none;
  padding-left: 36px;
  background-color: #bbbbbb;
  cursor: pointer;
}
.btn-another:active {
  background-color: #019160;
  border: none;
}
.btn-another:hover {
  background-color: aliceblue;
}
.btn-save {
  position: absolute;
  left: 524px;
  margin-left: 40px;
  align-self: center;
}
</style>
<template>
  <div
    class="m-dialog"
    title="Thông tin khách hàng"
    :class="{ isHide: isHide }"
  >
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="form-header">
        <div class="heading">
          <b>Thông tin khách hàng</b>
        </div>
        <div class="btn-close-form">
          <button v-on:click="btnCancelOnClick">x</button>
        </div>
      </div>
      <div class="basic-info">
        <div class="insert-image">
          <div class="avatar"></div>
          <div class="hint">
            Vui lòng chọn ảnh có định dạng <b>.jpg, .jpeg, .png, .gif.</b>
          </div>
        </div>
        <div class="col-left-1">
          <div class="input-customer-field">
            <label>Mã khách hàng(<span class="red-text">*</span>)</label>
            <input
              type="text"
              name="customer-code"
              id="customerCode"
              v-on:blur="blurCustomerCode()"
              v-model="customer.CustomerCode"
              class="input-box-small"
              :class="{ isBlurAlert: customerCodeAlert }"
              required
            />
          </div>
          <div class="input-customer-field">
            <label>Mã thẻ thành viên</label>
            <input name="member-code" id="memberCode" class="input-box-small" />
          </div>
          <div class="input-customer-field">
            <label>Ngày sinh</label>
            <input
              type="date"
              name="date-of-birth"
              id="dateOfBirth"
              class="input-box-small input-date"
            />
          </div>
        </div>
        <div class="col-right">
          <div class="input-customer-field">
            <label>Họ và tên (<span class="red-text">*</span>)</label>
            <input
              type="text"
              class="input-box-small"
              id="fullName"
              required
              v-model="customer.FullName"
              :class="{ isBlurAlert: fullNameAlert }"
              v-on:blur="blurName()"
            />
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
              <label
                ><input type="radio" checked name="gender" value="1" /><span
                  >Nam</span
                ></label
              >
              <label
                ><input type="radio" name="gender" value="2" /><span
                  >Nữ</span
                ></label
              >
              <label
                ><input type="radio" name="gender" value="3" /><span
                  >Khác</span
                ></label
              >
            </div>
          </div>
        </div>
      </div>
      <div class="contact-info">
        <div class="col-left-2">
          <div class="input-customer-field">
            <label>Email {{customer.Email}}</label>
            <input
              type="email"
              id="email"
              placeholder="example@domain.com"
              class="input-box-medium"
              v-model="customer.Email"
              v-on:blur="blurEmail()"
            />
          </div>
          <div class="input-customer-field">
            <label>Nhóm khách hàng</label>
            <input
              type="text"
              id="customerGroupName"
              class="input-box-medium"
            />
          </div>
          <div class="input-customer-field">
            <label>Địa chỉ</label>
            <input type="text" id="address" class="input-box-large" />
          </div>
        </div>
        <!-- SDT -->
        <div class="col-right">
          <div class="input-customer-field">
            <label>Số điện thoại {{customer.PhoneNumber}}(<span class="red-text">*</span>)</label>
            <input
              type="text"
              class="input-box-small"
              id="phoneNumber"
              v-model="customer.PhoneNumber"
              v-on:blur="blurPhoneNumber()"
              :class="{ isBlurAlert: phoneNumberAlert }"
              required
            />
          </div>
          <!-- Ms thue -->
          <div class="input-customer-field">
            <label>Tên công ty</label>
            <input
              type="text"
              placeholder="Tên công ty"
              id="companyName"
              class="input-box-small"
            />
          </div>
        </div>
      </div>
      <div class="form-footer">
        <div class="btn-cancel" style="vertical-align: top">
          <button class="btn-another" v-on:click="btnCancelOnClick">Hủy</button>
        </div>
        <div class="btn-save" id="btnSave">
          <button class="btn-with-icon" style="width: 100px">
            <div class="icon-btn icon-save"></div>
            <div class="text-btn">Lưu</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    phoneNumberAlert: Boolean,
    customerCodeAlert : Boolean,
    fullNameAlert : Boolean,
    isHide: Boolean,
  },
  //Giá trị từ parent truyển đến
  methods: {
    btnSaveOnClick() {
      alert(this.customer.PhoneNumber);
    },
    btnCancelOnClick() {
      this.$emit("closeForm", true);
    },
    //OnBlur CustomerCode Input
    blurCustomerCode() {
      if (!this.customer.CustomerCode) {
        alert(this.errorCustomerCodeEmpty);
        this.customerCodeAlert = true;
      } else this.customerCodeAlert = false;
    },
    //OnBlur FullName Input 
    blurName() {
      if (!this.customer.FullName) {
        alert(this.errorNameEmpty);
        this.fullNameAlert = true;
      } else this.fullNameAlert = false;
    },
    //OnBlur PhoneNumber Input
    blurPhoneNumber() {
      if (!this.customer.PhoneNumber) {
        //Lỗi để trống
        alert(this.errorPhoneNumberEmpty);
        this.phoneNumberAlert = true;
      } else
      this.phoneNumberAlert = false;
    },
    blurEmail(){
      if(!this.customer.Email)
        return
      if(!this.validateEmail(this.customer.Email)){
        alert(this.errorEmailFormat);
      }
    },
    
    validateEmail(email) {
      const re = /\S+@\S+\.\S+/;
      return re.test(String(email).toLowerCase());
    },
    // validateEmail(email) {
    //   var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    //   return re.test(email);
    // },
    validatePhoneNumber(input){
      return (!isNaN(input))&&(parseInt('input', 10) >= 0);
    }
  },
  data() {
    return {
      errorEmailFormat: "Định dạng email không đúng",
      errorEmailEmpty: "Email không được để trống",
      errorNameEmpty: "Tên khách hàng không được để trống",
      errorPhoneNumberEmpty: "Số điện thoại không được để trống ",
      errorPhoneNumberFormat: "Sai định dạng số điện thoại",
      errorCustomerCodeEmpty: "Mã khách hàng không được để trống",
      employee: {
        DateOfBirth: "1992-06-17T00:00:00",
        Address: "319 Prospect Hill Blvd, Keith Bldg, Boise, Idaho, 76994",
        DepartmentId: "142cb08f-7c31-21fa-8e90-67245e8b283e",
        DepartmentName: "Phòng Marketting",
        EducationalBackground: 5,
        Email: "kute@example.com",
        EmployeeCode: "NV-247682s",
        FirstName: "Trương Phương",
        FullName: "Mai Thị Bích",
        Gender: null,
        GenderName: "Không xác định",
        IdentityDate: null,
        IdentityNumber: "25323254060",
        IdentityPlace: "abc",
        JoinDate: "2014-12-05T00:00:00",
        LastName: "Minh",
        MaritalStatus: 5,
        PersonalTaxCode: "06951619",
        PhoneNumber: "099a194059",
        PositionId: "25c6c36e-1668-7d10-6e09-bf1378b8dc91",
        PositionName: "Thu ngân",
        QualificationId: "3541ff76-58f0-6d1a-e836-63d5d5eff719",
        QualificationName: "Kỹ sư CNTT",
        Salary: 16275117,
        WorkStatus: 2,
        WorkStatusName: "Đang thử việc",
      },
      customer: {
        CustomerCode: "",
        FullName: "",
        CustomerCardCode: "",
        GroupCustomerId: "",
        DateOfBirth: "",
        Gender: "",
        GenderName: "",
        Email: "",
        PhoneNumber: "",
        GroupCustomerName: "",
        CompanyName: "",
        Address: "",
      },
    };
  },
};
</script>
