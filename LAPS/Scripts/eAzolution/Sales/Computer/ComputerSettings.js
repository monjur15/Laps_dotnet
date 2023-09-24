$(document).ready(function () {
    ComputerDetailsHelper.PopulateColorCombo();
    ComputerDetailsHelper.PopulateBrandCombo();

    $("#btnSave").click(function () {
        ComputerDetailsManager.SaveComputerInfo();
    });
    ComputerSummaryHelper.GenerateComputerSummaryGrid();
    /* $("#btnClearAll").click(function () {
         ProductsDetailsHelper.clearProductsForm();
     });
     */

    //$("#btnEdit").click(Function(){
    //MobileDetailsManager.EditMobileInfo();
    //});

    //ComputerSummaryHelper.GenerateComputerSummaryGrid();
    //ProductModelDetailsHelper.GenerateProductModelGrid(0);

});