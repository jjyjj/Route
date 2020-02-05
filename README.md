## Route 日常
#### 1
完成了初始的项目配置工作，采用数据库是sqlite。期间有几个问题：
* 使用数据库迁移， Add-Migration 名字 这一点不知道为什么出错，但是多次确定就迁移成功了
* 部署到github，还是出现了部署不成功的问题，自己并没有真正会使用，这里记录一下。操作步骤连接到自己的github=>点击右下方的部署确定即可
* 操作数据库方面，采用的是ef ，注入上下文，linq语法，快速简洁，但是这个项目中并没有将一些可重用代码封装。
#### 2
理解REST风格
REST是一种架构风格，并不是规范或标准，且与协议无关，但是要实现REST架构需要使用一些协议
[REST的优点]()
[REST的六大约束]()
[成熟度的级别]()
#### 3
* 资源的命名，采用名词形式，不要采取动词
eg：获取所有用户信息
X：api/getusers
V：api/users
eg：获取用户信息，并按照年龄排序
V:api/users?orderBy=name
___
ControllerBase与Controller
ApiController 注解
IActionResult
#### 4 http方法 
* post 创建
* get 获取
* delete 删除
* patch 更新
* put 替换