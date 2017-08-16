
using System;
namespace WCF.BussinessObject.Objects
{
    public class  ExpertsObjects
    {
         public Guid ExpertId { get; set; }  
        public string FullName { get; set; }  
        public string Email { get; set; }  
        public string Mobile { get; set; }  
        public string Address { get; set; }  
        public string Specialize { get; set; }  
        public Nullable<DateTime> StartDate { get; set; }  
        public Nullable<bool> Status { get; set; }  
        public string Description { get; set; }  
        public Nullable<bool> Deleted { get; set; }
       
    }
}
