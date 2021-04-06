(function ($, undefined) {
    var Form = function ($element, options) {
        $.extend(this, $.fn.ListOfOrders.defaults, $element.data(), typeof options === 'object' && options);
        this.setControls({
            form: $element
            , SeccDivtbProductsOrdersList: $('#SeccDivtbProductsOrdersList', $element)
            , SeccDivtbOrdersList: $('#SeccDivtbOrdersList', $element)
            , lblNroOrder: $('#lblNroOrder', $element)
            , lblContactName: $('#lblContactName', $element)
            , txtDateConfirmation: $('#txtDateConfirmation', $element)
            , chkConfirm: $('#chkConfirm', $element)
            , txtTotal: $('#txtTotal', $element)
            , txtCommentary: $('#txtCommentary', $element)
            , btnSave: $('#btnSave', $element)

        });

    };

    Form.prototype = {
        constructor: Form,
        init: function () {
            var that = this,
                controls = this.getControls();
            that.InitLoadPage();
        },

        InitLoadPage: function(){
            var that = this,
                controls = that.getControls();
            controls.chkConfirm[0].checked = true;
            that.GetListOfOrders();
            that.tblSelectTableOrders();
            controls.SeccDivtbProductsOrdersList.hide();
            that.btnSave_click();

        },

        GetListOfOrders: function () {
            console.log("Ingreso mètodo GetListOfOrders");
            var that = this,
                controls = that.getControls();

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                async: true,
                url: '/Orders/GetListOfOrders',
                //data: JSON.stringify(),

                success: function (response) {
                    console.log("Ingresoooo2222");
                    if (response != null) {
                        console.log("Ingresoooo333");
                        data = response.data;
                        console.log("Cantidad de datos: ", data);
                        $("#divtbOrdersList").DataTable({
                            "scrollY": "200px",
                            "scrollCollapse": true,
                            "paging": false,
                            "searching": false,
                            "destroy": true,
                            "scrollX": true,
                            "sScrollXInner": "100%",
                            "autoWidth": true,
                            "select": {
                                "style": "os",
                                "info": false
                            },
                            data: data,
                            language: {
                                "lengthMenu": "Display _MENU_ records per page",
                                "zeroRecords": "No existe datos",
                                "info": " ",
                                "infoEmpty": " ",
                                "infoFiltered": "(filtered from _MAX_ total records)"
                            },
                            columns: [
                                { "data": "OrderID" }, // Nro Orden
                                { "data": "OrderDate" }, // Fecha
                                { "data": "ContactName" }, // Nombre/Razon Social
                                { "data": "Phone" } // Telefono
                            ],
                            "columnDefs": [{
                                "orderable": false,
                                "className": "",
                                "targets": 0,
                                "defaultContent": "",
                                "visible": true
                            }
                            ]
                        });

                    }

                }
            });
        },

        tblSelectTableOrders: function(){
            var that = this,
                controls = that.getControls();
            var total = 0;
            var table = $('#divtbOrdersList').dataTable();
            $('#divtbOrdersList').on('click', 'tbody tr', function () {
                controls.txtTotal.prop("disabled", true);
                let currentTr = $(this).parents("tr")[0] || $(this)[0];
                console.log("currentTr: ", currentTr);
                if (!$(currentTr).hasClass("selected")) {
                    var currentData = table.fnGetData(table.fnGetPosition(currentTr));
                    console.log("currentData : ", currentData);

                    var paramOrder = {
                        orderID: currentData.OrderID,
                    };

                    console.log("currentData2 : ", paramOrder);
                    var strContactName = currentData.ContactName;
                    console.log("strContactName : ", strContactName);
                        controls.SeccDivtbProductsOrdersList.show();
                        controls.SeccDivtbOrdersList.hide();
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            async: true,
                            url: '/Orders/GetListProductOrders',
                            data: JSON.stringify(paramOrder),

                            success: function (response) {
                                console.log("Ingresoooo2222");
                                if (response != null) {
                                    console.log("Ingresoooo333");
                                    data = response.Data;
                                    controls.lblNroOrder.html(currentData.OrderID);
                                    controls.lblContactName.html(strContactName);
                                    $("#divtbProductsOrdersList").DataTable({
                                        "scrollY": "200px",
                                        "scrollCollapse": true,
                                        "paging": false,
                                        "searching": false,
                                        "destroy": true,
                                        "scrollX": true,
                                        "sScrollXInner": "100%",
                                        "autoWidth": true,
                                        "select": {
                                            "style": "os",
                                            "info": false
                                        },
                                        data: data,
                                        language: {
                                            "lengthMenu": "Display _MENU_ records per page",
                                            "zeroRecords": "No existe datos",
                                            "info": " ",
                                            "infoEmpty": " ",
                                            "infoFiltered": "(filtered from _MAX_ total records)"
                                        },
                                        columns: [
                                            { "data": "ProductID" }, // Pedido
                                            { "data": "ProductName" }, // Nombre producto
                                            { "data": "Quantity" }, // Cantidad
                                            { "data": "UnitPrice" }, // Precio
                                            { "data": "Total" } //Total
                                        ],
                                        "columnDefs": [{
                                            "orderable": false,
                                            "className": "",
                                            "targets": 0,
                                            "defaultContent": "",
                                            "visible": true
                                        }
                                        ],
                                        "footerCallback": function () {

                                            total = this.api()
                                                .column(4)
                                                .data()
                                                .reduce(function (a, b) {
                                                    return parseInt(a) + parseInt(b);
                                                }, 0);
                                            console.log("Resultado total :", total);
                                            controls.txtTotal.val(total);  

                                        }
                                    });

                                    

                                }

                            }
                        });
                }
            });           
        },

        btnSave_click: function () {
            var that = this,
                controls = that.getControls();

            controls.btnSave.on('click', function () {

                if (controls.txtDateConfirmation.val() == "") {
                    alert("Por favor ingrese fecha")
                    return false;
                }
                if (controls.txtCommentary.val() == "") {
                    alert("Por favor ingrese comentario");
                    return false;
                }
                var obj = {};

                obj.DateConfirmation = controls.txtDateConfirmation.val();
                if(controls.chkConfirm[0].checked){
                    obj.Confirmed = 1;
                }else{
                    obj.Confirmed = 0;
                }
                obj.Comments = controls.txtCommentary.val();

                console.log("obj :", obj);
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    async: true,
                    url: '/Orders/GetRegistertProductOrders',
                    data: JSON.stringify(obj),
                    
                    success: function (response) {
                        if (response != null) {
                            if (response.data.split("|")[0]) {
                                alert(response.data.split("|")[1]);
                                that.cleanFiels();
                                controls.btnSave.prop("disabled", true);
                                controls.txtDateConfirmation.prop("disabled", true);
                                controls.txtCommentary.prop("disabled", true);

                            } else {
                                alert("Error al confirmar pedido");
                                that.cleanFiels();
                                controls.btnSave.prop("disabled", true);
                            }
                        } else {
                            alert("Error al confirmar pedido");
                            that.cleanFiels();
                            controls.btnSave.prop("disabled", true);
                        }

                    }
                })

            });
            
        },

        cleanFiels: function(){
            var that = this,
                controls = that.getControls();

            controls.txtDateConfirmation.val('');
            controls.txtCommentary.val('');
        },

        setControls: function (value) {
            this.m_controls = value;
        },

        getControls: function () {
            return this.m_controls || {};
        },
    };

    $.fn.ListOfOrders = function () {

        var option = arguments[0],
            args = arguments,
            value,
            allowedMethods = [];

        this.each(function () {
            var $this = $(this),
                data = $this.data('ListOfOrders'),
                options = $.extend({}, $.fn.ListOfOrders.defaults,
                    $this.data(), typeof option === 'object' && option);

            if (!data) {
                data = new Form($this, options);
                $this.data('ListOfOrders', data);
            }

            if (typeof option === 'string') {
                if ($.inArray(option, allowedMethods) < 0) {
                    throw "Unknown method: " + option;
                }
                value = data[option](args[1]);
            } else {
                data.init();
                if (args[1]) {
                    value = data[args[1]].apply(data, [].slice.call(args, 2));
                }
            }

        });
        return value || this;
    };

    $.fn.ListOfOrders.defaults = {
    }

    $('#ListOfOrders').ListOfOrders();


})(jQuery);