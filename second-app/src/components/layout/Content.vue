<template>
  <div class="content">
    <!-- <h1>This is h1 tag form content</h1> -->
    <!-- <router-view></router-view> -->
    <AddForm />

  </div>
</template>

<script>
import AddForm from '../form/AddForm'
export default {
  name: 'Content',
  components :{
    AddForm
  },
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