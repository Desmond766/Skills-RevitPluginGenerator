---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFlexDuct(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.Mechanical.FlexDuctType)
zh: 文档、文件
source: html/860d0483-974f-c270-454b-625ab8f85b31.htm
---
# Autodesk.Revit.Creation.Document.NewFlexDuct Method

**中文**: 文档、文件

Adds a new flexible duct into the document, 
using a point array and duct type.

## Syntax (C#)
```csharp
public FlexDuct NewFlexDuct(
	IList<XYZ> points,
	FlexDuctType ductType
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array indicating the path of the flexible duct, including the end points.
- **ductType** (`Autodesk.Revit.DB.Mechanical.FlexDuctType`) - The type of the flexible duct.

## Returns
If creation was successful then a new flexible duct is returned, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument points is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the flexible duct cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the flexible duct type does not exist in the given document.

