---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsLanding.CanCreateAutomaticLanding(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/e62d4713-6b77-f2ae-aa4a-6679c56daa07.htm
---
# Autodesk.Revit.DB.Architecture.StairsLanding.CanCreateAutomaticLanding Method

Checks whether automatic landing(s) can be created between the given two stairs runs and
 logically join(s) with the stairs runs.

## Syntax (C#)
```csharp
public static bool CanCreateAutomaticLanding(
	Document document,
	ElementId firstRunId,
	ElementId secondRunId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the stairs runs.
- **firstRunId** (`Autodesk.Revit.DB.ElementId`) - The first stairs run.
- **secondRunId** (`Autodesk.Revit.DB.ElementId`) - The second stairs run.

## Returns
True if automatic landing(s) can be created between the two stairs runs, False otherwise.

## Remarks
This only checks whether two stairs runs meet restriction to create automatic landing(s)
 without checking the stairs edit scope and document modifiable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

