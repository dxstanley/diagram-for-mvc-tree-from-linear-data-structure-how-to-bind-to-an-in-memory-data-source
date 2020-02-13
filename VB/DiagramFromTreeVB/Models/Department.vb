Public Class Department
    Public Property ID As Integer
    Public Property ParentID As Integer?
    Public Property DepartmentName As String

    Public Sub New(ByVal id As Integer, ByVal parentId As Integer?, ByVal departmentName As String)
        Me.ID = id
        Me.ParentID = parentId
        Me.DepartmentName = departmentName
    End Sub

    Public Sub New()
    End Sub
End Class
