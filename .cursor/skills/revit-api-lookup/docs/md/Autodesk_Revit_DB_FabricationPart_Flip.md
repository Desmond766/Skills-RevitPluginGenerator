---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.Flip
source: html/761fe3db-573c-b929-1173-64feb52c6a6d.htm
---
# Autodesk.Revit.DB.FabricationPart.Flip Method

Flips the fabrication part that is directionally oriented (tees, crosses, valves, dampers, etc.) to the opposite direction.

## Syntax (C#)
```csharp
public bool Flip()
```

## Returns
Returns true if successful otherwise false if the fabrication part cannot be flipped.

## Remarks
Existing connections will be maintained, disconnect warnings will be posted if the connection cannot be maintained.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - It is not a valid part that can be flipped.

