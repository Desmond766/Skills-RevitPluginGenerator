---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.FlexDuct.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
zh: 创建、新建、生成、建立、新增
source: html/4896a7a5-97bc-28c3-f2e8-b9428d3ee865.htm
---
# Autodesk.Revit.DB.Mechanical.FlexDuct.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new flexible duct into the document, using a point array and flexible duct type.

## Syntax (C#)
```csharp
public static FlexDuct Create(
	Document document,
	ElementId systemTypeId,
	ElementId ductTypeId,
	ElementId levelId,
	IList<XYZ> points
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the HVAC system type.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the flexible duct.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id for the flexible duct.
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array indicating the path of the flexible duct, including the end point.

## Returns
If creation was successful then a new flexible duct is returned, otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid HVAC system type.
 -or-
 The type ductTypeId is not valid flexible duct type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The valid number of points is less than two. In order to create a flex curve, at least two points are required. Note the duplicate points don't take into account.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

