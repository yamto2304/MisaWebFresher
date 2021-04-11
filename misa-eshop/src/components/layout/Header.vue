<template>
  <div class="header">
    <div class="header-box-name">
      <div class="header-name"><b>Cửa hàng</b></div>
    </div>
    <div class="header-center-box">
      <div class="btn-store-info">
        <select>
          <option>Chuỗi cửa hàng</option>
          <option>-- Kho tổng</option>
          <option>-- misard</option>
        </select>
      </div>

      <a class="btn-user-setting">
        <select class="user-setting"
          name="user-setting"
          id="user-setting"
          placeholder="Hoàng Đình Tuấn"
        >
          <!-- <option value="0">Hoàng Đình Tuấn</option> -->
          <option value="1">Thay đổi mật khẩu</option>
          <option value="2">Góp ý với nhà phát triển</option>
          <option value="3">Đăng xuất</option>
        </select>
      </a>
    </div>
    <button class="btn-misa-support icon-misa-support" title="Tổng đài hỗ trợ MISA support"> </button>
    <a class="btn-notify icon-notify-18" title="Thông báo"> </a>
    <a class="btn-help icon-help-18" title="Trợ giúp"> </a>
  </div>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      author: "Mel",
    };
  },
  props: {
    msg: String,
  },
};
</script>
<style scoped>
</style>