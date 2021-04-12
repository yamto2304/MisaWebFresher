<template>
  <div class="m-dialog" :class="{ isHide: isHide }">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="form-header">
        <div class="heading"><b>Thêm mới cửa hàng</b></div>
        <div class="btn-close-form"><button>X</button></div>
      </div>
      <div class="form-content"></div>
      <div class="form-footer">
        <div></div>
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
      error: {
        EmailFormat: "Định dạng email không đúng",
        EmailEmpty: "Email không được để trống",
        NameEmpty: "Tên khách hàng không được để trống",
        PhoneNumberEmpty: "Số điện thoại không được để trống ",
        PhoneNumberFormat: "Sai định dạng số điện thoại",
        CustomerCodeEmpty: "Mã khách hàng không được để trống",
      },
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
  top: calc(50% - 300px);
  width: 600px;
  height: 480px;
  border-radius: 5px;
  background-color: #fff;
  border: 2px solid #dfdfdf;
  border-color: red;
  z-index: 1000;
}
.form-header {
  background-color: burlywood;
  display: flex;
  position: relative;
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
  border-radius: 50%;
  cursor: pointer;
  align-items: center;
  border: white;
  margin: 10px 14px;
}
.form-content {
    background-color: #dfdfdf;
    position: relative;
    top: 0;
    height: calc(100% - 68px - 40px);
    width: 100%;
}

.form-footer {
  background-color: burlywood;
  display: flex;
  position: relative;
  bottom: 0;
  width: 100%;
  height: 68px;
  outline: none;
  border-bottom-right-radius: 5px;
  border-bottom-left-radius: 5px;
}

/* ========================== */
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
}

.btn-save {
  position: absolute;
  left: 524px;
  margin-left: 40px;
  align-self: center;
}
</style>