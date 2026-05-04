---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.AreaLoadType)
zh: 创建、新建、生成、建立、新增
source: html/6eba11bd-fda9-abea-a1b8-af0744722f33.htm
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
	XYZ forceVector,
	AreaLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new area load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The analytical surface host element id for the area Load.
- **loops** (`System.Collections.Generic.IList < CurveLoop >`) - The loops that define geometry of the area load.
 The curve loop collection should contains a closed loops consisting of lines.
- **forceVector** (`Autodesk.Revit.DB.XYZ`) - The force vector applied to the 1st reference point of the area load.
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
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown if the host element id is a Curved Panel.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created area load.

