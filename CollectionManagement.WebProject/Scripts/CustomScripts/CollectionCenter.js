/// <reference path="../jquery-1.10.2.min.js" />

//$('#btn-cancelForm').click(function//  () {
//    window.location.href = '/Dashboard/Index';
//});

function cancelForm() { window.location.href = '/Dashboard/Index'; }

$('#btn-GetData').click(function () {
    $('.alert').hide();
    var txnId = $('#TransactionId').val();
    if (txnId != "") {
        $.ajax({
            url: '/Dashboard/GetTransactionData',
            type: 'post',
            async: false,
            data: { txnId: txnId },
            cache: false,
            success: function (result) {
                $('#div-txnid').hide();
                $('#div-txnData').show().html(result);
            }
        });
    }
    else {
        $('#customMsg').text('Please Enter Transaction Id.');
        $('.alert').show();
    }
});

function changeMOP(obj) {
    var val = $(obj).val();
    if (val == 1) {
        $('.cheque').hide();
        $('#cash').show();
        $('.dd').hide();
    }
    if (val == 2) {
        $('.cheque').show();
        $('#cash').hide();
        $('.dd').hide();
    }
    if (val == 3) {
        $('.cheque').hide();
        $('#cash').hide();
        $('.dd').show();
    }
}



function saveMOP() {
    $('#validationMsg').text('');
    var hasError = false;
    var val = $('#ModeOfPayment').val();
    if (val == 0) {
        hasError = true;
        $('#validationMsg').text('Payment Details are required.');
    }
    if (val == 1) {
        //cash
        if ($('#Amount2k').val() == "" || $('#Amount5h').val() == "" || $('#Amount2h').val() == ""
            || $('#Amount1h').val() == "" || $('#Amount50').val() == "") {
            hasError = true;
            $('#validationMsg').text('Cash denominations are required.');
        }
    }
    if (val == 2) {
        //cheque
        if ($('#BankNameC').val() == "" || $('#BankAddressC').val() == "" || $('#ChequeNumber').val() == "") {
            hasError = true;
            $('#validationMsg').text('Bank Details are required.');
        }
    }
    if (val == 3) {
        //dd
        if ($('#BankNameD').val() == "" || $('#BankAddressD').val() == "" || $('#DDNumber').val() == "") {
            hasError = true;
            $('#validationMsg').text('Bank Details are required.');
        }
    }

    if (!hasError) {
        var formData = new FormData();
        var other_data = $('form').serializeArray();
        $.each(other_data, function (key, input) {
            formData.append(input.name, input.value);
        });
        $.ajax({
            url: '/Dashboard/SavePaymentDetails',
            type: 'post',
            async: false,
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (result) {
                debugger
                $('#customMsg').text(result.result);
                $('.alert').show();
            }
        });

        setTimeout(
            function () {
                // window.location.href = '/Dashboard/Index';
                $.ajax({
                    url: '/Dashboard/GetTransactionData',
                    type: 'post',
                    async: false,
                    data: { txnId: $('#TransactionId').val() },
                    cache: false,
                    success: function (result) {
                        $('#div-txnid').hide();
                        $('#div-txnData').show().html(result);
                        $('#customMsg').text('');
                        $('.alert').hide();
                    }
                });
            }, 5000);
    }
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