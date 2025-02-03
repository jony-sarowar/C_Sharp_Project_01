using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessManagementSystem.Entities;
using MessManagementSystem.Manager;

namespace MessManagementSystem.Factory
{
    internal class CraditPaymentMemberFactory : BaseMemberFactory
    {
        public CraditPaymentMemberFactory(MessMember mem) : base(mem)
        {
        }

        public override IMessMemberManager Create()
        {
            CreditPaymentManager manager = new CreditPaymentManager();
            decimal netPayment = _mem.TotalPaid;

            return manager;
        }
    }
}
