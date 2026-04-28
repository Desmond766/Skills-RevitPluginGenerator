---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.SaveAs
source: html/32b06707-cfd5-837c-9951-791fd50a6bc9.htm
---
# Autodesk.Revit.UI.UIDocument.SaveAs Method

Saves the document to a file name obtained from the Revit user without prompting the user to overwrite file if it exists.

## Syntax (C#)
```csharp
public void SaveAs()
```

## Remarks
This method may not be called unless all transactions, sub-transactions, and transaction groups that were opened by the API code were closed. 
 That also implies that this method cannot be called during dynamic updates.

## Exceptions
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - SaveAs may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Is not a primary document, it is a linked document.
 -or-
 SaveAs is temporarily disabled.
 -or-
 Thrown if there are any transactions, sub-transactions or transaction groups which
 were opened by the API code, and not closed. All of these items must be handled
 before attempting to save the document.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown if saving is cancelled by an external application during 'DocumentSavingAs' event.

