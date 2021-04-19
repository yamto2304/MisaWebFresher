<template>
  <div class="load">
    <Loading
      class="loading"
      :active.sync="showLoading"
      :loader="loader"
      :color="color"
      :height="height"
      :width="width"
      :opacity="opacity"
      :background-color="backgroundColor"
      :blur="blur"
      :is-full-page="fullPage"
    >
    </Loading>
  </div>
</template>

<script>
// Import component
import Loading from "vue-loading-overlay";
// Import stylesheet
import "vue-loading-overlay/dist/vue-loading";

export default {
  name: "BaseLoading",

  components: {
    Loading,
  },
  props: ["showLoading"],
  methods: {},
  data() {
    return {
      isLoading: false,
      color: "#019160",
      loader: "dots",
      width: 50,
      height: 100,
      backgroundColor: "#f0f0f0",
      fullPage: false,
      opacity: 0.5,
      isHideParent: true,
      blur: "15px",
    };
  },
};
</script> 
<style scoped>
.load {
  width: 100px;
  height: 100px;
  position: fixed;
  z-index: 10000000;
  left: 50%;
  top: 30%;
  text-align: -webkit-center;
  background-color: transparent;
}
.loading {
  color: #019160;
  height: 100%;
  width: 100%;
  opacity: 0.5;
  background-color: #fff;
}
</style>