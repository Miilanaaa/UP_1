//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP_1.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zavka
    {
        public int Id_zavka { get; set; }
        public Nullable<int> Kod { get; set; }
        public string Id_Specialnost { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
        public virtual Specialnost Specialnost { get; set; }
    }
}
