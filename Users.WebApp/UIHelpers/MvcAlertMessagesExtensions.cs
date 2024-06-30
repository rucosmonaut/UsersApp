namespace Users.WebApp.UIHelpers
{
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Web;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class MvcAlertMessagesExtensions
    {
        private const string AlertPrefix = "MvcAlert.";

        public static ActionResult WithAlert(
            this ActionResult actionResult,
            AlertClass alertClass,
            string message,
            HttpContext httpContext)
        {
            var response = httpContext.Response;
            var cookies = response.Cookies;
            var cookieOptions = new CookieOptions
            {
                Path = "/",
                Secure = true
            };
            var cookieKey = string.Format(
                format: AlertPrefix + "{0}",
                arg0: alertClass);
            var cookieValue = HttpUtility.UrlEncode(message);

            cookies.Append(
                key: cookieKey,
                value: cookieValue,
                options: cookieOptions);
            return actionResult;
        }

        public static HtmlString Alerts(
            this HtmlHelper helper,
            HttpContext httpContext)
        {
            var builder = new StringBuilder();
            var cookieCollection = httpContext.Request.Cookies;

            foreach (var cookieKey in cookieCollection.Keys)
            {
                if (!cookieKey.StartsWith(AlertPrefix))
                {
                    continue;
                }

                var cookieValue = cookieCollection[cookieKey];

                builder.AppendFormat(
                    format: "<div class='alert alert-timeout alert-{0}' id='alertTimeout'>{1}</div>",
                    arg0: cookieKey
                       .Replace(
                            oldValue: AlertPrefix,
                            newValue: string.Empty)
                       .ToLower(),
                    arg1: HtmlEncoder
                        .Default
                        .Encode(
                            value: HttpUtility.UrlDecode(
                                str: cookieValue)!));

                httpContext
                    .Response
                    .Cookies
                    .Delete(key: cookieKey);
            }

            return new HtmlString(
                value: builder.ToString());
        }

        public static HtmlString AlertsTimeoutScript(this HtmlHelper helper)
        {
            const string Script = @"<script type='text/javascript'>" +
                     @" $(function () { setTimeout (function () { $('.alert-timeout').fadeOut(); }, 5000); });" +
                     @"</script>";

            return new HtmlString(
                value: Script);
        }
    }
}
