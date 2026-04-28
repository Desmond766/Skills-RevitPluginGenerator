---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.AcquireAssemblyViews(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/9d899efa-112e-b169-fde8-303f0967593d.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.AcquireAssemblyViews Method

Transfers the assembly views owned by a source assembly instance to a target sibling assembly instance of the same assembly type.

## Syntax (C#)
```csharp
public static void AcquireAssemblyViews(
	Document document,
	ElementId sourceAssemblyInstanceId,
	ElementId targetAssemblyInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the assembly instances live.
- **sourceAssemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that currently owns the assembly views.
- **targetAssemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance which will become the new owner of the assembly views.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - sourceAssemblyInstanceId is not an AssemblyInstance with assembly views.
 -or-
 targetAssemblyInstanceId is not an AssemblyInstance.
 -or-
 sourceAssemblyInstanceId and targetAssemblyInstanceId are not AssemblyInstances from the same assembly type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

