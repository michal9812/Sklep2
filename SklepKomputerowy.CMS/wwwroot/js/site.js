// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    // Initialize and change language to hindi
 
    $(".datetimepicker").datepicker($.datepicker.regional["pl"]);



});


function searchOrders() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("searchOrder");
    filter = input.value.toUpperCase();
    table = document.getElementById("dataOrderstable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
/* 
Dynamic creation of table is not the best practice...
Better way to clone existing table and fill it with data.
*/
function LadujZawartoscDataAsync(url, data, elementDocelowy) {
  

    $.ajax({
        type: "GET",
        url: url,
        data: data,
        cache: false,
        dataType: "html",
        traditional: true,
        beforeSend: function () {
          
        },
        success: function (data) {
            console.log(data);

            
            $(elementDocelowy).html(data);



       
       
           

        }
    });
      
}
function szukajMiejscowosc() {
    $("#dataOrderstable > tbody:nth-child(2) > tr").empty();
    var adres = $('#searchAddres').val();
    var imieNazwisko = $('#searchImieNazwisko').val();
    var dataPoczotek = $('#searchdateinto').val();
    var dataKoniec = $('#searchdatefrom').val();
  
    laduj({ adres: adres, imieNazwisko: imieNazwisko, dataPoczotek: dataPoczotek, dataKoniec: dataKoniec});
}
function laduj(dane) {

    LadujZawartoscDataAsync('/Zamowienie/ZamowienieList', dane, '#pracownicy');
}