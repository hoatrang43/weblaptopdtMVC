/* var data=[];
    $('.add-bottom .btn-save').click(function AddSP(){
       count ++;
       var maSP=document.getElementById('ma').Val();
        var loai=document.getElementById('loai').Value;
        var ten=document.getElementById('name').Val();
        var gia=document.getElementById('price-product').Value;
        var anh=document.getElementById('picture');
        var item={
            maSP: maSP,
            loai: loai,
            ten: ten,
            gia: gia,
            anh: anh

        };
        var dataListTag=document.getElementById('dataList');
        dataListTag.innerHTML +=`<tr>
            <td>${count}</td>
            <td>${maSP}</td>
            <td>${loai}</td>
            <td>${ten}</td>
            <td>${gia}</td>
            <td>${anh}</td>     
            </tr>`; 
        console.log(this.data); 
    }) */

    var data=[];
    $('.add-bottom .btn-save').click(function AddSP(){
       count ++;
       var maSP=document.getElementById('ma').Val();
        var loai=document.getElementById('loai').Val();
        var ten=document.getElementById('name').Val();
        var gia=document.getElementById('price-product').Val();
        var anh=document.getElementById('picture');
       
        var dataListTag=document.getElementById('dataList');
        dataListTag.innerHTML +=`<tr>
            <td>${count}</td>
            <td>${maSP}</td>
            <td>${loai}</td>
            <td>${ten}</td>
            <td>${gia}</td>
            <td>${anh}</td>     
            </tr>`; 
        console.log(this.data); 
    })
/* var data=[];
   function AddSP(){
       count ++;
       var sp='';
       for( var sanpham of data){
           sp+='<tr>';
           sp+='<td>'+count+'</td>';
           sp+='<td>'+sanpham.maSP+'</td>';
           sp+='<td>'+sanpham.loai+'</td>';
           sp+='<td>'+sanpham.ten+'</td>';
           sp+='<td>'+sanpham.gia+'</td>';
           sp+='<td>'+sanpham.anh+'</td>';
           sp+='</tr>';
       }
       var dataListTag=document.getElementById('dataList');
       dataListTag.innerHTML=sp;
    }
    function onClickCreateSP(){
        var maSP=document.getElementById('ma').Value;
        var loai=document.getElementById('loai').Val();
        var ten=document.getElementById('name').Val();
        var gia=document.getElementById('price-product').Val();
        var anh=document.getElementById('picture');
    }
    console.log(maSP);
    console.log(loai); */
      /*  var maSP=document.getElementById('ma').Value();
        var loai=document.getElementById('loai').Value();
        var ten=document.getElementById('name').Value();
        var gia=document.getElementById('price-product').Value;
        var anh=document.getElementById('picture');
        var item={
            maSP: maSP,
            loai: loai,
            ten: ten,
            gia: gia,
            anh: anh

        };
        var dataListTag=document.getElementById('dataList');
        dataListTag.innerHTML +=`<tr>
            <td>${count}</td>
            <td>${maSP}</td>
            <td>${loai}</td>
            <td>${ten}</td>
            <td>${gia}</td>
            <td>${anh}</td>     
            </tr>`;  */
    