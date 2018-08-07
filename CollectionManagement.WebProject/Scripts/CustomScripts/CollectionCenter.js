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
    var val = $('#modeOfPayment').val();
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

    if (!hasError)
        window.location.href = '/Dashboard/Index';
}

