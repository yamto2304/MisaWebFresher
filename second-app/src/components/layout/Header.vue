<template>
  <div class="header">
    <div class="department-info">
      <select class="select-restaurant">
        <option>Nhà hàng Biển Đông</option>
        <option>Nhà hàng Hải Dương</option>
        <option>Nhà hàng Đội Cấn</option>
        <option>Nhà hàng Cầu Giấy</option>
      </select>
    </div>
    <div class="account-info">
        <div class="account-avatar"></div>
        <div class="account-name">Hoàng Đình Tuấn</div>
        <div class="account-option icon-option-default-16"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Header',
  data() {
    return {
      author : "Mel"
    }
  },
  props: {
    msg: String
  }
}
</script>
<style scoped>

</style>