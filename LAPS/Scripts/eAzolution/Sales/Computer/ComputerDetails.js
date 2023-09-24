var ComputerDetailsManager = {
    SaveComputerInfo: function () {

        var object = ComputerDetailsHelper.CreateObjectFromFields();
        //ComputerSummaryHelper.GenerateComputerSummaryGrid();

        var obj = JSON.stringify(object);
        var jsonParam = 'computer:' + obj;
        var serviceUrl = "../Computer/SaveComputerInfo/";
        AjaxManager.SendJson2(serviceUrl, jsonParam, onSuccess, onFailed);

        function onSuccess(jsonData) {
            if (jsonData == "Success") {

                AjaxManager.MsgBox('success', 'center', 'Success:', 'Computer Info Save Successfully',
                    [
                        {
                            addClass: 'btn btn-primary',
                            text: 'Ok',
                            onClick: function ($noty) {
                                $noty.close();
                                return null;
                                $("#cmpSummaryDiv").data("kendoGrid").dataSource.read();
                                ComputerSummaryHelper.GenerateComputerSummaryGrid();
                                ComputerDetailsHelper.ClearForm();
                            }
                        }
                    ]);
            } else {
                AjaxManager.MsgBox('error', 'center', 'Error', jsonData,
                    [
                        {
                            addClass: 'btn btn-primary',
                            text: 'Ok',
                            onClick: function ($noty) {
                                $noty.close();
                            }
                        }
                    ]);
            }

        }
        function onFailed(error) {
            AjaxManager.MsgBox('error', 'center', 'Error', error.statusText,
                [{
                    addClass: 'btn btn-primary', text: 'Ok', onClick: function ($noty) {
                        $noty.close();
                    }
                }]);
        }

        //ComputerSummaryHelper.GenerateComputerSummaryGrid();

    }

};
var ComputerDetailsHelper = {
    PopulateColorCombo: function () {
        var objColors = new Object();
        objColors = AjaxManager.GetDataSource("../Computer/PopulateColorCombo");

        $("#cmbColor").kendoComboBox({
            placeholder: "Select Color",
            dataValueField: "ColorId",
            dataTextField: "Color",
            dataSource: objColors,
            filter: "contains",
        

        })
    },
    //For Brand Combo
    PopulateBrandCombo: function () {
        var objBrands = new Object();
        objBrands = AjaxManager.GetDataSource("../Computer/PopulateBrandCombo");

        $("#cmbBrand").kendoComboBox({
            placeholder: "Select Brand",
            dataValueField: "BrandId",
            dataTextField: "Brand",
            dataSource: objBrands,
            filter: "contains",
          
        })
    },

    CreateObjectFromFields: function () {
        /*debugger;*/
        var object = new Object();

        object.ComputerId = $("#hdnComputerId").val();
        object.ModelName = $('#txtModelName').val();
        object.BrandId = $('#cmbBrand').val();
        object.ColorId = $('#cmbColor').val();
        object.Price = $('#txtPrice').val();
        object.Is5G = $('input[name="Is5G"]:checked').val();
        /*object.IsSmart = $("#chkIsSmart").is(":checked") == true ? 1 : 0*/

        return object;
    },

    ClearForm: function () {
        /*debugger;*/
        $("#hdnComputerId").val(0);
        $("#txtModelName").val("");
        $("#cmbBrand").data("kendoComboBox").value("");
        $("#cmbColor").data("kendoComboBox").value("");
        $("#txtPrice").val("");
        $('input[name=Is5G]').attr('checked', false);

        $("#btnSave").text("Save");
        $("#btnClearAll").text("Clear");
    },

    //ValidateMobileInfo: function () {
    //    var data = [];
    //    var validator = $("#MobileDetailsDiv").kendoValidator().data("kendoValidator"),
    //        status = $(".status");
    //    if (validator.validate()) {
    //        status.text("").addClass("valid");
    //        return true;
    //    }
    //    else {
    //        status.text("Opos! There is invalid data in the form.)
    //    }

    //},



    //clearMobileForm: function () {
    // $("#hdnMobileId").val("");
    // $("#txtModelName").val("");
    // $("#txtBrandId").data("kendoComboBox").val("");
    // $("#txtColorId").data("kendoComboBox").val("");
    // $("#txtMobilePrice").val("");           
    // $("#MobileModelDetailsDiv").data('kendoGrid').dataSource.data("");
    // $("#MobileDetailsDiv > form").kendoValidator();
    // $("#MobileDetailsDiv").find("span.k-tooltip-validation").hide();     
    // $('input[name="Is5G"]:checked').val();
    // $("#chkIsSmart").is(":checked") == true ? 1 : 0
    // var status = $(".status");
    // status.text("").removeClass("invalid");

    //For Brand and Color Combo
    PopulateBrandandColorCombo: function () {
        var objBrandsandColors = new Object();
        objBrandsandColors = AjaxManager.GetDataSource("../Computer/ComputerBrandandColorMaping");

        //$("#cmbBrand").kendoComboBox({
        //    placeholder: "Select Brand",
        //    dataValueField: "BrandId",
        //    dataTextField: "Brand",
        //    dataSource: objBrands,
        //    filter: "contains",

        //})
    },
};



