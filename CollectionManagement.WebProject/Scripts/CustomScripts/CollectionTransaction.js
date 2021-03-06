﻿/// <reference path="../jquery-1.10.2.min.js" />

var i = 1;
$('#DepartmentId').change(function () {

    var val = $(this).val();
    if (val != "") {
        $.ajax({
            url: '/Dashboard/GetServiceByDept',
            type: 'post',
            async: false,
            data: { deptId: val },
            success: function (result) {
                if (result != '') {
                    var v = i;
                    while (v >= 1) {
                        $('[id*=ServiceId').html('');
                        $('[id*=ServiceId').append('<option value="0">Select Service</option>');
                        // Loop through each of the results and append the option to the dropdown
                        $.each(result, function (k, a) {
                            $('[id*=ServiceId').append('<option value="' + a.ServiceId + '">' + a.ServiceNameEnglish + '</option>');
                        });
                        v = v - 1;
                    }


                }
            }

        });
    }
});

$('#btn-addNewRow').click(function () {
    i = i + 1;
    if ($('.service-rows tbody tr').length == 1) { $('[id*=btn-removeRow').show(); }
    $('.service-rows tbody').append(
        '<tr class="row_' + i + '">' +
        '<td><select class="form-control serviceDD" id="ServiceId' + i + '" name="ServiceId' + i + '" onchange="return changeInService(this);" ><option value="" >Select Service</option></select></td >' +
        '<td><input autocomplete="off" class="form-control text-box single-line objectCode" id="ObjectCode' + i + '" name="ObjectCode' + i + '" placeholder="Object Code" type="text" value="" readonly="readonly"></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line rateTxt numeric" id="Rate' + i + '" name="Rate' + i + '" placeholder="Rate" type="text" value="" onblur="return calculateAmount(this);"></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line quantityTxt numeric" id="Quantity' + i + '" name="Quantity' + i + '" placeholder="Quantity" type="text" value=""  onblur="return calculateAmount(this);"></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line amountTxt" id="Amount' + i + '" name="Amount' + i + '" placeholder="Amount" type="text" value="" readonly="readonly"></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line remarksTxt" id="Remarks' + i + '" name="Remarks' + i + '" placeholder="Remarks" type="text" value=""></td>' +
        '<td><button type="button" class="btn btn-warning mr-1" id="btn-removeRow' + i + '" onclick="return removeRow(this);"><i class="icon-delete"></i> Delete</button></td></tr>'
    );
    if ($('#DepartmentId').val() != "") {
        $.ajax({
            url: '/Dashboard/GetServiceByDept',
            type: 'post',
            async: false,
            data: { deptId: $('#DepartmentId').val() },
            success: function (result) {
                if (result != '') {
                    $('#ServiceId' + i).html('');
                    $('#ServiceId' + i).append('<option value="0">Select Service</option>');
                    // Loop through each of the results and append the option to the dropdown
                    $.each(result, function (k, v) {
                        $('#ServiceId' + i).append('<option value="' + v.ServiceId + '">' + v.ServiceNameEnglish + '</option>');
                    });
                }
            }

        });
    }
});

function removeRow(obj) {
    var elem = $(obj).parent().parent();

    $(elem).remove();
    i = i - 1;
    if (i >= 2) { $('#btn-removeRow1').show(); }
    else { $('#btn-removeRow1').hide(); }
    if ($('.service-rows tbody tr').length == 1) {
        $('[id*=btn-removeRow').hide();
    }
}

$('#btn-SaveForm').click(function (e) {
    var hasError = false;
    $('#validationMsg').text('');
    if ($("#applicationForm").valid()) {
        e.preventDefault(); //Stop default form submission
        var formData = new FormData();
        var other_data = $('form').serializeArray();
        $.each(other_data, function (key, input) {
            formData.append(input.name, input.value);
        });
        var index = 0;
        $.each($('.service-rows tbody tr'), function (k, v) {
            if ($(this).children().children('.serviceDD').val() == "0" || $(this).children().children('.rateTxt').val() == ""
                || $(this).children().children('.quantityTxt').val() == "") {
                $('#validationMsg').text('Please enter service details.');
                e.preventDefault();
                hasError = true;
            }
            else {
                formData.append("TransactionServiceModelList[" + index + "].ServiceId", $(this).children().children('.serviceDD').val());
                formData.append("TransactionServiceModelList[" + index + "].Rate", $(this).children().children('.rateTxt').val());
                formData.append("TransactionServiceModelList[" + index + "].Quantity", $(this).children().children('.quantityTxt').val());
                formData.append("TransactionServiceModelList[" + index + "].Remarks", $(this).children().children('.remarksTxt').val());
            }
            index++;
        });
        if (!hasError) {
            $.ajax({
                url: '/Dashboard/AddApplicationForm',
                type: 'post',
                async: false,
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (result) {
                    $('#customMsg').text(result.result);
                    $('.alert').show();
                }
            });

            setTimeout(
                function () {
                    window.location.href = '/Dashboard/Index';
                }, 8000);
        }
    }
});

$('#btn-cancelForm').click(function () {
    window.location.href = '/Dashboard/Index';
});


//$('.quantityTxt').blur(function () {
//    var totalAmount = 0;
//    $.each($('.service-rows tbody tr'), function (k, v) {
//        var rate = $(this).children().children('.rateTxt').val();
//        var quantity = $(this).children().children('.quantityTxt').val();

//        if ($.isNumeric(rate) && $.isNumeric(quantity)) {
//            totalAmount = rate * quantity;
//        }
//    });
//    $('#TotalAmount').val(totalAmount);
//});

//$('.serviceDD').change(function () {
function changeInService(obj) {
    var val = $(obj).val();
    var attrId = $(obj).attr('id');
    if (val != "") {
        $.ajax({
            url: '/Dashboard/GetServiceDetailsById',
            type: 'post',
            async: false,
            data: { serviceId: val },
            success: function (result) {
                if (result != '') {
                    $('#' + attrId).parent().parent().children().children('.objectCode').val(result);
                }
            }

        });
    }
}
//});

function calculateAmount(obj) {
    // $('.amountTxt').blur(function () {
    var totalAmount = 0;
    var amount = 0;
    var attrId = $(obj).attr('id');
    var attrClass = $(obj).attr('class');
    var rate = 0;
    var quantity = 0;
    if (attrClass.indexOf("quantityTxt") > -1) {
        rate = $(obj).parent().parent('tr').find('.rateTxt').val();
        quantity = $(obj).val();
    }
    else if (attrClass.indexOf("rateTxt") > -1) {
        quantity = $(obj).parent().parent('tr').find('.quantityTxt').val();
        rate = $(obj).val();
    }
    if ($.isNumeric(rate) && $.isNumeric(quantity)) {
        amount = rate * quantity;
    }
    $(obj).closest('tr').find('.amountTxt').val(amount.toFixed(2));
    //  });


    $.each($('.service-rows tbody tr'), function (k, v) {
        var rate = $(this).children().children('.rateTxt').val();
        var quantity = $(this).children().children('.quantityTxt').val();

        if ($.isNumeric(rate) && $.isNumeric(quantity)) {
            totalAmount = totalAmount + (rate * quantity);
        }
    });
    $('#TotalAmount').val(totalAmount.toFixed(2));
}


$(".numeric").keydown(function (event) {
    var flag = false;

    if (event.shiftKey == true) {
        event.preventDefault();
    }
    // Allow Only: keyboard 0-9, numpad 0-9, backspace, tab, left arrow, right arrow, delete
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 46) {
        // Allow normal operation
        flag = true;
    } else {
        // Prevent the rest
        event.preventDefault();
    }

    if (flag) {

    }
});