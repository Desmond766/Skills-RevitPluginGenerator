---
kind: method
id: M:Autodesk.Revit.DB.CurveByPoints.SetVisibility(Autodesk.Revit.DB.FamilyElementVisibility)
source: html/52b01138-5c79-c6f3-7cbf-ec0072712feb.htm
---
# Autodesk.Revit.DB.CurveByPoints.SetVisibility Method

Sets the visibility.

## Syntax (C#)
```csharp
public void SetVisibility(
	FamilyElementVisibility visibility
)
```

## Parameters
- **visibility** (`Autodesk.Revit.DB.FamilyElementVisibility`)

## Remarks
The visibility of the CurveByPoints can be changed for different 
types of views and detail levels in the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when visibility is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed.

