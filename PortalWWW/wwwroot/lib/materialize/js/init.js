$(function () {
	menu();
	
	$('select').formSelect();
	//modalsCheckCreate();
	//modalsAlertDelete();
	//selectedCategoryinProduct();
	//colassiableAddProduct();
	$('.collapsible').collapsible();
});


//saidenav menu 
function menu() {
	$('.sidenav').sidenav();
	$('#sidenav').sidenav({ edge: 'left' });
}
function activeSelected() {
	
}
