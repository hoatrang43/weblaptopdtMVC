/* $('.order-delete').click(function(){
    var data = JSON.parse(`[${ sessionStorage.getItem('orders')}]`);
    var pro=this.closet('.order-detail');
    var tt=pro.find('.order-product-name').text();
    data.splice(tt-1,1);
    window.sessionStorage.setItem('orders',JSON.stringify(data));
    $(pro).remove();

}) */