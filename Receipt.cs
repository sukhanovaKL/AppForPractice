//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppForPractice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public string Name { get; set; }
        public string PhoneOrganization { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.TimeSpan TimeStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public System.TimeSpan TimeEnd { get; set; }
        public int CoutMinutes { get; set; }
        public int InternetPricesId { get; set; }
        public int TotalCost { get; set; }
        public string Number { get; set; }
        public string FIO_Operator { get; set; }
        public int ShiftNumber { get; set; }
        public int KlientId { get; set; }
    
        public virtual InternetPrice InternetPrice { get; set; }
        public virtual KlientsInfo KlientsInfo { get; set; }
    }
}
