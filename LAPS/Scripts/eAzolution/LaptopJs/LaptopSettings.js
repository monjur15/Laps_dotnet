function done(){
    alert("DONE!");
}

$(document).ready(function () {
    debugger;
    LaptopDetailsHelper.PopulateColorCombo();
    LaptopDetailsHelper.PopulateBrandCombo();
    LaptopSummaryHelper.GenerateLaptopSummaryGrid();

    $("#btnSave").click(function () {
        debugger;
        LaptopDetailsManager.SaveLaptopInfo();
        
    });

    /* $("#btnClearAll").click(function () {
         ProductsDetailsHelper.clearProductsForm();
     });
     */

    //$("#btnEdit").click(Function(){
    //MobileDetailsManager.EditMobileInfo();
    //});

   
    //ProductModelDetailsHelper.GenerateProductModelGrid(0);

});
