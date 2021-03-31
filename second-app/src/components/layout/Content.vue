<template>
  <div class="content">
    <!-- <h1>This is h1 tag form content</h1> -->
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'Content',
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