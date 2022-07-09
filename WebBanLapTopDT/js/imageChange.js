function ChangeImage(id){
   var image= document.getElementById(id).getAttribute('src');
   document.getElementById('img-main').setAttribute('src',image);
}