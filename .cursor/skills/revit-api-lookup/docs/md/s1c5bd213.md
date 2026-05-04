---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.HasSaveablePositions
source: html/2759f2e4-241d-f39d-c450-2b5674af5b24.htm
---
# Autodesk.Revit.DB.RevitLinkType.HasSaveablePositions Method

Determines whether the link has changes to shared positioning that could
 be saved.

## Syntax (C#)
```csharp
public bool HasSaveablePositions()
```

## Returns
True if the link has shared positioning changes which can be saved.
 False if there are no changes to shared coordinates, or if the changes
 cannot be saved.

