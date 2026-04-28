---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides(Autodesk.Revit.DB.WorksetId,Autodesk.Revit.DB.WorksharingDisplayGraphicSettings)
source: html/86f6c525-1504-f09f-52ab-e16a4da48131.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides Method

Sets the graphic overrides assigned to elements in a particular user workset.

## Syntax (C#)
```csharp
public void SetGraphicOverrides(
	WorksetId worksetId,
	WorksharingDisplayGraphicSettings overrides
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The workset of interest, which must be a user workset.
- **overrides** (`Autodesk.Revit.DB.WorksharingDisplayGraphicSettings`) - The desired graphic overrides for this workset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - worksetId does not correspond to a user workset in the document
 containing this WorksharingDisplaySettings.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

