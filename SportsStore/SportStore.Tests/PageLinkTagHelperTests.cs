﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor;
using Moq;
using SportsStore.Infrastructure;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{

    public class PageLinkTagHelperTests
    {
        //[Fact]
        //public void Can_Generate_Page_Links()
        //{
        //    var urlHelper = new Mock<IUrlHelper>();
        //    urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
        //        .Returns("Test/Page1")
        //        .Returns("Test/Page2")
        //        .Returns("Test/Page3");
        //    var urlHelperFactory = new Mock<IUrlHelperFactory>();
        //    urlHelperFactory.Setup(f =>
        //  f.GetUrlHelper(It.IsAny<ActionContext>()))
        //        .Returns(urlHelper.Object);
        //    PageLinkTagHelper helper =
        //        new PageLinkTagHelper(urlHelperFactory.Object)
        //        {
        //            PageModel = new PagingInfo
        //            {
        //                CurrentPage = 2,
        //                TotalItems = 28,
        //                ItemsPerPage = 10
        //            },
        //            PageAction = "Test"
        //        };
           

        //}
    }
}
