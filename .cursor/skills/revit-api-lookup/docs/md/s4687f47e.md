---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.SetElementIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/cf8c11bb-f0c7-6d50-cbdf-41d0a010d9d6.htm
---
# Autodesk.Revit.UI.Selection.Selection.SetElementIds Method

Selects the elements.

## Syntax (C#)
```csharp
public void SetElementIds(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The ids of the elements to be selected.

## Remarks
This function will select the specified elements within the project and update the UI.
 See SetReferences for more selection options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Changing the selection is not permitted while handling SelectionChanged Event.

