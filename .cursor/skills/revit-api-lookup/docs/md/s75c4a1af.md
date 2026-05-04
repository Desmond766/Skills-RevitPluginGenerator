---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.IsInRevealObstaclesMode(Autodesk.Revit.DB.View)
source: html/f158a901-fc99-dc87-d8de-79b739b86a43.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.IsInRevealObstaclesMode Method

Returns current state of Reveal Obstacles mode for the given view.

## Syntax (C#)
```csharp
public static bool IsInRevealObstaclesMode(
	View DBView
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The view to determine current state of Reveal Obstacles mode for.

## Returns
True if Reveal Obstacles mode is ON for the view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element "DBView" is in a family document or a document in in-place edit mode.
 -or-
 View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document containing DBView is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The Path of Travel calculation service is not available

