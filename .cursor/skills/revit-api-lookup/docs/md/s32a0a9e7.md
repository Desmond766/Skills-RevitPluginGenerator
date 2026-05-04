---
kind: type
id: T:Autodesk.Revit.UI.FilterDialog
source: html/9d0df7ca-0a3d-12b3-26b7-d28752220f59.htm
---
# Autodesk.Revit.UI.FilterDialog

Allows display of the dialog used to create and edit FilterElements in Autodesk Revit.

## Syntax (C#)
```csharp
public class FilterDialog : IDisposable
```

## Remarks
The class provides the option to launch the dialog by selecting an existing FilterElement,
 or automatically creating a new ParameterFilterElement.
 In both cases the affected element will be selected for editing.
 Note that the user may opt to add, delete or edit any of the available filter elements (or make no changes at all).

