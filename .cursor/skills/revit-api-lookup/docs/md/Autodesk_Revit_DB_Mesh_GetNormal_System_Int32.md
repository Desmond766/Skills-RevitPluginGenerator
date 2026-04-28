---
kind: method
id: M:Autodesk.Revit.DB.Mesh.GetNormal(System.Int32)
source: html/08018daf-09a2-e244-ad4b-b6d0d4f7d63f.htm
---
# Autodesk.Revit.DB.Mesh.GetNormal Method

Returns a normal unit vector at the given index.

## Syntax (C#)
```csharp
public XYZ GetNormal(
	int idx
)
```

## Parameters
- **idx** (`System.Int32`) - A zero-based index. It must be consistent with the DistributionOfNormals.

## Returns
XYZ value representing a normal unit vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value is not a valid index of a normal of the mesh.
 A valid value is not negative and is smaller than the number of normals in the mesh.

