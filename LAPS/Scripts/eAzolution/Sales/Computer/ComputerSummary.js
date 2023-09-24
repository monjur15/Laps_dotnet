var ComputerSummaryManager = {
    gridDataSource: function () {
        debugger;
        var gridData = new kendo.data.DataSource({
            type: "json",
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true,
            allowUnsort: true,
            pageSize: 10,
            transport: {
                read: {
                    url: '../Computer/ComputerInfoGrid/',
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8"
                },
                parameterMap: function (options) {
                    return JSON.stringify(options);
                }
            },
            schema: { data: "Items", total: "TotalCount" }
        });
        return gridData;
    },

    clickEventForDeleteButton: function () {
        var gridData = $("#cmpSummaryDiv").data("kendoGrid");
        var selectedData = gridData.dataItem(gridData.select());
        if (selectedData != null) {
            ComputerSummaryManager.Delete(selectedData.ComputerId);
        }
    },

    Delete: function (id) {
        var jsonParam = 'id:' + id;
        var serviceUrl = "../Computer/DeleteComputerInfo";
        AjaxManager.SendJson2(serviceUrl, jsonParam, onSuccess, onFailed);

        function onSuccess(jsonData) {
            if (jsonData == "Success") {
                AjaxManager.MsgBox('success', 'center', 'Success:', 'Computer Deleted Successfully',
                    [
                        {
                            addClass: 'btn btn-primary',
                            text: 'OK',
                            onClick: function ($notify) {
                                $notify.close();
                                $("#cmpSummaryDiv").data("kendoGrid").dataSource.read();
                                ComputerDetailsHelper.ClearForm();
                            }
                        }
                    ]);
            }
            else {
                AjaxManager.MsgBox('error', 'center', 'Error', jsonData,
                    [
                        {
                            addClass: 'btn btn-primary',
                            text: 'OK',
                            onClick: function ($notify) {
                                $notify.close();
                            }
                        }
                    ])
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
    }
};
var ComputerSummaryHelper = {

    GenerateComputerSummaryGrid: function () {

        $("#cmpSummaryDiv").kendoGrid({

            dataSource: ComputerSummaryManager.gridDataSource(),
            pageable: {
                refresh: true,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            },
            xheight: 450,
            filterable: true,
            sortable: true,
            columns: ComputerSummaryHelper.GenerateComputerColumns(),
            editable: false,
            navigatable: true,
            selectable: "row"
        })

    },


    GenerateComputerColumns: function () {
        return columns = [


            { field: "ComputerId", title: "ComputerId", hidden: true, width: 100 },
            { field: "ModelName", title: "ModelName", width: 150 },
            { field: "Brand", title: "Brand", width: 100 },
            { field: "Color", title: "Color", width: 100 },
            { field: "Price", title: "Price", width: 100, sortable: true },
            { field: "Is5G", title: "Is5G", width: 60, sortable: false },
            /*{ field: "IsSmart", title: "IsSmart", width: 60, sortable: false, },*/
            { field: "Edit", title: "Edit", filterable: false, width: 95, template: '<button type="button" class="k-button" value="Edit" id="btnEdit" onClick="ComputerSummaryHelper.clickEventForEditButton()" ><span class="k-icon k-i-pencil"></span></button>', sortable: false },
            { field: "Delete", title: "Delete", filterable: false, width: 95, template: '<button type="button" class="k-button" value="Delete" id="btnDelete" onClick="ComputerSummaryManager.clickEventForDeleteButton()" ><span class="k-icon k-i-pencil"></span></button>', sortable: false },

        ];
    },

    clickEventForEditButton: function () {
        var gridData = $("#cmpSummaryDiv").data("kendoGrid");
        var selectedData = gridData.dataItem(gridData.select());

        $("#hdnComputerId").val(selectedData.ComputerId);

        $("#txtModelName").val(selectedData.ModelName);
        $("#cmbBrand").data("kendoComboBox").value(selectedData.BrandId);
        $("#cmbColor").data("kendoComboBox").value(selectedData.ColorId);
        $("#txtPrice").val(selectedData.Price);
        //if (selectedData.IsSmart == 1)
        //    $("#chkIsSmart").prop("checked", true);
        //else
        //    $("#chkIsSmart").prop("checked", false);

        if (selectedData.Is5G == 1) {
            $("#rd5G").prop("checked", true);
        }
        else {
            $("#rdnot5G").prop("checked", true);

        }

    }
};