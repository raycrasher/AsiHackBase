$(document).ready(function () {
    var lastsel2;
    var dataCounter = 0;
    jQuery("#tblData").jqGrid({
        datatype: "local",
        colNames: ['ID', 'WORD', 'How to Read', 'Meaning', 'Sample'],
        colModel: [
            { name: 'id', index: 'id', width: 60, sorttype: "int", hidden: true },
            { name: 'word', index: 'word', width: 90, sorttype: "string", editable: true },
            { name: 'howtoread', index: 'name', sorttype: "string", width: 100, editable: true },
            { name: 'meaning', index: 'howtoread', width: 80, align: "right", sorttype: "string", editable: true },
            { name: 'sample', index: 'sample', width: 80, align: "right", sorttype: "string", editable: true },
        ],
        onSelectRow: function (id) {
            if (id != lastsel2) {
                jQuery("#tblData").saveRow(lastsel2, false, 'clientArray');
                jQuery("#tblData").jqGrid('saveRow', lastsel2);
                jQuery('#tblData').jqGrid('editRow', id, true);
                lastsel2 = id;
            }
        },
        loadComplete: function (data) {
            var mydata = [
            { id: "1", word: "着信履歴", howtoread: "ちゃくしんりれき", meaning: "record of calls received", sample: "-" },
            { id: "2", word: "送信箱", howtoread: "そうしんばこ", meaning: "outbox", sample: "-" },
            { id: "3", word: "可能(な)", howtoread: "かのう", meaning: "possible", sample: "-" },
            { id: "4", word: "がぞう", howtoread: "がぞう", meaning: "picture, image", sample: "-" },
            { id: "5", word: "年老いた", howtoread: "としおいた", meaning: "old (person)", sample: "-" },
            { id: "6", word: "捨てる", howtoread: "すてる", meaning: "throw", sample: "-" },
            { id: "7", word: "昼間が暖かい", howtoread: "ひるまがあたたかい", meaning: "It's warm in the daytime", sample: "-" },
            { id: "8", word: "まよなか", howtoread: "すてる", meaning: "end of month", sample: "-" },
            { id: "9", word: "年中無休", howtoread: "ねんじゅうむきゅう", meaning: "open everyday throughout the year", sample: "-" },
            { id: "10", word: "親類", howtoread: "しんるい", meaning: "relatives", sample: "-" },
            ];
            for (var i = 0; i <= mydata.length; i++) {
                dataCounter++;
                jQuery("#tblData").jqGrid('addRowData', i + 1, mydata[i]);
            }
            var NoOfCellAdd = (dataCounter < 10) ? (10 - dataCounter) : 0;
            for (var i = 0; i <= NoOfCellAdd; i++) {
                $("#tblData").addRowData(dataCounter, {});
                dataCounter++;
            }
        },
        rowNum: 10,
        height: 500,
        multiselect: true,
        caption: ""
    }).jqGrid('setGridWidth', '900');;

    jQuery("#btnAdd").click(function () {
        jQuery("#tblData").saveRow(lastsel2, false, 'clientArray');
        var rowId = jQuery("#tblData").jqGrid('getGridParam', 'selarrrow');
        if (rowId.length > 0) {
            var postData = [];
            for (var i = 0; i < rowId.length; i++) {
                var tempWord = jQuery("#tblData").jqGrid('getCell', rowId[i], 'word');
                if (tempWord != "") {
                    postData.push({
                        word: tempWord,
                        howtoread: jQuery("#tblData").jqGrid('getCell', rowId[i], 'howtoread'),
                        meaning: jQuery("#tblData").jqGrid('getCell', rowId[i], 'meaning'),
                        sample: jQuery("#tblData").jqGrid('getCell', rowId[i], 'sample')
                    });
                }
            }
            var jsonPostData = JSON.stringify(postData);
            if (postData.length != 0) {
                $.ajax({
                    type: "POST",
                    url: "/SetData",
                    data: {
                        jgGridData: jsonPostData
                    },
                    dataType: "jsonp",
                    contentType: "application/jsonp; charset=utf-8",
                    success: function (response, textStatus, xhr) {
                        alert("success");
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        alert("error");
                    }
                });
            }
            else {
                alert("Please select row with WORD data!");
            }
        }
        else {
            alert("No selected data!");
        }
    });

});