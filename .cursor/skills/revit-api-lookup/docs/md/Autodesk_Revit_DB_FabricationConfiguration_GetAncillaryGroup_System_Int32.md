---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAncillaryGroup(System.Int32)
source: html/881dd623-3c7d-59e1-b19d-9f56e5f6d45a.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAncillaryGroup Method

Gets the fabrication ancillary group of the specified fabrication ancillary identifier.

## Syntax (C#)
```csharp
public string GetAncillaryGroup(
	int ancillaryId
)
```

## Parameters
- **ancillaryId** (`System.Int32`) - The fabrication ancillary database identifier of the ancillary.

## Returns
The group name of the ancillary.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ancillary does not exist.

