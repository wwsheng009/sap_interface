
//测试SAP RFC端口调用的JS脚本
//2012-11-03
//王卫生


var SalesOrder = function () {
    var oo = {};
    oo.Import = new Array();
    //oo.Export = new Array();
    //oo.Tables = new Array();
    //var anImport = {};
   // anImport.Name = "CUSTOMER_NUMBER";
   // anImport.Value = "0000001033";
   // oo.Import[0] = anImport;

    //var sImport = {};
    //sImport.Name = "SALES_ORGANIZATION";
   // sImport.Value = "1000";
    //oo.Import[1] = sImport;
    var customerNumber = $('#customerNumber').val();
    var salesOrg = $('#salesOrg').val();
    oo.Import[0] = { 'Name': 'CUSTOMER_NUMBER', 'Value': customerNumber }

    oo.Import[1] = { 'Name': 'SALES_ORGANIZATION', 'Value': salesOrg }
    oo.Import[2] = { 'Name': 'TRANSACTION_GROUP', 'Value': '0' };
    return oo;
}

$(function () {
    $('#submit').click(function () {
        // $.blockUI();
        var username = $('#username').val();
        var password = $('#password').val();
        var client = $('#client').val();
        var lang = $('#lang').val();
        $.post(baseUrl + '/Query/login', { "username": username, "password": password ,"client":client,"lang":lang }, function (json) {
            $('#jsonview').text(json);
            var o = eval('(' + json + ')');
            $('#jsonview').jsonView(o);
            //      $.unblockUI();
        });
    });

    $('#getSaleOrderList').click(function () {

        var data = SalesOrder();

        var encoded = encodeURIComponent(JSON.stringify(data));
        $.blockUI();
        $.ajax({ url: baseUrl + '/Se37/Post',
            type: 'POST',
            data: { "jsondata": encoded, "funame": "BAPI_SALESORDER_GETLIST" },
            dataType: 'json',
            error: function () { alert('Error！！'); $.unblockUI(); },
            success: function (json) {
                var o = eval('(' + json + ')');
                if (o.Message != undefined || o.Message != null) {
                    $.unblockUI();
                    alert(o.Message);

                }
                $('#jsonview').jsonView(o.Tables[0].Value[0]);
                $.unblockUI();
                //   alert('查询成功');
            }
        });

    });
});