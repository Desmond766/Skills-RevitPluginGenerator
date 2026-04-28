---
kind: method
id: M:Autodesk.Revit.DB.InternalDefinition.SetAllowVaryBetweenGroups(Autodesk.Revit.DB.Document,System.Boolean)
source: html/6f5af0cc-2ab3-153a-e07d-78fbc12aefc1.htm
---
# Autodesk.Revit.DB.InternalDefinition.SetAllowVaryBetweenGroups Method

Whether or not the parameter values can vary across group members.

## Syntax (C#)
```csharp
public ICollection<ElementId> SetAllowVaryBetweenGroups(
	Document document,
	bool allowVaryBetweenGroups
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document of this parameter.
- **allowVaryBetweenGroups** (`System.Boolean`) - Whether this parameter should be allowed to vary between groups.

## Returns
The ids of elements that were updated to align the values between groups.

## Remarks
When a parameter is set to not vary between groups Revit will automatically align the parameter values
 of any elements that actually varied between group instances.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This parameter does not support the specified value of allowVaryBetweenGroups.
 -or-
 document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

