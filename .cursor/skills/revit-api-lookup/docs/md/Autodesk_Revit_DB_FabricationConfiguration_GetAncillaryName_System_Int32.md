---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAncillaryName(System.Int32)
source: html/e9a3df25-b421-150f-649a-e9172f1f1706.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAncillaryName Method

Gets the fabrication ancillary name for the specified fabrication ancillary identifier.

## Syntax (C#)
```csharp
public string GetAncillaryName(
	int ancillaryId
)
```

## Parameters
- **ancillaryId** (`System.Int32`) - The fabrication ancillary database identifier of the ancillary.

## Returns
The name of the ancillary.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ancillary does not exist.

