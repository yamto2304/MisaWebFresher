<template>
  <div class="navbar">
    <div class="logo-box">
      <div class="eshop-logo"></div>
    </div>
    <div class="navbar-content">
      <div class="center-content-menu">
        <a class="nav-item">
          <div class="nav-item-icon icon-overview"></div>
          <div class="nav-item-text">Tổng quan</div>
        </a>
        <a class="nav-item">
          <span class="nav-item-icon icon-report"></span>
          <span class="nav-item-text">Báo cáo</span>
        </a>
        <a class="nav-item">
          <div class="nav-item-icon icon-order"></div>
          <div class="nav-item-text">Đơn hàng</div>
        </a>
        <a class="nav-item">
          <div class="nav-item-icon icon-purchase"></div>
          <div class="nav-item-text">Mua hàng</div>
        </a>
        <a class="nav-item">
          <div class="nav-item-icon icon-promotion"></div>
          <div class="nav-item-text">Khuyến mại</div>
        </a>
        <a class="nav-item active-item">
          <div class="nav-item-icon icon-store-manager"></div>
          <div class="nav-item-text">Quản lý cửa hàng</div>
        </a>
      </div>

      <div class="bottom-content-menu">
        <a class="nav-item special-item">
          <div class="nav-item-icon icon-goods"></div>
          <div class="nav-item-text">Hàng hóa</div>
        </a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      name: "my Navbar",
    };
  },
};
</script>

<style scoped>
</style>