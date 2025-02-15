//function addToCart(productId, quantity) {
//    $.ajax({
//        url: '@Url.Action("AddToCart", "ShoppingCart")',
//        type: 'POST',
//        data: { 'viewModel.ShoppingCartItem.ProductId': productId, 'viewModel.ShoppingCartItem.Quantity': quantity },
//        success: function (response) {
//            if (response.success) {
//                alert(response.message);
//                // Optional: Update the cart item count or other cart details on the page
//            } else {
//                alert(response.message);
//            }
//        },
//        error: function () {
//            alert("An error occurred while adding the product to the cart.");
//        }
//    });
//}

//function incrementQuantity() {
//    var quantity = parseInt(document.getElementById("quantity").value);
//    console.log(quantity);
//    if (quantity < 100) {
//        document.getElementById("quantity").value = quantity + 1;
//    }
//}


//function updateCartItemCount() {
//    $.ajax({
//        url: '@Url.Action("GetCartCount", "ShoppingCart")',
//        type: 'GET',
//        success: function (response) {
//            $('#cart-item-count').text(response.itemCount);
//            console.log(response.itemCount)
//        },
//        error: function () {
//            console.error("An error occurred while fetching the cart item count.");
//        }
//    });
//}

//updateCartItemCount();