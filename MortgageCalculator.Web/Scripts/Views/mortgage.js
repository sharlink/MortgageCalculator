
$.ajax({
    url: "http://localhost:49608/api/mortgage",
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        responsiveHelper_dt_basic = undefined;
        var table = $('#table-mortgage').dataTable({
            "bDestroy": true
        }).fnDestroy();

        if (data != "No record available") {

            table = $('#table-mortgage').dataTable({

                "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
                    "t" +
                    "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                "autoWidth": true,
                processing: true,
                "scrollX": true,
                "data": data,
                "columns": [
                    { "data": "name" }, { "data": "mortgageType" },
                    { "data": "interestRepayment" }, {
                        "data": "effectiveStartDate", "render": function (row) {
                            return moment(row).format('MM/DD/YYYY');
                        }
                    },
                    {
                        "data": "effectiveEndDate", "render": function (row) {
                            return moment(row).format('MM/DD/YYYY');
                        }
                    },
                    { "data": "termsInMonths" }, { "data": "cancellationFee" }, { "data": "establishmentFee" }

                ]

            });


        }
        else {
            table = $('#table-mortgage').DataTable({
                "language": {
                    "zeroRecords": "No records available"
                },
                "data": []
            });
        }
    }
});


//var table = $("#table-mortgage").dataTable({
//    "processing": true,
//    "serverSide": true,
//    "ajax": {
//        "url": $baseApiUrl + "mortgage"
//    },
//    "columns": [
//        { "data": "name" }, { "data": "name" }, { "data": "name" },
//        { "data": "name" }, { "data": "name" }, { "data": "name" },
//        { "data": "name" }, { "data": "name" }, { "data": "name" },
//        { "data": "name" }
//    ],
//    "language": {
//        "emptyTable": "There are no customers at present.",
//        "zeroRecords": "There were no matching customers found."
//    },
//    "searching": false,
//    "ordering": true,
//    "paging": true
//});



    //$.ajax({
    //    type: "GET",
    //    url: $baseApiUrl + "mortgage",
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {

    //        console.log(data);
    //    }, //End of AJAX Success function  

    //    failure: function (data) {
    //        alert(data.responseText);
    //    }, //End of AJAX failure function  
    //    error: function (data) {
    //        alert(data.responseText);
    //    } //End of AJAX error function  

    //});  

