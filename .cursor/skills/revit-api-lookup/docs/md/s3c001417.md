---
kind: method
id: M:Autodesk.Revit.DB.XYZ.Divide(System.Double)
zh: 点
source: html/263802a2-959a-5a44-4991-26964943ca75.htm
---
# Autodesk.Revit.DB.XYZ.Divide Method

**中文**: 点

Divides this vector by the specified value and returns the result.

## Syntax (C#)
```csharp
public XYZ Divide(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The value to divide this vector by.

## Returns
The divided vector.

## Remarks
The divided vector is obtained by dividing each coordinate of 
this vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number or zero.

