---
kind: method
id: M:Autodesk.Revit.UI.FilterDialog.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/9eaeb95d-0f62-0b31-159a-3cdaf28111f8.htm
---
# Autodesk.Revit.UI.FilterDialog.#ctor Method

Constructs a new instance of the FilterDialog class,
 while setting the id of the FilterElement to be selected when the dialog is shown.

## Syntax (C#)
```csharp
public FilterDialog(
	Document doc,
	ElementId filterToSelect
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document that owns the FilterElements displayed and edited in the dialog.
- **filterToSelect** (`Autodesk.Revit.DB.ElementId`) - The FilterElement to be selected.
 If InvalidElementId, then the first (if any) available FilterElement will be selected.

## Remarks
Show the dialog with the Show() method after setting the desired options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The supplied ElementId filterToSelect is not of a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

