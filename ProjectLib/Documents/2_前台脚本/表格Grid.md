# 表格Grid

---

## 行选择范围 (1 到 10 行)

![js](https://skillicons.dev/icons?i=js)

```

grid.selectRowsByRange(0, 9)

```

---

## 列表跳转详细画面时, 取消列表页面勾选 

![js](https://skillicons.dev/icons?i=js)

```

grid.clearSelection();

```

---

## 保存时, 同时保存表格数据

![js](https://skillicons.dev/icons?i=js)

```

grid.saveCell(); 

```

---

## 表格行根据不同的条件变更css样式

![css](https://skillicons.dev/icons?i=css)

```

.isback {
    -webkit-text-stroke-color: red;
    -webkit-text-stroke-width: medium;
}

```

![js](https://skillicons.dev/icons?i=js)

```

grid.rowDataBound = rowBound;

function rowBound(args) {
    if (args.data['ZSR_Isback']==1) {
        args.row.classList.add('isback');
    } 
}

```

---
