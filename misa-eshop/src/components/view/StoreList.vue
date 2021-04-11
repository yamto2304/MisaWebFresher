<template>
  <div class="store-list-content">
    <div class="header-content">
      <button class="btn-with-icon" title="Ctrl + 1">
        <div class="icon-add"></div>
        <div class="text-btn">Thêm mới</div>
      </button>
      <button class="btn-with-icon" title="Ctrl + 2">
        <div class="icon-duplicate"></div>
        <div class="text-btn">Nhân bản</div>
      </button>
      <button class="btn-with-icon" title="Ctrl + E">
        <div class="icon-edit"></div>
        <div class="text-btn">Sửa</div>
      </button>
      <button class="btn-with-icon" title="Ctrl + D">
        <div class="icon-delete"></div>
        <div class="text-btn">Xóa</div>
      </button>
      <button class="btn-with-icon btn-end" title="Ctrl + Y">
        <div class="icon-reload"></div>
        <div class="text-btn">Nạp</div>
      </button>
    </div>
    <div class="data-content"></div>
    <div class="paging-bar">
      <!-- <div class="paging-option">
        <div class="btn-paging paging-return"></div>
        <div class="btn-paging paging-back"></div>
        <div class="paging-text"><p>Trang</p></div>
        <div class="btn-paging paging-next"></div>
        <div class="btn-paging paging-end"></div>
        <div class="btn-paging paging-refresh"></div>
      </div>
      <div class="paging-record-infor paging-text">Hiển thị 1 - 10 trên 30 kết quả</div> -->
    </div>
  </div>
</template>
<script>
export default {
  name: "Customer",
  // props: ['isHideParent'],
  components: {},
  methods: {},

  data() {
    return {};
  },
  async created() {},
};
</script>
<style scoped>
</style>
