<template>
  <div class="delete-dialog" :class="{ isHideAlert: isHideAlert }">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="form-header">
        <div class="heading"><b>Xóa dữ liệu</b></div>
        <div class="btn-close-form">
          <button class="btn-x" v-on:click="btnCancelOnClick">X</button>
        </div>
      </div>
      <div class="form-content">
        <div class="icon-popup-question"></div>
        <div class="text-content">
          Bạn có chắc chắn muốn xóa <b>{{ storeName }}</b> khỏi danh sách
          cửa hàng ?
        </div>
      </div>
      <div class="form-footer">
        <button class="btn-with-icon btn-delete-footer">
          <div class="icon-delete icon-footer"></div>
          <div class="text-btn text-footer" v-on:click="btnDeleteOnClick">
            Xoá
          </div>
        </button>
        <button class="btn-with-icon btn-cancel-footer">
          <div class="icon-cancel-blue icon-footer"></div>
          <div
            class="text-btn text-footer"
            style="color: #2b3173"
            v-on:click="btnCancelOnClick"
          >
            Huỷ bỏ
          </div>
        </button>
      </div>
    </div>
  </div>
</template>
<script>
import * as axios from "axios";
export default {
  props: {
    isHideAlert: Boolean,
    storeName: String,
    storeId: String,
  },
  components: {},
  methods: {
    /**=============================================
     * Đóng form
     * Active : Click button X, button Cancel
     * Result : Close form, reset form mode to "add"
     * CreatedBy : Tuanhd(16/4/2021)
     ==============================================*/
    btnCancelOnClick() {
      // this.$emit("changeFormMode", "add");
      // this.formMode = "add";
      // alert(this.formMode);
      this.$emit("closeAlert", true);
    },

    /**=============================
     * Confirm xóa dữ liệu
     * Active : Click button "Xóa"
     * Result : Detele that store
     * CreatedBy : Tuanhd(16/4/2021)
     ==============================*/
    btnDeleteOnClick() {
      //Gọi Api xoá dữ liệu
      console.log(this.storeId);
      axios
        .delete("https://localhost:44314/api/v1/Stores/" + this.storeId)
        .then((res) => {
          //Đẩy data thu được vào biến selectedStore và truyền xuống con
          // this.selectedStore = res.data;
          console.log(res);
          //Đóng alert
          this.$emit("closeAlert", true);
          //Load dữ liệu
        })
        .catch((res) => {
          //Có thể mở form mới hoặc thông báo khác
          console.log(res);
        });
    },
  },
  data() {},
};
</script>
<style scoped>
.isHideAlert {
  display: none;
}
.delete-dialog {
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
  left: calc(50% - 200px);
  top: calc(50% - 78px);
  width: 400px;
  height: 156px;
  border-radius: 4px;
  background-color: #fff;
  border: 2px solid #dfdfdf;
  z-index: 1000;
}
.btn-x {
  border: none;
  cursor: pointer;
  outline: none;
}
/* ========================================= */
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
/* ======================================== */
.form-content {
  /* background-color: #dfdfdf; */
  background-color: #ffffff;
  position: relative;
  top: 0;
  width: 378px;
  height: 44px;
  padding: 10px;
  border: 1px solid #e4e4e4;
  display: flex;
}
/* ======================================== */
.form-footer {
  background-color: #ffffff;
  display: flex;
  position: relative;
  bottom: 0;
  width: 100%;
  height: 49px;
  /* padding: 10px; */
  outline: none;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px;
  align-items: center;
  border-top: 1px solid #e4e4e4;
}
.btn-delete-footer {
  position: absolute;
  left: 232px;
  background-color: red;
  border-radius: 3px;
  height: 32px;
  width: 75px;
  padding: 7px;
  outline: none;
}
.btn-cancel-footer {
  position: absolute;
  right: 8px;
  background-color: #ffffff;
  border-radius: 3px;
  height: 32px;
  width: 75px;
  padding: 7px;
  outline: none;
}
.icon-footer {
  position: relative;
  left: -24px;
  top: -2px;
}
.text-footer {
  position: absolute;
  left: 20px;
}
</style>