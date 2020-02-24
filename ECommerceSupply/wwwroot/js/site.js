/* With no-setup, this is one of the better options. Item Quantity and Price DEFINATELY need to be verified, ideally as the checkout/cart screen pops up. You can submit this info to such a page easily, in the worst case use xmlhttprequest. */
/* If I wanted to improve quality I would probably move these into a Cart Object with prototype functions */
function getCartItemValue(cartItem) {
    return (parseFloat(cartItem["Price"].replace(/^\$+|\$+$/g, '')) * parseInt(cartItem["Purchase Options"]));
}
function getTotalCartItemValue(cart) {
    var total = 0.0;
    if (cart == null) return total; //could use getCart() here, but assume there is a reason in this case
    for (var i = 0; i < cart.length; i++) {
        total += getCartItemValue(cart[i]);
    }
    return total;
}
function getItemsInCart(cart) {
    return ((cart == null) ? getCart() : cart).length;
}
function getTotalItemsInCart(cart) {
    if (cart == null) return 0; //could use getCart() here, but assume there is a reason in this case
    var total = 0;
    for (var i = 0; i < cart.length; i++) {
        total += parseInt(cart[i]["Purchase Options"]);
    }
    return total;
}
function getCart() {
    return JSON.parse(localStorage.getItem("cart") || '[]');
}
function setCart(text) {
    document.querySelector("nav menu li:last-child span").innerText = text;
}
function add_to_client_cart(el) { //probably should have edge case where if Item is in there twice it either combines the listing or clears cart (likely tampered with)
    var itemInfo = getItemInfo(el);
    var localStorageItem = getCart();
    var i;
    if (localStorageItem.length > 0) {
        var found = false;
        for (i = 0; i < localStorageItem.length; i++) {
            if (localStorageItem[i].Name == itemInfo.Name) {
                var temp = parseInt(localStorageItem[i]["Purchase Options"]) + parseInt(itemInfo["Purchase Options"]);
                if (temp <= parseInt(itemInfo["Avalible Quantity"])) localStorageItem[i]["Purchase Options"] = temp.toString();
                found = true;
            }
        }
        if (!found) localStorageItem.push(itemInfo);
    } else {
        localStorageItem.push(itemInfo);
    }
    localStorage.setItem("cart", JSON.stringify(localStorageItem));
    setCart(getTotalItemsInCart(localStorageItem));
    display_cart_content(localStorageItem);
}


function display_cart_content(cart) {
    var cart_list = document.querySelector("aside.cart .list");
    cart_list.innerHTML = "";
    for (var i = 0; i < cart.length; i++) {
        var listItem = document.createElement('li');
        listItem.innerHTML = cart[i]["Name"] + " x" + cart[i]["Purchase Options"];
        var priceItem = document.createElement('span');
        priceItem.innerText = getCartItemValue(cart[i]).toFixed(2);
        listItem.appendChild(priceItem);
        cart_list.appendChild(listItem);
    }
    document.querySelector("aside.cart div h2 span").innerText = getTotalCartItemValue(cart).toFixed(2);
}


function getItemInfo(el) { //minifed
    var item_Info = Array.prototype.slice.call(el.parentElement.parentElement.querySelectorAll("td:not(:first-child):not(:last-child)")).map(function (f) { return f.innerText; }).concat(el.parentElement.querySelector("input[type=number]").value);
    var names = Array.prototype.slice.call(el.parentElement.parentElement.parentElement.querySelectorAll("th:not(:first-child)")).map(function (f) { return f.innerText; });
    return Object.assign(...names.map((k, i) => ({ [k]: item_Info[i] })));
}
window.onload = function () {
    var current_cart = getCart();
    setCart(getTotalItemsInCart(current_cart));
    display_cart_content(current_cart);
};
function clearCart() {
    localStorage.clear();
    setCart(0);
    document.querySelector("aside.cart div h2 span").innerText = "0";
    document.querySelector("aside.cart .list").innerHTML = "";
}
function clearCartUI() {
    if (confirm("Press OK if you are sure about clearing your cart") == true) clearCart();
}
function display_cart(display) {
    document.querySelector("aside.cart").style.cssText = 'display:' + (display ? 'block' : 'none') + '!important;';
}
function placeOrder() {
    if (getItemsInCart(getCart())) {
        clearCart();
        alert("Your order has been 'Placed'.");
    } else {
        alert("Your order wasn't placed, your cart is empty.")
    }
}

