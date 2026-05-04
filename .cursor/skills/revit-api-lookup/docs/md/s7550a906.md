---
kind: method
id: M:Autodesk.Revit.DB.WorksetDefaultVisibilitySettings.IsWorksetVisible(Autodesk.Revit.DB.WorksetId)
source: html/1b15a741-d1a0-e791-5d93-d59773ecc137.htm
---
# Autodesk.Revit.DB.WorksetDefaultVisibilitySettings.IsWorksetVisible Method

Indicates whether the workset is visible by default.

## Syntax (C#)
```csharp
public bool IsWorksetVisible(
	WorksetId worksetId
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - Id of the workset.

## Returns
Whether the workset is visible by default.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no workset with this Id in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - WorksetDefaultVisibilitySettings is not applicable to family documents.

