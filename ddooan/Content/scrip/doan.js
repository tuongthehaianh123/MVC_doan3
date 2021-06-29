// Item in your cart 

var itemCount = 0;
var priceTotal = 0;



// Thêm sản phẩm vào giỏ hàng
$('.add').click(function () {
    itemCount++;

    $('#itemCount').text(itemCount).css('display', 'block');
    $(this).siblings().clone().appendTo('#cartItems').append('<button class="removeItem">Xóa khỏi giỏ hàng</button>');

    // Tính tổng tiền
    var price = parseInt($(this).siblings().find('.dongia').text());
    priceTotal += price;
    $('#cartTotal').text("Tổng: " + priceTotal + "₫");
});



// Ẩn và hiện giỏ hàngm
$('.openCloseCart').click(function () {
    $('#shoppingCart').toggle();
});


// Empty Cart
$('#emptyCart').click(function () {
    itemCount = 0;
    priceTotal = 0;

    $('#itemCount').css('display', 'none');
    $('#cartItems').text('');
    $('#cartTotal').text("Tổng: " + priceTotal + "₫");
});



// Xóa sản phẩm trong giỏ hàng
$('#shoppingCart').on('click', '.removeItem', function () {
    $(this).parent().remove();
    itemCount--;
    $('#itemCount').text(itemCount);

    // Cập nhật lại tổng tiền sau khi xóa sp
    var price = parseInt($(this).siblings().find('.dongia').text());
    priceTotal -= price;
    $('#cartTotal').text("Tổng: " + priceTotal + "₫");

    if (itemCount == 0) {
        $('#itemCount').css('display', 'none');
    }
});

// slide
//khai báo biến slideIndex đại diện cho slide hiện tại



// Tìm kiếm
function myFunction() {
    // Declare variables 
    var input = document.getElementById('search');
    var filter = input.value.toUpperCase();
    var item = document.getElementsByClassName('item');
    var name = document.getElementsByClassName('name');
    var txtValue;
    for (var i = 0; i < item.length; i++) {
        name = item[i].getElementsByClassName('name')[0];
        if (name) {
            txtValue = name.textContent || name.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                item[i].style.display = "";
            } else {
                item[i].style.display = "none";
            }
        }

    }
}