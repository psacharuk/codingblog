using CodingBlog.UI.Test.Helpers;
using NUnit.Framework;

namespace CodingBlog.UI.Test
{
    [TestFixture]
    public class RouteTableTests
    {
        [Test]
        public void url_when_slash_redirect_to_post_list()
        {
            string url = "~/";

            RouteHelpers.TestRoute(url, new
            {
                Controller = "Post", 
                Action = "List",
                Year = string.Empty,
                Month = string.Empty,
                Day = string.Empty
            });
        }

        [Test]
        public void url_when_full_date_and_post_name_redirect_to_post_details_by_date_and_name()
        {
            string url = "~/2011/03/22/post-name";
            RouteHelpers.TestRoute(url, new
            {
                Controller = "Post",
                Action = "Details",
                Year = "2011",
                Month = "03",
                Day = "22",
                PostName = "post-name"
            });
        }

        [Test]
        public void url_when_full_date_redirect_to_post_list_by_full_name()
        {
            string url = "~/2011/03/22";
            RouteHelpers.TestRoute(url, new
            {
                Controller = "Post",
                Action = "List",
                Year = "2011",
                Month = "03",
                Day = "22",
            });
        }

        [Test]
        public void url_when_year_month_redirect_to_post_list_by_year_month()
        {
            string url = "~/2011/03";
            RouteHelpers.TestRoute(url, new
            {
                Controller = "Post",
                Action = "List",
                Year = "2011",
                Month = "03",
                Day = string.Empty,
            });   
        }

        [Test]
        public void url_when_year_redirect_to_post_list_by_year()
        {
            string url = "~/2011";
            RouteHelpers.TestRoute(url, new
            {
                Controller = "Post",
                Action = "List",
                Year = "2011",
                Month = string.Empty,
                Day = string.Empty,
            });
        }

        [Test]
        public void url_when_tag_tag_name_redirect_to_post_list_by_tag()
        {
            string url = "~/Tag/tag-name";
            RouteHelpers.TestRoute(url, new
            {
                Controller = "Post",
                Action = "ListPerTag",
                Tag = "tag-name"
            });
        }

        [Test]
        public void url_when_cb_admin_redirect_to_admin_index()
        {
            string url = "~/cb-admin";
            RouteHelpers.TestRoute(url, new
            {
                Controller = "Admin",
                Action = "Index"
            });
        }
    }
}