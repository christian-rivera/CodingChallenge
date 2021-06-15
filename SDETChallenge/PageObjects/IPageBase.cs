using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.PageObjects
{
    public interface IPageBase
    {
        int getPrice();
        int priceToInt(string value);
    }
}
