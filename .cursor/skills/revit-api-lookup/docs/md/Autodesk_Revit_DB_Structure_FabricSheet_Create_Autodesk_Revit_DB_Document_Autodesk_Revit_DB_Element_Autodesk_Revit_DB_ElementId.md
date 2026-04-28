---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/e04241db-159d-3b49-7c87-80aaa5b84afa.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a single flat Fabric Sheet element within the project.

## Syntax (C#)
```csharp
public static FabricSheet Create(
	Document document,
	Element hostElement,
	ElementId fabricSheetTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the fabric sheet is to be created.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the FabricSheet. The host can be a Structural Floor, Structural Wall, Structural Slab, or a Part created from a structural layer belonging to one of those element types.
- **fabricSheetTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the FabricSheetType.

## Returns
The newly created single Fabric Sheet instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElement was not found in the given document.
 -or-
 The host Element is not a valid host for Fabric Sheet.
 -or-
 fabricSheetTypeId should refer to an FabricSheetType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

