//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookmarks.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookmarksTag
    {
        public int BookmarkId { get; set; }
        public int TagId { get; set; }
    
        public virtual Bookmark Bookmark { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
