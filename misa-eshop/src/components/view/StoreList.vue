<template>
  <div class="store-list-content">
    <AddAndEdit
      :isHide="isHideParent"
      @closeForm="closeForm"
      :isAddMode="isParentAddMode"
      :store="selectedStore"
      :formHeading="isParentAddMode ? 'Thêm mới cửa hàng' : 'Sửa cửa hàng'"
    />
    <DeleteAlert
      :isHideAlert="isHideParentAlert"
      :storeName="selectedStore.storeName"
      :storeId="selectedStore.storeId"
      @closeAlert="closeAlert"
    />
    <div class="header-content">
      <button
        style="border-right: 1px solid #190472"
        class="btn-with-icon"
        title="Ctrl + 1"
        v-on:click="btnAddOnClick()"
      >
        <div class="icon-add"></div>
        <div class="text-btn">Thêm mới</div>
      </button>
      <button
        style="border-right: 1px solid #190472"
        class="btn-with-icon"
        title="Ctrl + 2"
      >
        <div class="icon-duplicate"></div>
        <div class="text-btn">Nhân bản</div>
      </button>
      <button
        style="border-right: 1px solid #190472"
        class="btn-with-icon"
        title="Ctrl + E"
        v-on:click="btnEditOnClick()"
        :class="isHaveRowClicked ? '' : 'disable-item'"
      >
        <div class="icon-edit"></div>
        <div class="text-btn">Sửa</div>
      </button>
      <button
        style="border-right: 1px solid #190472"
        class="btn-with-icon"
        title="Ctrl + D"
        :class="isHaveRowClicked ? '' : 'disable-item'"
        v-on:click="btnDeleteOnClick()"
      >
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
                <select class="select-filter">
                  <option>Tất cả</option>
                  <option>Đang hoạt động</option>
                  <option>Ngừng hoạt động</option>
                </select>
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
          <div
            class="btn-paging icon-return"
            :class="valueInputPaging > 1 ? '' : 'disable-item'"
          ></div>
          <div
            class="btn-paging icon-back"
            :class="valueInputPaging > 1 ? '' : 'disable-item'"
          ></div>
          <div class="paging-text">Trang</div>
          <input class="input-paging" v-model="valueInputPaging" />
          <div class="paging-text">trên {{ maxPage }}</div>
          <div
            class="btn-paging icon-next"
            :class="valueInputPaging < this.maxPage ? '' : 'disable-item'"
          ></div>
          <div
            class="btn-paging icon-end"
            :class="valueInputPaging < this.maxPage ? '' : 'disable-item'"
          ></div>
          <div class="btn-paging icon-refresh"></div>
          <select class="select-number-records select-number-page">
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
import DeleteAlert from "../form/DeleteAlert";
import * as axios from "axios";
export default {
  name: "Store",
  props: {
    // store: Object,
  },
  components: {
    AddAndEdit,
    DeleteAlert,
  },
  methods: {
    /**=======================================
     * Thêm mới store
     * Active : Click button Add
     * Result : Open Form to Add store
     * CreatedBy : Tuanhd(14/4/2021)
     * ModifiedBy : Tuanhd(16/4/2021)
     =========================================*/
    btnAddOnClick() {
      //Hiện form thêm mới
      this.isHideParent = false;
      //Cài đặt mode của form là Add
      this.isParentAddMode = true;
      //Truyền xuống Object rỗng để làm trống form
      this.selectedStore = this.emptyStore;
    },

    /**=======================================================
     * Chỉnh sửa store
     * Active : Click button Edit
     * Result : Open form (added data)
     * CreatedBy : Tuanhd(14/4/2021)
     * ModifiedBy : Tuanhd(16/4/2021)
     =========================================================*/
    btnEditOnClick() {
      //Id của bản ghi được chọn lưu tại biến selectedRow
      //Value của bản ghi được load về tại biến selectedStore

      //Update form mode to "Edit"
      this.isParentAddMode = false;
      //Hiện form Sửa
      this.isHideParent = false;
    },
    /**======================================
     * Xóa cửa hàng
     * Active : Click button Delete
     * Result : Open alert delete
     * * CreatedBy : Tuanhd(16/4/2021)
     ========================================*/
    btnDeleteOnClick() {
      //Mở delete alert
      this.isHideParentAlert = false;
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

    /**====================================================================
     * Đóng alert
     * Active : Recive data from child
     * <param name="value">Alert có ẩn hay không ?</param>
     * Result(value = true) : Close that child and show StoreList component
     * Result(value = false): Still open form
     * CreatedBy : Tuanhd(16/4/2021)
     =====================================================================*/
    closeAlert(value){
      this.isHideParentAlert = value;
    },

    /**==================================================
     * Chuyển form mode về Add
     * Active : Recive data from child
     * <param name="value">Form thêm hay sửa ?</param>
     * Result(value = true) : This form will add a store
     * Result(value = false): This form will edit a store
     * CreatedBy : Tuanhd(14/4/2021)
     * ModifiedBy : Tuanhd(16/4/2021)
     ===================================================*/
    isAddMode(value) {
      this.isAddMode = value;
    },

    /**=======================================================================
     * Chọn dòng được click, đẩy dữ liệu của dòng được click vào selectedStore
     * Active : Click a row in data table
     * <param name="key">Id của dòng được chọn</param>
     * Result : Save Id of selected row to selectecRow param
     * CreatedBy : Tuanhd(14/4/2021)
     =========================================================================*/
    activeRow(key) {
      this.selectedRow = key;
      this.isHaveRowClicked = true;
      //Gọi Api lấy dữ liệu từ Id đã lấy
      axios
        .get("https://localhost:44343/api/v1/Stores/" + this.selectedRow)
        .then((res) => {
          //Đẩy data thu được vào biến selectedStore và truyền xuống con
          this.selectedStore = res.data;
          // console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
    },
  },

  data() {
    return {
      //Số trang tối đa lúc paging, đang fix cứng là 3
      maxPage: 3,
      //Giá trị trang hiện tại trong Paging
      valueInputPaging: 1,
      //Đã có dòng nào được click hay chưa ?
      isHaveRowClicked: false,
      //Form có ở mode Add không ?
      isParentAddMode: true,
      //Dòng được chọn
      selectedRow: null,
      //Object store được chọn
      selectedStore: {},
      //Ẩn form
      isHideParent: true,
      //Hiện form cảnh báo delete
      isHideParentAlert: true,
      stores: [],
      emptyStore: {
        // storeId: null,
        // storeCode: null,
        // StoreName: null,
        // Address: null,
        // PhoneNumber: null,
        // StoreTaxCode: null,
        // CountryId: null,
        // ProvinceId: null,
        // DistrictId: null,
        // WardId: null,
        // Street: null,
        // Status: null,
        // CreatedDate: null,
        // CreatedBy: null,
        // ModifiedDate: null,
        // ModifiedBy: null,
      },
    };
  },
  /**=============================
   * Lấy dữ liệu khi load trang 
   * CreatedBy : Tuanhd(14/4/2021)
   ==============================*/
  async created() {
    //Lấy dữ liệu từ API
    const response = await axios.get(`https://localhost:44343/api/v1/Stores`);

    console.log(response.data.length + " Bản ghi được tìm thấy !");
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
