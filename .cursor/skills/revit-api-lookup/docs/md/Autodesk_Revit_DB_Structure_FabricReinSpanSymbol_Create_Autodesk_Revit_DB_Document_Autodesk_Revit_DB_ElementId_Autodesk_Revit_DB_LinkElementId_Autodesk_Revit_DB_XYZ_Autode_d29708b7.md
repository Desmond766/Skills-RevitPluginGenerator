---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricReinSpanSymbol.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.LinkElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/5b20c5e2-9ee4-c3a9-0820-a7e370f104f9.htm
---
# Autodesk.Revit.DB.Structure.FabricReinSpanSymbol.Create Method

**中文**: 创建、新建、生成、建立、新增

Places a new instance of the Structural Fabric Reinforcement Symbol into the project relative to a particular FabricSheet and View.

## Syntax (C#)
```csharp
public static FabricReinSpanSymbol Create(
	Document document,
	ElementId viewId,
	LinkElementId hostId,
	XYZ point,
	ElementId symbolId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The id of the view in which the symbol should appear.
- **hostId** (`Autodesk.Revit.DB.LinkElementId`) - The ElementId of FabricSheet (either in the document, or linked from another document).
- **point** (`Autodesk.Revit.DB.XYZ`) - The span symbol's head position.
- **symbolId** (`Autodesk.Revit.DB.ElementId`) - The id of the family symbol of this symbol.

## Returns
A reference to the newly-created symbol.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - hostId should refer to a FabricSheet element.
 -or-
 viewId does not refer to a valid view type for FabricReinSpanSymbol - only floor plan, reflected ceiling plans and elevations are permitted.
 -or-
 symbolId should refer to a FamilySymbol of category OST_FabricReinSpanSymbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

