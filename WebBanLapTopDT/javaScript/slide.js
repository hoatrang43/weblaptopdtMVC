var i=1;
var N=5;

function Next(){
	if(i<N)
	{
		i +=1;
		
	}
	else
	{
		i=1;	
	}
	document.getElementById("slide").setAttribute("src",'Images/Banner/'+i+".jpg")
}
function Back(){
	if(i>1)
		i -=1;
	else
	{
		i=N;
		
	}
	document.getElementById("slide").setAttribute('src','Images/Banner/'+i+'.jpg')
}
function LoadImage(){
	setInterval(Next,3000);//tự động chạy
}
