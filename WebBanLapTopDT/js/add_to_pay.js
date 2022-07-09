$(document).ready(function () {
    var amount = JSON.parse(`[${ sessionStorage.getItem('orders')}]`).length;
    
    $(".cart-amount").text(amount);
    $('.btn-dathang').click(function(){
        var product =  $( this ).parent();
        var imgPro = product.find('.order-detail img').attr('src');
        var namePro = product.find('.order-product-name').text();
        var price = product.find('.item-price').text();
        var sl=product.next().find('.txt-amount').val();
        var total=price*sl;
        var order = {
            'name': namePro,
            'price': price,
            'sl':sl,
            'img': imgPro,
            'total':total
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
        var cartItem =   `<div class='content'>
        <div class="sp" >                              
            <img class='prd-img' src="${data[i].img}"  />								
            <label class="prd-name">${data[i].name}</label>																	
        </div>
        <div class="dongia" >														
            <label class="item-price" >${data[i].price}</label>																				
        </div>
        <div class='soluong' >								
            <label class='sl' >${data[i].sl}</label>
        </div>
        <div class='price-pay' >								
            <label class='gia'>${data[i].total}</label>
        </div>
        <hr size="2" style="background-color: gray;width: 100%;" >
        </div>`;
          content+=cartItem;
    }
    $(".sanpham").html(content);
});








