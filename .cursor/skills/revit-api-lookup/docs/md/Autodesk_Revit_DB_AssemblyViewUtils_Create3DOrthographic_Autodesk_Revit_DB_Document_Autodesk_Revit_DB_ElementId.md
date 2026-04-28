---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.Create3DOrthographic(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/d1d13c59-ed2a-844a-5ad0-f195ee2d4a2f.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.Create3DOrthographic Method

Creates a new orthographic 3D assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static View3D Create3DOrthographic(
	Document document,
	ElementId assemblyInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.

## Returns
A new orthographic 3D assembly view.

## Remarks
The view will have the same orientation as the Default 3D view.
 The document must be regenerated before using the 3D view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - assemblyInstanceId is not an AssemblyInstance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

