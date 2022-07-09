$(document).ready(function(){
	$('#btn-search').on("click",function(){
	   var value =$(".txt").val().toLowerCase();
	   var data = [];
	   var d = 0;
	   var p = 20;
	   var content ="<h5>SẢN PHẨM MUỐN TÌM</h5>";
	   for(var i=0;i < p; i++){
		   $("#"+i).filter(function(){
			   if($("#" +i+" .product-name").text().toLowerCase().indexOf(value)>-1){
				   var imglink =$("#"+i).find(".p-img").attr('src');
				   var name=$("#"+i).find(".product-name").text();
				   var price=$("#"+i).find(".price").text();
				   var order={
					   'imglink':imglink,
					   'name':name,
					   'price':price,
				   }
				   $(data[d]=order);
				   d++;
			   }
		   });
	   }
	   if(data.length>0)
	   {
		   for(var i=0;i <data.length;i++)
		   {
			   var cartItem =`<div class="col-4 col-m-6 col-s-12">
               <div id="0" class="product-corgi">
                   <div class="product-img col-12">
                       <a href="ProductDetail.html"><img class="product-img" src="${data[i].imglink}" /></a>
                   </div>
                   <div class="product-name"><a href="ProductDetail.html" class="p-name">${data[i].name}</a></div>
                   <div class="product-price"><label class="price">${data[i].price}</label></div>
                   <div><button class="btn-buy">THÊM VÀO GIỎ HÀNG</button></div>
               </div>
           </div>`
			   content +=cartItem;
               
		   }
	   }
	   else{
		   content +="<h5>Không tìm thấy sản phẩm<h5>"
	   }
	   console.log(content);
	   $("#search-re").html(content);
	   document.getElementById("product").style.display="none";
	});
});