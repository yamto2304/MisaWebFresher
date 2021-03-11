$(document).ready(function () {
  loadData();
});

function loadData() {
//get Data
  $.ajax({
    url:"http://api.manhnv.net/api/employees",
    method: "GET",
  }).done(function(res){
    var data = res;
    
    $.each(data, function(index, item){
      var dateOfBirth =  item["DateOfBirth"];
      dateOfBirth = formatDate(dateOfBirth);
      var salary = item.Salary
      //salary = formatMoney()
      var checkbox = `<input type="checkbox"/>`;
      if(item.Gender > 0){
        var checkbox = '<input type="checkbox" checked/>'
      }
      
      var tr = $(`<tr>
          <td><div><span>`+item["EmployeeCode"]+` </span></div></td>
          <td><div><span>`+item['FullName']+` </span></div></td>
          <td><div class="text-align-center">`+ checkbox + `</div></td>
          <td><div class="text-align-center"><span>`+dateOfBirth+`</span></div></td>
          <td><div><span>`+item['PhoneNumber']+`</span></div></td>
          <td><div><span>`+item['Email']+`</span></div></td>
          <td><div><span>`+item['PositionName']+`</span></div></td>
          <td><div><span>`+item['DepartmentName']+`</span></div></td>
          <td><div class="text-align-right"><span>`+salary+`</span></div></td>
          <td><div title="`+item['Address']+`"><span>`+item['Address']+`</span></div></td>
          <td><div><span>`+item['WorkStatusName']+`</span></div></td>
        </tr>`);
        $('table tbody').append(tr);
       
    })
    
  }).fail(function (res) {
    
  })
//binding data
}  

/**-----------------------------------------------------
 * Format dữ liệu ngày tháng sang ngày/tháng/năm
 * @param {*} date tham số có kiểu dữ liệu bất kì
 * @returns CreatedBy :hdtuan (1/1/2111) 
 */
function formatDate(date) {
  var date = new Date(date);
  if(Number.isNaN(date.getTime())){
    return "";
  } else {
    var day = date.getDate();//lấy ngày trong tháng
    var month = date.getMonth();//lấy tháng - tính từ 0
    var year = date.getFullYear();//lấy năm - khác với getFullYear();

    day = day < 10 ? '0' + day : day;
    month = month < 10 ? '0' + month : month;

    return day + '/' + month + '/'+year;
  }
}

/**
 * Định dạng hiển thị tiền tệ
 * @param {Number} money Số tiền
 * CreatedBy:hdtuan (date)
 */
function formatMoney(money) {
  var num = '$' + money.toFixed(0).replace(/(\d)<?=(\d\d\d)+(?!\d))/g, "$1.");
  return num;
}