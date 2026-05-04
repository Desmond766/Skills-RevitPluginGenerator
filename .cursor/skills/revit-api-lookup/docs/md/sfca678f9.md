---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetMaterialByGUID(System.Guid)
source: html/a2bebe19-1cb3-7bfc-c19f-d17ee5e614b8.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetMaterialByGUID Method

Gets the material identifier by its GUID.

## Syntax (C#)
```csharp
public int GetMaterialByGUID(
	Guid materialGUID
)
```

## Parameters
- **materialGUID** (`System.Guid`) - The material GUID.

## Returns
The material identifier. Returns 0 if not found.

