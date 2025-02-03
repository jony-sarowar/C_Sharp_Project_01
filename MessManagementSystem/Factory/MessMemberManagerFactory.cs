using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessManagementSystem.Entities;
using MessManagementSystem.Enums;
using MessManagementSystem.Manager;

namespace MessManagementSystem.Factory
{
    public class MessMemberManagerFactory
    {
        public BaseMemberFactory CreateFactory(MessMember mem)
        {
            BaseMemberFactory returnValue = null;
            if (mem.PayType == PaymentType.Credit)
            {
                returnValue = new CraditPaymentMemberFactory(mem);
            }
            else if (mem.PayType == PaymentType.Cash)
            {
                returnValue = new CashPaymentMemberFactory(mem);
            }
            return returnValue;
        }
    }
}
