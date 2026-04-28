---
kind: property
id: P:Autodesk.Revit.DB.GeometryObject.Id
source: html/abb781de-203f-4035-784b-713e65cca169.htm
---
# Autodesk.Revit.DB.GeometryObject.Id Property

A unique integer identifying the GeometryObject in its associated non view-specific GeometryElement.

## Syntax (C#)
```csharp
public int Id { get; }
```

## Remarks
This id can be stored and used for future referencing. The reference should be stable between minor geometric changes and modifications, 
but may not remain valid if there are major changes to the element or its surroundings.
Note that the id may be negative(and thus invalid for referencing) if obtained from view - specific geometry, 
or if obtained from most GeometryObjects created in memory by the API. Negative ids cannot be used for referencing.
These integer ids should not be used for comparison purposes(other than to check if they are equivalent or not).
Nothing should be assumed about rules about how an element populates the sequence of different numeric values as this may change based on the element's definition.

