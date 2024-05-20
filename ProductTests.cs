using SampleProject.PageObjectModel;
using NUnit.Framework;
using System;
using System.Linq;
using Atata;

namespace AtataUITests1
{

    public class ProductTest : UITestFixture
    {
        decimal Total = 570;
        ProductsPage productPage;
        [SetUp]
        public void LoginAndNavigateToProductPage()
        {
            productPage = Login();
        }

        [Test]
        public void DeleteUsingJSConfirm()
        {
            Go.To<DashBoardPage>().Products.Click();
            productPage.Header.Should.Equal("Products")
            .Products.Rows.Count.Get(out int count).AggregateAssert(page => page
            .Products.Rows[x => x.Name == "Armchair"].DeleteUsingJSConfirm.Click()
            .Products.Rows[x => x.Name == "Armchair"].Should.Not.BePresent()
            .Products.Rows.Count.Should.Equal(count - 1).Products.Rows.Select(x => x.Price.Get()).ToArray().Sum().ToSutSubject().Should.Equal(Total)).
             Products.Rows.Select(x => x.Amount.Value).ToArray().Sum().ToSutSubject().Should.Equal(245);
            Thread.Sleep(5000);
        }

        [Test]
        public void DeleteUsingBSModelConfirm()
        {
            Go.To<DashBoardPage>().Products.Click();
            productPage.Header.Should.Equal("Products")
           .Products.Rows.Count.Get(out int count).AggregateAssert(page => page
            .Products.Rows[x => x.Name == "Armchair"].DeleteBSModel()
            .Products.Rows[x => x.Name == "Armchair"].Should.Not.BePresent()
            .Products.Rows.Count.Should.Equal(count - 1).Products.Rows.Select(x => x.Price.Get()).ToArray().Sum().ToSutSubject().Should.Equal(Total))
            .Products.Rows.Select(x => x.Amount.Value).ToArray().Sum().ToSutSubject().Should.Equal(245);
            Thread.Sleep(5000);

        }


        [Test]
        public void DeleteUsingJqueryConfirm()
        {
            Go.To<DashBoardPage>().Products.Click();
            productPage.Header.Should.Equal("Products")
           .Products.Rows.Count.Get(out int count).AggregateAssert(page => page
            .Products.Rows[x => x.Name == "Armchair"].DeleteJQuery()
            .Products.Rows[x => x.Name == "Armchair"].Should.Not.BePresent()
            .Products.Rows.Count.Should.Equal(count - 1).Products.Rows.Select(x => x.Price.Get()).ToArray().Sum().ToSutSubject().Should.Equal(Total))
            .Products.Rows.Select(x => x.Amount.Value).ToArray().Sum().ToSutSubject().Should.Equal(245);
            Thread.Sleep(5000);
        }

    }
}
