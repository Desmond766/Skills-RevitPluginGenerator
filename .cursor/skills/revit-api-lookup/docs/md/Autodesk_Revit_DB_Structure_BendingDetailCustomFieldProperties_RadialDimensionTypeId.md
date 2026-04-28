---
kind: property
id: P:Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.RadialDimensionTypeId
source: html/90b4d8ee-1165-0311-579b-99772b0368d7.htm
---
# Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.RadialDimensionTypeId Property

Identifies the Id of the radial dimension type which is used to show dimensions.

## Syntax (C#)
```csharp
public ElementId RadialDimensionTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The radialDimensionTypeId should be an id of a radial dimension type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

