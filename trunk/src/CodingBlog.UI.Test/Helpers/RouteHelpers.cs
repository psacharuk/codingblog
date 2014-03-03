using System.Web;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace CodingBlog.UI.Test.Helpers
{
    public static class RouteHelpers
    {
        public static RouteData TestRoute(string url, object expectedValues)
        {
            var routeConfig = new RouteCollection();
            MvcApplication.RegisterRoutes(routeConfig);
            var mockHttpContext = MakeMockHttpContext(url);

            RouteData routeData = routeConfig.GetRouteData(mockHttpContext.Object);

            Assert.IsNotNull(routeData.Route, "No route was matched");

            var expectedDict = new RouteValueDictionary(expectedValues);

            foreach (var expectedVal in expectedDict)
            {
                if(expectedVal.Value == null)
                    Assert.IsNull(routeData.Values[expectedVal.Key]);
                else
                    Assert.AreEqual(expectedVal.Value.ToString(),
                        routeData.Values[expectedVal.Key].ToString());
            }

            return routeData;
        }

        private static Mock<HttpContextBase> MakeMockHttpContext(string url)
        {
            var mockHttpContext = new Mock<HttpContextBase>();

            var mockRequest = new Mock<HttpRequestBase>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);
            mockRequest.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(url);

            var mockResponse = new Mock<HttpResponseBase>();
            mockHttpContext.Setup(x => x.Response).Returns(mockResponse.Object);
            mockResponse.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(x => x);
            return mockHttpContext;
        }
    }
}