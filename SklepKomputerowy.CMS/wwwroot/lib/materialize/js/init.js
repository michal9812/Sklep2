$(function () {
	menu();
	modalsCheckCreate();
	modalsAlertDelete();
	selectedCategoryinProduct();
	colassiableAddProduct();
	$('.collapsible').collapsible();

});
$(document).ready(function () {

});

//saidenav menu 
function menu() {
	$('.sidenav').sidenav();
	$('#sidenav').sidenav({ edge: 'left' });
}
//modals
function modalsCheckCreate() {
	if ((document.referrer.toString().endsWith("Create") == false) || (document.referrer.toString().endsWith("Delete") == false)) {
		const modalListItemCheck = $('#modalListItemCheck')
		modalListItemCheck.modal();
		modalListItemCheck.modal('open');
	}
}
function modalsAlertDelete() {
	$('#modalDeleteAlert').modal();
}
function selectedCategoryinProduct() {

	$("#selectedCategoryName").formSelect();
}
function colassiableAddProduct() {

	$('#colassiableAddProduct').collapsible();
}