<template>
   <div>This is customer page</div>
</template>

<script>
export default {
  name: 'Customer',
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
