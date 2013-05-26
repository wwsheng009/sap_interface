
/*
王卫生
2012-7-12
使用JQuery ,EasyUI,实现SAP中SE37调用界面
1.读取函数的参数信息
2.增加，修改数据
3.调用函数
4.返回结果
2012-7-15
1.增加远程读取数据库表功能，函数调用后，把表结果保存到数据库中。
2.#table的分页读取，避免大数据
2012-7-16
1.增加进入编辑状态的选项，#table不但可以从远程调用，也可以从本地内存中读取缓存
*/

//全局变量，保存函数的主数据
//import ,export,change,tables的表主数据，保存了表的元数据，如表名，长度
//从数据库中获取
var g_json;

//#table正处于编辑的table/结构的名字,.
var g_editingTable;
//是否正在编辑状态下。true/false
var g_isEditing = false;
//当前所使用的函数的名字
var g_functionname;
//键值对，Name /Value ,作为缓存,存取在编辑时的对象
var g_tableValue = {};

//调用函数后，g_ret保存返回的对象，保存的是对象名与值
var g_ret;
//#Import ,#Export,#Change,#Tables表定义
var columns = new Array([
        { field: 'Direction', title: 'Direction', width: 50 },
        { field: 'Name', title: 'Name', width: 100, align: 'left' },
        { field: 'Documentation', title: 'Documentation', width: 300 },
        { field: 'Optional', title: 'Optional', width: 60, formatter: function (value) {
            if (String(value) == 'true') {
                return 'Optional';
            }
            else {
                return 'Required';
            }
        }
        },
        { field: 'DefaultValue', title: 'DefaultValue', width: 100, editor: 'text' },
        { field: 'DataType', title: 'DataType', width: 50 },
        { field: 'Decimals', title: 'Decimals', width: 50 },
        { field: 'action', title: 'Action', width: 70, align: 'center',
            formatter: function (value, row, index) {
                if (row.editing) {
                    var s = '<a href="#" onclick="saverow( ' + index + ',\'' + getTabname(row.Direction) + '\')">Save</a> ';
                    var c = '<a href="#" onclick="cancelrow(' + index + ',\'' + getTabname(row.Direction) + '\')">Cancel</a>';
                    return s + c;
                } else {
                    var e = '<a href="#" onclick="editrow(' + index + ',\'' + getTabname(row.Direction) + '\')">Edit</a> ';
                    var d = '<a href="#" onclick="deleterow(' + index + ',\'' + getTabname(row.Direction) + '\')">Delete</a>';
                    return e;
                }
            }
        }
    ]);

//根据参数的方向判断表名。
function getTabname(direction) {
    switch (direction) {
        case 1:
            return '#import';
        case 2:
            return '#export';
        case 3:
            return '#change';
        case 7:
            return '#tables';
        case undefined:
            return '#struct';
        default:
            return '';


    }
}

//单击后如果是结构类型，显示结构定义。
var fonClickrow = function (rowIndex, rowData) {
    //alert(rowIndex + rowData.DataType)
    //$('#struct').datagrid('loadData',{});

    //$('#table').empty();
    if (rowData.DataType === 24 || rowData.DataType === 25) {

    clearTable('#struct');
    clearTable('#table');
    
        //g_editingTable保存正在编辑的表的名字。#table，用于定位，跟踪编辑数据。
        g_editingTable = rowData.Name;

        //#struct显示了结构的定义，给结构加上一个关键字段，指明是哪个表或结构的定义
        var detail = g_json.Objects[rowData.Name];
        for (x in detail) {
            detail[x].key = rowData.Name;
        }
        $('#struct').datagrid('loadData', detail);

        if (rowData.DataType === 25) {
            //g_idEditing指示是在编辑状态下，不从数据库中读取
            createEYtable(rowData.Name, g_isEditing);
            if (g_isEditing == true) {
                //加载数据，如果之前已经有保存的数据，把它加载进来
                loadTableDataFromCache(rowData.Name);
            }
        }
        //针对结构，因为数据小，始终从内存获取，
        else if (rowData.DataType === 24 ) {
            createEYtable(rowData.Name, false);
            //加载数据，如果之前已经有保存的数据，把它加载进来
            loadTableDataFromCache(rowData.Name);
        }

    }
    else {
       // rowData.DefaultValue = g_tableValue[rowData.Name];
    }
};


//绑定编辑事件
function editrow(index, tablename) {
    $(tablename).datagrid('beginEdit', index);

}
function deleterow(index, tablename) {
    $.messager.confirm('Confirm', 'Are you sure?', function (r) {
        if (r) {
            $(tablename).datagrid('deleteRow', index);
        }
    });
}
function saverow(index, tablename) {
    $(tablename).datagrid('endEdit', index);
}
function cancelrow(index, tablename) {
    $(tablename).datagrid('cancelEdit', index);
}


//方便同时初始化四个表。
function datagrid(tablename) {

    $(tablename).datagrid({
        //url: 'datagrid_data.json',
        width: 900,
        onClickRow: fonClickrow,
        columns: columns,
        onBeforeEdit: function (index, row) {
            row.editing = true;
            updateActions(tablename);
        },
        onAfterEdit: function (index, row) {
            row.editing = false;
           //如果不是表或是结构，直接更新缓存
            if (row.DataType !== 24 && row.DataType !== 25) {
                g_tableValue[row.Name] = clone(row.DefaultValue);
            }
            updateActions(tablename);
        },
        onCancelEdit: function (index, row) {
            row.editing = false;
            updateActions(tablename);
        }

    })

}
//用于构建#struct用的列定义表
function datagrid_s(tablename) {
    var column = { field: 'key', title: 'Key', width: 50 }
    //columns[0].splice(0, 1, column);
     columns[0].push(column);
    datagrid(tablename);
}
//更新后提交值
function updateActions(tablename) {
    var rowcount = $(tablename).datagrid('getRows').length;

    for (var i = 0; i < rowcount; i++) {
        $(tablename).datagrid('updateRow', {
            index: i,
            row: { action: '' }
        });
    }
}

//////////////table*****************************
//清空table
var clearTable = function (tablename) {
    //注意这里是清空整个表数据。
    var rows = [];
    $(tablename).datagrid('loadData', rows);
    
    //以下只是清空一页的所有行项目
    //    var rowcount = $(tablename).datagrid('getRows').length;
    ////    rowcount.rows = [];
    ////    $(tablename).datagrid('acceptChanges');
    //    for (var i = 0; i < rowcount; i++) {
    //        $(tablename).datagrid('deleteRow', i);
    //    }
}
//从内存中读取数据
var loadTableDataFromCache = function (name) {
    //$('#table').datagrid('load', {});
    var rows = {};
    if (g_tableValue[name] != undefined) {
        rows = clone(g_tableValue[name]);
        rows.total = 200;
        var value = {};
        value.rows = rows;
        value.total = 200;
        try {
            $('#table').datagrid('loadData', value);

        } catch (e) {

        }
    }

}

//保存#table中值到内存中
var saveTableValue = function () {
    var rowdata = $('#table').datagrid('getData');
    g_tableValue[g_editingTable] = clone(rowdata.rows);
    alert("保存成功");

}

//与远程交互，服务器读取数据
var createEYtable = function (name, option) {
    // $("#table").empty();
    var cols = buildColumn(name);
    var options = {
        url: baseUrl + '/Se37/getdata?funame=' + g_functionname + '&tablename=' + g_editingTable,
        //$('#table').attr('url', baseUrl + '/sap/getdata');
        width: 900,
        columns: [cols],
        onBeforeEdit: function (index, row) {
            row.editing = true;
            updateActions('#table');
        },
        onAfterEdit: function (index, row) {
            row.editing = false;
            updateActions('#table');
        },
        onCancelEdit: function (index, row) {
            row.editing = false;
            updateActions('#table');
        }

    };
    if (option == true) {
        options.url = '';
    }

    $('#table').datagrid(options)

}

//复制对象，在保存用户的输入值时，一定要把对象复制保存，
//在读取时，同样也需要复制出来。

function clone(obj) {
    // Handle the 3 simple types, and null or undefined
    if (null == obj || "object" != typeof obj) return obj;

    // Handle Date
    if (obj instanceof Date) {
        var copy = new Date();
        copy.setTime(obj.getTime());
        return copy;
    }

    // Handle Array
    if (obj instanceof Array) {
        var copy = [];
        for (var i = 0; i < obj.length; ++i) {
            copy[i] = clone(obj[i]);
        }
        return copy;
    }

    // Handle Object
    if (obj instanceof Object) {
        var copy = {};
        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) copy[attr] = clone(obj[attr]);
        }
        return copy;
    }

    throw new Error("Unable to copy obj! Its type isn't supported.");
}


//添加一行数据
var addTableRow = function () {

    $('#table').datagrid('appendRow', {});
}

//从g_json中的Objects结构定义列表中提取转换成easyui用的列定义
var buildColumn = function (colname) {
    var columns = {};
    var Objects = g_json.Objects;
    for (var o in Objects) {
        var l = Objects[o];
        var col = [];
        for (var m in l) {
            var orr = {};
            orr['field'] = l[m].Name;
            orr['title'] = l[m].Documentation;
            if (l[m].UcLength < 100) {
                orr['width'] = 100;
            }
            else { orr['width'] = l[m].UcLength; }

            orr['editor'] = 'text';
            col.push(orr);
        }
        var orrex = { field: 'action', title: 'Action', width: 70, align: 'center',
            formatter: function (value, row, index) {
                if (row.editing) {
                    var s = '<a href="#" onclick="saverow( ' + index + ',\'' + '#table' + '\')">Save</a> ';
                    var c = '<a href="#" onclick="cancelrow(' + index + ',\'' + '#table' + '\')">Cancel</a>';
                    return s + c;
                } else {
                    var e = '<a href="#" onclick="editrow(' + index + ',\'' + '#table' + '\')">Edit</a> ';
                    var d = '<a href="#" onclick="deleterow(' + index + ',\'' + '#table' + '\')">Delete</a>';
                    return e + d;
                }
            }
        };

        col.push(orrex);
        columns[o] = col;
        // orr.columns = col;
        //  columns.push(orr);
    }
    if (colname != undefined) {
        return columns[colname];
    }
    else {
        return columns;
    }


}


////////////////////**************************************


//把g_json打包，包含更新后的值，用于提交服务器
var pack = function () {

    var oo = {};
    oo.Import = new Array();
    oo.Export = new Array();
    oo.Change = new Array();
    oo.Tables = new Array();
    //oo.All = new Array();

    //oo.Import = g_json.Import;
    for (var x in g_json.Import) {
        var cl = {};
        cl.Name = g_json.Import[x].Name;
        cl.Value = g_json.Import[x].DefaultValue;
        var datatype = g_json.Import[x].DataType;
        if (datatype == 24 || datatype == 25) {
            if (g_tableValue[cl.Name] != undefined) {
                var rows = clone(g_tableValue[cl.Name]);
                cl.Value = rows;
            }

        }
        oo.Import[x] = cl;
    }
    for (var x in g_json.Export) {
        var cl = {};
        cl.Name = g_json.Export[x].Name;
        cl.Value = g_json.Export[x].DefaultValue;
        var datatype = g_json.Export[x].DataType;
        if (datatype == 24 || datatype == 25) {
            if (g_tableValue[cl.Name] != undefined) {
                var rows = clone(g_tableValue[cl.Name]);
                cl.Value = rows;
            }

        }
        oo.Export[x] = cl;
    }
    for (var x in g_json.Change) {
        var cl = {};
        cl.Name = g_json.Change[x].Name;
        cl.Value = g_json.Change[x].DefaultValue;
        var datatype = g_json.Change[x].DataType;
        if (datatype == 24 || datatype == 25) {
            if (g_tableValue[cl.Name] != undefined) {
                var rows = clone(g_tableValue[cl.Name]);
                cl.Value = rows;
            }

        }
        oo.Change[x] = cl;
    }
    for (var x in g_json.Tables) {
        var cl = {};
        cl.Name = g_json.Tables[x].Name;
        cl.Value = g_json.Tables[x].DefaultValue;
        var datatype = g_json.Tables[x].DataType;
        if (datatype == 24 || datatype == 25) {
            if (g_tableValue[cl.Name] != undefined) {
                var rows = clone(g_tableValue[cl.Name]);
                cl.Value = rows;
            }

        }
        oo.Tables[x] = cl;
    }


    return oo;
}
//调用成功后，往内存更新返回的值。
var updateRet = function () {

    for (var t in g_ret.Import) {
        var Name = g_ret.Import[t].Name;
        var Value = g_ret.Import[t].Value;
        g_tableValue[Name] = clone(Value);
        for (var x in g_json.Import) {
            if (g_json.Import[x].Name == Name) {
                g_json.Import[x].DefaultValue = Value;
            }
        }
        
    }
    for (var t in g_ret.Export) {
        var Name = g_ret.Export[t].Name;
        var Value = g_ret.Export[t].Value;
        g_tableValue[Name] = clone(Value);
        for (var x in g_json.Export) {
            if (g_json.Export[x].Name == Name) {
                g_json.Export[x].DefaultValue = Value;
            }
        }
        
    }
    for (var t in g_ret.Change) {
        var Name = g_ret.Change[t].Name;
        var Value = g_ret.Change[t].Value;
        g_tableValue[Name] = clone(Value);
        for (var x in g_json.Change) {
            if (g_json.Change[x].Name == Name) {
                g_json.Change[x].DefaultValue = Value;
            }
        }
        
    }
    for (var t in g_ret.Tables) {
        var Name = g_ret.Tables[t].Name;
        var Value = g_ret.Tables[t].Value;
        g_tableValue[Name] = clone(Value);
        for (var x in g_json.Tables) {
            if (g_json.Tables[x].Name == Name) {
                g_json.Tables[x].DefaultValue = Value;
            }
        }
    }

    $('#import').datagrid('loadData', g_json.Import);
    $('#export').datagrid('loadData', g_json.Export);
    $('#change').datagrid('loadData', g_json.Change);
    $('#tables').datagrid('loadData', g_json.Tables);

}

//返回#struct中的表值
//var getStructValue = function () {

//    var o = {};
//    var Struct = $('#struct').datagrid('getData');
//    var orr = new Array();
//    for (var x in Struct.rows) {
//        var cl = {};
//        o.key = Struct.rows[x].key;
//        cl.name = Struct.rows[x].Name;
//        cl.value = Struct.rows[x].DefaultValue;
//        orr[x] = cl;
//    }
//    o.list = orr;
//    return o;
//}

//把#struct中的值更新到Import中
//var updatestruct = function () {
//    var oo = pack();
//    var st = getStructValue();
//    for (var o in oo.Import) {
//        if (oo.Import[o].name == st.key) {
//            oo.Import[o].value = st.list;
//        }
//    }
//}
//Jquery全局载入函数。
//

var getRfclist = function () {

    $.ajax({
        type: "POST",     //AJAX提交方式为GET提交
        url: baseUrl + '/Se37/getFuncList',   //处理页的URL地址
        data: "funcname=" + escape($('#funame').val()),   //要传递的参数
        success: function (json) {   //成功后执行的方法
            if (json != "") {
                var data = eval('(' + json + ')');
                var layer = "<table>";
                for (var i in data) {
                    layer += "<tr><td class='line'>" + data[i].FUNCNAME + "</td><td class='line'>" + data[i].STEXT + "</td></tr>";
                }

                layer += "</table>";
                $('#searchresult').empty();  //先清空#searchresult下的所有子元素
                $('#searchresult').append(layer); //将刚才创建的table插入到#searchresult内
                $('.line').hover(function () {  //监听提示框的鼠标悬停事件
                    $(this).addClass("hover");
                }, function () {
                    $(this).removeClass("hover");
                });
                $('.line').click(function () {  //监听提示框的鼠标单击事件
                    $('#funame').val($(this).text());
                    $('#searchresult').empty();
                });
            } else {
                $('#searchresult').empty();
            }
        },
        error: function () { alert("O No~~~"); }
    });

}

$(function () {
    // $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);


    datagrid('#import');
    datagrid('#export');
    datagrid('#tables');
    datagrid('#change');
    datagrid_s('#struct');

    //$('#funame').onkeyup(getRfclist());

    //单击按钮，读取sap的函数的元数据定义
    $('#isEditing').click(function () {
        if ($('#isEditing').attr('checked') == 'checked') {
            g_isEditing = true;
        }
        else g_isEditing = false;
    });


    //返回函数的元数据，如函数的输入，输出，表，结构等。
    $('#submit').click(function () {
        $.blockUI();
        g_functionname = $('#funame').val();
        g_functionname.replace(/(^\s*)(\s*$)/g, '')
        if (g_functionname === '') {
            alert('Please input the function name');
            $.unblockUI();
        }
        else {
            $("#re_prd").empty();
            $.post(baseUrl + '/Se37/fun', { "type": "funM", "funame": g_functionname }, function (json) {
                //解析json
                var o = eval('(' + json + ')');
                //  var o = json.parseJSON();
                if (o.Message != undefined || o.Message != null) {
                    $.unblockUI();
                    alert(o.Message);
                    
                }
                $('#import').datagrid('loadData', o.Import);
                $('#export').datagrid('loadData', o.Export);
                $('#change').datagrid('loadData', o.Change);
                $('#tables').datagrid('loadData', o.Tables);
                //$.JSONView(o,$('#re_prd'));
                g_json = o;
                $.unblockUI();
            });
        }
    });


    //测试将要提交的数据
    $('#checkpostdata').click(function () {

        $('#jsonview').jsonView(pack());
    });

    //向服务器提交数据。
    $('#post').click(function () {
        g_functionname = $('#funame').val();
        g_functionname.replace(/(^\s*)(\s*$)/g, '')
        var data = pack();

        var encoded = encodeURIComponent(JSON.stringify(data));
        $.blockUI();
        $.ajax({ url: baseUrl + '/Se37/Post',
            type: 'POST',
            data: { "jsondata": encoded, "funame": g_functionname },
            dataType: 'json',
            error: function () { alert('Error！！'); $.unblockUI(); },
            success: function (json) {
                var o = eval('(' + json + ')');
                if (o.Message != undefined || o.Message != null) {
                    $.unblockUI();
                    alert(o.Message);

                }
                g_ret = o;
                updateRet();
                $.unblockUI();
                //   alert('查询成功');
            }
        });

    });

    //返回这次连接的信息
    $('#getServer').click(function () {
        $.post(baseUrl + '/Se37/SeverInfo', {}, function (json) {
            var o = eval('(' + json + ')');
            $('#jsonview').jsonView(o);

        });
    });

});