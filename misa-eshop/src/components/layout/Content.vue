<template>
  <div class="content">
    <!-- <h1>This is h1 tag form content</h1> -->
    <StoreList/>
    <!-- <AddAndEdit/> -->
    <!-- <DeleteAlert/> -->
  </div>
</template>

<script>
import StoreList from '../view/StoreList.vue'
// import AddAndEdit from '../form/AddAndEdit.vue'
// import DeleteAlert from '../form/DeleteAlert.vue'
export default {
  // name: 'Content',
  components :{
    StoreList,
    // AddAndEdit,
    // DeleteAlert,
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