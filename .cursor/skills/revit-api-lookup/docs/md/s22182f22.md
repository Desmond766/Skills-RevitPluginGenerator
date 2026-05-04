---
kind: method
id: M:Autodesk.Revit.DB.Curve.GetEndPointReference(System.Int32)
zh: 曲线
source: html/5619a3fd-38e1-fb56-7286-2e5f33a3b2b8.htm
---
# Autodesk.Revit.DB.Curve.GetEndPointReference Method

**中文**: 曲线

Returns a stable reference to the start point or the end point of the curve.

## Syntax (C#)
```csharp
public Reference GetEndPointReference(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Use 0 for the start point; 1 for the end point.

## Returns
Reference to the point or Nothing nullptr a null reference ( Nothing in Visual Basic) if reference cannot be obtained.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the specified index is not 0 or 1.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the object is internally marked as read-only or this curve is unbound.

