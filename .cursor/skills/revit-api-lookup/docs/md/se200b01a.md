---
kind: type
id: T:Autodesk.Revit.DB.SketchEditScope
source: html/8538b361-08df-9fd2-93bb-1790a09130f7.htm
---
# Autodesk.Revit.DB.SketchEditScope

A SketchEditScope allows an application to create and maintain an editing session for a Sketch.

## Syntax (C#)
```csharp
public class SketchEditScope : EditScope
```

## Remarks
Start/end of a SketchEditScope will start/end a transaction group. After a SketchEditScope is started, an application can start transactions and edit the sketch.
 Individual transactions the application creates inside SketchEditScope will not appear in the undo menu.
 All transactions committed during the edit mode will be merged into a single one which will bear the given name passed into SketchEditScope constructor.

