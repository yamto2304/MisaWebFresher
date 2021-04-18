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
          Bạn có chắc chắn muốn xóa <b>{{ storeName }}</b> khỏi danh sách cửa
          hàng ?
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
        .delete("https://localhost:44314/api/v1/Store/" + this.storeId)
        .then((res) => {
          //Đẩy data thu được vào biến selectedStore và truyền xuống con
          // this.selectedStore = res.data;
          console.log(res.data.devMsg);
          //Đóng alert
          this.$emit("closeAlert", true);
          //Load dữ liệu
          this.$emit('loadData');
        })
        .catch((res) => {
          // Có thể mở form mới hoặc thông báo khác
          console.log(res.data);
        });
    },
  },
  data() {},
  $emit: ['loadData'],
};
</script>
<style scoped>
</style>