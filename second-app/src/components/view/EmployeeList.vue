<template>
  <div class="content-body">
    <div class="header-content">
      <div class="title">Danh sách nhân viên</div>
      <div class="content-feature">
        <button
          id="btnAdd"
          class="btn-with-icon"
          v-on:click="btnAddOnClick"
        >
          <div class="icon-add"></div>
          <div class="text-btn">Thêm nhân viên</div>
        </button>
      </div>
    </div>
    <div class="filter-bar">
      <div class="filter-left">
        <input
          id="txtSearchEmployee"
          class="icon-search input-search"
          type="text"
          placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
        />
        <select
          id="cbxDepartment"
          fieldName="CustomerGroupName"
          fieldValue="CustomerGroupId"
          api="/api/customergroups"
          class="m-control"
        >
          <option value="19165ed7-212e-21c4-0428-030d4265475f">
            Tất cả phòng ban
          </option>
          <option value="19165ed7-212e-21c4-0428-030d4265475f">
            Văn phòng Tổng công ty
          </option>
          <option value="7a0b757e-41eb-4df6-c6f8-494a84b910f4">
            Phong đào tạo công nghệ
          </option>
          <option value="3631011e-4559-4ad8-b0ad-cb989f2177da">
            Phòng Nhân sự
          </option>
        </select>
        <select
          id="cbxPosition"
          fieldName="CustomerGroupName"
          fieldValue="CustomerGroupId"
          api="/api/customergroups"
          class="m-control"
        >
          <option value="19165ed7-212e-21c4-0428-030d4265475f">
            Tất cả vị trí
          </option>
          <option value="19165ed7-212e-21c4-0428-030d4265475f">Giám đốc</option>
          <option value="7a0b757e-41eb-4df6-c6f8-494a84b910f4">
            Trưởng phòng
          </option>
          <option value="3631011e-4559-4ad8-b0ad-cb989f2177da">
            Nhân viên
          </option>
        </select>
      </div>
      <div class="filter-right">
        <button id="btnRefresh" class="icon-refresh btn-only-icon btn-seconds"></button>
      </div>
    </div>
<!-- =================================================== -->
    <div class="data-table">
      <table id="tbl-customer">
          <thead>
              <tr>
                  <th>Mã khách hàng</th>
                  <th>Tên khách hàng</th>
                  <th>Giới tính</th>
                  <th>Địa chỉ</th>
                  <th>Ngày sinh</th>
                  <th>Email</th>
                  <th>SĐT</th>
                  <th>Nhóm khách hàng</th>
                  <th>Tên công ty</th>
                  <th>Tình trạng theo dõi</th>
              </tr>
          </thead>
          <tbody id="body-data">
              
          </tbody>
      </table>
    </div>
<!-- ============================================= -->
    <div class="paging-bar">
            <div class="paging-record-infor">
                Hiển thị <b>1-10/1000</b> nhân viên
            </div>
            <div class="paging-option">
                <div class="paging-back">
                    <button class="paging-back-all btn-circle"></button>
                    <button class="paging-back-one btn-circle"></button>
                </div>
                <div class="paging-number">
                    <label><input class="btn-circle" type="radio" id="bcp" name="page" value="1" checked><span>1</span></label>
                    <label><input class="btn-circle" type="radio" id="bcp" name="page" value="2"><span>2</span></label>
                    <label><input class="btn-circle" type="radio" id="bcp" name="page" value="3"><span>3</span></label>
                    <label><input class="btn-circle" type="radio" id="bcp" name="page" value="4"><span>4</span></label>
                </div>
                <div class="paging-next">
                    <button class="paging-next-one btn-circle"></button>
                    <button class="paging-next-all btn-circle"></button>
                </div>
            </div>
            <div class="pagin-record-option">
                <b>10</b> nhân viên/trang
            </div>
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
    return {}
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

/* #txtSearchEmployee {
  min-width: 300px;
} */
</style>