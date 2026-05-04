---
kind: property
id: P:Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.AngularDimensionTypeId
source: html/9831ce4e-0bef-8e07-5260-32d8ecb80a3e.htm
---
# Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.AngularDimensionTypeId Property

Identifies the Id of the angular dimension type which is used to show dimensions.

## Syntax (C#)
```csharp
public ElementId AngularDimensionTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The angularDimensionTypeId should be an id of an angular dimension type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

