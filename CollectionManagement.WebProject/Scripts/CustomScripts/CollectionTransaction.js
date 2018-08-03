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
        '<td><select class="form-control" id="ServiceId' + i + '" name="ServiceId' + i + '"><option value="">Select Service</option></select></td >' +
        '<td><input autocomplete="off" class="form-control text-box single-line" id="Rate' + i + '" name="Rate' + i + '" placeholder="Rate" type="text" value=""></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line" id="Quantity' + i + '" name="Quantity' + i + '" placeholder="Quantity" type="text" value=""></td>' +
        '<td><input autocomplete="off" class="form-control text-box single-line" id="Remarks' + i + '" name="Remarks' + i + '" placeholder="Remarks" type="text" value=""></td>' +
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