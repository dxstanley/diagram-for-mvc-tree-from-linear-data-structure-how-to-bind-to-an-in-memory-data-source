Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View(DepartmentProvider.GetDepartments())
    End Function

    Public Function LinearUpdate(ByVal nodeUpdateValues As MVCxDiagramNodeUpdateValues(Of Department, Integer)) As ActionResult
        For Each item In nodeUpdateValues.Update
            DepartmentProvider.Update(item)
        Next

        For Each itemKey In nodeUpdateValues.DeleteKeys
            DepartmentProvider.Delete(itemKey)
        Next

        For Each item In nodeUpdateValues.Insert
            Dim insertedItem = DepartmentProvider.Insert(item)
            nodeUpdateValues.MapInsertedItemKey(item, insertedItem.ID)
        Next

        Return DiagramExtension.GetBatchUpdateResult(nodeUpdateValues)
    End Function
End Class