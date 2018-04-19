'use strict';

$.ajax({
    url: "http://localhost:49608/api/mortgage",
    type: 'GET',
    dataType: 'json',
    success: function (data) {

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
                columnDefs: [
                    { width: 800, targets: 0 }
                ],
                fixedColumns: true,
                "columns": [
                    { "data": "name" },
                    { "data": "mortgageType" },
                    { "data": "interestRepayment" },
                    {
                        "data": "effectiveStartDate",
                        "render": function (row) {
                            return moment(row).format('MM/DD/YYYY');
                        }
                    },
                    {
                        "data": "effectiveEndDate", "render": function (row) {
                            return moment(row).format('MM/DD/YYYY');
                        }
                    },
                    { "data": "interestRate" },
                    { "data": "termsInMonths" },
                    { "data": "cancellationFee" },
                    { "data": "establishmentFee" }

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

$.ajax({
    url: $baseApiUrl + 'mortgage/type',
    type: "GET",
    dataType: "json",
    // data: { id: request },
    contentType: "application/json; charset=utf-8",
    success: function (data) {

        var option_list = data;

        $("#option-mortgagetype").empty();
        for (var i = 0; i < option_list.length; i++) {
            $("#option-mortgagetype").append(
                $("<option></option>").attr(
                    "value", option_list[i].key).text(option_list[i].value)
            );
        }
        $('#option-mortgagetype').prop('selectedIndex', 0);


    },
    error: function (response) {
        alert(response.responseText);
    },
    failure: function (response) {
        alert(response.responseText);
    }
});


var loanAmount = $("#loan-amount");

$("#slider-loan-amount").slider({
    range: "max",
    min: 100000,
    max: 5000000,
    value: 1000000,
    step: 100000,
    create: function () {
        loanAmount.text($(this).slider("value"));
    },
    slide: function (event, ui) {
        loanAmount.text(ui.value);
    },
    stop: function () {
        LoanCalculation();
    }
});


var loanyear = $("#loan-year");

$("#slider-year").slider({
    range: "max",
    min: 1,
    max: 35,
    value: 20,
    step: 1,
    create: function () {
        loanyear.text($(this).slider("value"));
    },
    slide: function (event, ui) {
        loanyear.text(ui.value);
    },
    stop: function () {
        LoanCalculation();
    }
});

GetInterestRates("0");
$('#option-mortgagetype').change(function () {
    var selectedMortgageType = $("#option-mortgagetype option:selected").val();
    GetInterestRates(selectedMortgageType);
});



function GetInterestRates(mortgageType) {
    if (mortgageType !== "") {
        switch (mortgageType) {
            case "0":
                $("#interest-rate").text("8.50");
                break;
            case "1":
                $("#interest-rate").text("10.99");
                break;
        }

        LoanCalculation();
    }
}



$("#btn-loan-calculate").click(function () {

    //  LoanCalculation();
});

function LoanCalculation() {
    var loanAmount = $("#slider-loan-amount").slider("value");
    var loanTenure = $("#slider-year").slider("value");
    var numberOfMonths = loanTenure * 12;
    var rateOfInterest = $("#interest-rate").text();
    var monthlyInterestRatio = (rateOfInterest / 100) / 12;

    var top = Math.pow((1 + monthlyInterestRatio), numberOfMonths);
    var bottom = top - 1;
    var sp = top / bottom;
    var emi = ((loanAmount * monthlyInterestRatio) * sp);
    var totalRepayment = (numberOfMonths * emi);
    var totalInterest = totalRepayment - loanAmount;

    $("#btn-total-interest").text($.number(totalInterest.toFixed(0)));
    $("#btn-total-repayment").text($.number(totalRepayment.toFixed(0)));

}
