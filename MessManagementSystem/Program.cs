using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MessManagementSystem.Entities;
using MessManagementSystem.Enums;
using MessManagementSystem.Factory;
using MessManagementSystem.Repositories;

namespace MessManagementSystem
{
    internal class Program
    {
        public static MemberRepository mRepo = new MemberRepository();
        static void Main(string[] args)
        {
            try
            {
                DoTask();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {

                Console.ReadLine();

            }
        }
        static void CenterText(string text)
        {
            string[] lines = text.Split('\n');
            int windowWidth = Console.WindowWidth;
            int maxLineLength = 0;
            foreach (string line in lines)
            {
                maxLineLength = Math.Max(maxLineLength, line.Length);
            }

            foreach (string line in lines)
            {
                int spaces = Math.Max((windowWidth - maxLineLength) / 2, 0);
                Console.WriteLine(new string(' ', spaces) + line.PadRight(maxLineLength));
            }
        }

        private static void DoTask()
        {
            DateTime mydate = DateTime.Now;
            int operation = 0;
            CenterText("Mess Management System (MMS)");
            CenterText("═══════════════════════════");
            CenterText("Date:"+mydate);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            CenterText("Welcome to mess member booking dashboard\n");
            Console.ResetColor();
            Console.WriteLine();
            CenterText("How many actions would you like to take ?\n");

            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                CenterText("Select Your Action Number");
                CenterText("═════════════════════════════");
                CenterText("Instructions:\n\n1. Read Members Information \n2. Create Member \n3. Update Member \n4. Delete Member\n5. Show Single Member");
                operation = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (operation)
                {
                    case 1:
                        ShowMember(null);
                        break;
                    case 2:
                        CreateMember();
                        break;
                    case 3:
                        UpdateMember();
                        break;
                    case 4:
                        DeleteMember();
                        break;
                    case 5:
                        ShowSingleMember();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        CenterText("Please Input valid Instruction Number!\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private static void ShowSingleMember()
        {
            Console.WriteLine("Enter Member Id");
            int memId = Convert.ToInt32(Console.ReadLine());
            MessMember mem = mRepo.GetMember(memId);
            ShowMember(mem);
        }

        private static void DeleteMember()
        {
            Console.WriteLine("Enter Member Id");
            int memId = Convert.ToInt32(Console.ReadLine());
            MessMember delMember = mRepo.DeleteMember(memId);
            ShowMember(delMember);
        }

        private static void UpdateMember()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("**You can update all fields except date and email.");
            Console.ResetColor();
            Console.WriteLine("Enter Update Id:");
            int memId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter Update Name:");
            string name =  Console.ReadLine();

            Console.WriteLine("\nEnter Update Phone Number:");
            string phoneNumber =  Console.ReadLine();

            string email = "";

            Console.WriteLine("\nEnter Update Room No:");
            string roomNo =  Console.ReadLine();

            Console.WriteLine("\nEnter Update Seat No:");
            string seatNo =  Console.ReadLine();

            Console.WriteLine("\nEnter Update Amount:");
            decimal totalPaid = Convert.ToDecimal(Console.ReadLine());

        EnterRoomType:
            Console.WriteLine("\nEnter Update Room type:\nInstructions:\n\n1. Vip \n2. Exclusive \n3. Elegant");

            RoomType rType;
            string rTypeValue = Console.ReadLine();
            try
            {
                rType = (RoomType)(Enum.Parse(typeof(RoomType), rTypeValue));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterRoomType;
            }

        PaymentType:
            Console.WriteLine("\nEnter Update Payment type:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Hints: * Cash Payment = 10% Discount, Credit Payment = Discount not allowed");
            Console.ResetColor();
            Console.WriteLine("\nInstructions:\n1. Cash Payment \n2. Credit Payment");

            PaymentType payType;
            string payTypeValue = Console.ReadLine();
            try
            {
                payType = (PaymentType)(Enum.Parse(typeof(PaymentType), payTypeValue));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto PaymentType;
            }
            
            string bookingDate = "";
            Console.WriteLine();

            MessMember member = new MessMember(memId, name, phoneNumber, email, roomNo, seatNo, totalPaid, rType,payType,bookingDate);
            BaseMemberFactory upMemFactory = new MessMemberManagerFactory().CreateFactory(member);
            upMemFactory.ApplyTotalPaid();
            MessMember upMem = mRepo.UpdateMember(member);
            ShowMember(upMem);

        }
        
        private static void CreateMember()
        {
            int memId = 0;
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter Phone Number:");
            string phoneNumber =  Console.ReadLine();

            Console.WriteLine("\nEnter Email:");
            string email =  Console.ReadLine();

            Console.WriteLine("\nEnter Room No:");
            string roomNo =  Console.ReadLine();

            Console.WriteLine("\nEnter Seat No:");
            string seatNo =  Console.ReadLine();

            Console.WriteLine("\nEnter Total Amount:");
            decimal totalPaid =Convert.ToDecimal(Console.ReadLine());


        EnterRoomType:
            Console.WriteLine("\nEnter Room type:\nInstructions:\n\n1. Vip \n2. Exclusive \n3. Elegant");

            RoomType rType;
            string rTypeValue = Console.ReadLine();
            try
            {
                rType = (RoomType)(Enum.Parse(typeof(RoomType), rTypeValue));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterRoomType;
            }

            PaymentType:
            Console.WriteLine("\nEnter Payment type:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Hints: * Cash Payment = 10% Discount, Credit Payment = Discount not allowed");
            Console.ResetColor();
            Console.WriteLine("\nInstructions:\n1. Cash Payment \n2. Credit Payment");

            PaymentType payType;
            string payTypeValue = Console.ReadLine();
            try
            {
                payType = (PaymentType)(Enum.Parse(typeof(PaymentType), payTypeValue));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto PaymentType;
            }

            Console.WriteLine("\nEnter Booking Date:");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Date format: (DD-MM-YY)");
            Console.ResetColor();
            string bookingDate = Console.ReadLine();
            Console.WriteLine();
            

            MessMember member = new MessMember(memId, name, phoneNumber, email, roomNo, seatNo, totalPaid, rType, payType, bookingDate);

            BaseMemberFactory memFactory = new MessMemberManagerFactory().CreateFactory(member);
            memFactory.ApplyTotalPaid();
            MessMember newMember = mRepo.CreateNewMember(member);
            ShowMember(newMember);
        }

        private static void ShowMember(MessMember mem)
        {
            List<MessMember> messMembers = new List<MessMember>();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("╔═══╦════════╦════════════╦════════════════╦═══════╦═══════╦══════════╦════════╦══════════╦════════╦════════╦════════╗");
            Console.ResetColor();

            Console.WriteLine(string.Format("|{0,-3}|{1,-8}|{2,-12}|{3,-16}|{4,-7}|{5,-7}|{6,-10}|{7,-8}|{8,-10}|{9,-8}|{10,-8}|{11,-8}|",
                "ID", "Name", "Number", "Email", "Room No", "Seat No", "Room Type", "Pay Type", "Total Paid", "Discount", "Net Pay","Date"));

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("╠═══╬════════╬════════════╬════════════════╬═══════╬═══════╬══════════╬════════╬══════════╬════════╬════════╬════════╣");
            Console.ResetColor();

            if (mem == null)
            {
                messMembers = mRepo.GetMembers().ToList();
                int totalMembers = messMembers.Count;

                for (int i = 0; i < totalMembers; i++)
                {
                    MessMember item = messMembers[i];
                    Console.WriteLine(string.Format("|{0,-3}|{1,-8}|{2,-12}|{3,-16}|{4,-7}|{5,-7}|{6,-10}|{7,-8}|{8,-10}|{9,-8}|{10,-8}|{11,-8}|",
                        item.Id, item.Name, item.PhoneNumber, item.Email, item.RoomNo, item.SeatNo, item.Rtype, item.PayType, item.TotalPaid, item.Discount, item.NetAmount, item.BookingDate));

                    if (i == totalMembers - 1) 
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("╚═══╩════════╩════════════╩════════════════╩═══════╩═══════╩══════════╩════════╩══════════╩════════╩════════╩════════╝");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                 Console.WriteLine("╠═══╬════════╬════════════╬════════════════╬═══════╬═══════╬══════════╬════════╬══════════╬════════╬════════╬════════╣");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.WriteLine(string.Format("|{0,-3}|{1,-8}|{2,-12}|{3,-16}|{4,-7}|{5,-7}|{6,-10}|{7,-8}|{8,-10}|{9,-8}|{10,-8}|{11,-8}|",
                    mem.Id, mem.Name, mem.PhoneNumber, mem.Email, mem.RoomNo, mem.SeatNo, mem.Rtype, mem.PayType, mem.TotalPaid, mem.Discount, mem.NetAmount,mem.BookingDate));

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("╚═══╩════════╩════════════╩════════════════╩═══════╩═══════╩══════════╩════════╩══════════╩════════╩════════╩════════╝");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
