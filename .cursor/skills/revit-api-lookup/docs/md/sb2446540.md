---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/4a88ee1b-9a7b-47f3-f4d9-8f30c2526a0c.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a FabricArea from an array of curves.

## Syntax (C#)
```csharp
public static FabricArea Create(
	Document aDoc,
	Element hostElement,
	IList<CurveLoop> curveLoops,
	XYZ majorDirection,
	XYZ majorDirectionOrigin,
	ElementId fabricAreaTypeId,
	ElementId fabricSheetTypeId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the FabricArea. The host can be a Structural Floor, Structural Wall, Structural Slab, or a Part created from a structural layer belonging to one of those element types.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - An array of curves that will define the outline of the FabricArea.
 This includes curves defining openings in the interior of the area.
- **majorDirection** (`Autodesk.Revit.DB.XYZ`) - A vector to define the major direction of the FabricArea.
- **majorDirectionOrigin** (`Autodesk.Revit.DB.XYZ`) - An origin point of the major direction line
- **fabricAreaTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the FabricAreaType.
- **fabricSheetTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the FabricSheetType.

## Returns
The newly created FabricArea.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not all curveLoops in curveLoops are closed and continuous.
 -or-
 Not all curveLoops in curveLoops are in the same plane.
 -or-
 curveLoops should only contain lines or arcs.
 -or-
 The element hostElement was not found in the given document.
 -or-
 the host Element is not a valid host for Area Reinforcement, Path Reinforcement, Fabric Area or Fabric Sheet.
 -or-
 fabricAreaTypeId should refer to an FabricAreaType element.
 -or-
 fabricSheetTypeId should refer to an FabricSheetType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - majorDirection has zero length.

