---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/8f5c6758-dea3-6659-c0e9-b75bc4764150.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a FabricArea based on a host boundary.

## Syntax (C#)
```csharp
public static FabricArea Create(
	Document aDoc,
	Element hostElement,
	XYZ majorDirection,
	ElementId fabricAreaTypeId,
	ElementId fabricSheetTypeId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the FabricArea. The host can be a Structural Floor, Structural Wall, Structural Slab, or a Part created from a structural layer belonging to one of those element types.
- **majorDirection** (`Autodesk.Revit.DB.XYZ`) - A vector to define the major direction of the FabricArea.
- **fabricAreaTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the FabricAreaType.
- **fabricSheetTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the FabricSheetType.

## Returns
The newly created FabricArea.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElement was not found in the given document.
 -or-
 the host Element is not a valid host for Area Reinforcement, Path Reinforcement, Fabric Area or Fabric Sheet.
 -or-
 fabricAreaTypeId should refer to an FabricAreaType element.
 -or-
 fabricSheetTypeId should refer to an FabricSheetType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - majorDirection has zero length.

