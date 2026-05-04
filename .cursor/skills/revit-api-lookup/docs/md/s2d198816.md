---
kind: method
id: M:Autodesk.Revit.DB.PolymeshTopology.GetUV(System.Int32)
source: html/fbabdfa5-a2fe-0cc4-1784-2739785e059b.htm
---
# Autodesk.Revit.DB.PolymeshTopology.GetUV Method

Returns one UV coordinate at the given index.

## Syntax (C#)
```csharp
public UV GetUV(
	int idx
)
```

## Parameters
- **idx** (`System.Int32`) - A zero-based index of a UV coordinate

## Returns
UV coordinates at the given index

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value is not a valid index of a UV coordinate of the polymesh.
 A valid valure is not negative and is smaller than the number of UV coordinates in the polymesh.

