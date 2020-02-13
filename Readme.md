# Diagram for MVC - Tree from Linear Data Structure - How to bind the extension to an in-memory data source

The DevExpress ASP.NET MVC  [Diagram](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramExtension)  extension can build a tree structure from a linear data structure. Use the  [Bind(object nodeDataObject)](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramExtension.Bind(System.Object))  method to bind the Diagram to the data source.

To transform a linear data structure to hierarchical, the data source should contain two additional fields:

-   The first field - assigned to the  [Mappings.Node.Key](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappingInfo.Key)  property and contains unique values.
-   The second field - assigned to the  [Mappings.Node.ParentKey](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramNodeMappingInfo.ParentKey)  property and contains values that indicate the current node's parent nodes.

You can bind other node settings to the data source. Assign field values to the corresponding settings in the  [Mappings.Node](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramNodeMappingInfo._properties)  property.

The  [BatchUpdateRouteValues](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramSettings.BatchUpdateRouteValues)  property specifies a Controller and Action that handle callbacks related to node and edge updates. When you update inserted items' data, use the  [MapInsertedItemKey](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.MVCxDiagramItemUpdateValues-2.MapInsertedItemKey(-0--1))  method to provide key values for the items.

The  [SettingsAutoLayout](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramSettings.SettingsAutoLayout)  property specifies the auto-layout algorithm and orientation the extension uses to build a diagram.  

<!-- default file list -->
*Files to look at*:

* [Index.cshtml](./CS/DiagramFromTree/Views/Home/Index.cshtml) (VB [Index.vbhtml](./VB/DiagramFromTreeVB/Views/Home/Index.vbhtml))
* [HomeController.cs](./CS/DiagramFromTree/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DiagramFromTreeVB/Controllers/HomeController.vb))
* [Department.cs](./CS/DiagramFromTree/Models/Department.cs) (VB: [Department.vb](./VB/DiagramFromTreeVB/Models/Department.vb))
* [DepartmentProvider.cs](./CS/DiagramFromTree/Models/DepartmentProvider.cs) (VB: [DepartmentProvider.vb](./VB/DiagramFromTreeVB/Models/DepartmentProvider.vb))
<!-- default file list end -->