---
kind: method
id: M:Autodesk.Revit.DB.WorksetDefaultVisibilitySettings.SetWorksetVisibility(Autodesk.Revit.DB.WorksetId,System.Boolean)
source: html/cc477191-cc03-6dbf-48b7-fd08f83d75b6.htm
---
# Autodesk.Revit.DB.WorksetDefaultVisibilitySettings.SetWorksetVisibility Method

Set the default visibility of a workset.

## Syntax (C#)
```csharp
public void SetWorksetVisibility(
	WorksetId worksetId,
	bool visible
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - Id of the workset.
- **visible** (`System.Boolean`) - Whether the workset should be visible by default or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no workset with this Id in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - WorksetDefaultVisibilitySettings is not applicable to family documents.

