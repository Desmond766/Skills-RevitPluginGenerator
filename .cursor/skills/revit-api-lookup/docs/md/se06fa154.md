---
kind: method
id: M:Autodesk.Revit.DB.PolymeshTopology.GetNormal(System.Int32)
source: html/b85564ec-7e50-fe75-6094-2eb5b36dd4c6.htm
---
# Autodesk.Revit.DB.PolymeshTopology.GetNormal Method

Returns a normal vector at the given index

## Syntax (C#)
```csharp
public XYZ GetNormal(
	int idx
)
```

## Parameters
- **idx** (`System.Int32`) - A zero-based index

## Returns
XYZ value representing a normal vector

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value is not a valid index of a normal of the polymesh.
 A valid valure is not negative and is smaller than the number of normals in the polymesh.

