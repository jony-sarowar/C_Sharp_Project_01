using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MessManagementSystem.Entities;
using MessManagementSystem.Enums;
using MessManagementSystem.Interfaces;

namespace MessManagementSystem.Repositories
{
    public class MemberRepository:IMessMemberContract
    {
        public List<MessMember> messMemberList;
        public MemberRepository() 
        {
            messMemberList = new List<MessMember>()
            {
                new MessMember {Id=1,Name="Jony",PhoneNumber="01824895119",Email="jony@gmail.com",RoomNo="R1",SeatNo="S1",TotalPaid=10000,Rtype=RoomType.Vip,PayType=PaymentType.Cash,BookingDate="22-01-25"},
                new MessMember {Id=2,Name="Fahim",PhoneNumber="01824890099",Email="fahim@gmail.com",RoomNo="R1",SeatNo="S2",TotalPaid=8000,Rtype=RoomType.Elegant,PayType=PaymentType.Credit,BookingDate="23-01-25"},
                new MessMember {Id=3,Name="Ananda",PhoneNumber="01772489009",Email="ananda@gmail.com",RoomNo="R1",SeatNo="S3",TotalPaid=12000,Rtype=RoomType.Exclusive,PayType=PaymentType.Cash,BookingDate="24-01-25"},
                new MessMember {Id=4,Name="Rifat",PhoneNumber="01992489007",Email="rifat@gmail.com",RoomNo="R1",SeatNo="S4",TotalPaid=15000,Rtype=RoomType.Vip,PayType=PaymentType.Credit,BookingDate="25-01-25"},
                new MessMember {Id=5,Name="Shohag",PhoneNumber="01332489559",Email="shohag@gmail.com",RoomNo="R1",SeatNo="S5",TotalPaid=5000,Rtype=RoomType.Elegant,PayType=PaymentType.Cash,BookingDate="26-01-25"}


            };
        }

        public MessMember CreateNewMember(MessMember member)
        {
            MessMember existingMember = (from m in messMemberList orderby m.Id descending select m).FirstOrDefault();
            member.Id = existingMember.Id + 1;
            messMemberList.Add(member);
            return member;
        }

        public MessMember DeleteMember(int id)
        {
            var member = GetMember(id);
            if (member != null)
            {
                messMemberList.Remove(member);
            }
            return member;
        }

        public MessMember GetMember(int id)
        {
            var mem = (from row in messMemberList where row.Id == id select row).FirstOrDefault();
            return mem;
        }

        public IEnumerable<MessMember> GetMembers()
        {
            return from rows in messMemberList select rows;
        }

        public MessMember UpdateMember(MessMember upMem)
        {
            MessMember mem = GetMember(upMem.Id);
            if (mem != null)
            {
                mem.Name = upMem.Name;
                mem.PhoneNumber = upMem.PhoneNumber;
                //mem.Email = upMem.Email;
                mem.RoomNo = upMem.RoomNo;
                mem.SeatNo = upMem.SeatNo;
                mem.TotalPaid = upMem.TotalPaid;
                mem.Rtype = upMem.Rtype;
                mem.PayType = upMem.PayType;
                //mem.BookingDate = upMem.BookingDate;
                mem.NetAmount = upMem.NetAmount;
                mem.Discount = upMem.Discount;


            }
            return mem;
        }
    }
}
