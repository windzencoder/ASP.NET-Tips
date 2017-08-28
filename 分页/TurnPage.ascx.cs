using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web
{
    //转到第几页
    public delegate void GoToPage(int PageNum);
    //分页
    public partial class TurnPage : System.Web.UI.UserControl
    {
        
        private GoToPage _GoToPage = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="GP">代理</param>
        public void InitControl(GoToPage GP)
        {
            _GoToPage = GP;
        }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int DataCount
        {
            get { return Int32.Parse(lbl_TotalCount.Text); }
            set { lbl_TotalCount.Text = value.ToString(); }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrPageNum
        {
            get { return Int32.Parse(lbl_CurrPage.Text); }
            set { lbl_CurrPage.Text = value.ToString(); }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageNum
        {
            get { return Int32.Parse(lbl_TotalPage.Text); }
            set { lbl_TotalPage.Text = value.ToString(); }
        }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize
        {
            get { return Int32.Parse(ddl_PageSize.SelectedValue); }
        }

        /// <summary>
        /// 首页点击事件
        /// </summary>
        protected void btn_FristPage_Click(object sender, EventArgs e)
        {
            _GoToPage(1);
        }

        /// <summary>
        /// 上一页点击事件
        /// </summary>
        protected void btn_PrevPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_CurrPage.Text) > 1)
                _GoToPage(int.Parse(lbl_CurrPage.Text) - 1);            
            else            
                _GoToPage(1);            
        }

        /// <summary>
        /// 下一页点击事件
        /// </summary>
        protected void btn_NextPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_CurrPage.Text) < int.Parse(lbl_TotalPage.Text))
                _GoToPage(int.Parse(lbl_CurrPage.Text) + 1);
            else
                _GoToPage(int.Parse(lbl_TotalPage.Text));
        }

        /// <summary>
        /// 尾页点击事件
        /// </summary>
        protected void btn_LastPage_Click(object sender, EventArgs e)
        {
            _GoToPage(int.Parse(lbl_TotalPage.Text));
        }

        public void ControlButtonClick()
        {
            if (DataCount > 0)
            {
                btn_FristPage.Enabled = true;
                btn_PrevPage.Enabled = true;
                btn_LastPage.Enabled = true;
                btn_NextPage.Enabled = true;
            }
            else
            {
                btn_FristPage.Enabled = false;
                btn_PrevPage.Enabled = false;
                btn_LastPage.Enabled = false;
                btn_NextPage.Enabled = false;
            }


            //第一页
            if (CurrPageNum == 1)
            {
                btn_FristPage.Enabled = false;
                btn_PrevPage.Enabled = false;
            }
            //最后一页
            if (CurrPageNum == TotalPageNum)
            {
                btn_LastPage.Enabled = false;
                btn_NextPage.Enabled = false;
            }

            if (CurrPageNum == 0)
            {
                btn_FristPage.Enabled = false;
                btn_PrevPage.Enabled = false;
                btn_LastPage.Enabled = false;
                btn_NextPage.Enabled = false;
            }
        }

        /// <summary>
        /// 每页页数下拉框切换事件
        /// </summary>
        protected void ddl_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GoToPage(1);
        }

        /// <summary>
        /// GO按钮点击事件
        /// </summary>
        protected void btn_GO_Click(object sender, EventArgs e)
        {
            int pageNum;
            //尝试转换
            if (int.TryParse(txt_PageNum.Text, out pageNum))
            {
                if (pageNum > TotalPageNum)
                    _GoToPage(TotalPageNum);
                else if (pageNum < 1)
                    _GoToPage(1);
                else
                    _GoToPage(pageNum);
            }
        }

    }
}