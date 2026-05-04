---
kind: method
id: M:Autodesk.Revit.DB.PolymeshTopology.GetFacet(System.Int32)
source: html/9ce0a3c4-8ad9-c445-9af2-a71c13dd6ca9.htm
---
# Autodesk.Revit.DB.PolymeshTopology.GetFacet Method

Returns a definition of one facet

## Syntax (C#)
```csharp
public PolymeshFacet GetFacet(
	int idx
)
```

## Parameters
- **idx** (`System.Int32`) - A zero-based index of the facet

## Returns
An instance of PolymeshFacet that represents
 one facet defined by 3 vertices of the polymesh.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value is not a valid index of a facet of the polymesh.
 A valid value is not negative and is smaller than the number of facets in the polymesh.

