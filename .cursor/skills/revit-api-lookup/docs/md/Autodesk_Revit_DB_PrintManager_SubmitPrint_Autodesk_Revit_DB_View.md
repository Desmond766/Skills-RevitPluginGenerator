---
kind: method
id: M:Autodesk.Revit.DB.PrintManager.SubmitPrint(Autodesk.Revit.DB.View)
source: html/b3ce6806-a94a-6646-a93d-b1298901aac5.htm
---
# Autodesk.Revit.DB.PrintManager.SubmitPrint Method

Print a view with the current PrintManager settings.

## Syntax (C#)
```csharp
public bool SubmitPrint(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The User-assigned view.

## Returns
True if successful, otherwise False.

## Remarks
PrintManager will apply the local settings to global and print the user-assigned view with the current settings.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this operation is not allowed in the current application mode,
or the print resource is occupied by others.

