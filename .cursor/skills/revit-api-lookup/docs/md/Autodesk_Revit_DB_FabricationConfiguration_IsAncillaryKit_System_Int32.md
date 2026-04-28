---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.IsAncillaryKit(System.Int32)
source: html/b4c6e352-3a70-eb07-84a1-2d107fb6da40.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.IsAncillaryKit Method

Gets whether the specified fabrication ancillary identifier is an ancillary kit or not.

## Syntax (C#)
```csharp
public bool IsAncillaryKit(
	int ancillaryId
)
```

## Parameters
- **ancillaryId** (`System.Int32`) - The fabrication ancillary database identifier of the ancillary.

## Returns
Returns true if the ancillary is a kit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ancillary does not exist.

