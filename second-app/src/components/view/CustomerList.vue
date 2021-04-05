<template>
  <div class="content-body">
    <AddForm :isHide="isHideParent" @closeForm="closeForm"/>
    <div class="header-content">
      <div class="title" >Danh sách khách hàng</div>
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
        <input class="icon-search input-search" 
        type="text" 
        placeholder="Tìm kiếm theo mã, Tên hoặc Số điện thoại">
        <select
          id="cbxDepartment"
          fieldName="CustomerGroupName"
          fieldValue="CustomerGroupId"
          api="/api/customergroups"
          class="m-control"
        >
          <option >
            Tất cả phòng ban
          </option>
          <option >
            Văn phòng Tổng công ty
          </option>
          <option >
            Phong đào tạo công nghệ
          </option>
          <option>
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
          <option>
            Tất cả vị trí
          </option>
          <option>Giám đốc</option>
          <option>
            Trưởng phòng
          </option>
          <option>
            Nhân viên
          </option>
        </select>
      </div>
      <div class="filter-right">
        <button class="btn-only-icon btn-refresh" id="refresh">
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
    <!-- <AddForm @closePopup="false" :isHide="false"/> -->
  </div>
</template>
<script>
import AddForm from '../form/AddForm'
export default {
  name: 'Customer',
  // props: ['isHideParent'],
  components :{
    AddForm
  },
  methods: {
    btnAddOnClick() {
      this.isHideParent = false;
      // alert("btnAddCustomerOnClick")
    },
    //Refresh
    refresh(){
        // loadData();
        window.location.reload();
    },
    //ClosePopup
    closeForm(value){
      this.isHideParent = value;
    }
  },
  data() {
    return {
      author : "Mel",
      isHideParent : true
    }
  },
}
</script>
<style scoped>
.input-search {
    padding-left: 40px;
    width: 300px;
}
</style>
