---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},System.Boolean,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/efcdc1d2-97e2-1e4f-3ae9-38fd9e9e2767.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new PathReinforcement object from an array of curves and given Rebar Shape id.

## Syntax (C#)
```csharp
public static PathReinforcement Create(
	Document document,
	Element hostElement,
	IList<Curve> curveArray,
	bool flip,
	ElementId pathReinforcementTypeId,
	ElementId rebarBarTypeId,
	ElementId startRebarHookTypeId,
	ElementId endRebarHookTypeId,
	ElementId rebarShapeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **hostElement** (`Autodesk.Revit.DB.Element`) - The element that will host the PathReinforcement. The host can be a Structural Floor, Structural Wall, Structural Slab, or a Part created from a structural layer belonging to one of those element types.
- **curveArray** (`System.Collections.Generic.IList < Curve >`) - An array of curves that will define the outline of the PathReinforcement.
- **flip** (`System.Boolean`) - A flag controlling the bars relative to the curves.
- **pathReinforcementTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the PathReinforcementType.
- **rebarBarTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarBarType.
- **startRebarHookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarHookType for the start of the bar.
 If this parameter is InvalidElementId, it means to create a rebar with no start hook.
- **endRebarHookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarHookType for the end of the bar.
 If this parameter is InvalidElementId, it means to create a rebar with no end hook.
- **rebarShapeId** (`Autodesk.Revit.DB.ElementId`) - The id of the RebarShape element that defines the shape of the rebars in the object.

## Returns
The newly created PathReinforcement.

## Remarks
The method sets Rebar Shape of primary bars only.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curveArray is empty.
 -or-
 The input curveArray contains at least one helical curve and is not supported for this operation.
 -or-
 The element hostElement was not found in the given document.
 -or-
 the host Element is not a valid host for Area Reinforcement, Path Reinforcement, Fabric Area or Fabric Sheet.
 -or-
 The structural rebar is not within area and path reinforcement.
 -or-
 curves in curveArray are not continuous and open.
 -or-
 pathReinforcementTypeId should refer to an Path Reinforcement Type element.
 -or-
 rebarBarTypeId should refer to an RebarBarType element.
 -or-
 startRebarHookTypeId should be invalid or refer to an RebarHookType element.
 -or-
 endRebarHookTypeId should be invalid or refer to an RebarHookType element.
 -or-
 rebarShapeId should refer to two dimensional Rebar Shape element with segments forming only right angles.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - startRebarHookTypeId cannot be set for given rebar shape.
 -or-
 endRebarHookTypeId cannot be set for given rebar shape.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.

