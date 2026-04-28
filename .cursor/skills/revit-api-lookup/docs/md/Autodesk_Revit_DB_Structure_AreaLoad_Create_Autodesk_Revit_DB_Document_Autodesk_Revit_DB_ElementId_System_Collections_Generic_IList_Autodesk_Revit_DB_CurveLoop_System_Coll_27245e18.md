---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{System.Int32},System.Collections.Generic.IList{System.Int32},Autodesk.Revit.DB.Structure.AreaLoadType)
zh: 创建、新建、生成、建立、新增
source: html/648a9838-3e26-df6b-f68f-5534b1ac1485.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new custom area load within the project.

## Syntax (C#)
```csharp
public static AreaLoad Create(
	Document document,
	ElementId hostElemId,
	IList<CurveLoop> loops,
	IList<XYZ> forceVectors,
	IList<int> refPointCurveIndexes,
	IList<int> refPointCurveEnds,
	AreaLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new area load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The analytical surface host element id for the area Load.
- **loops** (`System.Collections.Generic.IList < CurveLoop >`) - The loops that define geometry of the area load.
 The curve loop collection should contains a closed loops consisting of lines.
- **forceVectors** (`System.Collections.Generic.IList < XYZ >`) - The array of force vectors applied to the maximum three reference point of the area load.
- **refPointCurveIndexes** (`System.Collections.Generic.IList < Int32 >`) - The array of maximum three curve indexes on which reference points should be placed on.
- **refPointCurveEnds** (`System.Collections.Generic.IList < Int32 >`) - The array of maximum three curve ends indicating where reference points should be placed on.
 The array can have only 0 or 1 values, which means 0 - curve start point, 1 - curve end point.
- **symbol** (`Autodesk.Revit.DB.Structure.AreaLoadType`) - The symbol of the AreaLoad. Set Nothing nullptr a null reference ( Nothing in Visual Basic) to use default type.

## Returns
If successful, returns an object of the newly created AreaLoad. Nothing nullptr a null reference ( Nothing in Visual Basic) is returned if the operation fails.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - hostElemId is not permitted for this type of load.
 -or-
 One of the following requirements is not satisfied :
 - curve loops loops are not planar
 - curve loops loops are self-intersecting
 - curve loops loops contains zero length curves
 -or-
 Thrown when force vector is equal zero.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown if the host element id is a Curved Panel.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created area load.

