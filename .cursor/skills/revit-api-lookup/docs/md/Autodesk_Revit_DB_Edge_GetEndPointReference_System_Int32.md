---
kind: method
id: M:Autodesk.Revit.DB.Edge.GetEndPointReference(System.Int32)
source: html/c6471321-61c7-22b6-698a-be803c77ff70.htm
---
# Autodesk.Revit.DB.Edge.GetEndPointReference Method

Returns a stable reference to the start or the end point of the edge.

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the object is internally marked as read-only in the setter.

