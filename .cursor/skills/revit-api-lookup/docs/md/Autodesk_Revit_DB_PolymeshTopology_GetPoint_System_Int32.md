---
kind: method
id: M:Autodesk.Revit.DB.PolymeshTopology.GetPoint(System.Int32)
source: html/fce4d0ee-9d95-f6ce-813a-e67cb28fe203.htm
---
# Autodesk.Revit.DB.PolymeshTopology.GetPoint Method

Returns one point at the given index.

## Syntax (C#)
```csharp
public XYZ GetPoint(
	int idx
)
```

## Parameters
- **idx** (`System.Int32`) - A zero-based index of a polymesh point

## Returns
XYZ coordinates of the point

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value is not a valid index of a point of the polymesh.
 A valid valure is not negative and is smaller than the number of points in the polymesh.

