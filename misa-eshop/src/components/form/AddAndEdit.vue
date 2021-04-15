<template>
  <div class="m-dialog" :class="{ isHide: isHide }">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="form-header">
        <div class="heading"><b>Thêm mới cửa hàng</b></div>
        <div class="btn-close-form" v-on:click="btnCancelOnClick">
          <button class="btn-x" v-on:click="btnCancelOnClick" title="Đóng">
            X
          </button>
        </div>
      </div>
      <div class="form-content">
        <div class="box-content">
          <div class="form-row-basic">
            <div class="row-item-name">
              Mã cửa hàng <span class="red-text">*</span>
            </div>
            <input
              class="row-input-big"
              :class="{ isBlurAlert: this.storeCodeAlert }"
              v-model="store.storeCode"
              v-on:blur="blurStoreCode()"
            />
          </div>
          <div class="form-row-basic">
            <div class="row-item-name">
              Tên cửa hàng <span class="red-text">*</span>
            </div>
            <input
              class="row-input-big"
              :class="{ isBlurAlert: this.storeNameAlert }"
              v-model="store.storeName"
              v-on:blur="blurStoreName()"
            />
          </div>
          <div class="form-row-high">
            <div class="row-item-name">
              Địa chỉ <span class="red-text">*</span>
            </div>
            <input
              class="row-input-big"
              :class="{ isBlurAlert: this.storeAddressAlert }"
              v-model="store.address"
              v-on:blur="blurStoreAddress()"
            />
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Số điện thoại</div>
              <input class="row-input-small" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Mã số thuế</div>
              <input class="row-input-small" v-model="store.phoneNumber" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Quốc gia</div>
              <input class="row-input-small" v-model="store.countryId" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Tỉnh/Thành phố</div>
              <input class="row-input-small" v-model="store.provinceId" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Quận/Huyện</div>
              <input class="row-input-small" v-model="store.districtId" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Phường/Xã</div>
              <input class="row-input-small" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Đường phố</div>
              <input class="row-input-small" v-model="store.wardId" />
            </div>
          </div>
        </div>
      </div>
      <div class="form-footer">
        <button class="btn-with-icon btn-help-footer">
          <div class="icon-help-13"></div>
          <div class="text-btn theme-color-text" title="F1">Trợ giúp</div>
        </button>
        <div class="footer-feature">
          <button
            class="btn-with-icon btn-save-footer"
            v-on:click="btnSaveOnClick"
          >
            <div class="icon-save"></div>
            <div
              class="text-btn theme-color-text"
              style="color: #ffffff"
              title="Ctrl+S"
            >
              Lưu
            </div>
          </button>
          <button
            class="btn-with-icon btn-save-add"
            v-on:click="btnSaveAndAddOnClick"
          >
            <div class="icon-add-form"></div>
            <div class="text-btn theme-color-text" title="Ctrl+Shift+S">
              Lưu và Thêm mới
            </div>
          </button>
          <button
            class="btn-with-icon btn-cancel-form"
            v-on:click="btnCancelOnClick"
          >
            <div class="icon-cancel-form"></div>
            <div class="text-btn theme-color-text" title="Ctrl+B">Huỷ bỏ</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  props: {
    isHide: Boolean,
    isAddMode: Boolean,

    storeCodeAlert: Boolean,
    storeNameAlert: Boolean,
    storeAddressAlert: Boolean,

    // store: Object,
  },
  components: {},
  methods: {
    /**===============================================================================
     * Lưu
     * Active : Click button "Lưu"
     * Result : Save a shop (Add new or Edit) and close form, reset form mode to "add"
     * CreatedBy : Tuanhd(14/4/2021)
     =================================================================================*/
    async btnSaveOnClick() {
      if (this.isAddMode) {
        const response = await axios.post(
          "https://localhost:44343/api/v1/Stores",
          this.store
        );
        console.log(response);
      } else {
        alert("Chỉnh sửa");
      }
      this.$emit("closeForm", true);
      this.$emit("isAddMode", true);
    },
    /**=============================================
     * Đóng form
     * Active : Click button X, button Cancel
     * Result : Close form, reset form mode to "add"
     * CreatedBy : Tuanhd(14/4/2021)
     ==============================================*/
    btnCancelOnClick() {
      // this.$emit("changeFormMode", "add");
      // this.formMode = "add";
      // alert(this.formMode);
      this.$emit("closeForm", true);
      this.$emit("isAddMode", true);
    },
    /**===============================================================================
     * Lưu và thêm mới
     * Active : Click button "Lưu và thêm mới"
     * Result : Save a shop (Add new or Edit) and reopen AddAndEdit form (with no data)
     * CreatedBy : Tuanhd(14/4/2021)
     =================================================================================*/
    btnSaveAndAddOnClick() {
      this.$emit("closeForm", true);
      alert("Lưu và thêm mới");
      this.$emit("isAddMode", true);
      // this.$emit("closeForm", false);
    },
    /**================================================
     * Check Mã cửa hàng
     * Active : Mouse click outside the StoreCode input
     * Result : The border become red
     * CreatedBy : Tuanhd(14/4/2021)
     =================================================*/
    blurStoreCode() {
      if (this.store.StoreCode.value() == null) {
        // alert(this.store.StoreCode);
        console.log(this.store.StoreCode);
        this.storeCodeAlert = true;
      } else this.storeCodeAlert = false;
    },
    /**================================================
     * Check Tên cửa hàng
     * Active : Mouse click outside the StoreName input
     * Result : The border become red
     * CreatedBy : Tuanhd(14/4/2021)
     ==================================================*/
    blurStoreName() {
      // this.showSmallMessage();
      if (!this.store.StoreName) {
        // alert(this.errorNameEmpty);
        this.storeNameAlert = true;
      } else this.storeNameAlert = false;
    },
    /**===================================================
     * Check Địa chỉ cửa hàng
     * Active : Mouse click outside the StoreAddress input
     * Result : The border become red
     * CreatedBy : Tuanhd(14/4/2021)
     =====================================================*/
    blurStoreAddress() {
      // this.showSmallMessage();
      if (!this.store.StoreAddress) {
        this.storeAddressAlert = true;
      } else this.storeAddressAlert = false;
    },
  },
  mounted() {
    
  },
  data() {
    return {
       store: {},
    };
  },
};
</script>
<style scoped>
.isHide {
  display: none;
}
.isBlurAlert {
  border-color: red !important;
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
/* =========================================== */
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