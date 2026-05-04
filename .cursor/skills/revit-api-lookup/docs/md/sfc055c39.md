---
kind: method
id: M:Autodesk.Revit.DB.XYZ.Add(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/f6f3d7e1-7a31-d4ac-f268-5cb977aed424.htm
---
# Autodesk.Revit.DB.XYZ.Add Method

**中文**: 点

Adds the specified vector to this vector and returns the result.

## Syntax (C#)
```csharp
public XYZ Add(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The vector to add to this vector.

## Returns
The vector equal to the sum of the two vectors.

## Remarks
The added vector is obtained by adding each coordinate of the specified vector
to the corresponding coordinate of this vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

