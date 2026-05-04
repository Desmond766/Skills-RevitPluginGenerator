---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.CreateSheet(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/afd8688c-80d3-8c70-804c-0eed87eab8f3.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.CreateSheet Method

Creates a new sheet assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static ViewSheet CreateSheet(
	Document document,
	ElementId assemblyInstanceId,
	ElementId titleBlockId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.
- **titleBlockId** (`Autodesk.Revit.DB.ElementId`) - Id of the titleblock family to use. For no titleblock, pass invalidElementId.

## Returns
A new sheet assembly view.

## Remarks
The document must be regenerated before using the sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - assemblyInstanceId is not an AssemblyInstance.
 -or-
 titleBlockId is not a TitleBlock.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

