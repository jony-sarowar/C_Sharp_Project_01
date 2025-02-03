using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessManagementSystem.Entities;

namespace MessManagementSystem.Interfaces
{
    public interface IMessMemberContract
    {
        IEnumerable<MessMember> GetMembers();
        MessMember GetMember(int id);
        MessMember CreateNewMember(MessMember member);
        MessMember UpdateMember(MessMember member);
        MessMember DeleteMember(int id);
    }
}
