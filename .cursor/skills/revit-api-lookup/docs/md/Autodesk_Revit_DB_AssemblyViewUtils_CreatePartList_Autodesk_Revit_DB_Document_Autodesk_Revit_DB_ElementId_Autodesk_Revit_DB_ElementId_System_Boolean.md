---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.CreatePartList(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/c211c569-f7bc-8869-ea4d-71bbb4034748.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.CreatePartList Method

Creates a new part list multicategory schedule assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static ViewSchedule CreatePartList(
	Document document,
	ElementId assemblyInstanceId,
	ElementId viewTemplateId,
	bool isAssigned
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.
- **viewTemplateId** (`Autodesk.Revit.DB.ElementId`) - Id of the view template that is used to create the view;
 if invalidElementId, the view will be created with the default settings.
- **isAssigned** (`System.Boolean`) - If true, the template will be assigned, if false, the template will be applied.

## Returns
A new part list multicategory schedule assembly view.

## Remarks
The new part list schedule will be preloaded with fields "Category", "Family and Type" and "Count".
 The document must be regenerated before using the schedule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - assemblyInstanceId is not an AssemblyInstance.
 -or-
 viewTemplateId is not a correct view template for the schedule view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

