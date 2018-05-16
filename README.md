# .NET-App

### C# 源码计数器

- 设计背景

编程工作中，有些文档需要填写代码量，例如申请软件著作权。查阅相关资料之后，编写了这个小程序。

- 设计思路

主要思路为分析项目文件，根据项目文件查找代码文件，然后遍历代码文件
进行分析

- 相关技术
	- 抽象类
	- 文件操作
	- 字符串解析

- 项目结构
	- 抽象类
		- FileAnalyser 文件分析类，负责校验文件，并定义分析文件方法
		- ProjectDocument 项目工程类，负责定义项目文件属性及方法
	- 实体类
		- FileEntity 文件实体类，负责存储代码文件信息
		- ProjectFileEntity 项目工程实体类，负责存储项目文件信息
		- LineEntity 代码行实体类，负责存储代码行信息
	- 集合类
		- FileCollection 文件实体集合，负责文件集合统计数据
	- 功能类
		- CSProjectDocument C#项目工程类，继承ProjectDocument类，负责分析C#项目工程文件
		- CSFileAnalyser cs文件分析类，继承FileAnalyser，负责分析cs文件

- 代码示例
	
	调用方法
```
            ProjectDocument mDocument = ProjectDocument.Create(this.txtFileName.Text);
            if (mDocument == null)
            {
                MessageBox.Show("Analyse for " + this.txtFileName.Text + " error !");
                return;
            }
            mDocument.ClearResults();
            mDocument.AnalyseAllFile();
```

### C# 房贷计算器

- 设计背景

	百度小程序中的房贷计算器不能满足我个人的需求，故而开发一个.NET小程序。希望后期能用JS重写，发布在网上供大家使用。

- 设计思路

	根据百度公式：等额本息月还款 = [贷款本金×月利率×（1+月利率）^还款月数]÷[（1+月利率）^还款月数－1]

- 相关技术

	- WinForm 键入事件
	- 字符串与浮点型数据转换

- 功能

	键入相关数据， 进行计算


### C# 键盘记录器

---

- 设计背景

	Win系统带有API可以获取键入值，本小程序主要应用了一个网上广为流传的类，可以说一个测试DEMO。有俗称为键盘钩子

- 设计思路

	使用Win API获取建入值

- 相关技术

	Win API

- 功能

	开启记录，记录每个键盘键入值，最终可以导出

### C# 抽签小程序

- 设计背景

	设置一个Excel名单表，对名单进行随机抽取。

- 设计思路

	使用Timer定时器，运行定时器进行名单随机滚动，停止定时器获得抽签结果

- 相关技术

	- 随机数
	- Excel读取/导出
	- XML文档读写

- 相关类库

	- C1.C1Excel Excel操作相关

- 功能

	- 读取Excel名单
	- 名单随机抽签
	- 评分功能
	- Excel导出功能


### C# 爬虫小程序

- 设计思路

	主要基于Http Get请求网页数据，进行分析。涉及递归调用，多线程提高效率，守护线程等。

- 相关技术

	- 抽象类
	- 多线程 
	- 队列
	- Http Get请求
	- 字符串解析
- 项目结构

	- AbsChain 职责链抽象类，负责定义HTML处理方法，定义递归处理方法等
	- AbsThreadManager 线程管理抽象类，负责定义守望线程，管理多线程
	- UrlQueue URL队列对象，管理URL队列
	- Crawl 爬虫对象，负责结合URL队列与职责链，运行爬取功能
	- HttpGet HTTP GET请求类，负责获取HTML文本
	- ThreadEntity 爬虫线程，实体对象


### C# 妈妈再打我一下生成器

- 设计背景

	网上很火的一个“妈妈再打我一下”的漫画图片，给了网友无限的想象发挥空间，此小程序可以给图片添加配文的形式，快速生成图片

- 设计思路

	GDI+ 绘图技术，在图片基础上添加文字

- 相关技术

	GDI+