---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides(Autodesk.Revit.DB.WorksetId)
source: html/6753b405-5170-1636-83ce-902c9a27526f.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides Method

Returns the graphic overrides assigned to elements in a particular workset.

## Syntax (C#)
```csharp
public WorksharingDisplayGraphicSettings GetGraphicOverrides(
	WorksetId worksetId
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The workset id of interest. This must be a user workset.

## Returns
Returns the graphic overrides assigned to the workset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - worksetId does not correspond to a user workset in the document
 containing this WorksharingDisplaySettings.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

