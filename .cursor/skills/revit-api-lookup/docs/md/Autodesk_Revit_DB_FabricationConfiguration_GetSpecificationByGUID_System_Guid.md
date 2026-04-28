---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetSpecificationByGUID(System.Guid)
source: html/1c0d88ad-f1c0-ad43-1263-f66f52b587b6.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetSpecificationByGUID Method

Gets the specification identifier by its GUID.

## Syntax (C#)
```csharp
public int GetSpecificationByGUID(
	Guid specificationGUID
)
```

## Parameters
- **specificationGUID** (`System.Guid`) - The specification GUID.

## Returns
The specification identifier. Returns 0 if not found.

