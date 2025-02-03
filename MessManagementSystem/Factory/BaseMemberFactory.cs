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
    public abstract class BaseMemberFactory
    {
        public abstract IMessMemberManager Create();
        protected MessMember _mem;

        protected BaseMemberFactory(MessMember mem)
        {
            _mem = mem;
        }

        public MessMember ApplyTotalPaid()
        {
            IMessMemberManager manager = this.Create();

            _mem.Discount = manager.GetDiscount() / 100 * _mem.TotalPaid;

            if (_mem.PayType == PaymentType.Cash)
            {
                _mem.NetAmount = _mem.TotalPaid - _mem.Discount;

            }
            else
            {
                _mem.NetAmount = _mem.TotalPaid - _mem.Discount;
            }
             
            return _mem;

        }
    }
}
