---
kind: type
id: T:Autodesk.Revit.DB.StairsEditScope
source: html/47e4576e-4b01-ed1f-6dc1-885b6780aa07.htm
---
# Autodesk.Revit.DB.StairsEditScope

StairsEditScope allows user to maintain a stairs-editing session.

## Syntax (C#)
```csharp
public class StairsEditScope : EditScope
```

## Remarks
Start/end of a StairsEditScope will start/end a transaction group. After a StairsEditScope is started, user can start transactions and edit the stairs.
 Individual transactions the user creates inside StairsEditScope will not appear in the undo menu.
 All transactions committed during the edit mode will be merged into a single one which will bear the given name passed into StairsEditScope constructor.

