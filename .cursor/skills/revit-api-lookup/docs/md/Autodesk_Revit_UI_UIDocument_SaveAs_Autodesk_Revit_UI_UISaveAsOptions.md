---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.SaveAs(Autodesk.Revit.UI.UISaveAsOptions)
source: html/7a5b49c3-f01d-9105-3b36-e04bea72887f.htm
---
# Autodesk.Revit.UI.UIDocument.SaveAs Method

Saves the document to a file name obtained from the Revit user optionally prompting the user to overwrite file if it exists.

## Syntax (C#)
```csharp
public void SaveAs(
	UISaveAsOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.UI.UISaveAsOptions`) - UI options for the SaveAs operation.

## Remarks
This method may not be called unless all transactions, sub-transactions, and transaction groups that were opened by the API code were closed. 
 That also implies that this method cannot be called during dynamic updates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - SaveAs may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Is not a primary document, it is a linked document.
 -or-
 SaveAs is temporarily disabled.
 -or-
 Thrown if there are any transactions, sub-transactions or transaction groups which
 were opened by the API code, and not closed. All of these items must be handled
 before attempting to save the document.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown if saving is cancelled by an external application during 'DocumentSavingAs' event.

