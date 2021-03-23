<template>
  <div class="hello">
    <h1>{{ msg = "This is content" }}</h1>
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