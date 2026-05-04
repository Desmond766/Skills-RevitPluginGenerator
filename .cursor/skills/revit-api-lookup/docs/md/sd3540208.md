---
kind: method
id: M:Autodesk.Revit.DB.PrintManager.SubmitPrint
source: html/0c9524b7-33b5-8c76-2843-c7024f03e4d7.htm
---
# Autodesk.Revit.DB.PrintManager.SubmitPrint Method

Print the views and sheets defined in the current local PrintManager settings.

## Syntax (C#)
```csharp
public bool SubmitPrint()
```

## Returns
True if successful, otherwise False.

## Remarks
PrintManager will apply the local settings to global and print the view/views/sheets which user defined with the current settings.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this operation is not allowed in the current application mode,
or the print resource is occupied by others.

