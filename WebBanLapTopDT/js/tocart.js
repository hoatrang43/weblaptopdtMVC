$(document).ready(function () {
    var currentProductLoad = window.sessionStorage.getItem('orders');

    if(currentProductLoad!=null) {
        let currentProductArrLoad = "[" + currentProductLoad + "]"
        let currentProductArrNewLoad = JSON.parse(currentProductArrLoad)
        console.log(currentProductArrNewLoad.length)
        $(".cart-zone > a").append(`<label class='cart-amount'>0</label>`)
        $(".cart-zone > a > label:last-child").text(currentProductArrNewLoad.length)
    }

    var amount = JSON.parse(`[${ sessionStorage.getItem('orders')}]`).length;
    
    $(".cart-amount").text(amount);
    $('.chitiet .buy .btn-them').click(function(){
        var product =  $( this ).parent();
        var imgPro = product.find('#img-main').attr('src');
        var namePro = product.find('.product-name').text();
        var price = product.find('.price').text();
        var old_price= product.find('.old-price').text();
        var order = {
            'name': namePro,
            'price': price,
            'old_price':old_price,
            'img': imgPro
        };

        var currentProduct = window.sessionStorage.getItem('orders');
        var newOrder="";
        if(currentProduct!=null)
            newOrder = currentProduct + "," + JSON.stringify(order);
        else
            newOrder = JSON.stringify(order);
        window.sessionStorage.setItem('orders', newOrder);
        
        var current= Number($(".cart-amount").text());
        current+=1;
        $(".cart-amount").text(current);  
    });
});
$(document).ready(function(){
    var dataOrder = `[${sessionStorage.getItem('orders')}]`;
    var data = JSON.parse(dataOrder);
    $(".cart-amount").text(data.length);
    $('.cart-number').text(`(Có ${data.length} sản phẩm)`);
    var content = "";
    for(let i = 0; i< data.length; i++){
        var cartItem =   `<div  class=" order-detail">
        <input class='check' type="checkbox"></input>
        <img src="${data[i].img}" />
        <div class="order-description">
			<label class="order-product-name">${data[i].name}</label>
            <button class="order-delete" onclick="xoa()">Xóa</button>
			
			<label class="order-later">Để mua sau</label>
	    </div>
							
		<div class="order-price">
            <label ><s>${data[i].old_price}</s></label><br/>
			<label class="item-price" style="color: red">${data[i].price}</label>
							
		</div>
							
		<div class="order-amount">
			<input class="btn-sub" type="button" value="-"/>
			<input  class="txt-amount" type="text" name="quantity" value="1"/>
			<input  class="btn-plus" type="button" value="+"/>
		</div>
        <hr size='1' color='#d1d1d1' style="width: 100%" />
        </div>`;
          content+=cartItem;
    }
    $(".cart").html(content);
});








