---
kind: method
id: M:Autodesk.Revit.DB.GroupType.LoadFrom(System.String,Autodesk.Revit.DB.GroupLoadOptions)
source: html/58fdeb1b-4fb7-109e-8089-8c63761c0835.htm
---
# Autodesk.Revit.DB.GroupType.LoadFrom Method

Replaces the group with the contents of the input file.

## Syntax (C#)
```csharp
public void LoadFrom(
	string fileName,
	GroupLoadOptions options
)
```

## Parameters
- **fileName** (`System.String`) - The file to be used for the replacment.
- **options** (`Autodesk.Revit.DB.GroupLoadOptions`) - Group load options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not a valid RVT file.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given fileName does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this GroupType" is in a document which is in an edit mode or is in family mode.
 -or-
 The element "this GroupType" does not belong to a project document.
 -or-
 The GroupType is not a Model group type and can't be reloaded.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this GroupType is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this GroupType is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this GroupType has no open transaction.

