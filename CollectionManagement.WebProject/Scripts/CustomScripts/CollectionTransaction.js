/// <reference path="../jquery-1.10.2.min.js" />


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
                    $('#ServiceId1').html('');
                    // Loop through each of the results and append the option to the dropdown
                    $.each(result, function (k, v) {
                        $('#ServiceId1').append('<option value="' + v.ServiceId + '">' + v.ServiceNameEnglish + '</option>');
                    });
                }
            }

        });
    }
});
var i = 1;
$('#btn-addNewRow').click(function () {
    i = i + 1;
    $('.service-rows tbody').append(
        '<tr class="row_' + i + '">' +
        '<td><select class="form-control serviceDD" id="ServiceId' + i + '" name="ServiceId' + i + '"><option value="">Select Service</option></select></td >' +
        '<td><input autocomplete="off" class="form-control text-box single-line rateTxt" id="Rate' + i + '" name="Rate' + i + '" placeholder="Rate" type="text" value=""></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line quantityTxt" id="Quantity' + i + '" name="Quantity' + i + '" placeholder="Quantity" type="text" value=""></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line remarksTxt" id="Remarks' + i + '" name="Remarks' + i + '" placeholder="Remarks" type="text" value=""></td>' +
        '<td><button type="button" class="btn btn-warning mr-1" id="btn-removeRow' + i + '" onclick="return removeRow(this);"><i class="icon-delete"></i> Delete</button></td></tr>'
    );

    $.ajax({
        url: '/Dashboard/GetServiceByDept',
        type: 'post',
        async: false,
        data: { deptId: $('#DepartmentId').val() },
        success: function (result) {
            if (result != '') {
                $('#ServiceId' + i).html('');
                // Loop through each of the results and append the option to the dropdown
                $.each(result, function (k, v) {
                    $('#ServiceId' + i).append('<option value="' + v.ServiceId + '">' + v.ServiceNameEnglish + '</option>');
                });
            }
        }

    });
});

function removeRow(obj) {
    var elem = $(obj).parent().parent();
    $(elem).remove();
}

$('#btn-SaveForm').click(function (e) {
    if ($("#applicationForm").valid()) {
        e.preventDefault(); //Stop default form submission
        var formData = new FormData();
        var other_data = $('form').serializeArray();
        $.each(other_data, function (key, input) {
            formData.append(input.name, input.value);
        });
        var index = 0;
        $.each($('.service-rows tbody tr'), function (k, v) {
            formData.append("TransactionServiceModelList[" + index + "].ServiceId", $(this).children().children('.serviceDD').val());
            formData.append("TransactionServiceModelList[" + index + "].Rate", $(this).children().children('.rateTxt').val());
            formData.append("TransactionServiceModelList[" + index + "].Quantity", $(this).children().children('.quantityTxt').val());
            formData.append("TransactionServiceModelList[" + index + "].Remarks", $(this).children().children('.remarksTxt').val());
            index++;
        });

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
});

$('#btn-cancelForm').click(function () {
    window.location.href = '/Dashboard/Index';
});


$('#TotalAmount').blur(function () {
    var totalAmount = 0;
    $.each($('.service-rows tbody tr'), function (k, v) {
        var rate = $(this).children().children('.rateTxt').val();
        var quantity = $(this).children().children('.quantityTxt').val();
       
        if ($.isNumeric(rate) && $.isNumeric(quantity)) {
            totalAmount = rate * quantity;
        }      
    });
    $(this).val(totalAmount);
});