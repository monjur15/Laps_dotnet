var LaptopSummaryManager = {
    gridDataSource: function () {

        var gridData = new kendo.data.DataSource({
            type: "json",
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true,
            allowUnsort: true,
            pageSize: 10,
            transport: {
                read: {
                    url: '../Laptop/LaptopInfoGrid/',
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
    }
};
var LaptopSummaryHelper = {
    GenerateLaptopSummaryGrid: function () {

        $("#LpSummaryDiv").kendoGrid({

            dataSource: LaptopSummaryManager.gridDataSource(),
            pageable: {
                refresh: true,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            },
            xheight: 450,
            filterable: true,
            sortable: true,
            columns: LaptopSummaryHelper.GenerateLaptopColumns(),
            editable: false,
            navigatable: true,
            selectable: "row"
        })

    },

    GenerateLaptopColumns: function () {
        return columns = [


            { field: "LaptopId", title: "LaptopId", hidden: true, width: 100 },
            { field: "ModelName", title: "LaptopName", width: 100 },
            { field: "BrandId", title: "Brand", width: 100 },
            { field: "ColorId", title: "Color", width: 100 },
            { field: "Price", title: "Price", width: 100, sortable: true },
            { field: "IsW", title: "IsW", width: 60, sortable: false },
            { field: "IsActive", title: "IsActive", width: 60, sortable: false, },
            { field: "Edit", title: "Edit", filterable: false, width: 50, template: '<button type="button" class="k-button" value="Edit" id="btnEdit" onClick="LaptopSummaryHelper.clickEventForEditButton()" ><span class="k-icon k-i-pencil"></span></button>', sortable: false },
            { field: "Delete", title: "Delete", filterable: false, width: 50, template: '<button type="button" class="k-button" value="Delete" id="btnDelete"  ><span class="k-icon k-i-pencil"></span></button>', sortable: false },

        ];
    },

    clickEventForEditButton: function () {
        var gridData = $("#LpSummaryDiv").data("kendoGrid");
        var selectedData = gridData.dataItem(gridData.select());

        $("#hdnLaptopId").val(selectedData.MobileId);

        $("#txtModelName").val(selectedData.ModelName);
        $("#cLpBrand").data("kendoComboBox").value(selectedData.BrandId);
        $("#cLpColor").data("kendoComboBox").value(selectedData.ColorId);
        $("#txtPrice").val(selectedData.Price);
        if (selectedData.IsW == 1)
            $("#IsW").prop("checked", true);
        else
            $("#IsW").prop("checked", false);

        if (selectedData.Is5G == 1) {
            $("#chkIsLatest").prop("checked", true);
        }
        else {
            $("#chkIsLatest").prop("checked", true);

        }

    }

};