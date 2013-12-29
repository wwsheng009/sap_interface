// 默认的代码是一个从 linb.Com 派生来的的类
Class('App', 'linb.Com', {
    // 要确保键值对的值不能包含外部引用
    Instance: {
        // 实例的属性要在此函数中初始化，不要直接放在Instance下
        initialize: function () {
            // 本Com是否随着第一个控件的销毁而销毁
            this.autoDestroy = true;
            // 初始化属性
            this.properties = {};
        },
        // 初始化内部控件（通过界面编辑器生成的代码，大部分是界面控件）
        // *** 如果您不是非常熟悉linb框架，请慎重手工改变本函数的代码 ***
        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.SButton)
                .setHost(host, "ctl_sbutton1")
                .setLeft(30)
                .setTop(30)
                .setWidth(162)
                .setCaption(" 点 我 ")
                .onClick("_ctl_sbutton1_onclick")
            );

            append(
                (new linb.UI.TreeGrid)
                .setHost(host, "ctl_treegrid3")
                .setDock("none")
                .setLeft(10)
                .setTop(220)
                .setWidth(660)
                .setHeight(370)
                .setRowNumbered(true)
                .setHeader([{ "id": "col1", "width": 80, "type": "input", "caption": "col1" }, { "id": "col2", "width": 80, "type": "input", "caption": "col2" }, { "id": "col3", "width": 80, "type": "input", "caption": "col3" }, { "id": "col4", "width": 80, "type": "input", "caption": "col4"}])
                .setRows([{ "cells": [{ "value": "row1 col1", "id": "c_a", "oValue": "row1 col1" }, { "value": "row1 col2", "id": "c_b", "oValue": "row1 col2" }, { "value": "row1 col3", "id": "c_c", "oValue": "row1 col3" }, { "value": "row1 col4", "id": "c_d", "oValue": "row1 col4"}], "id": "d" }, { "cells": [{ "value": "row2 col1", "id": "c_e", "oValue": "row2 col1" }, { "value": "row2 col2", "id": "c_f", "oValue": "row2 col2" }, { "value": "row2 col3", "id": "c_g", "oValue": "row2 col3" }, { "value": "row2 col4", "id": "c_h", "oValue": "row2 col4"}], "id": "e" }, { "cells": [{ "value": "row3 col1", "id": "c_i", "oValue": "row3 col1" }, { "value": "row3 col2", "id": "c_j", "oValue": "row3 col2" }, { "value": "row3 col3", "id": "c_k", "oValue": "row3 col3" }, { "value": "row3 col4", "id": "c_l", "oValue": "row3 col4"}], "sub": [["sub1", "sub2", "sub3", "sub4"]], "id": "f"}])
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        // 加载其他Com可以用本函数
        iniExComs: function (com, threadid) {
        },
        // 可以自定义哪些界面控件将会被加到父容器中
        customAppend: function (parent, subId, left, top) {
            // "return false" 表示默认情况下所有的第一层内部界面控件会被加入到父容器
            return false;
        },
        // Com本身的事件映射
        events: { "onReady": "_com_onready" },
        // 例子：button 的 click 事件函数
        //to interact with server
        //to show message
        popMsg: function (msg) {
            linb.UI.Dialog.pop(msg);
        }, 

        request: function (hash, callback, onStart, onEnd, file) {
            _.tryF(onStart);
            linb.Thread.observableRun(function (threadid) {
                var data = { key: 'DBProcess', para: hash }, options;
                if (file) {
                    data.file = file;
                    options = { method: 'post' };
                }
                options = { method: 'post' };
                linb.request('http://localhost:2144/linb/jsonre', data, function (rsp) {
                    var obj = rsp;
                    if (obj) {
                        if (!obj.error)
                            _.tryF(callback, [obj]);
                        else
                            SPA.popMsg(_.serialize(obj.error));
                    } else
                        SPA.popMsg(_.serialize(rsp));
                    _.tryF(onEnd);
                }, function (rsp) {
                    SPA.popMsg(_.serialize(rsp));
                    _.tryF(onEnd);
                }, threadid, options)
            });
        },

        _ctl_sbutton1_onclick: function (profile, e, src, value) {
            var uictrl = profile.boxing();
            linb.alert("我是 " + uictrl.getAlias());
            //SPA.ctl_treegrid3.setRows();
            var key = 1;
            var value = 2;
            SPA.request({ action: 'update', key: key, value: value },
                function (rsp) {
                    if (rsp.data == 'ok') {
                        SPA.ctl_treegrid3.setRows(rsp.value);
                        // SPA.iValue.updateValue()
                    }
                }
            );

        },
        _com_onready: function (com, threadid) {
            SPA = this;
        }
    }
});