Public Class DepartmentProvider
    Public Shared Function GetDepartments() As IList(Of Department)
        Dim objects As IList(Of Department) = CType(HttpContext.Current.Session("Departments"), IList(Of Department))

        If objects Is Nothing Then
            objects = New List(Of Department) From {
                New Department(1, 0, "Corporate Headquarters"),
                New Department(2, 1, "Sales and Marketing"),
                New Department(3, 1, "Finance"),
                New Department(4, 1, "Engineering"),
                New Department(5, 2, "Field Office: Canada"),
                New Department(6, 2, "Field Office: East Coast"),
                New Department(7, 2, "Pacific Rim Headquarters"),
                New Department(8, 2, "Marketing"),
                New Department(9, 4, "Consumer Electronics Div."),
                New Department(10, 4, "Software Products Div."),
                New Department(11, 7, "Field Office: Singapore"),
                New Department(12, 7, "Field Office: Japan"),
                New Department(13, 9, "Software Development"),
                New Department(14, 10, "Quality Assurance"),
                New Department(15, 10, "Customer Support"),
                New Department(16, 10, "Research and Development"),
                New Department(17, 10, "Customer Services")
            }
            HttpContext.Current.Session("Departments") = objects
        End If

        Return objects
    End Function

    Public Shared Sub Update(ByVal department As Department)
        Dim editObject = GetEditableObject(department.ID)

        If editObject IsNot Nothing Then
            editObject.DepartmentName = department.DepartmentName
            editObject.ParentID = department.ParentID
        End If
    End Sub

    Public Shared Sub Delete(ByVal departmentID As Integer)
        Dim editObject = GetEditableObject(departmentID)
        If editObject IsNot Nothing Then GetDepartments().Remove(editObject)
    End Sub

    Private Shared ObjectInsertLock As Object = New Object()

    Public Shared Function Insert(ByVal department As Department) As Department
        SyncLock ObjectInsertLock
            Dim editObject = New Department()
            editObject.ID = GetNextDepartmentID()
            editObject.DepartmentName = department.DepartmentName
            editObject.ParentID = department.ParentID
            Return editObject
        End SyncLock
    End Function

    Private Shared Function GetNextDepartmentID() As Integer
        Dim deps = GetDepartments()
        Return If(deps.Any(), deps.[Select](Function(d) d.ID).Max() + 1, 0)
    End Function

    Private Shared Function GetEditableObject(ByVal departmentID As Integer) As Department
        Return (From obj In GetDepartments() Where obj.ID = departmentID Select obj).FirstOrDefault()
    End Function
End Class