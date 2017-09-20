# Oracle使用

工作中使用Oracle的一些记录

## 本地网络服务名配置

使用`oracle configuration assistant`来进行本地网络服务名配置，参考[oracle本地网络服务名配置](http://jingyan.baidu.com/article/73c3ce2818b5e7e50343d925.html)

## 通用的分页

通用的分页的构造语句

```
        // <summary>
        /// Oracle通用分页
        /// </summary>
        /// <param name="strSql">符合条件的所有记录集查询SQL字符串</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageNum">当前页</param>
        public static string GetOraclePagerString(string strSql, int pageSize, int pageNum)
        {
            string strRet = "select * from (select A.*, rownum rn from (select * from (" + strSql + " )) A where rownum <= " + pageSize * pageNum + ") where rn > " + pageSize * (pageNum - 1);
            return strRet;
        }
```

