var customers = [];

var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function(){
    
    if(this.readyState == 4 && this.status == 200){
        customers = JSON.parse(this.response);
        loadTable(customers);
    }
    
}
xhttp.open("GET", "http://api.manhnv.net/api/customers", true);
xhttp.send();

function loadTable(data){
    //debugger
    // dddd
    
    var table = document.getElementById('tbl-customer');

    for(let i = 0; i < data.length; i++){
        //debugger
        let row = `<tr>
            <td>${data[i].CustomerCode}</td>
            <td>${data[i].FullName}</td>
            <td>${data[i].Gender}</td>
            <td>${data[i].DateOfBirth}</td>
            <td>${data[i].Email}</td>
            <td>${data[i].PhoneNumber}</td>
            <td>${data[i].Address}</td>
            </tr>`;
        table.innerHTML += row;
    }
}
