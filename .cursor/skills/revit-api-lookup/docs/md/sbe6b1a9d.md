---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/3cf77bb2-3780-296e-0d19-698a289098eb.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new AreaReinforcement object based on a host boundary.

## Syntax (C#)
```csharp
public static AreaReinforcement Create(
	Document document,
	Element hostElement,
	XYZ majorDirection,
	ElementId areaReinforcementTypeId,
	ElementId rebarBarTypeId,
	ElementId rebarHookTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the AreaReinforcement. The host can be a Structural Floor, Structural Wall, Structural Slab, or a Part created from a structural layer belonging to one of those element types.
- **majorDirection** (`Autodesk.Revit.DB.XYZ`) - A vector to define the major direction of the AreaReinforcement.
- **areaReinforcementTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the AreaReinforcementType.
- **rebarBarTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarBarType.
- **rebarHookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarHookType.
 If this parameter is InvalidElementId, it means to create a rebar with no hooks.

## Returns
The newly created AreaReinforcement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElement was not found in the given document.
 -or-
 the host Element is not a valid host for Area Reinforcement, Path Reinforcement, Fabric Area or Fabric Sheet.
 -or-
 areaReinforcementTypeId should refer to an AreaReinforcementType element.
 -or-
 rebarBarTypeId should refer to an RebarBarType element.
 -or-
 rebarHookTypeId should be invalid or refer to an RebarHookType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - majorDirection has zero length.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.

