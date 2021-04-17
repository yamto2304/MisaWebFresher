<template>
  <div class="header">
    <div v-show="isShowAcount" class="setting" @click="ShowAcount"></div>
    <div class="header-box-name">
      <div class="header-name"><b>Cửa hàng</b></div>
    </div>
    <div class="header-center-box">
      <div class="btn-store-info">
        <select class="store-infor">
          <option>Chuỗi cửa hàng</option>
          <option>Kho tổng</option>
          <option>misard</option>
        </select>
      </div>

      <div class="btn-user-setting" @click="ShowAcount">
        <div class="user-info">
          <div class="icon-avatar"></div>
          <div class="user-name"><b>Hoàng Đình Tuấn</b></div>
          <div class="right-side-icon"></div>
        </div>
        <div class="menu" v-show="isShowAcount">
          <div @click="ShowAcount" class="option-menu">
            <img
              class="icon"
              src="../../assets/icon/icon-change-password16.png"
            />
            <span class="title-option">Thay đổi mật khẩu</span>
          </div>
          <div @click="ShowAcount" class="option-menu">
            <img class="icon" src="../../assets/icon/icon-feedback.png" />
            <span class="title-option">Góp ý với nhà phát triển</span>
          </div>
          <div @click="ShowAcount" class="option-menu">
            <img class="icon" src="../../assets/icon/icon-logout16.png" />
            <span class="title-option">Đăng xuất</span>
          </div>
        </div>

        <!-- <select class="user-setting"
          name="user-setting"
          id="user-setting"
          placeholder="Hoàng Đình Tuấn"
        >
          <option value="1">Thay đổi mật khẩu</option>
          <option value="2">Góp ý với nhà phát triển</option>
          <option value="3">Đăng xuất</option>
        </select> -->
      </div>
    </div>
    <button
      class="btn-misa-support icon-misa-support"
      title="Tổng đài hỗ trợ MISA support"
    ></button>
    <a class="btn-notify icon-notify-18" title="Thông báo"> </a>
    <a class="btn-help icon-help-18" title="Trợ giúp"> </a>
  </div>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      isShowAcount: false,
      author: "Mel",
    };
  },
  methods: {
    ShowAcount() {
      this.isShowAcount = !this.isShowAcount;
    },
  },
  props: {
    msg: String,
  },
};
</script>
<style scoped>
</style>