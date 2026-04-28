---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.CreateDetailSection(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.AssemblyDetailViewOrientation,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/d1dbb597-be46-0e7d-f173-af2e270831b9.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.CreateDetailSection Method

Creates a new detail section assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static ViewSection CreateDetailSection(
	Document document,
	ElementId assemblyInstanceId,
	AssemblyDetailViewOrientation direction,
	ElementId viewTemplateId,
	bool isAssigned
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.
- **direction** (`Autodesk.Revit.DB.AssemblyDetailViewOrientation`) - The direction for the new view.
- **viewTemplateId** (`Autodesk.Revit.DB.ElementId`) - Id of the view template that is used to create the view; if invalidElementId, the view will be created with the default settings.
- **isAssigned** (`System.Boolean`) - If true, the template will be assigned; if false, the template will be applied.

## Returns
A new detail section assembly view.

## Remarks
The detail section will cut through the center of the assembly instance's outline.
 The document must be regenerated before using the detail section.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - assemblyInstanceId is not an AssemblyInstance.
 -or-
 viewTemplateId is not a correct view template for the geom view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

