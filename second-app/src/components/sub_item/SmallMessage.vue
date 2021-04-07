<template>
  <div class="small-mess" id="small-mess" :class="{ isHide: isHide }">Halooo</div>
</template>
<script>
export default {
  props: {
    isHide: Boolean,
    coordinateX : Number,
    coordinateY : Number,
  },
  mounted(){

  },
  methods:{
      setPosition(x,y){
        //   let message = document.querySelector('#small-mess');
          this.coordinateX = x;
          this.coordinateY = y;
          
      }
  }
};
</script>
<style scoped>
.small-mess {
  border: 1px solid black;
  position: fixed;
  /* top: 30px;
    left: 30px; */
}
</style>