<template>
  <div class="m-dialog" :class="{ isHide: isHide }">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="form-header">
        <div class="heading">
          <b>{{ formHeading }}</b>
        </div>
        <div class="btn-close-form" v-on:click="btnCancelOnClick">
          <button class="btn-x" v-on:click="btnCancelOnClick" title="Đóng">
            X
          </button>
        </div>
      </div>
      <div class="form-content">
        <div class="box-content">
          <div class="form-row-basic">
            <div class="row-item-name">
              Mã cửa hàng <span class="red-text">*</span>
            </div>
            <input
              ref="storeCode"
              v-model="store.storeCode"
              class="row-input-big"
              :class="{ isBlurAlert: storeCodeAlert }"
              v-on:blur="blurStoreCode"
            />
            <div v-show="storeCodeAlert" class="div_error">
              <img src="../../assets/icon/exclamation.png" />
              <span class="title_error">Trường này không được để trống</span>
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-name">
              Tên cửa hàng <span class="red-text">*</span>
            </div>
            <input
              v-model="store.storeName"
              class="row-input-big"
              :class="{ isBlurAlert: storeNameAlert }"
              v-on:blur="blurStoreName()"
            />
            <div v-show="storeNameAlert" class="div_error">
              <img src="../../assets/icon/exclamation.png" />
              <span class="title_error">Trường này không được để trống</span>
            </div>
          </div>
          <div class="form-row-high">
            <div class="row-item-name">
              Địa chỉ <span class="red-text">*</span>
            </div>
            <textarea
              v-model="store.address"
              class="row-input-big"
              v-on:blur="blurStoreAddress()"
              :class="{ isBlurAlert: storeAddressAlert }"
            />
            <div v-show="storeAddressAlert" class="div_error">
              <img src="../../assets/icon/exclamation.png" />
              <span class="title_error">Trường này không được để trống</span>
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Số điện thoại</div>
              <input class="row-input-small" v-model="store.phoneNumber" />
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Mã số thuế</div>
              <input class="row-input-small" v-model="store.storeTaxCode" />
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Quốc gia</div>
              <!-- <input class="row-input-small" v-model="store.countryId" /> -->
              <select
                class="select-location"
                v-model="store.countryId"
                v-on:change="changedCountry(store.countryId)"
              >
                <option value="null" selected>Chọn quốc gia</option>
                <option
                  v-for="(country, index) in countries"
                  :key="index"
                  :value="country.countryId"
                >
                  {{ country.countryName }}
                </option>
              </select>
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Tỉnh/Thành phố</div>
              <!-- <input class="row-input-small" v-model="store.provinceId" /> -->
              <select
                :class="store.countryId == null ? 'disable-item' : ''"
                class="select-location"
                v-model="store.provinceId"
                v-on:change="changedProvince(store.provinceId)"
              >
                <option value="null" selected disabled>Chọn tỉnh</option>
                <option
                  v-for="(province, index) in provinces"
                  :key="index"
                  :value="province.provinceId"
                >
                  {{ province.provinceName }}
                </option>
              </select>
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Quận/Huyện</div>
              <!-- <input class="row-input-small" v-model="store.districtId" /> -->
              <select
                class="select-district"
                v-model="store.districtId"
                v-on:change="changedDistrict(store.districtId)"
                :class="store.provinceId == null ? 'disable-item' : ''"
              >
                <option value="null" selected disabled>Chọn Quận/Huyện</option>
                <option
                  v-for="(district, index) in districts"
                  :key="index"
                  :value="district.districtId"
                >
                  {{ district.districtName }}
                </option>
              </select>
            </div>
          </div>
          <div class="form-row-basic">
            <div class="row-item-left">
              <div class="row-item-name">Phường/Xã</div>
              <!-- <input class="row-input-small" v-model="store.wardId" /> -->
              <select
                class="select-location"
                v-model="store.wardId"
                :class="store.districtId == null ? 'disable-item' : ''"
              >
                <option value="null" selected disabled>Chọn Phường/Xã</option>
                <option
                  v-for="(ward, index) in wards"
                  :key="index"
                  :value="ward.wardId"
                >
                  {{ ward.wardName }}
                </option>
              </select>
            </div>
            <div class="row-item-right">
              <div class="row-item-name">Đường phố</div>
              <input class="row-input-small" v-model="store.street" />
            </div>
          </div>
        </div>
      </div>
      <div class="form-footer">
        <button class="btn-with-icon btn-help-footer">
          <div class="icon-help-13"></div>
          <div class="text-btn theme-color-text" title="F1">Trợ giúp</div>
        </button>
        <div class="footer-feature">
          <button
            class="btn-with-icon btn-save-footer"
            v-on:click="btnSaveOnClick"
          >
            <div class="icon-save"></div>
            <div
              class="text-btn theme-color-text"
              style="color: #ffffff"
              title="Ctrl+S"
            >
              Lưu
            </div>
          </button>
          <button
            class="btn-with-icon btn-save-add"
            v-on:click="btnSaveAndAddOnClick"
          >
            <div class="icon-add-form"></div>
            <div class="text-btn theme-color-text" title="Ctrl+Shift+S">
              Lưu và Thêm mới
            </div>
          </button>
          <button
            class="btn-with-icon btn-cancel-form"
            v-on:click="btnCancelOnClick"
          >
            <div class="icon-cancel-form"></div>
            <div class="text-btn theme-color-text" title="Ctrl+B">Huỷ bỏ</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import * as axios from "axios";
export default {
  props: {
    isHide: Boolean,
    isAddMode: Boolean,
    formHeading: String,
    store: {
      // storeId: null,
      // storeCode: "",
      // StoreName: "",
      // Address: "",
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
    storeId: String,
    // countries : getCountries(),
  },
  components: {},
  methods: {
    validateData() {
      //Check StoreCode trống
      this.blurStoreCode();
      //Check StoreName trống
      this.blurStoreName();
      //Check StoreAddress trống
      this.blurStoreAddress();
    },
    focusFirstInput() {
      this.$nextTick(() => {
        this.$refs.storeCode.focus();
      });
    },
    /**==============================
     * Hiển thị form
     * CreatedBy : Tuanhd(19/4/2021)
     ===============================*/
    showForm() {
      this.storeCodeAlert = false;
      this.storeNameAlert = false;
      this.storeAddressAlert = false;
      this.focusFirstInput();
      this.getCountries();
      if (!this.isAddMode) {
        this.getProvinces();
        this.getDistricts();
        this.getWards();
      }
    },
    //ClearData
    clearData() {
      this.store.countryId = null;
      this.store.provinceId = null;
      this.store.districtId = null;
      this.store.wardId = null;
      this.store.storeCode = null;
      this.store.storeName = null;
      this.store.address = null;
      this.store.phoneNumber = null;
      this.store.status = null;
      this.store.street = null;
      this.store.storeTaxCode = null;
    },
    /**===============================================================================
     * Lưu
     * Active : Click button "Lưu"
     * Result : Save a shop (Add new or Edit) and close form, reset form mode to "add"
     * CreatedBy : Tuanhd(14/4/2021)
     =================================================================================*/
    btnSaveOnClick() {
      this.validateData();
      if (this.errorInValidate) return;
      if (this.isAddMode) {
        console.log("add");
        axios
          .post("https://localhost:44314/api/v1/Store", this.store)
          .then((res) => {
            // console.log(res.data);
            console.log(res.data.devMsg);

            this.$emit("isReload", true);
          })
          .catch((res) => {
            // console.log(res);
            console.log(res.response.data.devMsg);
          });
        console.log(this.store);
        // console.log(response);
      } else {
        // console.log("edit");
        axios
          .put(
            "https://localhost:44314/api/v1/Store/" + this.store.storeId,
            this.store
          )
          .then((res) => {
            // console.log(res);
            console.log(res.data.devMsg);
            this.$emit("isReload", true);
          })
          .catch((res) => {
            console.log(res.response.data.devMsg);
          });
      }
      this.$emit("isAddMode", true);
      this.$emit("closeForm", true);
    },
    /**=============================================
     * Đóng form
     * Active : Click button X, button Cancel
     * Result : Close form, reset form mode to "add"
     * CreatedBy : Tuanhd(14/4/2021)
     ==============================================*/
    btnCancelOnClick() {
      this.clearData();
      this.$emit("closeForm", true);
      this.$emit("isAddMode", true);
    },
    /**===============================================================================
     * Lưu và thêm mới
     * Active : Click button "Lưu và thêm mới"
     * Result : Save a shop (Add new or Edit) and reopen AddAndEdit form (with no data)
     * CreatedBy : Tuanhd(14/4/2021)
     =================================================================================*/
    btnSaveAndAddOnClick() {
      this.validateData();
      if (this.isAddMode) {
        console.log("add");
        axios
          .post("https://localhost:44314/api/v1/Store", this.store)
          .then((res) => {
            console.log(res);
            this.clearData();
            this.$emit("isReload", true);
          })
          .catch((res) => {
            console.log(res.response.data.devMsg);
          });
        console.log(this.store);
        // console.log(response);
      } else {
        // console.log("edit");
        axios
          .put(
            "https://localhost:44314/api/v1/Store/" + this.store.storeId,
            this.store
          )
          .then((res) => {
            this.clearData();
            this.$emit("isReload", true);
            // console.log(res);
            console.log(res.data.devMsg);
          })
          .catch((res) => {
            console.log(res.response.data.devMsg);
          });
      }

      console.log(this.isAddMode);
    },

    /**================================================
     * Check Mã cửa hàng
     * Active : Mouse click outside the StoreCode input
     * Result : The border become red
     * CreatedBy : Tuanhd(14/4/2021)
     =================================================*/
    blurStoreCode() {
      if (!this.store.storeCode) {
        this.storeCodeAlert = true;
        this.errorInValidate = true;
      } else this.storeCodeAlert = false;
    },
    /**================================================
     * Check Tên cửa hàng
     * Active : Mouse click outside the StoreName input
     * Result : The border become red
     * CreatedBy : Tuanhd(14/4/2021)
     ==================================================*/
    blurStoreName() {
      // this.showSmallMessage();
      if (!this.store.storeName) {
        this.errorInValidate = true;
        this.storeNameAlert = true;
      } else this.storeNameAlert = false;
    },
    /**===================================================
     * Check Địa chỉ cửa hàng
     * Active : Mouse click outside the StoreAddress input
     * Result : The border become red
     * CreatedBy : Tuanhd(14/4/2021)
     =====================================================*/
    blurStoreAddress() {
      // this.showSmallMessage();
      if (!this.store.address) {
        this.storeAddressAlert = true;
        this.errorInValidate = true;
      } else this.storeAddressAlert = false;
    },

    /**=============================
     * Lấy dữ liệu quốc gia
     * CreatedBy : Tuanhd(17/4/2021)
     ===============================*/
    getCountries() {
      // console.log("Load Country !");
      // Lấy dữ liệu từ API
      axios.get(`https://localhost:44314/api/v1/Country`).then((response) => {
        //Lưu dữ liệu vào biến countries để show dữ liệu
        this.countries = response.data.data;
        console.log(response.data.data.length + " Quốc gia được tìm thấy !");
      });
    },
    /**=============================
     * Lấy dữ liệu tỉnh/thành phố
     * CreatedBy : Tuanhd(17/4/2021)
     ===============================*/
    getProvinces() {
      // console.log("Load Province !");
      // Lấy dữ liệu từ API
      axios.get(`https://localhost:44314/api/v1/Province`).then((response) => {
        //Lưu dữ liệu vào biến provinces để show dữ liệu
        this.provinces = response.data.data;
        console.log(response.data.data.length + " Tỉnh được tìm thấy !");
      });
    },
    /**=============================
     * Lấy dữ liệu quận/huyện
     * CreatedBy : Tuanhd(17/4/2021)
     ===============================*/
    getDistricts() {
      // console.log("Load District !");
      // Lấy dữ liệu từ API
      axios.get(`https://localhost:44314/api/v1/District`).then((response) => {
        //Lưu dữ liệu vào biến districts để show dữ liệu lên bảng
        this.districts = response.data.data;
        console.log(response.data.data.length + " Huyện được tìm thấy !");
      });
    },
    /**=============================
     * Lấy dữ liệu phường/xã
     * CreatedBy : Tuanhd(17/4/2021)
     ===============================*/
    getWards() {
      // console.log("Load Ward !");
      // Lấy dữ liệu từ API
      axios.get(`https://localhost:44314/api/v1/Ward`).then((response) => {
        //Lưu dữ liệu vào biến wards để show dữ liệu lên bảng
        this.wards = response.data.data;
        console.log(response.data.data.length + " Xã được tìm thấy !");
      });
    },

    /**============================================
     * Lấy dữ liệu tỉnh/thành phố khi chọn quốc gia
     * CreatedBy : Tuanhd(17/4/2021)
     =============================================*/
    changedCountry(value) {
      // console.log("Mã quốc gia : " + value);
      // Lấy dữ liệu từ API
      axios
        .get(`https://localhost:44314/api/v1/Province/WithParent/` + value)
        .then((response) => {
          //Lưu dữ liệu vào biến provinces để chạy v-for show dữ liệu lên bảng
          this.provinces = response.data.data;
          console.log(response.data.data.length + " Tỉnh được tìm thấy !");
        });
      this.store.provinceId = null;
      this.store.districtId = null;
      this.store.wardId = null;
    },
    /**============================================
     * Lấy dữ liệu quận/huyện khi chọn quốc gia
     * CreatedBy : Tuanhd(19/4/2021)
     =============================================*/
    changedProvince(value) {
      // Lấy dữ liệu từ API
      axios
        .get(`https://localhost:44314/api/v1/District/WithParent/` + value)
        .then((response) => {
          //Lưu dữ liệu vào biến districts để chạy v-for show dữ liệu lên bảng
          this.districts = response.data.data;
          console.log(
            response.data.data.length + " Quận/Huyện được tìm thấy !"
          );
        });
      this.store.districtId = null;
      // this.store.wardId = null;
    },
    /**============================================
     * Lấy dữ liệu xã/phường khi chọn quốc gia
     * CreatedBy : Tuanhd(19/4/2021)
     =============================================*/
    changedDistrict(value) {
      // Lấy dữ liệu từ API
      axios
        .get(`https://localhost:44314/api/v1/Ward/WithParent/` + value)
        .then((response) => {
          //Lưu dữ liệu vào biến wards để chạy v-for show dữ liệu lên bảng
          this.wards = response.data.data;
          console.log(response.data.data.length + " Xã/Phường được tìm thấy !");
        });
    },

    loadCountryName(id) {
      // console.log("Mã quốc gia : " + id);
      // Lấy dữ liệu từ API
      axios
        .get(`https://localhost:44314/api/v1/Country/` + id)
        .then((response) => {
          return response;
        });
    },

    loadProvinceName(id) {
      // console.log("Mã tỉnh : " + id);
      // Lấy dữ liệu từ API
      axios
        .get(`https://localhost:44314/api/v1/Province/` + id)
        .then((response) => {
          return response;
        });
    },
  },
  mounted() {},
  created() {
    this.getCountries();
  },
  computed: {},
  data() {
    return {
      storeCodeAlert: false,
      storeNameAlert: false,
      storeAddressAlert: false,
      countries: [],
      provinces: [],
      districts: [],
      wards: [],
      selectedLocation: [],
      emptyStore: {},
      errorInValidate: false,
    };
  },
};
</script>
<style scoped>
.div_error {
  width: 16px;
  height: 16px;
  padding: 4px;
}
.div_error:hover .title_error {
  display: block;
}
.title_error {
  font-size: 13px;
  position: fixed;
  left: calc(50% + 285px);
  color: #ffffff;
  background-color: rgb(233, 61, 61);
  padding: 8px;
  border-radius: 2px;
  display: none;
}
</style>