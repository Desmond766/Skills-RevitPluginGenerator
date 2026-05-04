---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAllSpecifications(Autodesk.Revit.DB.FabricationPart)
source: html/736406c3-c459-2fad-b966-7dc37f339b65.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAllSpecifications Method

Gets all specification identifiers in the fabrication configuration.

## Syntax (C#)
```csharp
public IList<int> GetAllSpecifications(
	FabricationPart part
)
```

## Parameters
- **part** (`Autodesk.Revit.DB.FabricationPart`) - The fabrication part.

## Returns
An array of specification identifiers.

## Remarks
If a part is passed, only returns specifications which are valid for the part, otherwise returns all specifications.

