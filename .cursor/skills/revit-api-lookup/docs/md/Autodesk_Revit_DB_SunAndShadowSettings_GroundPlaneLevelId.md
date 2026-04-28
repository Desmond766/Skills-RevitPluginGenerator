---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.GroundPlaneLevelId
source: html/cb9cf987-a64c-e1cb-7d85-f4374eb953e9.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GroundPlaneLevelId Property

Identifies the element id of the Ground Plane level for the SunAndShadowSettings element.

## Syntax (C#)
```csharp
public ElementId GroundPlaneLevelId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the element level is not a valid Ground Plane Level element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

