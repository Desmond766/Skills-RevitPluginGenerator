---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.CreateDetailSection(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.AssemblyDetailViewOrientation)
source: html/784df7d5-3da2-9a3d-fc5f-8b97ce019b23.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.CreateDetailSection Method

Creates a new detail section assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static ViewSection CreateDetailSection(
	Document document,
	ElementId assemblyInstanceId,
	AssemblyDetailViewOrientation direction
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.
- **direction** (`Autodesk.Revit.DB.AssemblyDetailViewOrientation`) - The direction for the new view.

## Returns
A new detail section assembly view.

## Remarks
The detail section will cut through the center of the assembly instance's outline.
 The document must be regenerated before using the detail section.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - assemblyInstanceId is not an AssemblyInstance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

