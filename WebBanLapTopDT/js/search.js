$(document).ready(function(){
	$('#btn-search').on("click",function(){
	   var value =$(".txt").val().toLowerCase();
	   var data = [];
	   var d = 0;
	   var p = 20;
	   var content ="<h2>Kết Qủa Tìm Kiếm</h2>";
	   for(var i=0;i < p; i++){
		   $("#"+i).filter(function(){
			   if($("#" +i+" .product-name").text().toLowerCase().indexOf(value)>-1){
				   var imglink =$("#"+i).find(".product-img").attr('src');
				   var name=$("#"+i).find(".product-name").text();
                   var old=$("#"+i).find(".old-price").text();
				   var price=$("#"+i).find(".price").text();
				   var order={
					   'imglink':imglink,
					   'name':name,
                       'old':old,
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
			   var cartItem =`<div class="col-3 col-m-4 col-s-6">
				   <div id="0" class="product">
					   <img class="product-img" src="${data[i].imglink}" /><br/>
					   <a href="#"> <label class="product-name">${data[i].name}</label></a><br />
					   Gía Cũ: <s class="old-price">${data[i].old}</s><br/>
					   Gía Mới: <label class="price">${data[i].price}</label><br/>
					   <input class="btn-buy" type="button" value="ĐẶT MUA" ></input>
					   <input class="btn-view" type="button" value="CHI TIẾT" ></input>		
				   </div>
			   </div>`
			   content +=cartItem;
		   }
	   }
	   else{
		   content +="<h1>Không tìm thấy sản phẩm<h1>"
	   }
	   console.log(content);
	   $("#search-re").html(content);
	   document.getElementById("main").style.display="none";
	   document.getElementById("search-re").style.display="block";
	});
});