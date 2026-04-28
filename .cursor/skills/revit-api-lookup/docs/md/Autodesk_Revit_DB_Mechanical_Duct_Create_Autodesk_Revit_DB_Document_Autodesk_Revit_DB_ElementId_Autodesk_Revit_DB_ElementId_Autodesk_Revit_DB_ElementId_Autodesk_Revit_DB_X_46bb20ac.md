---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/86174dcb-e86e-c987-93ff-75e3d2773cf0.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new duct from two points.

## Syntax (C#)
```csharp
public static Duct Create(
	Document document,
	ElementId systemTypeId,
	ElementId ductTypeId,
	ElementId levelId,
	XYZ startPoint,
	XYZ endPoint
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the HVAC system type.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the duct type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level ElementId for the duct.
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The start point of the duct.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The end point of the duct.

## Returns
The created duct.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid HVAC system type.
 -or-
 The duct type ductTypeId is not valid duct type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The points of startPoint and endPoint are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

