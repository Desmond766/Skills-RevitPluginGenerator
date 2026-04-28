---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.GetBuildingConstructionOverride(Autodesk.Revit.DB.Analysis.ConstructionType)
source: html/258ac094-fd76-e05f-e69a-fe8d200b4df0.htm
---
# Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.GetBuildingConstructionOverride Method

Gets the Building Construction override for a ConstructionType.

## Syntax (C#)
```csharp
public bool GetBuildingConstructionOverride(
	ConstructionType constructionType
)
```

## Parameters
- **constructionType** (`Autodesk.Revit.DB.Analysis.ConstructionType`) - The ConstructionType override value to get.

## Returns
True if analytical construction properties specified in Constructions.xml are used for the given ConstructionType, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The ConstructionType is invalid.

