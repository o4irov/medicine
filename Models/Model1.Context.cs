﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace лр5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MedicineEntities : DbContext
    {
        public MedicineEntities()
            : base("name=MedicineEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Hospital_need_medicine> Hospital_need_medicine { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }
        public virtual DbSet<Pharmacy_has_medicine> Pharmacy_has_medicine { get; set; }
    
        public virtual ObjectResult<seaq_Result> seaq(Nullable<int> price, string sravn)
        {
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var sravnParameter = sravn != null ?
                new ObjectParameter("sravn", sravn) :
                new ObjectParameter("sravn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seaq_Result>("seaq", priceParameter, sravnParameter);
        }
    
        public virtual ObjectResult<seaq2_Result> seaq2(string name_of_medecine)
        {
            var name_of_medecineParameter = name_of_medecine != null ?
                new ObjectParameter("name_of_medecine", name_of_medecine) :
                new ObjectParameter("name_of_medecine", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seaq2_Result>("seaq2", name_of_medecineParameter);
        }
    }
}