---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAncillaryGroupName(System.Int32)
source: html/2367e7e5-4c90-0473-cddc-0281093af660.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAncillaryGroupName Method

Gets the fabrication ancillary group and name for the specified fabrication ancillary identifier.

## Syntax (C#)
```csharp
public string GetAncillaryGroupName(
	int ancillaryId
)
```

## Parameters
- **ancillaryId** (`System.Int32`) - The fabrication ancillary database identifier of the ancillary.

## Returns
The group and name of the ancillary.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ancillary does not exist.

