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
            { id: "1", word: "確り", howtoread: "しっかり", meaning: "tightly, firmly, steadily", sample: "test" },
            { id: "2", word: "確り", howtoread: "しっかり", meaning: "tightly, firmly, steadily", sample: "test" },
            { id: "3", word: "確り", howtoread: "しっかり", meaning: "tightly, firmly, steadily", sample: "test" },
            { id: "4", word: "確り", howtoread: "しっかり", meaning: "tightly, firmly, steadily", sample: "test" },
            { id: "5", word: "確り", howtoread: "しっかり", meaning: "tightly, firmly, steadily", sample: "test" },
            { id: "6", word: "確り", howtoread: "しっかり", meaning: "tightly, firmly, steadily", sample: "test" },
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
    });

    jQuery("#btnAdd").click(function () {
        jQuery("#tblData").saveRow(lastsel2, false, 'clientArray');
        var rowId = jQuery("#tblData").jqGrid('getGridParam', 'selarrrow');
        if (rowId.length > 0) {
            var postData = [];
            for (var i = 0; i < rowId.length; i++) {
                var tempWord = jQuery("#tblData").jqGrid('getCell', rowId[i], 'word');
                alert(tempWord);
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