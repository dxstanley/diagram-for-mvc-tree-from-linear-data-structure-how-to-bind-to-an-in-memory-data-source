@Code
    ViewData("Title") = "Diagram for MVC - Tree from Linear Data Structure - How to bind the extension to an in-memory data source"
End Code

@ModelType IEnumerable(Of DiagramFromTreeVB.Department)

@Html.DevExpress().Diagram(Sub(settings)
                                    settings.Name = "Diagram"

                                    settings.BatchUpdateRouteValues = New With {.Controller = "Home", .Action = "LinearUpdate"}

                                    settings.Mappings.Node.Key = "ID"
                                    settings.Mappings.Node.Text = "DepartmentName"
                                    settings.Mappings.Node.ParentKey = "ParentID"

                                    settings.SettingsAutoLayout.Type = DevExpress.Web.ASPxDiagram.DiagramAutoLayout.Tree
                                End Sub).Bind(Model).GetHtml()