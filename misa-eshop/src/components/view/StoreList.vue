<template>
  <div class="store-list-content">
    <AddAndEdit
      ref="AddAndEdit"
      :isHide="isHideParent"
      @closeForm="closeForm"
      @isReload="isReload"
      :isAddMode="isParentAddMode"
      :store="selectedStore"
      :formHeading="isParentAddMode ? 'Thêm mới cửa hàng' : 'Sửa cửa hàng'"
    />
    <DeleteAlert
      :isHideAlert="isHideParentAlert"
      :storeName="selectedStore.storeName"
      :storeId="selectedStore.storeId"
      @closeAlert="closeAlert"
      @isReload="isReload"
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
        :class="isHaveRowClicked ? '' : 'disable-item'"
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
      <button
        class="btn-with-icon btn-end"
        title="Ctrl + Y"
        @click="loadAllData"
      >
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
                  <input class="input-filter" v-model="filter.storeCode" />
                </div>
              </th>
              <th class="store-name">
                <div class="th-name">Tên cửa hàng</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" v-model="filter.storeName" />
                </div>
              </th>
              <th class="store-address">
                <div class="th-name">Địa chỉ</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" v-model="filter.address" />
                </div>
              </th>
              <th class="store-phone">
                <div class="th-name">Số điện thoại</div>
                <div class="th-filter">
                  <button class="btn-filter">*</button>
                  <input class="input-filter" v-model="filter.phoneNumber" />
                </div>
              </th>
              <th class="store-status">
                <div class="th-name">Trạng thái</div>
                <select class="select-filter" v-model="filter.status">
                  <option :value="2">Tất cả</option>
                  <option :value="1">Đang hoạt động</option>
                  <option :value="0">Ngừng hoạt động</option>
                </select>
              </th>
            </tr>
          </thead>
          <BaseLoading :showLoading="showLoading" />
          <tbody>
            <tr
              class="el-table__row"
              v-for="store in stores.slice(this.indexStart, this.indexEnd)"
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
                <div class="cell">
                  {{ store.status == 1 ? "Đang hoạt động" : "Ngừng hoạt động" }}
                </div>
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
            @click="valueInputPaging = 1"
          ></div>
          <div
            class="btn-paging icon-back"
            :class="valueInputPaging > 1 ? '' : 'disable-item'"
            @click="valueInputPaging--"
          ></div>
          <div class="paging-text">Trang</div>
          <input class="input-paging" v-model="valueInputPaging" />
          <div class="paging-text">trên {{ numberPage }}</div>
          <div
            class="btn-paging icon-next"
            :class="valueInputPaging < this.numberPage ? '' : 'disable-item'"
            @click="valueInputPaging++"
          ></div>
          <div
            class="btn-paging icon-end"
            :class="valueInputPaging < this.numberPage ? '' : 'disable-item'"
            @click="valueInputPaging = numberPage"
          ></div>
          <div class="btn-paging icon-refresh" @click="loadData"></div>
          <select
            class="select-number-records select-number-page"
            v-model="page.numberStoreSelect"
          >
            <option
              v-for="(number, index) in selectNumberStore"
              :key="index"
              :value="number"
            >
              {{ number }}
            </option>
            <!-- <option>15</option>
            <option>25</option>
            <option>50</option>
            <option>100</option> -->
          </select>
        </div>
        <div class="paging-record-infor paging-text">
          Hiển thị {{ indexStart }} - {{ indexEnd }} trên
          {{ this.countData }} kết quả
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import AddAndEdit from "../form/AddAndEdit";
import DeleteAlert from "../form/DeleteAlert";
import BaseLoading from "../view/BaseLoading";
import * as axios from "axios";
export default {
  name: "Store",
  props: {
    // store: Object,
  },
  components: {
    AddAndEdit,
    DeleteAlert,
    BaseLoading,
  },
  methods: {
    /**=============================
     * Chạy LoadData từ con gọi lên
     * CreatedBy : Tuanhd(19/4/2021)
     ==============================*/
    isReload() {
      // this.loadData();
      this.getStoreByFilter(this.filter);
    },
    /**===============================
     * LoadData đồng thời reset paging
     * CreatedBy : Tuanhd(19/4/2021)
     ================================*/
    loadAllData() {
      this.valueInputPaging = 1;
      // this.loadData();
      this.getStoreByFilter(this.filter);
    },

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
      //Gọi hàm load dữ liệu ban đầu cho form
      this.$refs.AddAndEdit.showForm();
      //Load all contries
      this.$refs.AddAndEdit.getCountries();
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
      this.$refs.AddAndEdit.showForm();

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
    closeAlert(value) {
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
      // console.log(this.selectedRow);
      this.isHaveRowClicked = true;
      //Gọi Api lấy dữ liệu từ Id đã lấy
      axios
        .get("https://localhost:44314/api/v1/Store/" + this.selectedRow)
        .then((res) => {
          //Đẩy data thu được vào biến selectedStore và truyền xuống con
          this.selectedStore = res.data.data;
          // console.log(res);
          // console.log(res);
        })
        .catch((res) => {
          console.log(res.response);
        });
    },

    async getStoreByFilter(filter) {
      this.showLoading = true;
      console.log("LoadData by filter !");
      await axios
        .get(
          `https://localhost:44314/api/v1/Store/filter?storeCode=${filter.storeCode}&storeName=${filter.storeName}&address=${filter.address}&phoneNumber=${filter.phoneNumber}&status=${filter.status}`
        )
        .then((res) => {
          //Đẩy data thu được vào biến selectedStore và truyền xuống con
          this.filterStores = res.data.data;
          this.countData = res.data.data.length;
          console.log(res.data.data);
          // console.log(res);
        })
        .catch((res) => {
          console.log(res.response);
        });
        this.showLoading = false;
    },
    /**===============================
     * Chỉ LoadData
     * CreatedBy : Tuanhd(19/4/2021)
     ================================*/
    async loadData() {
      this.showLoading = true;
      console.log("loadData !!");
      // Lấy dữ liệu từ API
      await axios
        .get(`https://localhost:44314/api/v1/Store`)
        .then((response) => {
          //Lưu dữ liệu vào biến stores để chạy v-for show dữ liệu lên bảng

          this.allStores = response.data.data;
          // this.countData = response.data.data.length;
          console.log(response.data.data.length);
        });
      this.showLoading = false;
    },
  },
  watch: {
    valueInputPaging() {
      if (this.valueInputPaging < 1) this.valueInputPaging = 1;
      if (this.valueInputPaging > this.numberPage)
        this.valueInputPaging = this.numberPage;
    },
    "filter.storeCode"() {
      this.getStoreByFilter(this.filter);
    },
    "filter.storeName"() {
      this.getStoreByFilter(this.filter);
    },
    "filter.address"() {
      this.getStoreByFilter(this.filter);
    },
    "filter.status"() {
      this.getStoreByFilter(this.filter);
    },
    "filter.phoneNumber"() {
      this.getStoreByFilter(this.filter);
    },
  },
  computed: {
    stores() {
      return this.filterStores;
      // .slice(this.indexStart - 1, this.indexEnd);
    },
    countStore() {
      return this.stores.length;
    },
    numberPage() {
      var number =
        (this.countStore - (this.countStore % this.page.numberStoreSelect)) /
        this.page.numberStoreSelect;
      if (this.countStore % this.page.numberStoreSelect > 0) number++;
      return number;
    },
    indexStart() {
      var numberEnd = this.valueInputPaging * this.page.numberStoreSelect;
      if (numberEnd > this.countStore) numberEnd = this.countStore;

      if (this.countStore == 0) return 0;
      var number =
        (this.valueInputPaging - 1) * this.page.numberStoreSelect + 1;
      if (number < 0) return 0;
      if (number > numberEnd) return numberEnd;
      return number;
    },
    indexEnd() {
      var number = this.valueInputPaging * this.page.numberStoreSelect;
      if (number > this.countStore) number = this.countStore;
      return number;
    },
  },
  data() {
    return {
      filterStores: {},
      filter: {
        storeCode: "",
        storeName: "",
        address: "",
        phoneNumber: "",
        status: "2",
      },
      page: {
        pageNumber: 1,
        numberStoreSelect: 15,
      },
      //Các giá trị phân trang
      selectNumberStore: [15, 25, 50, 100],
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
      //Tổng số store
      countData: 0,
      //Ẩn form
      isHideParent: true,
      //Hiện form cảnh báo delete
      isHideParentAlert: true,
      //Tất cả store lấy được
      allStores: [],
      //Loading
      showLoading: true,
      //Object store rỗng
      emptyStore: {},
    };
  },
  /**=============================
   * Lấy dữ liệu khi load trang 
   * CreatedBy : Tuanhd(14/4/2021)
   ==============================*/
  created() {
    // this.loadData();
    this.getStoreByFilter(this.filter);
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
