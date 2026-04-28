---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.CanBeDivided(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/14e87b16-51cf-52e8-87f0-06b47f80c1de.htm
---
# Autodesk.Revit.DB.DividedSurface.CanBeDivided Method

This returns true if the reference represents a face that can be used to create a divided surface.

## Syntax (C#)
```csharp
public static bool CanBeDivided(
	Document document,
	Reference reference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference.

## Returns
True if the reference can be used to create a divided surface, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

