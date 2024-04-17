# ej 控件封装

---

## 概述

在海澜的项目中目前新增了一个项目脚本 **jsCtlTool.js** (目录: ..\Lib\jq\jsCtlTool.js) \
脚本的主要作用是将 ej 的控件创建及取值赋值的操作方法进行简化封装 \
脚本内容主要应用在控件创建上 

画面必要参数 **PageName** 内容为画面名称 对应于翻译

当前最高版本 @version 1.0.3.2024.0328

---

## 实例

![js](https://skillicons.dev/icons?i=js)
```

//引用
<script src="@Href(" ~/Lib/jq/jsCtlTool.js?ver=" + DateTime.Now.ToString("yyyyMMddHHmmss"))" charset="utf-8"></script>
<script>
        var PageName = "ZLIssueBarcodeBiz";
        . . .
        function initInput() {
            . . .
            //构筑控件
            JsCT.TextBoxInit("txtBarcode", "");//输入框
            JsCT.DatePickerInit("txtDate", "");//时间框
            JsCT.SearchInput.Init("txtZZLDenno", ZZLDennoSel_Dialog);//弹出画面选择
            var ds2 = [];
            JsCT.DropDownListInit("cboAdjustFlg", ds2, null);//下拉选择
            . . .
            //赋值
            JsCT.SetVal("txtBarcode", m.ZCP_Barcode);
            JsCT.SetVal("txtStartDate", new Date(m.ZCP_StartDate).format("yyyy/MM/dd"));
            JsCT.SetAttr("txtTanto", m.ZCP_Tanto, m.TantoNm);
            JsCT.GetEj2InstancesObj("#txtSoko").value = m.ZCP_Soko;
            . . .
            //表格
            var col = [
                { field: 'ZTNUM_Index', type: 'number', headerText: GetJqLangTxt(PageName, "ColZTNUM_Index"), width: 60, allowEditing: false, isPrimaryKey: true, visible: false },//序号
                { field: 'ZTNUM_Denno', type: 'string', headerText: GetJqLangTxt(PageName, "ColZTNUM_Denno"), width: 150, allowEditing: false, visible: false },//到货单
                { field: 'ZTNUM_Date', type: 'datetime', headerText: GetJqLangTxt(PageName, "ColZTNUM_Date"), width: 150, format: { type: 'datetime', format: 'yyyy/MM/dd' }, allowEditing: false, visible: false },//到货日
                { field: 'ZTNUM_Code', type: 'string', headerText: GetJqLangTxt(PageName, "ColZTNUM_Code"), width: 150, allowEditing: false },//コード
                . . .
            ];
            var agg = [{ columns: [{ type: 'Sum', field: 'ZTNUM_Suryo' }, { type: 'Sum', field: 'ZTNUM_Tansu' }] }];
            grid = JsCT.GridCte.Init("grid", col, agg);
            grid.editSettings = { allowEditing: true, allowAdding: false, allowDeleting: true, newRowPosition: 'Top', mode: 'Batch' };
            grid.height = 200;
            grid.allowPaging = false;
            grid.queryCellInfo = function (obj) {
                if (obj.column.field == 'ZTNUM_Date') {
                    var tmp = dateFormaterYMD(obj.value);
                    if (tmp == "1900/01/01" || tmp == "1899/12/30")
                        obj.value = "";
                    else
                        obj.value = tmp;
                }
            };
        }

</script>

```

关于弹出查询框 \
在构筑控件的方法中 写法如下 : \
JsCT.SearchInput.Init("txtZaiCode", ZaiSel_Dialog); 

```

<script>
        //弹出查询事件
        function ZaiSel_Dialog(){ 
            . . . 
        }
</script>

<!-- html 变更前 -->
. . . 
        <div class="com_inputDiv cs14">
            <div class="e-float-input e-input-group">
                <input type="text" class="e-input e-control" id="txtZaiCode" readonly>
                <span class="e-float-line"></span>
                <label class="e-float-text e-label-top" id="label_txtZaiCode"></label>
                <span class="e-input-group-icon e-input-search" onclick="ZaiSel_Dialog();"></span>
            </div>
        </div><!--txtZaiCode 原材料コード-->
. . .

<!-- html 变更后 -->
. . . 
        <div class="com_inputDiv cs14"><input id="txtZaiCode" /></div>
. . .

<!-- 验证或者绑定某些值时 保留原控件属性 -->
. . .  
        <input id="txtDenno" required/>
        <input id="txtInTanto" isInTanto="true"/>
. . . 

```

---

## 通用模板写法

---

例如 \
表名 D_REPRecv 描述 返修单据接收维护主表 \
列名 REPRecv_Denno 描述 返修单号 \
列名简称 Denno

![js](https://skillicons.dev/icons?i=js)
```

//----BizHtml html写法----
<div class="com_inputDiv cs16"><input id="txt(列名简称)" /></div><!--txt(列名简称) (列描述)-->
<div class="com_inputDiv cs16"><input id="txtDenno" /></div><!--txtDenno 返修单号-->

//必填 : required 
//用户绑定登录人 : isInTanto="true"

//----initInput 初始化方法写法----
JsCT.TextBoxInit("txt(列名简称)", "");//(列描述)
JsCT.TextBoxInit("txtDenno", "");//返修单号

//日期 : JsCT.DatePickerInit("txt(列名简称)", new Date().format("yyyy/MM/dd"));//(列描述)
//弹出查询 : JsCT.SearchInput.Init("txt(列名简称)", (点击方法));//(列描述)
//其他特殊方法(区分,下拉等; 根据当前程序版本各异) : 略

//----getRecord 获取单条数据 赋值----
JsCT.SetVal("txt(列名简称)", dto.(列名));
JsCT.SetVal("txtDenno", dto.REPRecv_Denno);

//下拉控件 等 : JsCT.GetEj2InstancesObj("#txt(列名简称)").value = dto.(列名);
//弹出查询 : JsCT.SetAttr("txt(列名简称)", dto.(列名), dto.(关联查询列名));

//----doSaveData 保存----
dto.(列名) = $("#txt(列名简称)").val();
dto.REPRecv_Denno = $("#txtDenno").val();

//下拉控件 等 : dto.(列名) = JsCT.GetEj2InstancesObj("#txt(列名简称)").value;
//弹出查询 : dto.(列名) = $("#txt(列名简称)").attr("tagid");

//----ctlclosefn 锁定方法 : flag : true 锁定 false 解锁----
JsCT.GetEj2InstancesObj("#txt(列名简称)").readonly = flag;
JsCT.GetEj2InstancesObj("#txtDenno").readonly = flag;

//弹出查询 : cusCtlReadOnly("txt(列名简称)", flag);
//按钮 : JsCT.GetEj2InstancesObj("#btn").disabled = flag;
//表格 : grid.editSettings.allowEditing = !flag;

//----clearfn 清空方法----
JsCT.SetVal("txt(列名简称)", "");
JsCT.SetVal("txtDenno", "");

//下拉控件 等 : JsCT.GetEj2InstancesObj("#txt(列名简称)").value = null;    
//弹出查询 : JsCT.SetAttr("txt(列名简称)", "", "");
//表格 : grid.dataSource = [];

```
