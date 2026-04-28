---
kind: method
id: M:Autodesk.Revit.DB.CurtainSystem.AddCurtainGrid(Autodesk.Revit.DB.Reference)
source: html/1380ff9f-c8cc-2c71-0105-57800ef44677.htm
---
# Autodesk.Revit.DB.CurtainSystem.AddCurtainGrid Method

Add CurtainGrid on the specified face for the CurtainSystem.

## Syntax (C#)
```csharp
public void AddCurtainGrid(
	Reference face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Reference`) - The face new CurtainGrid will be created on.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument face is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creating CurtainGrid on the specified face fails or regenerate fails.

