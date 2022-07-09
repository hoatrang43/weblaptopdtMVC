var formater = Intl.NumberFormat("vi", {
    style: 'currency',
    currency: 'VND',
    /* minimumFractionDigits: 0 */
});

function replaceDot(s){
	while(s.indexOf(".")>=0)
		s = s.replace(".", "");
	return s;
}
function Update_Total_Price(){
    var data = $('.price')
    var total_price=0
    
    for(var i=0;i<data.length;i++){
        var price = $(data[i]).text()
		
        var parent = $(data[i]).parent().parent()
        var amount = parent.find('.txt-quantity').val()
        price = price.toString().replace(' đ','')
		
        price = replaceDot(price);
        total_price+= Number(price) * amount
    }
    console.log(total_price);
    $('.amount').text(formater.format(total_price.toString()));
    $('.total-price').text(formater.format(total_price.toString()));
   
}

$(document).ready(function () {
    var orders = sessionStorage.getItem('orders') == null? []: JSON.parse(`[${ sessionStorage.getItem('orders')}]`);
    var amount = orders.length;
    $(".cart-amount").text(amount);
    $('.product-corgi div .btn-buy').click(function(){
        var product =  $(this).parent().parent();
        var imgPro = product.find('img').attr('src');
        console.log(product.find('img'));
        var namePro = product.find('.product-name').text();
        var price = product.find('.price').text();
        var order = {
            'name': namePro,
            'price': price,
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
    var data = sessionStorage.getItem('orders') == null? []: JSON.parse(`[${ sessionStorage.getItem('orders')}]`);
    $(".cart-amount").text(data.length);
    var content = "";
    for(let i = 0; i< data.length; i++){
        var cartItem =   `<div class="product-main">
        <div class="col-5">
            <div class="col-1"><input type="checkbox" class="check"/></div>
            <div class="col-3">
                <div class="product-img">
                    <img src="${data[i].img}" />
                </div>
            </div>
            <div class="col-8">
                <div class="product-name">${data[i].name}</div>
            </div>
        </div>
        <div class="col-7">
            <div class="right-product-main">
                <div class="col-3">
                    <div class="price">${data[i].price}</div>
                </div>
                <div class="col-4">
                    <div class="quantity">
                        <div class="btn-sub">-</div>
                        <input id='txt' class="txt-quantity" type="text" value="1" />
                        <div class="btn-plus">+</div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="amount">${data[i].price}</div>
                </div>
                <div class="col-2">
                    <div class="act">Xoá</div>
                </div>
            </div>
        </div>
    </div>`;
          content+=cartItem;
    }
    $("#product-main").html(content);
});

$(document).ready(function(){
    //Update_Total_Price()
    $('.btn-plus').click(function(){
        var parent = $(this).parent()
        $(parent).find('.txt-quantity').val(parseInt($(parent).find('.txt-quantity').val())+1)
        Update_Total_Price()
    })
    $('.btn-sub').click(function(){
        var parent = $(this).parent()
        if(Number($(parent).find('.txt-quantity').val()) > 1) {

            $(parent).find('.txt-quantity').val(parseInt($(parent).find('.txt-quantity').val())-1)
        }
        
        Update_Total_Price()
    });

    $('.check').change(function(){
        var thisPrice = Number(replaceDot($(this).parent().parent().next().find('.amount').text().replace(' đ',"").replace(' ₫','')));
        var thisAmount = $(this).parent().parent().next().find('.txt-quantity').val();
        var total = Number(replaceDot($('.total-price').text().replace(' đ', "").replace(' ₫', '')))
        
       if($(this).prop('checked')){
                $('.total-price').text(formater.format(thisPrice + total));
       } else{
           total = Number(replaceDot($('.total-price').text().replace('đ','').replace('₫', '')));
           $('.total-price').text(formater.format(total - thisPrice));
       }    
    });
})


$(document).ready(function(){
    $('.act')
})


