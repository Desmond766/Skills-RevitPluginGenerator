---
kind: property
id: P:Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.DiameterDimensionTypeId
source: html/81f1e17a-7ee5-d3ea-3aaf-6203bb2ff7cb.htm
---
# Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.DiameterDimensionTypeId Property

Identifies the Id of the diameter dimension type which is used to show dimensions.

## Syntax (C#)
```csharp
public ElementId DiameterDimensionTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The diameterDimensionTypeId should be an id of a diameter dimension type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

