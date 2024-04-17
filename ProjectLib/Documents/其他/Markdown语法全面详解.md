# Markdown 语法全面详解

[Markdown 官方教程](https://markdown.com.cn/basic-syntax/headings.html)

[语法全面详解(知乎外链)](https://zhuanlan.zhihu.com/p/143586985)

---

## 简介

Markdown是一种轻量级的标记语言，它允许人们使用易读易写的纯文本格式编写文档，借助可实现快速排版且转换成格式丰富的HTML页面。
目前被越来越多的写作爱好者及工作者使用。
其语法十分简单，常用标记符号少，学习时间少，一旦掌握这种标记语言，将极大提高效率。
但是若需要复杂排版如左右对齐缩进等，还是选择word等专业软件。
Markdown用简洁的语法代替排版，而不像常用文字处理软件Word或Pages等进行排版、字体、插入等设置。
标记语言可以通过键盘即实现字体大小、插入表格，图片，超链接，脚注等。

Markdown的优点最大好处是：快速掌握。
简单，适合所有人群，方便打开，不至于出现低版本word打不开高版本word的文档。
避免软件不同，如对方是wps，看到的word文档效果和你不一样。
方便快速排版，节省时间。
纯文本内容，兼容所有的文本编辑器与文字处理软件。
支持Markdown语法的编辑器有很多，部分网站也支持。

两款在线编辑器：
http://daringfireball.net/projects/markdown/dingus
https://stackedit.io/ 

## Markdown 使用语法

1. 标题设置（#方法较方便）
(1) 第一种方法：在标题文字前加#，一级标题为#，二级标题为##，三级标题为###，以此类推，最多六级，其中一级标题文字最大。
(2) 第二种方法：在标题文字下行输入--（符号前不可有空格），可表示二级标题。在标题文字下行输入==，可表示一级标题。 

# 一级标题
## 二级标题
### 三级标题

- 项目1
- 项目2
- 项目3

2. 引用块注释>在一段文字前表示引用

> 引用块注释

3. 文字斜体 单 * 包括，加粗  双 * 包括，“*”可用“_”代替，也能实现斜体和加粗。

 *斜体*  **加粗**

4. 文字间换行：< br > 或 \ 或 回车

文<br>字 \
间

5. 图片 ! [ 文字内容 ] ( 图片名称 )  图片需要和.md文件放在一起或者为网络位置。

![文字内容](图片名称) 

6. 代码块

```

代码区

``` 

7. 任务列表

[x] 任务1 \
[ ] 任务2 \
[ ] 任务3

8. 图标 https://skillicons.dev

[![My Skills](https://skillicons.dev/icons?i=js,html,css,wasm)](https://skillicons.dev)

![js](https://skillicons.dev/icons?i=js)
![html](https://skillicons.dev/icons?i=html)
![css](https://skillicons.dev/icons?i=css)
![cs](https://skillicons.dev/icons?i=cs)
![dotnet](https://skillicons.dev/icons?i=dotnet)

---

> 备注 : 有些 Markdown 扩展内容 由于程序的问题无法兼容展示 这里暂不列出