---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPSpaceConstruction.NewConstruction(System.String)
source: html/dbf60a91-d9f9-1a5b-2437-106001715233.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSpaceConstruction.NewConstruction Method

Create a new construction for Space constructions.

## Syntax (C#)
```csharp
public MEPBuildingConstruction NewConstruction(
	string pName
)
```

## Parameters
- **pName** (`System.String`) - The name of the new Construction.

## Remarks
If the name is same as an existing one, an exception will be thrown.

