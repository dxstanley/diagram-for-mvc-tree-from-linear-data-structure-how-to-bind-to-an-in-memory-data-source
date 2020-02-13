using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagramFromTree.Models
{
    public class Department
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string DepartmentName { get; set; }

        public Department(int id, int? parentId, string departmentName)
        {
            ID = id;
            ParentID = parentId;
            DepartmentName = departmentName;
        }

        public Department() { }
    }
}