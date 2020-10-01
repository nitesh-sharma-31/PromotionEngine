using App.PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PromotionEngine.BusinessLogic
{
    public interface IPromotionManager
    {
        List<Promotion> AvailblePromotions { get; }

        double CheckOut();

        void AddPromotion(Promotion promotion);
    }
}
