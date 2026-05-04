---
kind: method
id: M:Autodesk.Revit.DB.XYZ.CrossProduct(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/c5c099ad-e9f5-976b-94ee-d96af1c677f3.htm
---
# Autodesk.Revit.DB.XYZ.CrossProduct Method

**中文**: 点

The cross product of this vector and the specified vector.

## Syntax (C#)
```csharp
public XYZ CrossProduct(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The vector to multiply with this vector.

## Returns
The vector equal to the cross product.

## Remarks
The cross product is defined as the vector which is perpendicular to both vectors 
with a magnitude equal to the area of the parallelogram they span.
Also known as vector product or outer product.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

