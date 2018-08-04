/// <reference path="../jquery-1.10.2.min.js" />

$('#btn-cancelForm').click(function () {
    window.location.href = '/Dashboard/Index';
});

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
        $('#cheque').hide();
        $('#cash').show();
        $('#dd').hide();
    }
    if (val == 2) {
        $('#cheque').show();
        $('#cash').hide();
        $('#dd').hide();
    }
    if (val == 3) {
        $('#cheque').hide();
        $('#cash').hide();
        $('#dd').show();
    }
}



function saveMOP() {
    window.location.href = '/Dashboard/Index';
}