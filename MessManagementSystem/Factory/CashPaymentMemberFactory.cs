using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessManagementSystem.Entities;
using MessManagementSystem.Manager;

namespace MessManagementSystem.Factory
{
    internal class CashPaymentMemberFactory : BaseMemberFactory
    {
        public CashPaymentMemberFactory(MessMember mem) : base(mem)
        {
        }

        public override IMessMemberManager Create()
        {
            CashPaymentManager manager = new CashPaymentManager();
            decimal netPayment = _mem.TotalPaid;

            return manager;
        }
    }
}
