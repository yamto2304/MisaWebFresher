<template>
  <div class="store-list-content">
    <div class="header-content">
      <AddAndEdit
        :isHide="isHideParent"
        @closeForm="closeForm"
        :isAddMode="isParentAddMode"
        :store="selectedStore"
      />
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
      <button
        class="btn-with-icon"
        title="Ctrl + E"
        v-on:click="btnEditOnClick()"
      >
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
              @click="activeRow(store.storeId)"
              :class="store.storeId === selectedRow ? 'row-actived' : ''"
            >
              <td>
                <div class="cell">{{ store.storeCode }}</div>
              </td>
              <td>
                <div class="cell">{{ store.storeName }}</div>
              </td>
              <td>
                <div class="cell">{{ store.address }}</div>
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
          <select class="select-number-records">
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
import AddAndEdit from "../form/AddAndEdit";
import * as axios from "axios";
export default {
  name: "Store",
  props: {
    store: Object,
  },
  components: {
    AddAndEdit,
  },
  methods: {
    /**=======================================
     * Thêm mới store
     * Active : Click button Add
     * Result : Open Form to Add store
     * CreatedBy : Tuanhd(14/4/2021)
     =========================================*/
    btnAddOnClick() {
      //Hiện form thêm mới
      this.isHideParent = false;
      //Cài đặt mode của form là Add
      this.isParentAddMode = true;
      //Truyền xuống Object rỗng để làm trống form
      this.selectedStore = {};
    },

    /**================================
     * Chỉnh sửa store
     * Active : Click button Edit
     * Result : Open form (added data)
     * CreatedBy : Tuanhd(14/4/2021)
     ================================*/
    btnEditOnClick() {
      //Id của bản ghi được chọn lưu tại biến selectedRow
      if (this.selectedRow == null) {
        alert("Chưa chọn bản ghi để sửa");
        return;
      } else {
        //Gọi Api lấy dữ liệu từ Id đã lấy
        axios
          .get("https://localhost:44343/api/v1/Stores/" + this.selectedRow)
          .then((res) => {
            //Đẩy data thu được vào biến selectedStore và truyền xuống con
            this.selectedStore = res.data;
            console.log(res);
          })
          .catch((res) => {
            console.log(res);
          });
      }
      //Update form mode to "Edit"
      this.isParentAddMode = false;
      //Hiện form Sửa
      this.isHideParent = false;
    },

    /**====================================================================
     * Đóng form
     * Active : Recive data from child
     * <param name="value">Form có ẩn hay không ?</param>
     * Result(value = true) : Close that child and show StoreList component
     * Result(value = false): Still open form
     * CreatedBy : Tuanhd(14/4/2021)
     =====================================================================*/
    closeForm(value) {
      this.isHideParent = value;
    },

    /**==================================================
     * Chuyển form mode về Add
     * Active : Recive data from child
     * <param name="value">Form thêm hay sửa ?</param>
     * Result(value = true) : This form will add a store
     * Result(value = false): This form will edit a store
     * CreatedBy : Tuanhd(14/4/2021)
     ===================================================*/
    isAddMode(value) {
      this.isAddMode = value;
    },

    /**=====================================================
     * Chọn dòng được click
     * Active : Click a row in data table
     * <param name="key">Id của dòng được chọn</param>
     * Result : Save Id of selected row to selectecRow param
     * CreatedBy : Tuanhd(14/4/2021)
     ======================================================*/
    activeRow(key) {
      this.selectedRow = key;
    },
  },

  data() {
    return {
      //Form có ở mode Add không ?
      isParentAddMode: true,
      //Dòng được chọn
      selectedRow: null,
      //Object store được chọn
      selectedStore: [],
      //Ẩn form
      isHideParent: true,
      stores: [],
    };
  },
  /**=============================
   * Lấy dữ liệu khi load trang 
   * CreatedBy : Tuanhd(14/4/2021)
   ==============================*/
  async created() {
    //Lấy dữ liệu từ API
    const response = await axios.get(`https://localhost:44343/api/v1/Stores`);

    console.log(response.data[0]);
    //Lưu dữ liệu vào biến stores để chạy v-for show dữ liệu lên bảng
    this.stores = response.data;
  },
};
</script>
<style scoped>
.row-actived {
  background-color: #e2e4f1;
}
.row-actived:hover {
  background-color: #e2e4f1;
}
</style>
