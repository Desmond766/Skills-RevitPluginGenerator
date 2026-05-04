---
kind: property
id: P:Autodesk.Revit.DB.ComponentRepeaterSlot.FamilyType
source: html/a838e63a-c320-8536-6d16-f174d25b7fd5.htm
---
# Autodesk.Revit.DB.ComponentRepeaterSlot.FamilyType Property

The id of the family type of the component in the slot, or invalid id if the slot is empty.

## Syntax (C#)
```csharp
public ElementId FamilyType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Invalid type for the slot. The type must be an adaptive family with no shape handles.
 In addition, it must have same category and same number of placement points as the current type of the repeater.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

