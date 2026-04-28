---
kind: method
id: M:Autodesk.Revit.DB.UV.op_Addition(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV)
source: html/92ef6a75-0ab6-1cd2-99fb-330557aa2eb6.htm
---
# Autodesk.Revit.DB.UV.op_Addition Method

Adds the two specified 2-D vectors and returns the result.

## Syntax (C#)
```csharp
public static UV operator +(
	UV left,
	UV right
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.UV`) - The first vector.
- **right** (`Autodesk.Revit.DB.UV`) - The second vector.

## Returns
The 2-D vector equal to the sum of the two source vectors.

## Remarks
The added vector is obtained by adding each coordinate of the right vector
to the corresponding coordinate of the left vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left or right is Nothing nullptr a null reference ( Nothing in Visual Basic) .

