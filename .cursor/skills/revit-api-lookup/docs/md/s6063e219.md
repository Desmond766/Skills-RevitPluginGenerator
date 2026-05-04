---
kind: method
id: M:Autodesk.Revit.DB.CurtainSystem.RemoveCurtainGrid(Autodesk.Revit.DB.Reference)
source: html/ded8d223-51bc-ced0-143a-60cecb144385.htm
---
# Autodesk.Revit.DB.CurtainSystem.RemoveCurtainGrid Method

Remove CurtainGrid from the specified face for the CurtainSystem.

## Syntax (C#)
```csharp
public void RemoveCurtainGrid(
	Reference face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Reference`) - The face CurtainGrid will be removed from.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input parameter face is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the CurtainGrid cannot be removed from the specified face or regenerate fails.

