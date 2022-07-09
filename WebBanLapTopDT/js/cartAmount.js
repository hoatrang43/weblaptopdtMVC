
$(document).ready(function(){
    Update_Total_Price();
	console.log(formater);
    $('.btn-plus').click(function(){
        var parent = $(this).parent()
        $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val())+1)
        Update_Total_Price()
    })
    $('.btn-sub').click(function(){
        var parent = $(this).parent()
        if(Number($(parent).find('.txt-amount').val()) > 1) {

            $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val())-1)
        }
        Update_Total_Price()
    })
})