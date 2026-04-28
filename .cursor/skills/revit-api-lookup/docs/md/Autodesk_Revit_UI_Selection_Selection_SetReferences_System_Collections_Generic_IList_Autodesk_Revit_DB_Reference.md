---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.SetReferences(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/813a9d31-bc4f-1ebc-9a7b-69a2a99d22ac.htm
---
# Autodesk.Revit.UI.Selection.Selection.SetReferences Method

Selects the references. The references can be an element or a subelement in the host or a linked document.

## Syntax (C#)
```csharp
public void SetReferences(
	IList<Reference> references
)
```

## Parameters
- **references** (`System.Collections.Generic.IList < Reference >`) - The references to be selected.

## Remarks
This function will select the specified references and update the UI.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Changing the selection is not permitted while handling SelectionChanged Event.

