---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewCurveArray
source: html/eb48f52e-197f-91a8-5cde-2e4ceaf91b57.htm
---
# Autodesk.Revit.Creation.Application.NewCurveArray Method

Creates an empty array that can store geometric curves.

## Syntax (C#)
```csharp
public CurveArray NewCurveArray()
```

## Returns
An empty array that can hold geometric curves.

## Remarks
This method can be used to create an array that can hold any curve type object. This
array can be then passed to methods, such as NewAreaLoad, to represent the geometry for the
boundary of the load.

