function ChangeImage(id){
    var image= document.getElementById(id).getAttribute('src');
    document.getElementById('product-imgbig').setAttribute('src',image);
}