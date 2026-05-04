---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.CancelConnectedFaceSet
source: html/11a71aab-1685-27ad-10c4-328e4a02b4fb.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.CancelConnectedFaceSet Method

Cancels the current face set - i.e., all data from it will be lost
 and the builder will have no open connected face set anymore.

## Syntax (C#)
```csharp
public void CancelConnectedFaceSet()
```

## Remarks
This function can be safely called upon builder without an open face set.

