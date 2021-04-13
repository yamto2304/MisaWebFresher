<template>
  <div class="m-dialog" :class="{ isHide: isHide }">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="form-header">
        <div class="heading"><b>Thêm mới cửa hàng</b></div>
        <div class="btn-close-form"><button class="btn-x">X</button></div>
      </div>
      <div class="form-content">
        <div class="box-content">
          <div class="form-row-basic">
            <div class="row-item-name">
              Mã cửa hàng <span class="red-text">*</span>
            </div>
            <input class="row-input-big" />
          </div>
          <div class="form-row-basic">
            <div class="row-item-name">
              Tên cửa hàng <span class="red-text">*</span>
            </div>
            <input class="row-input-big" />
          </div>
          <div class="form-row-high">
            <div class="row-item-name">
              Địa chỉ <span class="red-text">*</span>
            </div>
            <input class="row-input-big" />
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Số điện thoại</div>
              <input class="row-input-small" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Mã số thuế</div>
              <input class="row-input-small" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Quốc gia</div>
              <input class="row-input-small" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Tỉnh/Thành phố</div>
              <input class="row-input-small" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Quận/Huyện</div>
              <input class="row-input-small" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Phường/Xã</div>
              <input class="row-input-small" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Đường phố</div>
              <input class="row-input-small" />
            </div>
          </div>
        </div>
      </div>
      <div class="form-footer">
        <button class="btn-with-icon btn-help-footer">
          <div class="icon-help-13"></div>
          <div class="text-btn theme-color-text">Trợ giúp</div>
        </button>
        <div class="footer-feature">
          <button class="btn-with-icon btn-save-footer">
            <div class="icon-save"></div>
            <div class="text-btn theme-color-text" style="color: #ffffff">
              Lưu
            </div>
          </button>
          <button class="btn-with-icon btn-save-add">
            <div class="icon-add-form"></div>
            <div class="text-btn theme-color-text">Lưu và Thêm mới</div>
          </button>
          <button class="btn-with-icon btn-cancel-form">
            <div class="icon-cancel-form"></div>
            <div class="text-btn theme-color-text">Huỷ bỏ</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    isHide: Boolean,
  },
  components: {},
  methods: {
    btnSaveOnClick() {
      alert(this.customer.PhoneNumber);
    },
    btnCancelOnClick() {
      this.$emit("closeForm", true);
    },
    //OnBlur CustomerCode Input
    blurCustomerCode() {
      // this.showSmallMessage(id);
      if (!this.customer.CustomerCode) {
        // alert(this.errorCustomerCodeEmpty);
        this.customerCodeAlert = true;
      } else this.customerCodeAlert = false;
    },
    //OnBlur FullName Input
    blurName() {
      // this.showSmallMessage();
      if (!this.customer.FullName) {
        // alert(this.errorNameEmpty);
        this.fullNameAlert = true;
      } else this.fullNameAlert = false;
    },
    //OnBlur PhoneNumber Input
    blurPhoneNumber() {
      this.showSmallMessage();
      if (!this.customer.PhoneNumber) {
        //Lỗi để trống
        // alert(this.errorPhoneNumberEmpty);
        this.phoneNumberAlert = true;
      } else this.phoneNumberAlert = false;
    },
    blurEmail() {
      // this.showSmallMessage();
      if (!this.customer.Email) return;
      if (!this.validateEmail(this.customer.Email)) {
        this.emailAlert = true;
      }
    },

    validateEmail(email) {
      const re = /\S+@\S+\.\S+/;
      return re.test(String(email).toLowerCase());
    },
    showSmallMessage() {
      // this.coordinateX = document
      //   .querySelector("#" + id)
      //   .getBoundingClientRect().x;
      // this.coordinateY = document
      //   .querySelector("#" + id)
      //   .getBoundingClientRect().y;
      // this.isHideMessage = false;
    },
    closeMessage() {
      this.isHideMessage = true;
    },
  },
  mounted() {
    this.openMessageBlur;
  },
  data() {
    return {
      coordinateX: null,
      coordinateY: null,
      isHideMessage: true,
      error: {},
      customer: {
        customerId: "68915a99-9694-11eb-8a1f-00163e047e89",
        customerCode: "Kho23432",
        fullName: "Lê Quang Ngân",
        dateOfBirth: null,
        gender: null,
        memberCardCode: null,
        customerGroupId: "7a0b757e-41eb-4df6-c6f8-494a84b910f4",
        phoneNumber: "090909090",
        companyName: null,
        companyTaxCode: null,
        email: "Ngan@gmail.com",
        address: null,
        note: null,
        createdDate: null,
        createdBy: null,
        modifiedDate: null,
        modifiedBy: null,
      },
    };
  },
};
</script>
<style scoped>
.isHide {
  display: none;
}
.isBlurAlert {
  border-color: red;
}
.m-dialog {
  z-index: 998;
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
.dialog-content {
  position: fixed;
  left: calc(50% - 300px);
  top: calc(50% - 236px);
  width: 600px;
  height: 472px;
  border-radius: 5px;
  background-color: #fff;
  border: 2px solid #dfdfdf;
  /* border-color: red; */
  z-index: 1000;
}
.red-text {
  color: red;
}
.theme-color-text {
  color: #2b3173;
}
input:focus {
  border-color: #636dde;
}
/* ==================================== */
.form-header {
  background-color: #f0f0f0;
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  display: flex;
  position: relative;
  top: 0;
  left: 0;
  height: 40px !important;
  width: 100%;
  font-size: 16px;
  align-items: center;
}
.heading {
  margin: 10px 14px;
}
.btn-close-form {
  position: absolute;
  right: 0px;
  width: 24px;
  height: 24px;
  cursor: pointer;
  align-items: center;
  border: none;
  margin: 10px 14px;
}
.btn-x {
  border: none;
  cursor: pointer;
  outline: none;
}
.form-content {
  background-color: #dfdfdf;
  background-color: #fff;
  position: relative;
  top: 0;
  width: 568px;
  height: 356px;
  padding: 8px 16px 0px;
  border-top: 1px solid #e4e4e4;
}
.box-content {
  position: relative;
  height: 100%;
  width: 100%;
  background-color: #ffffff;
}
.form-row-basic {
  position: relative;
  overflow: hidden;
  outline: none;
  /* padding: 5px 10px; */
  right: auto;
  left: 0px;
  margin-top: 8px;
  height: 32px;
  background-color: #ffffff;
  display: flex;
}
.form-row-high {
  position: relative;
  overflow: hidden;
  outline: none;
  padding: 0;
  right: auto;
  left: 0px;
  margin-top: 8px;
  height: 90px;
  display: flex;
  /* padding: 5px 10px 4px; */
  background-color: #ffffff;
}
.row-item-left {
  height: 100%;
  width: 50%;
  position: relative;
  display: flex;
  left: 0;
}
.row-item-right {
  display: flex;
  height: 100%;
  width: calc(50% - 16px);
  padding-left: 16px;
  position: relative;
  right: 0;
}
.row-item-name {
  height: calc(100% - 8px);
  width: 100px;
  position: relative;
  padding: 4px 5px 0px 0;
  top: 0;
  left: 0;
  margin: 5px 0px;
}
.row-input-big {
  border: 1px solid #e4e4e4;
  border-radius: 3px;
  outline: none;
  position: relative;
  top: 0;
  left: 0;
  width: 447px;
  padding: 5px 10px;
}
.row-input-small {
  border: 1px solid #e4e4e4;
  border-radius: 3px;
  outline: none;
  position: relative;
  top: 0;
  left: 0;
  height: 20px;
  width: 157px;
  padding: 5px 10px;
}
/* =============================================== */
.form-footer {
  background-color: #ffffff;
  display: flex;
  position: relative;
  bottom: 0;
  width: 100%;
  height: 66px;
  outline: none;
  border-bottom-right-radius: 5px;
  border-bottom-left-radius: 5px;
  align-items: center;
  border-top: 1px solid #e4e4e4;
}
.btn-help-footer {
  position: relative;
  left: 8px;
  height: 35px;
  background-color: #ffffff;
}
.btn-help-footer:hover {
  background-color: #e5e6eb;
}
.footer-feature {
  background-color: #ffffff;
  display: flex;
  position: relative;
  height: 36px;
  width: 100%;
  margin: 8px;
}
.btn-save-footer {
  position: absolute;
  right: 256px;
  border-radius: 3px;
}
.btn-save-add {
  border-radius: 3px;

  position: absolute;
  right: 103px;
  background-color: #ffffff !important;
  border: 1px solid #2b3173;
}
.btn-cancel-form {
  border-radius: 3px;
  position: absolute;
  right: 8px;
  background-color: #ffffff !important;
  /* border: 1px solid #2b3173; */
}
.btn-cancel-form:hover {
  border: 1px solid #2b3173;
  cursor: pointer;
  border-radius: 3px;
}
/* ========================== */
</style>