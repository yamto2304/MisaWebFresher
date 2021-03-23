<template>
  <div class="content">
    <div class="header-content">
      <div class="title">Danh sách nhân viên</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Employees",
  components: {
    // Details,
  },
  methods: {
    btnAddOnClick() {
      // this.isHideParent = false;
      alert("btnAddOnClick")
    },
    rowOnClick(employee){
      alert(employee.FullName);
    },
    closePopup(value) {
      this.isHideParent = value;
    }
  },
  data() {
  },
  async created() {

    // const response = await axios.get("http://api.manhnv.net/api/employees");

    // console.log(response.data[0]);

    // this.employees = response.data;
  },

  
};
</script>
<style scoped>
  .grid-employee {
  margin-top: 10px;
  height: calc(100vh - 234px);
}

.el-avatar-employee {
  padding-top: 16px;
  padding-right: 16px;
}

.el-left {
  width: calc(100% - 180px);
}

.el-avatar-employee .el-avatar {
  border: 1px solid #ccc;
  width: 160px;
  height: 160px;
  margin: 0 auto;
  border-radius: 50%;
  cursor: pointer;
  /* background-image: url("/assets/img/default-avatar.jpg"); */
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}

.el-avatar-note {
  font-size: 12px;
}
.filter-left {
  display: flex;
}
.filter-left select {
  margin-left: 10px;
  margin-right: 10px;
}

.currency-for-input {
  position: absolute;
  right: 40px;
  line-height: 40px;
  font-style: italic;
}

#txtSearchEmployee {
  min-width: 300px;
}
</style>