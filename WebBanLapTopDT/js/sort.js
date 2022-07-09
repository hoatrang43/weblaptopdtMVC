$(document).ready(function(){
    $("#btn-sort").on("click", function(){
    var s = 0; 
    var l = 11;
    var data = []; 
    var content ="";
    for(var i =0; i<l;i++) {
    $("#"+i+"").filter(function() {
        var imglink = $("#"+i+"").find('.product-img').attr('src');
        var productName = $("#"+i+"").find('.product-name').text();
        var old=$("#"+i+"").find(".old-price").text();
        var price=$("#"+i+"").find(".price").text();
        var order = {
            'imglink':imglink,
            'name':productName,
            'old':old,
            'price':price
        }
        $(data[s] = order);
        s++;
        })}
    var product = data[0];
    data.sort(function(a,b){
        return a.price - b.price;
    });
    for(var i =0; i<l;i++)
    {
        var cartItem =`
            <div class="col-3 col-m-4 col-s-6">
            <div id="0" class="product">
                <img class="product-img" src="${data[i].imglink}" />
                <label class="product-name">${data[i].name}</label><br />
                <label><s>50.000 đ</s></label><label class="product-price">${data[i].price}</label>
                <input class="btn-buy" type="button" value="ĐẶT MUA" />
                <input class="btn-view" type="button" value="CHI TIẾT" />
            </div>
        </div>`
        content += cartItem;
       
    } 
    $("#search-re").html(content);
    document.getElementById("main").style.display = "none";
    })
});