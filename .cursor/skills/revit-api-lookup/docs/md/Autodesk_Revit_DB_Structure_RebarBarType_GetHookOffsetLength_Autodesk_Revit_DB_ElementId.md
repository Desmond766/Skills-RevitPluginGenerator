---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.GetHookOffsetLength(Autodesk.Revit.DB.ElementId)
source: html/0a1cd042-dfeb-5a5f-734e-0b91d6a9e8dc.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.GetHookOffsetLength Method

Identifies the hook offset length for a hook type

## Syntax (C#)
```csharp
public double GetHookOffsetLength(
	ElementId hookId
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type

## Returns
The hook offset length for a hook type

## Remarks
If the AutoCalcHookLengths property is turned off, the default hook offset length will be returned

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
 -or-
 the hook specified by id hookId doesn't have valid offset length
 -or-
 The element hookId does not exist in the document containing this RebarBarType
 -or-
 the hook specified by id hookId doesn't have valid default offset length
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document containing this RebarBarType is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The element is a member of a loaded family.
 -or-
 The element is a member of a group type that is
 not being edited.
 -or-
 hookId is a member of a loaded family.
 -or-
 hookId is a member of a group type that is
 not being edited.

