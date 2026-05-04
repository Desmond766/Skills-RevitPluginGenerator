---
kind: method
id: M:Autodesk.Revit.UI.Selection.ISelectionFilter.AllowReference(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
source: html/3661c377-3983-4b54-2dad-5acaa03c32f1.htm
---
# Autodesk.Revit.UI.Selection.ISelectionFilter.AllowReference Method

Override this post-filter method to specify if a reference to a piece of geometry is permitted to be selected.

## Syntax (C#)
```csharp
bool AllowReference(
	Reference reference,
	XYZ position
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - A candidate reference in selection operation.
- **position** (`Autodesk.Revit.DB.XYZ`) - The 3D position of the mouse on the candidate reference.

## Returns
Return true to allow the user to select this candidate reference. Return false to prevent selection of this candidate.

## Remarks
If an exception is thrown from this method, the element will not be permitted to be selected.

