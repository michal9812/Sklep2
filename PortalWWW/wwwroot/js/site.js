// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
$(function () {
    //var inputs = document.querySelectorAll('input');
    //for (var i = 0; i < inputs.length; i++) {
    
    //    inputs[i].addEventListener('blur', function () {
    //        if (!this.checkValidity()) {
    //            this.classList.add('invalid');
    //        } else {
    //            this.classList.remove('invalid');
    //        }
    //    });
    //}
});
function refreshQantity(id, count) {
    $.ajax({
        url: "/Koszyk/UpdateCartCount",
        method: "post",

        data: { "id": id, "liczbaProduktow": count },

    })
        .done(function (response) {
            console.log(response);
            $("#total-value").html(response.razem);
        })
        .fail(function () {
            alert("Wystąpił błąd w połączeniu");
        })

}

function increaseValue(Object) {
    let x = Object.getAttribute("data-id");
    let id = parseInt(x);
    let path = "item-count-".concat(x);
    var value = parseInt(document.getElementById(path).value, 10);
    value = isNaN(value) ? 0 : value;
    value++;

    document.getElementById(path).value = value;
    refreshQantity(id, value)
}
function decreaseValue(Object) {
    let x = Object.getAttribute("data-id");
    let id = parseInt(x);
    let path = "item-count-".concat(x);

    var value = parseInt(document.getElementById(path).value, 10);
    value = isNaN(value) ? 0 : value;
    if (value == 1) {
        return;
    }
    value--;
    document.getElementById(path).value = value;
    refreshQantity(id, value)

}
function Validate() {
    alert("123");
    $("ordersFrom").validate({
        focusInvalid: false,
        rules: {
            name: "required",
            email: {
                required: true,
                email: true
            },
            message: "required"
        },
        messages: {
            name: 'Fill in name',
            email: 'Fill in email',
            message: 'Fill in message'
        },

    });
}




