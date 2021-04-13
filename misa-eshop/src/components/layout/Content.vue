<template>
  <div class="content">
    <!-- <h1>This is h1 tag form content</h1> -->
    <StoreList/>
    <!-- <AddAndEdit/> -->
  </div>
</template>

<script>
import StoreList from '../view/StoreList.vue'
// import AddAndEdit from '../form/AddAndEdit.vue'
export default {
  // name: 'Content',
  components :{
    StoreList,
    // AddAndEdit,
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