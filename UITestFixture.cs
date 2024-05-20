using SampleProject.PageObjectModel;

namespace AtataUITests1
{
    [Parallelizable(ParallelScope.Self)]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp() =>
            AtataContext.Configure().Build();

        [TearDown]
        public void TearDown() =>
            AtataContext.Current?.Dispose();
        protected static ProductsPage Login() =>
       Go.To<LoginPage>()
           .Email.Set("admin@mail.com")
           .Password.Set("abc123")
           .SignIn.ClickAndGo();
    }
}
