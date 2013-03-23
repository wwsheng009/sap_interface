namespace MvcSapInterface.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;

    public class ChangePasswordModel
    {
        #region Properties

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword
        {
            get; set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword
        {
            get; set;
        }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword
        {
            get; set;
        }

        #endregion Properties
    }

    public class LogOnModel
    {
        #region Properties

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password
        {
            get; set;
        }

        [Display(Name = "记住我?")]
        public bool RememberMe
        {
            get; set;
        }

        [Required]
        [Display(Name = "用户名")]
        public string UserName
        {
            get; set;
        }

        #endregion Properties
    }

    public class RegisterModel
    {
        #region Properties

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword
        {
            get; set;
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "电子邮件地址")]
        public string Email
        {
            get; set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password
        {
            get; set;
        }

        [Required]
        [Display(Name = "用户名")]
        public string UserName
        {
            get; set;
        }

        #endregion Properties
    }
}