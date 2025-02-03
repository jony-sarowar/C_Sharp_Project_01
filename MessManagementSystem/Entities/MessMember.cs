using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessManagementSystem.Enums;

namespace MessManagementSystem.Entities
{
    public class MessMember
    {
        int id;
        string name;
        string phoneNumber;
        string email;
        string roomNo;
        string seatNo;
        decimal totalPaid;

        decimal discount;
        decimal netAmount;

        RoomType rtype;
        PaymentType payType;
        string bookingDate;
        public MessMember()
        {
            
        }

        public MessMember(int id, string name, string phoneNumber, string email, string roomNo, string seatNo, decimal totalPaid, RoomType rtype, PaymentType payType, string bookingDate)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.roomNo = roomNo;
            this.seatNo = seatNo;
            this.totalPaid = totalPaid;
            this.rtype = rtype;
            this.payType = payType;
            this.bookingDate = bookingDate;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string RoomNo { get => roomNo; set => roomNo = value; }
        public string SeatNo { get => seatNo; set => seatNo = value; }
        public decimal TotalPaid { get => totalPaid; set => totalPaid = value; }
        public decimal Discount { get => discount; set => discount = value; }
        public decimal NetAmount { get => netAmount; set => netAmount = value; }
        public RoomType Rtype { get => rtype; set => rtype = value; }
        public PaymentType PayType { get => payType; set => payType = value; }
        public string BookingDate { get => bookingDate; set => bookingDate = value; }
    }
}
