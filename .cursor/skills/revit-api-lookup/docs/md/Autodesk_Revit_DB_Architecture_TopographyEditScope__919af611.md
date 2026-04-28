---
kind: type
id: T:Autodesk.Revit.DB.Architecture.TopographyEditScope
source: html/2587c2f5-50b9-0eb0-85b2-2918dc5a34a0.htm
---
# Autodesk.Revit.DB.Architecture.TopographyEditScope

A TopographyEditScope allows an application to create and maintain an editing session for a TopographySurface.

## Syntax (C#)
```csharp
public class TopographyEditScope : EditScope
```

## Remarks
Start/end of a TopographyEditScope will start/end a transaction group. After a TopographyEditScope is started, an application can start transactions and edit the topography surface.
 Individual transactions the application creates inside TopographyEditScope will not appear in the undo menu.
 All transactions committed during the edit mode will be merged into a single one which will bear the given name passed into TopographyEditScope constructor.

