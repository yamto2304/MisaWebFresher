<template>
  <div>
    <AddForm :isHide="isHideParent" @closeForm="closeForm" />
    <SmallOption
      :isHide="isHideOption"
      id="small-option"
      v-bind:style="{ left: coordinateX, top: coordinateY }"
    />
    <div class="content-body"
    v-on:click="closeOption"
    >
      <div class="header-content">
        <div class="title">Danh sách khách hàng</div>
        <div class="content-feature">
          <button
            class="btn-with-icon"
            id="buttonAddCustomer"
            v-on:click="btnAddOnClick"
          >
            <div class="icon-add"></div>
            <div class="text-btn">Thêm khách hàng</div>
          </button>
        </div>
      </div>
      <div class="filter-bar">
        <div class="filter-left">
          <input
            class="icon-search input-search input-box"
            type="text"
            placeholder="Tìm kiếm theo mã, Tên hoặc Số điện thoại"
          />
          <select
            id="cbxDepartment"
            fieldName="CustomerGroupName"
            fieldValue="CustomerGroupId"
            api="/api/customergroups"
            class="m-control"
          >
            <option>Tất cả phòng ban</option>
            <option>Văn phòng Tổng công ty</option>
            <option>Phong đào tạo công nghệ</option>
            <option>Phòng Nhân sự</option>
          </select>
          <select
            id="cbxPosition"
            fieldName="CustomerGroupName"
            fieldValue="CustomerGroupId"
            api="/api/customergroups"
            class="m-control"
          >
            <option>Tất cả vị trí</option>
            <option>Giám đốc</option>
            <option>Trưởng phòng</option>
            <option>Nhân viên</option>
          </select>
        </div>
        <div class="filter-right">
          <button
            class="btn-only-icon btn-refresh"
            id="refresh"
            v-on:click="btnRefreshOnClick"
          >
            <div class="icon-refresh"></div>
          </button>
        </div>
      </div>
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
            <tr
              class="el-table__row"
              v-for="(customer, key) in customers"
              :key="customer.CustomerId"
              @click="activeRow(key)"
              @dblclick="showSmallOption($event)"
              :class="key === selectedRow ? 'row-actived' : ''"
            >
              <td>
                <div class="cell">{{ customer.CustomerCode }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.FullName }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.Gender }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.Address }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.DateOfBirth }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.Email }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.PhoneNumber }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.CustomerGroupName }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.CompanyName }}</div>
              </td>
              <td>
                <div class="cell">{{ customer.WorkStatusName }}</div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
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
            <label
              ><input
                class="btn-circle"
                type="radio"
                id="bcp"
                name="page"
                value="1"
                checked
              /><span>1</span></label
            >
            <label
              ><input
                class="btn-circle"
                type="radio"
                id="bcp"
                name="page"
                value="2"
              /><span>2</span></label
            >
            <label
              ><input
                class="btn-circle"
                type="radio"
                id="bcp"
                name="page"
                value="3"
              /><span>3</span></label
            >
            <label
              ><input
                class="btn-circle"
                type="radio"
                id="bcp"
                name="page"
                value="4"
              /><span>4</span></label
            >
          </div>
          <div class="paging-next">
            <button class="paging-next-one btn-circle"></button>
            <button class="paging-next-all btn-circle"></button>
          </div>
        </div>
        <div class="pagin-record-option"><b>10</b> nhân viên/trang</div>
      </div>
    </div>
  </div>
</template>
<script>
import AddForm from "../form/AddForm";
import SmallOption from "../sub_item/SmallOption";
export default {
  name: "Customer",
  // props: ['isHideParent'],
  components: {
    AddForm,
    SmallOption,
  },
  methods: {
    //Mở form thêm khách hàng
    btnAddOnClick() {
      this.isHideParent = false;
      // alert("btnAddCustomerOnClick");
    },
    //Refresh
    refresh() {
      // loadData();
      window.location.reload();
    },
    //CloseForm
    closeForm(value) {
      this.isHideParent = value;
    },
    //Bôi đậm hàng được click
    activeRow(key) {
      this.selectedRow = key;
      // alert(customer.CustomerId)
    },
    //Hiện Option sửa, xóa tại vị trí click
    showSmallOption(event) {
      this.coordinateX = event.clientX + "px";
      this.coordinateY = event.clientY - 20 + "px";
      this.isHideOption = false;
      // this.$emit("isHideOption", false);
    },
    //Click refresh
    btnRefreshOnClick() {
      // alert("refresh!");
      this.isHideOption = !this.isHideOption;
    },
    //Đóng form - click X hoặc "hủy"
    closeOption(){
      this.isHideOption = true;
    }
  },
  // mounted(){
  //   showSmallOption($event)
  // },
  data() {
    return {
      author: "Mel",
      isHideOption: true,
      selectedRow: null,
      isHideParent: true,
      coordinateX: null,
      coordinateY: null,
      customers: [
        {
          CustomerId: "one",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "two",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "three",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "four",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "five",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "six",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "seven",
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          CustomerId: "eight",
          FullName: "Nguyễn Văn Mạnh",
        },
        // {
        //   CustomerId: 90,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
        // {
        //   CustomerId: 100,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
        // {
        //   CustomerId: 110,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
        // {
        //   CustomerId: 120,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
        // {
        //   CustomerId: 130,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
        // {
        //   CustomerId: 140,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
        // {
        //   CustomerId: 15,
        //   FullName: "Nguyễn Văn Mạnh",
        // },
      ],
    };
  },
};
</script>
<style scoped>
.input-search {
  padding-left: 40px;
  width: 300px;
}
.row-actived {
  background-color: #01b075;
}
.row-actived:hover {
  background-color: #01b075;
}
</style>
