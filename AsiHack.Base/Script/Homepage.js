$(document).ready(function(){
	var lastsel2;
	var dataCounter=0;
	jQuery("#tblData").jqGrid({
	datatype: "local",
   	colNames:['ID','WORD', 'How to Read', 'Meaning','Sample'],
   	colModel:[
   		{name:'id',index:'id', width:60, sorttype:"int"},
   		{name:'word',index:'word', width:90, sorttype:"string",editable:true},
   		{name:'howtoread',index:'name', sorttype:"string", width:100,editable:true},
   		{name:'meaning',index:'howtoread', width:80, align:"right",sorttype:"string",editable:true},
   		{name:'sample',index:'sample', width:80, align:"right",sorttype:"string",editable:true},			
   	],
	onSelectRow: function(id){
		
			 if ($("#lastCellId").val() != -1)
                        jQuery('#tblData').saveRow($("#lastCellId").val(), false, 'clientArray');
			jQuery('#tblData').jqGrid('restoreRow',lastsel2);
			jQuery('#tblData').jqGrid('editRow',id,true);
			lastsel2=id;
			$("input, text", e.target).focus();
            $("#lastCellId").val(rowid);
		
	},
	onCellSelect: function(rowid, iCol, cellcontent, e) {

                if (rowid <= lastsel2) {
                    if ($("#lastCellId").val() != -1)
                        $("#tblData").saveRow($("#lastCellId").val(), false, 'clientArray');
                    $('#tblData').editRow(rowid, iCol, true);
                    $("input, text", e.target).focus();
                    $("#lastCellId").val(rowid);
                }
    },
	restoreAfterSelect: false,
	saveAfterSelect: true,	
	loadComplete: function(data) {
				var mydata = [
				{id:"1",word:"確り",howtoread:"しっかり",meaning:"tightly, firmly, steadily",sample:"test"},
				{id:"2",word:"確り",howtoread:"しっかり",meaning:"tightly, firmly, steadily",sample:"test"},
				{id:"3",word:"確り",howtoread:"しっかり",meaning:"tightly, firmly, steadily",sample:"test"},
				{id:"4",word:"確り",howtoread:"しっかり",meaning:"tightly, firmly, steadily",sample:"test"},
				{id:"5",word:"確り",howtoread:"しっかり",meaning:"tightly, firmly, steadily",sample:"test"},
				{id:"6",word:"確り",howtoread:"しっかり",meaning:"tightly, firmly, steadily",sample:"test"},
				];
				for(var i=0;i<=mydata.length;i++){
					dataCounter++;
					jQuery("#tblData").jqGrid('addRowData',i+1,mydata[i]);
				}
                var NoOfCellAdd = (dataCounter<10)?(10-dataCounter):0;
                for (var i = 0; i <= NoOfCellAdd; i++) {
                    $("#tblData").addRowData(dataCounter, {});
					dataCounter++;
                }
    },
	rowNum:10,
	height: 500,
   	multiselect: true,
   	caption: ""
	});
	
	$("#btnAdd").click(function(){
    var gridData = jQuery("#tblData").getRowData();
    var postData = JSON.stringify(gridData);
    alert("JSON serialized jqGrid data:\n" + postData);
    $.ajax({
        type: "POST",
        url: "/AddData",
        data : {
            jgGridData: postData
        },
        dataType:"jsonp",
        contentType: "application/json; charset=utf-8",
        success: function(response, textStatus, xhr) {
            alert("success");
        },
        error: function(xhr, textStatus, errorThrown) {
            alert("error");
        }
    });
});
	
});