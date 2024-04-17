# JS控件数据验证

---

## 方式

控件增加 required 属性

![js](https://skillicons.dev/icons?i=js)

```

<input id="txtDate" name="txtDate" required />

```
---

## 验证控件范围

需要将验证的控件放在 id 为 base 的节点下, 才能正确的拾取待验证的控件

![js](https://skillicons.dev/icons?i=js)

```

<div id="base" class="e-content">
    . . .
</div>

```

---

> 备注 :  如果需要控制台调试验证情况 : 请在打开页面时, 断点 initInputRule2() 方法 <br>
> 控制台会输出自动拾取控件的内容 (信息 console.log("inputRequired")  ) 为 :  <br>
><br>
> inputRequired_id txtDate<br>
> inputRequired_name txtDate<br>
> inputRequired_id txtSoko<br>
> inputRequired_name undefined<br>
> inputRequired_id txtSiireGenNo<br>
> inputRequired_name txtSiireGenNo<br>

> 备注2 : 放大镜查询的控件 必须增加 name 属性, 值等于控件 ID
