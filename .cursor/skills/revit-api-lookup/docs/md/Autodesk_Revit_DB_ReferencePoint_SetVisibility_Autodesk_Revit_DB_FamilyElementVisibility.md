---
kind: method
id: M:Autodesk.Revit.DB.ReferencePoint.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/6a4ba016-bc5e-8511-4990-c588a9311a6d.htm
---
# Autodesk.Revit.DB.ReferencePoint.SetVisibility Method

Sets the visibility for the point.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the point can be changed for different 
types of views and detail levels in the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed.

