function btnPlus() {
    var number = $("#txtQty").val();
    if (parseInt(number) >= 10) {
        return;
    }
    if (number === "" || number === undefined) {
        number = 0;
    }
    number = parseInt(number) + 1;
    $("#txtQty").val(number);
}
function btnMinus() {
    var number = $("#txtQty").val();
    if (number === "" || number === undefined || parseInt(number) === 0) {
        number = 0;
        $("#txtQty").val(number);
    }
    else {
        number = parseInt(number) - 1;
        $("#txtQty").val(number);
    }
}
function addShopingCart(id, name, price, avatar, vid) {
    $(".preloading").css("display", "block");
    var number = $("#txtQty").val();
    if (parseInt(number) <= 0) {
        alert("Vui lòng chọn số lượng cần đặt");
        $(".preloading").css("display", "none");
        return;
    }
    var total = parseInt(number) * parseInt(price);
    var data = JSON.stringify(new Cart(id, name, avatar, price, number, total, vid));
    $.ajax({
        url: "/Product/AddToCart",
        type: "POST",
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Status == 1) {
                location.href = "/gio-hang.html"
            }
        },
        error: function () {

        }
    });
    $(".preloading").css("display", "none");

}
function updateCart(id, vid, action) {
    $(".preloading").css("display", "block");


    var data = '{"vid":' + vid + ',"id":' + id + ',"action":' + action + '}';
    $.ajax({
        url: "/Product/UpdateCart",
        type: "POST",
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Status == -1 || data.Status == "-1") {
                location.href = "/";
            }
            else {
                $("#p_total_" + id).html(data.Amount+" vnđ");
                $("#c_total_" + vid).html(data.TotalAmount + " vnđ");
                $("#n_" + id).val(data.Qty);
            }
        },
        error: function () {

        }
    });
    $(".preloading").css("display", "none");

}
function removeCart(id, vid, action) {
    $(".preloading").css("display", "block");


    var data = '{"vid":' + vid + ',"id":' + id + ',"action":' + action + '}';
    $.ajax({
        url: "/Product/RemoveCart",
        type: "POST",
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Status == -1 || data.Status == "-1") {
                location.href = "/";
            }
            else {
                $.ajax({
                    url: "Product/PartialCart",
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        $("#shop_cart").html(data);
                        $(".preloading").css("display", "none");
                    }
                });
            }
        },
        error: function () {
            $(".preloading").css("display", "none");
        }
    });
    $(".preloading").css("display", "none");

}
function Cart(id, name, avatar, price, qty, total, vid) {
    var t = this;
    t.ID = id;
    t.Name = name;
    t.Avatar = avatar;
    t.Price = price;
    t.Qty = qty;
    t.Total = total;
    t.VendorID = vid;
}