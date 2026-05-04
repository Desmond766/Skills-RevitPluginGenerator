---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/69267708-f0ad-3fd5-2018-fa624e763fa5.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new AreaReinforcement object from an array of curves.
 This method replaces the NewAreaReinforcement method, which has been deprecated.

## Syntax (C#)
```csharp
public static AreaReinforcement Create(
	Document document,
	Element hostElement,
	IList<Curve> curveArray,
	XYZ majorDirection,
	ElementId areaReinforcementTypeId,
	ElementId rebarBarTypeId,
	ElementId rebarHookTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the AreaReinforcement. The host can be a Structural Floor, Structural Wall, Structural Slab, or a Part created from a structural layer belonging to one of those element types.
- **curveArray** (`System.Collections.Generic.IList < Curve >`) - An array of curves that will define the outline of the AreaReinforcement.
- **majorDirection** (`Autodesk.Revit.DB.XYZ`) - A vector to define the major direction of the AreaReinforcement.
- **areaReinforcementTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the AreaReinforcementType.
- **rebarBarTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarBarType.
- **rebarHookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarHookType.
 If this parameter is InvalidElementId, it means to create a rebar with no hooks.

## Returns
The newly created AreaReinforcement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curveArray is empty.
 -or-
 The input curveArray contains at least one helical curve and is not supported for this operation.
 -or-
 The element hostElement was not found in the given document.
 -or-
 the host Element is not a valid host for Area Reinforcement, Path Reinforcement, Fabric Area or Fabric Sheet.
 -or-
 Curves in curveArray are not closed and continuous.
 -or-
 areaReinforcementTypeId should refer to an AreaReinforcementType element.
 -or-
 rebarBarTypeId should refer to an RebarBarType element.
 -or-
 rebarHookTypeId should be invalid or refer to an RebarHookType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - majorDirection has zero length.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.

