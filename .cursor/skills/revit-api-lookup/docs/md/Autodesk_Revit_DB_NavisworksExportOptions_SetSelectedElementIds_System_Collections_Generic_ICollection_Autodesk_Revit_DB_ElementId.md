---
kind: method
id: M:Autodesk.Revit.DB.NavisworksExportOptions.SetSelectedElementIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/cb60be0c-ceb2-fc2d-97c2-84dc79d6cc72.htm
---
# Autodesk.Revit.DB.NavisworksExportOptions.SetSelectedElementIds Method

Sets the element ids of the elements to export. Used only when ExportScope = SelectedElements.

## Syntax (C#)
```csharp
public void SetSelectedElementIds(
	ICollection<ElementId> ids
)
```

## Parameters
- **ids** (`System.Collections.Generic.ICollection < ElementId >`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

