# ASP.NET-Tips

记录一些ASP.NET的小知识点

**生成GUID**

```C#
Guid.NewGuid().ToString().Replace("-", "").ToUpper();
```
