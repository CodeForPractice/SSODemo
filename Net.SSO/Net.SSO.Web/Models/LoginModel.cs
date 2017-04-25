using System.ComponentModel.DataAnnotations;

namespace Net.SSO.Web.Models
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginModel
    {
        public LoginModel()
        {
        }

        public LoginModel(string backUrl) : this()
        {
            BackUrl = backUrl;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string Pwd { get; set; }

        /// <summary>
        /// 回掉地址
        /// </summary>
        public string BackUrl { get; set; }
    }
}