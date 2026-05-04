---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPSpaceConstruction.DuplicateConstruction(Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction,System.String)
source: html/e472b09f-7080-381d-7b27-18257366ca3a.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSpaceConstruction.DuplicateConstruction Method

Create a new construction for Space constructions.

## Syntax (C#)
```csharp
public MEPBuildingConstruction DuplicateConstruction(
	MEPBuildingConstruction pCurrentConstruction,
	string pName
)
```

## Parameters
- **pCurrentConstruction** (`Autodesk.Revit.DB.Mechanical.MEPBuildingConstruction`) - The existing construction to be duplicated.
- **pName** (`System.String`) - The name of the new construction.

## Remarks
If the name is same with the existing one, an exception will be thrown.

