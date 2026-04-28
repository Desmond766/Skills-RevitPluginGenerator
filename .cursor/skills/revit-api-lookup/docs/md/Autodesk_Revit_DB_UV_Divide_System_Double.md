---
kind: method
id: M:Autodesk.Revit.DB.UV.Divide(System.Double)
source: html/f65911b8-4063-6f85-0648-327b1a3a28d5.htm
---
# Autodesk.Revit.DB.UV.Divide Method

Divides this 2-D vector by the specified value and returns the result.

## Syntax (C#)
```csharp
public UV Divide(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The value to divide this vector by.

## Returns
The divided 2-D vector.

## Remarks
The divided vector is obtained by dividing each coordinate of 
this vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is zero.

