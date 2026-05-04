---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsLanding.CreateAutomaticLanding(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/48bca49d-ae21-0329-072e-777553f38c07.htm
---
# Autodesk.Revit.DB.Architecture.StairsLanding.CreateAutomaticLanding Method

Creates automatic landing(s) between two stairs runs.

## Syntax (C#)
```csharp
public static IList<ElementId> CreateAutomaticLanding(
	Document document,
	ElementId firstRunId,
	ElementId secondRunId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the stairs runs and new landing(s).
- **firstRunId** (`Autodesk.Revit.DB.ElementId`) - The first stairs run.
- **secondRunId** (`Autodesk.Revit.DB.ElementId`) - The second stairs run.

## Returns
The created landing(s) between the two stairs runs.

## Remarks
This should be called within open stairs edit scope and transaction.
 The new stairs landing(s) and the document will be regenerated.
 The landing type of the new stairs landing(s) is determined by stairs type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The firstRunId is not a valid stairs run.
 -or-
 The secondRunId is not a valid stairs run.
 -or-
 The stairs runs firstRunId and secondRunId belong to different stairs host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element to which the stairs component firstRunId belong is not in an active StairsEditScope.
 -or-
 Cannot create automatic landing(s) between stairs runs of firstRunId and secondRunId.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - Failed to create automatic landing(s) due to document regeneration failures.

