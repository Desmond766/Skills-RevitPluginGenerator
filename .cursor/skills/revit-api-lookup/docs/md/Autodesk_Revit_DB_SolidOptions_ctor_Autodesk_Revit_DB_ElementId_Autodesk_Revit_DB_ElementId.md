---
kind: method
id: M:Autodesk.Revit.DB.SolidOptions.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/a3dae316-a275-89da-721a-0179308309e2.htm
---
# Autodesk.Revit.DB.SolidOptions.#ctor Method

Creates a new SolidOptions class with material and graphics style settings.

## Syntax (C#)
```csharp
public SolidOptions(
	ElementId materialId,
	ElementId graphicsStyleId
)
```

## Parameters
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material id for the Solid.
- **graphicsStyleId** (`Autodesk.Revit.DB.ElementId`) - The graphics style id for the Solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

