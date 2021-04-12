<template>
  <div class="store-list-content">
    <div class="header-content">
    <!-- <AddAndEdit /> -->
      <button 
        class="btn-with-icon" 
        title="Ctrl + 1" 
        v-on:click="btnAddOnClick()"
      >
        <div class="icon-add"></div>
        <div class="text-btn">Thêm mới</div>
      </button>
      <button class="btn-with-icon" title="Ctrl + 2">
        <div class="icon-duplicate"></div>
        <div class="text-btn">Nhân bản</div>
      </button>
      <button class="btn-with-icon" title="Ctrl + E">
        <div class="icon-edit"></div>
        <div class="text-btn">Sửa</div>
      </button>
      <button class="btn-with-icon" title="Ctrl + D">
        <div class="icon-delete"></div>
        <div class="text-btn">Xóa</div>
      </button>
      <button class="btn-with-icon btn-end" title="Ctrl + Y">
        <div class="icon-reload"></div>
        <div class="text-btn">Nạp</div>
      </button>
    </div>
    <!-- Data table =============== -->
    <div class="data-content">
      <div class="grid data-table">
        <table>
          <thead>
            <tr>
              <th class="store-code">
                <div class="th-name">Mã cửa hàng</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" />
                </div>
              </th>
              <th class="store-name">
                <div class="th-name">Tên cửa hàng</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" />
                </div>
              </th>
              <th class="store-address">
                <div class="th-name">Địa chỉ</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" />
                </div>
              </th>
              <th class="store-phone">
                <div class="th-name">Số điện thoại</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" />
                </div>
              </th>
              <th class="store-status">
                <div class="th-name">Trạng thái</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" />
                </div>
              </th>
            </tr>
          </thead>
          <tbody>
            <tr
              class="el-table__row"
              v-for="store in stores"
              :key="store.storeId"
              @click="activeRow(key)"
              :class="key === selectedRow ? 'row-actived' : ''"
            >
              <td>
                <div class="cell">{{ store.storeCode }}</div>
              </td>
              <td>
                <div class="cell">{{ store.storeName }}</div>
              </td>
              <td>
                <div class="cell">{{ store.storeAddress }}</div>
              </td>
              <td>
                <div class="cell">{{ store.phoneNumber }}</div>
              </td>
              <td>
                <div class="cell">{{ store.status }}</div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <!-- ========================== -->
    <div class="paging-bar">
      <div class="paging-content">
        <div class="paging-option">
          <div class="btn-paging icon-return"></div>
          <div class="btn-paging icon-back"></div>
          <div class="paging-text">Trang</div>
          <input class="input-paging" value="1" />
          <div class="paging-text">trên 3</div>
          <div class="btn-paging icon-next"></div>
          <div class="btn-paging icon-end"></div>
          <div class="btn-paging icon-refresh"></div>
          <select class="select-number-records icon-arrow-down">
            <option>15</option>
            <option>25</option>
            <option>50</option>
            <option>100</option>
          </select>
        </div>
        <div class="paging-record-infor paging-text">
          Hiển thị 1 - 10 trên 30 kết quả
        </div>
      </div>
    </div>
  </div>
</template>
<script>
// import AddAndEdit from "../form/AddAndEdit";
export default {
  name: "Store",
  // props: ['isHideParent'],
  components: {
    // AddAndEdit,
  },
  methods: {
    //Mở form thêm khách hàng
    btnAddOnClick() {
      alert("click !");
      this.isHideParent = false;
      // alert("btnAddCustomerOnClick");
    },
  },

  data() {
    return {
      isHideOption: true,
      stores: [
        {
          storeCode: 1,
          storeName: "Store 1",
          storeAddress: "Address 1",
          phoneNumber: 1,
          status: 1,
        },
        {
          storeCode: 2,
          storeName: "Store 2",
          storeAddress: "Address 2",
          phoneNumber: 2,
          status: 2,
        },
        {
          storeCode: 3,
          storeName: "Store 3",
          storeAddress: "Address 3",
          phoneNumber: 3,
          status: 3,
        },
        {
          storeCode: 4,
          storeName: "Store 4",
          storeAddress: "Address 4",
          phoneNumber: 4,
          status: 4,
        },
      ],
    };
  },
  async created() {},
};
</script>
<style scoped>
</style>
