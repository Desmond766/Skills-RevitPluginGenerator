---
kind: method
id: M:Autodesk.Revit.DB.SpotDimension.CanFlip
source: html/c953bd97-f7ee-c385-9cde-68bde956ff75.htm
---
# Autodesk.Revit.DB.SpotDimension.CanFlip Method

Verifies that the direction of the dimension can be flipped.

## Syntax (C#)
```csharp
public bool CanFlip()
```

## Returns
True if the element can be flipped, false otherwise.

## Remarks
Currently, flipping only allowed for non-pinned AlignmentStationLabels.

