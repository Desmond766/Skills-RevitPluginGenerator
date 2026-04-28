---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.SetBuildingConstruction(Autodesk.Revit.DB.Analysis.ConstructionType,Autodesk.Revit.DB.Construction)
source: html/fd7c6249-7aff-3c0c-d8df-6473b2b13fc5.htm
---
# Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction.SetBuildingConstruction Method

Sets the Building Construction of the Project Information.

## Syntax (C#)
```csharp
public void SetBuildingConstruction(
	ConstructionType constructionType,
	Construction buildingConstruction
)
```

## Parameters
- **constructionType** (`Autodesk.Revit.DB.Analysis.ConstructionType`) - The Construction Type of Building Construction.
- **buildingConstruction** (`Autodesk.Revit.DB.Construction`) - The Building Construction to be set.

## Remarks
This function is used to set the Building Construction of the Project Information.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - buildingConstruction is NULL.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Sets construction type to an invalid value.
 - or -
 Can not set construction type.

