using System;
using System.Collections.Generic;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Urls;
using System.Linq;

namespace FubuMVC.Core.Registration.Querying
{
    public class ChainSearch
    {
        // TODO -- add method here too
        public Type Type;
        public string CategoryOrHttpMethod = Categories.DEFAULT;
        public CategorySearchMode CategoryMode = CategorySearchMode.Relaxed;
        public TypeSearchMode TypeMode = TypeSearchMode.Any;

        public string Description()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BehaviorChain> FindForCategory(IEnumerable<BehaviorChain> chains)
        {
            if (CategoryMode == CategorySearchMode.Strict)
            {
                var category = CategoryOrHttpMethod ?? Categories.DEFAULT;
                return chains.Where(x => x.MatchesCategoryOrHttpMethod(category));
            }

            if (chains.Count() == 1)
            {
                return chains;
            }

            if (CategoryOrHttpMethod == null)
            {
                var candidates = chains.Where(x => x.MatchesCategoryOrHttpMethod(Categories.DEFAULT));
                if (candidates.Count() > 0) return candidates;

                return chains.Where(x => x.UrlCategory.Category == null);
            }

            return chains.Where(x => x.MatchesCategoryOrHttpMethod(CategoryOrHttpMethod));
        }
    }
}