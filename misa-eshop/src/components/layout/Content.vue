<template>
  <div class="content">
    <!-- <h1>This is h1 tag form content</h1> -->
    <!-- <AddForm/> -->
    <StoreList/>
  </div>
</template>

<script>
// import AddForm from '../form/AddForm'
import StoreList from '../view/StoreList.vue'
export default {
  // name: 'Content',
  components :{
    // AddForm
    StoreList,
  },
  data() {
    return {
    }
  },
  props: {
  }
}
</script>
<style scoped>

</style>