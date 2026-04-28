---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.GetConstructions(Autodesk.Revit.DB.Analysis.ConstructionType)
source: html/6b06dc30-43d1-477c-b525-334065bd43e9.htm
---
# Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.GetConstructions Method

Gets all the Building Constructions corresponding to the specific Construction type.

## Syntax (C#)
```csharp
public ICollection<Construction> GetConstructions(
	ConstructionType constructionType
)
```

## Parameters
- **constructionType** (`Autodesk.Revit.DB.Analysis.ConstructionType`) - The Construction Type of Building Construction.

## Returns
A collection containing Building constructions matching the construction type.

## Remarks
This function is used to get the Building Construction of the Project Information.

