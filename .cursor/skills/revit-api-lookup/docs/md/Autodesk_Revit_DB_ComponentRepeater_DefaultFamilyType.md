---
kind: property
id: P:Autodesk.Revit.DB.ComponentRepeater.DefaultFamilyType
source: html/5c58ac2c-7cf7-3fe1-dab4-7749c1b5a055.htm
---
# Autodesk.Revit.DB.ComponentRepeater.DefaultFamilyType Property

The default family type for the component repeater.

## Syntax (C#)
```csharp
public ElementId DefaultFamilyType { get; set; }
```

## Remarks
The default family type is the type of the instances in default slots. This includes slots that are added when the repeater grows.
 When setting this property, all slots with instances of the default type will change their components to an instance of the new default type.
 Empty slots will remain unchanged.
 Slots with non-default family instances will remain unchanged.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Invalid type for the repeater. The type must be an adaptive family with no shape handles.
 In addition, it must have same category and same number of placement points as the current type of the repeater.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

