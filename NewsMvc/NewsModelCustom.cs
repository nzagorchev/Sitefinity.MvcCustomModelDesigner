using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Frontend.News.Mvc.Models;

namespace SitefinityWebApp.NewsMvc
{
    public class NewsModelCustom : NewsModel
    {
        public string NoItemsText { get; set; }

        protected override ContentListViewModel CreateListViewModelInstance()
        {
            var viewModel = new NewsListViewModel();
            viewModel.NoItemsText = this.NoItemsText;
            return viewModel;
        }
    }
}
