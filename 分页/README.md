# 分页控件

这只是一个非常简单的分页控件，原理很简单：自定义一个用户控件，有一个委托，用户实现跳转页面的委托就行了。

```
TurnPage1.InitControl(GoToPage);
```

其中`GoToPage`是自己显示的跳转页面的方法

```
        /// <summary>
        /// 分页跳转
        /// </summary>
        /// <param name="PageNum">当前页码</param>
        private void GoToPage(int PageNum)
        {
            //每页显示记录数
            int pageSize = TurnPage1.PageSize;
            //总记录数
            int totalCount = 0;
            //分页数
            int pageCount = 0;
            
            //查询总记录数和当前页的数据
            ......

            //设置当前页和总记录数
            TurnPage1.CurrPageNum = PageNum;
            TurnPage1.DataCount = totalCount;

            //计算总页数
            try
            {
                pageCount = totalCount / pageSize;

                if (totalCount % pageSize != 0)
                    pageCount++;

                TurnPage1.TotalPageNum = pageCount;
            }
            catch
            {
                TurnPage1.TotalPageNum = 1;
            }

            TurnPage1.ControlButtonClick();
        }
        
 ```

实际上，还是可以再优化


