---
kind: property
id: P:Autodesk.Revit.DB.PolymeshTopology.NumberOfUVs
source: html/7ac4611a-e782-2ca8-0e42-dc1fd5586a24.htm
---
# Autodesk.Revit.DB.PolymeshTopology.NumberOfUVs Property

The number of UV coordinates available for the polymesh.

## Syntax (C#)
```csharp
public int NumberOfUVs { get; }
```

## Remarks
Normally, the number of UV coordinates corresponds to the number of points in a polymesh,
 but a polymesh does not have to have UVs assigned, in which case the value of this property is 0.

