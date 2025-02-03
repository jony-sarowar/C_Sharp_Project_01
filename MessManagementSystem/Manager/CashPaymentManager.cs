using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Manager
{
    public class CashPaymentManager : IMessMemberManager
    {
        public decimal GetDiscount()
        {
            return 10;
        }
    }
}
