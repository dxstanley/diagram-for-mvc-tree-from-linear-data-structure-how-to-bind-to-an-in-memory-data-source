using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagramFromTree.Models
{
    public class DepartmentProvider
    {
        public static IList<Department> GetDepartments()
        {
            IList<Department> objects = (IList<Department>)HttpContext.Current.Session["Departments"];
            if (objects == null)
            {
                objects = new List<Department>
                {
                    new Department(1, 0, "Corporate Headquarters"),
                    new Department(2, 1, "Sales and Marketing"),
                    new Department(3, 1, "Finance"),
                    new Department(4, 1, "Engineering"),
                    new Department(5, 2, "Field Office: Canada"),
                    new Department(6, 2, "Field Office: East Coast"),
                    new Department(7, 2, "Pacific Rim Headquarters"),
                    new Department(8, 2, "Marketing"),
                    new Department(9, 4, "Consumer Electronics Div."),
                    new Department(10, 4, "Software Products Div."),
                    new Department(11, 7, "Field Office: Singapore"),
                    new Department(12, 7, "Field Office: Japan"),
                    new Department(13, 9, "Software Development"),
                    new Department(14, 10, "Quality Assurance"),
                    new Department(15, 10, "Customer Support"),
                    new Department(16, 10, "Research and Development"),
                    new Department(17, 10, "Customer Services")
                };
                HttpContext.Current.Session["Departments"] = objects;
            }
            return objects;
        }

        public static void Update(Department department)
        {
            var editObject = GetEditableObject(department.ID);
            if (editObject != null)
            {
                editObject.DepartmentName = department.DepartmentName;
                editObject.ParentID = department.ParentID;
            }
        }

        public static void Delete(int departmentID)
        {
            var editObject = GetEditableObject(departmentID);
            if (editObject != null)
                GetDepartments().Remove(editObject);
        }

        private static object ObjectInsertLock = new object();

        public static Department Insert(Department department)
        {
            lock (ObjectInsertLock)
            {
                var editObject = new Department();
                editObject.ID = GetNextDepartmentID();
                editObject.DepartmentName = department.DepartmentName;
                editObject.ParentID = department.ParentID;
                return editObject;
            }
        }

        static int GetNextDepartmentID()
        {
            var deps = GetDepartments();
            return deps.Any() ? deps.Select(d => d.ID).Max() + 1 : 0;
        }

        static Department GetEditableObject(int departmentID)
        {
            return (from obj in GetDepartments() where obj.ID == departmentID select obj).FirstOrDefault();
        }
    }
}