---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.ShouldMergeWithMessage(Autodesk.Revit.DB.FailureMessageAccessor)
source: html/2c2d65d6-b025-2c62-c83b-dbe94f0835f1.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.ShouldMergeWithMessage Method

Checks if the FailureMessage should be merged with the other FailureMessage for better user experience.

## Syntax (C#)
```csharp
public bool ShouldMergeWithMessage(
	FailureMessageAccessor messageToMergeWith
)
```

## Parameters
- **messageToMergeWith** (`Autodesk.Revit.DB.FailureMessageAccessor`)

## Returns
True if messages should be merged

## Remarks
Messages should be merged if all user-visible information except failing elements is the same,
 failure resolution types are the same and merging lists of failing elements keeps message text applicable to all of them equally.
 Method is used by the Revit UI to display multiple messages as one.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - messageToMergeWith has not been properly initialized.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.

