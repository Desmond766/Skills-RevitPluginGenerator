---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.SetBuildingConstructionOverride(Autodesk.Revit.DB.Analysis.ConstructionType,System.Boolean)
source: html/de22b639-d4bf-56c2-caee-149e63d8b59c.htm
---
# Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.SetBuildingConstructionOverride Method

Sets the Building Construction override for a ConstructionType.

## Syntax (C#)
```csharp
public void SetBuildingConstructionOverride(
	ConstructionType constructionType,
	bool override
)
```

## Parameters
- **constructionType** (`Autodesk.Revit.DB.Analysis.ConstructionType`) - The ConstructionType to override.
- **override** (`System.Boolean`) - True to use analytical construction properties specified in Constructions.xml in the given ConstructionType, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The ConstructionType is invalid.

